using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Windows.Forms;


namespace WowFovChanger
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Where to load/save the file containing info about supported executables.
        /// </summary>
        private readonly string FilenameInfo = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
            + @"\" + Application.ProductName + @"\" + Application.ProductName + @".dat";

        /// <summary>
        /// Where to find default info about supported executables.
        /// </summary>
        private readonly string FilenameInfoDefault = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)
            + @"\" + Application.ProductName + @".dat";


        /// <summary>
        /// A list of WoW expansions we might care about.
        /// Needs to match the list of ExpansionNames.
        /// </summary>
        private enum Expansion
        {
            Other = -1,
            Vanilla = 0,
            Tbc = 1,
            Wrath = 2,
            Cata = 3,
            Mists = 4,
            Warlords = 5,
            Legion = 6,
            Bfa = 7,
            Slands = 8
        }

        /// <summary>
        /// Friendly names of the expansion.
        /// Needs to match the enum Expansion.
        /// </summary>
        private List<string> ExpansionNames = new List<string>
        {
            "Unknown",
            "Vanilla",
            "The Burning Crusade",
            "Wrath of the Lich King",
            "Cataclysm",
            "Mists of Pandaria",
            "Warlords of Draenor",
            "Legion",
            "Battle for Azeroth",
            "Shadowlands"
        };

        /// <summary>
        /// Holds a field of view as raw bytes.
        /// </summary>
        private class FovInfo
        {
            /// <summary>
            /// The byte with offset 0.
            /// </summary>
            public byte byte0;
            /// <summary>
            /// The byte with offset 1.
            /// </summary>
            public byte byte1;
            /// <summary>
            /// The byte with offset 2.
            /// </summary>
            public byte byte2;
            /// <summary>
            /// The byte with offset 3.
            /// </summary>
            public byte byte3;

            /// <summary>
            /// Default constructor sets all bytes to zero.
            /// </summary>
            public FovInfo()
            {
                byte0 = byte1 = byte2 = byte3 = 0;
            }

            /// <summary>
            /// Creates a new instance of FovInfo using the supplied field of view.
            /// </summary>
            /// <param name="fovWan">The field of view, in WoW angular units.</param>
            public FovInfo(float fovWan)
            {
                // TODO: Check endianess and do appropriate stuff.
                byte[] currentBytes = BitConverter.GetBytes(fovWan);
                byte0 = currentBytes[0];
                byte1 = currentBytes[1];
                byte2 = currentBytes[2];
                byte3 = currentBytes[3];
            }

            /// <summary>
            /// Creates a new instances of FovInfo using the supplied bytes.
            /// </summary>
            /// <param name="byte0">The byte with offset 0.</param>
            /// <param name="byte1">The byte with offset 1.</param>
            /// <param name="byte2">The byte with offset 2.</param>
            /// <param name="byte3">The byte with offset 3.</param>
            public FovInfo(byte byte0, byte byte1, byte byte2, byte byte3)
            {
                this.byte0 = byte0;
                this.byte1 = byte1;
                this.byte2 = byte2;
                this.byte3 = byte3;
            }

            /// <summary>
            /// Converts the raw byte to a single-precision float.
            /// </summary>
            /// <returns>A float represented by the raw bytes.</returns>
            public float ToFloat()
            {
                // TODO: Check endianess and do appropriate stuff.
                byte[] currentBytes = new byte[] { byte1, byte2, byte3, byte0 };
                return BitConverter.ToSingle(currentBytes, 0);
            }
        
            /// <summary>
            /// Creates a parsable string out of the raw bytes.
            /// </summary>
            /// <returns>A semi-colon-delimited array of values.</returns>
            public override string ToString()
            {
                return byte0.ToString() + ";" + byte1.ToString() + ";" + byte2.ToString() + ";" + byte3.ToString() + ";";
            }

            /// <summary>
            /// Attempt to parse a token for individual bytes.
            /// </summary>
            /// <param name="token">The string to parse.</param>
            /// <param name="fovInfo">An instance of FovInfo with the parsed values.</param>
            /// <returns>True if successful, false otherwise.</returns>
            public static bool TryParse(string token, out FovInfo fovInfo)
            {
                fovInfo = new FovInfo();

                string[] parts = token.Split(';');
                if (parts.Length != 4) return false;

                if (!byte.TryParse(parts[0], out fovInfo.byte0)) return false;
                if (!byte.TryParse(parts[1], out fovInfo.byte1)) return false;
                if (!byte.TryParse(parts[2], out fovInfo.byte2)) return false;
                if (!byte.TryParse(parts[3], out fovInfo.byte3)) return false;
                return true;
            }

        }

        /// <summary>
        /// Contains info about an executable we support.
        /// </summary>
        private class FileInfo
        {
            // Keeping the fields in alphabetical order so it matches the ParseLine/ToString methods.

            /// <summary>
            /// The aspect ratio FovRatio was set at.
            /// </summary>
            /// <example>
            /// If FovRatio was determined to be 45 on a 16:9 monitor,
            /// BaseAspectRatio is then 16 ÷ 9 = 1.77778.
            /// </example>
            public float BaseAspectRatio;

            /// <summary>
            /// The default field of view, as a sequence of bytes.
            /// </summary>
            public FovInfo DefaultFov;

            /// <summary>
            /// The expansion of the executable.
            /// </summary>
            public Expansion Expansion;

            /// <summary>
            /// The ratio between degrees and WoW angular units.
            /// </summary>
            /// <example>
            /// If 90 degrees equals 2 Wan, FovRatio would be
            /// 90 ÷ 2 = 45.
            /// </example>
            public float FovRatio;

            private string name;
            /// <summary>
            /// The friendly name of this WoW executable.
            /// Automatically strips any commas out.
            /// </summary>
            public string Name
            {
                get { return name; }
                set { name = value.Replace(",", ""); }
            }

            /// <summary>
            /// The offset of the field of view Int32, in bytes.
            /// </summary>
            public int Offset;

            /// <summary>
            /// The size of the file, in bytes.
            /// </summary>
            public int Size;

            private string version;
            /// <summary>
            /// The version of the file, as a string.
            /// Automatically strips any commas out.
            /// </summary>
            public string Version
            {
                get { return version; }
                set { version = value.Replace(",", ""); }
            }

            /// <summary>
            /// Default constructor.
            /// </summary>
            public FileInfo()
            {
                // These values should cause exceptions if we try to use them.
                // Better than accidentally borking someone's executable.
                BaseAspectRatio = 0;
                Expansion = Expansion.Other;
                FovRatio = 0;
                Name = "";
                Offset = int.MaxValue;
                Size = 0;
                Version = "";
            }

            // TODO Fix this comment.
            /// <summary>
            /// Explicit constructor allows setting each property in one go.
            /// </summary>
            /// <param name="baseAspectRatio"><inheritdoc cref="BaseAspectRatio"/></param>
            /// <param name="expansion">test</param>
            /// <param name="fovRatio">test</param>
            /// <param name="name">test</param>
            /// <param name="offset">test</param>
            /// <param name="size">test</param>
            /// <param name="version">test</param>
            public FileInfo(float baseAspectRatio, Expansion expansion, float fovRatio, string name, int offset, int size, string version)
            {
                BaseAspectRatio = baseAspectRatio;
                Expansion = expansion;
                FovRatio = fovRatio;
                this.name = name;
                Offset = offset;
                Size = size;
                this.version = version;
            }

            /// <summary>
            /// Determine if this instance matches the specific information.
            /// </summary>
            /// <param name="expansion">The expansion of the file in question.</param>
            /// <param name="size">The size of the file in question.</param>
            /// <param name="version">The version string of the file in question.</param>
            /// <returns>True if it's a match, false otherwise.</returns>
            public bool Matches(int size, string version)
            {
                if (size == Size && version == this.version) return true;
                return false;
            }

            /// <summary>
            /// See if this instances matches another instance.
            /// </summary>
            /// <param name="infoToMatch">The instance to match against.</param>
            /// <returns>True if it's a match, false otherwise.</returns>
            public bool Matches(FileInfo infoToMatch)
            {
                return this.Matches(infoToMatch.Size, infoToMatch.Version);
            }

            /// <summary>
            /// Parse a comma-delimited string to setup this FileInfo instance.
            /// </summary>
            /// <param name="line">The string to parse.</param>
            /// <returns>True if successful, false otherwise.</returns>
            public bool TryParse(string line)
            {
                // TODO: Update this if the number changes.
                int numberOfFields = 8;

                // Setup comment strings.
                string[] comments = new string[] { "//", "REM" };

                // If the trimmed line is empty, abort.
                line = line.Trim();
                if (line == "") return false;

                // Get all the tokens on the string.
                string[] fields = line.Split(',');

                // If there aren't enough tokens, abort.
                if (fields.Length != numberOfFields) return false;

                // If the first field is a comment, abort.
                if (comments.Contains(fields[0])) return false;

                // Try to parse each field.
                try
                {
                    // This order must match the order in ToString exactly.
                    int i = -1; // So we can insert fields without having to adjust a bunch of indices.
                    i++; if (!float.TryParse(fields[i], out BaseAspectRatio)) return false;
                    i++; if (!FovInfo.TryParse(fields[i], out DefaultFov)) return false;
                    i++; if (!Enum.TryParse(fields[i], out Expansion)) return false;
                    i++; if (!float.TryParse(fields[i], out FovRatio)) return false;
                    i++; Name = fields[i];
                    i++; if (!int.TryParse(fields[i], out Offset)) return false;
                    i++; if (!int.TryParse(fields[i], out Size)) return false;
                    i++; Version = fields[i];

                    // If we made it here, it was successful.
                    return true;
                }
                catch
                {
                    // There was an error, abort.
                    return false;
                }
            }

            /// <summary>
            /// Convert this to a comma-delimited string of values.
            /// </summary>
            /// <returns>A string representing the object.</returns>
            public override string ToString()
            {
                // This order must match the order in TryParse exactly.
                return BaseAspectRatio.ToString() + ","
                    + DefaultFov.ToString() + ","
                    + Expansion.ToString() + ","
                    + FovRatio.ToString() + ","
                    + Name + ","
                    + Offset.ToString() + ","
                    + Size.ToString() + ","
                    + Version;
            }

        }

        /// <summary>
        /// A list of files we currently support.
        /// </summary>
        private List<FileInfo> SupportedFiles;


        /// <summary>
        /// The text color for the output when an error is displayed.
        /// </summary>
        private Color errorColor = Color.Red;
        /// <summary>
        /// The text color for the output when the message is normal.
        /// </summary>
        private Color normalColor = System.Drawing.SystemColors.ControlText;

        /// <summary>
        /// True if the filename in txtFilename.Text is valid.
        /// </summary>
        private bool isFilenameValid = false;
        /// <summary>
        /// True if the field of view in txtNew.Text is valid.
        /// </summary>
        private bool isFovValid = false;

        /// <summary>
        /// The current field of view bytes set by the user.
        /// </summary>
        FovInfo currentFov = new FovInfo();


        public frmMain()
        {
            InitializeComponent(); // Form designer stuff.
            SetupComponent(); // Custom stuff.
        }

        /// <summary>
        /// Additional setup called after the form designer's InitializeComponent().
        /// </summary>
        private void SetupComponent()
        {
            // Get file info from the appdata folder.
            if (!LoadFileInfo(FilenameInfo))
            {
                // AppData failed, try the program folder.
                if (!LoadFileInfo(FilenameInfoDefault))
                {
                    // Everything failed, setup manually.
                    SetupDefaultInfo();
                }
            }

            // Setup the dropdown list.
            cboFileVersion.Items.Clear();
            for (int i = 0; i < SupportedFiles.Count; i++)
            {
                cboFileVersion.Items.Add(SupportedFiles[i].Name);
            }
        }

        /// <summary>
        /// Attempt to load supported file info from filename.
        /// Return a true/false value indicating success.
        /// </summary>
        /// <param name="filename">The file to load from.</param>
        /// <returns>True if successful, false otherwise.</returns>
        private bool LoadFileInfo(string filename)
        {
            // If the setup file doesn't exist, abort.
            if (!File.Exists(filename)) return false;

            // Try to load the info.
            try
            {
                // Each record is on a line by itself.
                string[] lines = File.ReadAllLines(filename);

                // If there are no lines, abort.
                if (lines.Length < 1) return false;

                // We'll keep track to make sure at least one line was a record.
                bool FoundRecord = false;

                // Parse all the lines.
                for (int i = 0; i < lines.Length; i++)
                {
                    // Parse each line and add it to the array if it's valid.
                    FileInfo temp = new FileInfo();
                    if (temp.TryParse(lines[i])) SupportedFiles.Add(temp);
                }

                // If we found no records, abort.
                if (!FoundRecord) return false;

                // We made it to the end, it must be good.
                return true;
            }
            catch
            {
                // If there are any errors, abort.
                return false;
            }
        }

        /// <summary>
        /// Manually add default supported file info.
        /// </summary>
        private void SetupDefaultInfo()
        {
            // TODO: Add more supported executables.
            SupportedFiles = new List<FileInfo>();
            SupportedFiles.Add(new FileInfo(16 / 9f, Expansion.Wrath, 50, "Wrath 3.3.5a", 0x5e7588, 7704216, "3:3:12340"));
        }

        /// <summary>
        /// Displays a message to the output in a friendly manner.
        /// </summary>
        /// <param name="message">The message to output.</param>
        private void DisplayMessage(string message)
        {
            txtOutput.BackColor = txtOutput.BackColor;
            txtOutput.ForeColor = normalColor;
            txtOutput.Text = message;
        }
        /// <summary>
        /// Displays a message to the output in an aggressive manner.
        /// </summary>
        /// <param name="message">The message to output.</param>
        private void DisplayError(string message)
        {
            txtOutput.BackColor = txtOutput.BackColor;
            txtOutput.ForeColor = errorColor;
            txtOutput.Text = message;
        }
        /// <summary>
        /// Clears the output.
        /// </summary>
        private void ClearOutput()
        {
            txtOutput.Text = "";
            txtOutput.BackColor = txtOutput.BackColor;
            txtOutput.ForeColor = normalColor;
        }


        private void txtFilename_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ClearOutput();

                if (File.Exists(txtFilename.Text))
                {
                    isFilenameValid = true;
                    if (isFovValid) btnApply.Enabled = true;
                    lblFilename.ForeColor = normalColor;
                    lblCurrent.ForeColor = normalColor;
                    FileInfo current = GetFileInfo(txtFilename.Text); // This gets the size and version.
                    int match = GetMatchingExecutable(current);
                    if (match >= 0)
                    {
                        cboFileVersion.SelectedIndex = match;
                        GetCurrentWanBytes();
                    }
                    else
                    {
                        DisplayError("Executable doesn't match supported files.");
                    }
                }
                else
                {
                    isFilenameValid = false;
                    lblFilename.ForeColor = errorColor;
                    lblCurrent.ForeColor = errorColor;
                    txtCurrent.Text = "";
                    btnApply.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnFilename_Click(object sender, EventArgs e)
        {
            try
            {
                ClearOutput();

                DialogResult result = ofdMain.ShowDialog();
                if (result == DialogResult.OK)
                {
                    txtFilename.Text = ofdMain.FileName;
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void txtNew_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ClearOutput();

                float value;
                bool success = float.TryParse(txtNew.Text, out value);

                if (success)
                {
                    isFovValid = true;
                    if (isFilenameValid) btnApply.Enabled = true;
                    lblNew.ForeColor = normalColor;
                    currentFov = new FovInfo(DegToWan(value));
                    DisplayMessage("(" + DegToWan(value).ToString() + " raw)");
                }
                else
                {
                    isFovValid = false;
                    lblNew.ForeColor = errorColor;
                    btnApply.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnDefault_Click(object sender, EventArgs e)
        {
            try
            {
                ClearOutput();

                currentFov = new FovInfo(0xDB, 0x0F, 0xC9, 0x3F);
                txtNew.Text = currentFov.ToFloat().ToString();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                ClearOutput();

                SetNewWanBytes();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }


        /// <summary>
        /// Get filesize and version from the given executable.
        /// </summary>
        /// <param name="filename">The executable to get info from.</param>
        /// <returns>A FileInfo object with the Size and Version set.</returns>
        private FileInfo GetFileInfo(string filename)
        {
            // Get the entire file as a byte array.
            byte[] fileBytes = File.ReadAllBytes(txtFilename.Text);

            // Get the filesize so we can compare it to known executables.
            int fileSize = fileBytes.Length;
            string fileSizePretty = GetPrettyFileSize(fileSize);
            txtFilesize.Text = String.Format("{0} ({1} bytes)", fileSizePretty, fileSize);

            // Get the version to compare.
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(txtFilename.Text);
            int major = fvi.FileMajorPart;
            int minor = fvi.FileMinorPart;
            int rev = fvi.FilePrivatePart;
            string version = String.Format("{0}:{1}:{2}", major, minor, rev);
            txtVersion.Text = version;

            // Return the known info so the calling function can see if it's a match for anything.
            FileInfo result = new FileInfo();
            result.Size = fileSize;
            result.Version = version;
            return result;
        }

        /// <summary>
        /// Find an executable in the supported list that matches relevant file info.
        /// </summary>
        /// <param name="current">The executable to match against.</param>
        /// <returns>The index of the supported executable if found, or -1 if no match was found.</returns>
        private int GetMatchingExecutable(FileInfo current)
        {
            // Start with the selected executable.
            if (SupportedFiles[cboFileVersion.SelectedIndex].Matches(current))
            {
                return cboFileVersion.SelectedIndex;
            }

            // Now look through all the supported executables.
            for (int i = 0; i < SupportedFiles.Count; i++)
            {
                if (SupportedFiles[i].Matches(current)) return i;
            }

            // We found nothing.
            return -1;
        }

        /// <summary>
        /// Gets all relevant info from the selected file and puts it on the screen.
        /// </summary>
        private void GetCurrentWanBytes()
        {
            int supportedIndex = cboFileVersion.SelectedIndex;

            // Get the entire file as a byte array.
            byte[] fileBytes = File.ReadAllBytes(txtFilename.Text);

            // Get the fov bytes from the selected offset.
            try
            {
                int offset = SupportedFiles[supportedIndex].Offset;
                GetFovFromOffset(ref fileBytes, offset); // Stores offset in the currentFov var.
                float fov = currentFov.ToFloat();
                txtCurrent.Text = string.Format("{0:f2}° ({1} raw)", WanToDeg(fov), fov);
            }
            catch (IndexOutOfRangeException ex)
            {
                // This means the offset was bad. Tell the user they suck.
                DisplayError("Given offset doesn't exist in the selected file.");
            }
        }

        /// <summary>
        /// Writes the field of view to the selected file at the given offset.
        /// </summary>
        private void SetNewWanBytes()
        {
            // Get the bytes from the executable.
            byte[] fileBytes = File.ReadAllBytes(txtFilename.Text);

            // Make a backup of the executable. If we can't find a valid name in 1000 tries, don't worry about it.
            string backupFilename;
            DateTime timestamp = DateTime.Now;
            int year = timestamp.Year;
            int month = timestamp.Month;
            int day = timestamp.Day;
            int hour = timestamp.Hour;
            int minute = timestamp.Minute;
            int second = timestamp.Second;
            string timestampString = String.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}", year, month, day, hour, minute, second);
            for (int i = 0; i < 1000; i++)
            {
                backupFilename = txtFilename.Text + "." + timestampString + "." + i.ToString() + ".bak";
                if (!File.Exists(backupFilename))
                {
                    File.WriteAllBytes(backupFilename, fileBytes);
                    break;
                }
            }

            // Set the new fov in the bytes.
            SetFovAtOffset(ref fileBytes, SupportedFiles[cboFileVersion.SelectedIndex].Offset);

            // Save the bytes back to the executable.
            File.WriteAllBytes(txtFilename.Text, fileBytes);

            // We're done, yay.
            DisplayMessage("Update success!");
        }

        /// <summary>
        /// Get the field of view bytes from the sourceBytes array using the provided offset.
        /// </summary>
        /// <param name="sourceBytes">The byte array to search.</param>
        /// <param name="startIndex">The starting offset to look at.</param>
        /// <returns>A FovInfo object with the relevant bytes.</returns>
        private void GetFovFromOffset(ref byte[] sourceBytes, int startIndex)
        {
            currentFov = new FovInfo(sourceBytes[startIndex], sourceBytes[startIndex + 1], sourceBytes[startIndex + 2], sourceBytes[startIndex + 3]);
        }

        /// <summary>
        /// Set the field of view bytes in the sourceBytes array using the provided offset.
        /// </summary>
        /// <param name="sourceBytes"></param>
        /// <param name="startIndex"></param>
        private void SetFovAtOffset(ref byte[] sourceBytes, int startIndex)
        {
            sourceBytes[startIndex] = currentFov.byte0;
            sourceBytes[startIndex + 1] = currentFov.byte1;
            sourceBytes[startIndex + 2] = currentFov.byte2;
            sourceBytes[startIndex + 3] = currentFov.byte3;
        }

        /// <summary>
        /// Takes a field of view value, in WoW angular units, and returns the
        /// equivalent in degrees.
        /// </summary>
        /// <param name="fovWan">The field of view to convert, in WoW angular units.</param>
        /// <returns>The degree equivalent of fovWan.</returns>
        private float WanToDeg(float fovWan)
        {
            float fovRatio = SupportedFiles[cboFileVersion.SelectedIndex].FovRatio;
            return fovWan * fovRatio;
        }

        /// <summary>
        /// Takes a field of view value, in degrees, and returns the equivalent
        /// in WoW angular units.
        /// </summary>
        /// <param name="fovDeg">The field of view to convert, in degrees.</param>
        /// <returns>The WoW angular unit equivalent of fovDeg.</returns>
        private float DegToWan(float fovDeg)
        {
            float fovRatio = SupportedFiles[cboFileVersion.SelectedIndex].FovRatio;
            return fovDeg / fovRatio;
        }

        /// <summary>
        /// Takes a filesize and converts it to a string with 3 significant figures
        /// and a trailing suffix like GB, MB, KB, or B.
        /// </summary>
        /// <param name="fileSize">The filesize, in bytes.</param>
        /// <returns>A prettified string.</returns>
        private string GetPrettyFileSize(int fileSize)
        {
            double size = fileSize;
            string suffix = "B";

            // Calculate powers of 2. Roughly equivalent to 10^3, 10^6, and 10^9.
            int giga = (int)Math.Pow(2, 30); // If you're using this program with gigabyte executables ... let me know why. That could be interesting. Or scary.
            int mega = (int)Math.Pow(2, 20);
            int kilo = (int)Math.Pow(2, 10);

            // Reduce big numbers to small numbers and set the appropriate prefix.
            if (size > giga) { size /= giga; suffix = "GB"; }
            else if (size > mega) { size /= mega; suffix = "MB"; }
            else if (size > kilo) { size /= kilo; suffix = "KB"; }

            // Determine how many decimals equates to 3 digits of precision.
            string digits = "2";
            if (size > 100) digits = "0";
            else if (size > 10) digits = "1";

            // Return the formatted string.
            return String.Format("{0:f" + digits + "} {1}", size, suffix);
        }
    }
}
