using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;


namespace WowFovChanger
{
    public partial class frmMain : Form
    {
        // TODO: Make 64-bit versions of relevant functions in case a newer client uses 8-byte doubles.

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
            Vanilla = 0,
            Tbc = 1,
            Wrath = 2,
            Cata = 3,
            Mists = 4,
            Warlords = 5,
            Legion = 6,
            Bfa = 7,
            Slands = 8,
            Other = 9
        }

        /// <summary>
        /// Friendly names of the expansion.
        /// Needs to match the enum Expansion.
        /// </summary>
        private List<string> ExpansionNames = new List<string>
        {
            "Vanilla",
            "The Burning Crusade",
            "Wrath of the Lich King",
            "Cataclysm",
            "Mists of Pandaria",
            "Warlords of Draenor",
            "Legion",
            "Battle for Azeroth",
            "Shadowlands",
            "Unknown"
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
                byte[] currentBytes = BitConverter.GetBytes(fovWan);
                if (!BitConverter.IsLittleEndian) SwapEndianess(ref currentBytes); // Need to be in Little Endian format.
                byte0 = currentBytes[0];
                byte1 = currentBytes[1];
                byte2 = currentBytes[2];
                byte3 = currentBytes[3];
            }

            /// <summary>
            /// Creates a new instances of FovInfo using the supplied bytes.
            /// Make sure the bytes are in LITTLE endian format.
            /// Windows defaults to little endian, but some Linux/Mac systems are big endian.
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
                byte[] currentBytes = new byte[] { byte0, byte1, byte2, byte3 };
                if (!BitConverter.IsLittleEndian) SwapEndianess(ref currentBytes);
                return BitConverter.ToSingle(currentBytes, 0);
            }
        
            /// <summary>
            /// Creates a pretty hex string out of the raw bytes.
            /// </summary>
            /// <returns>A semi-colon-delimited array of values.</returns>
            public override string ToString()
            {
                return "0x" + byte0.ToString("X2") + byte1.ToString("X2") + byte2.ToString("X2") + byte3.ToString("X2");
            }

            /// <summary>
            /// Creates a parsable string out of the raw bytes.
            /// </summary>
            /// <returns>A semi-colon-delimited array of values.</returns>
            public string ToStringParsable()
            {
                return byte0.ToString() + ";" + byte1.ToString() + ";" + byte2.ToString() + ";" + byte3.ToString() + ";";
            }

            /// <summary>
            /// Attempt to parse a string with tokens for individual bytes.
            /// </summary>
            /// <param name="toParse">The string to parse, in the format AA;BB;CC;DD .</param>
            /// <param name="fovInfo">An instance of FovInfo with the parsed values.</param>
            /// <returns>True if successful, false otherwise.</returns>
            public static bool TryParseTokens(string toParse, out FovInfo fovInfo)
            {
                fovInfo = new FovInfo();

                // Split the token on the semicolon. There should be exactly 4 parts.
                string[] parts = toParse.Split(';');
                if (parts.Length != 4) return false;

                // See if the values were entered as hex, like 0xC4.
                NumberStyles[] format = new NumberStyles[4];
                for (int i = 0; i < 4; i++)
                {
                    if (parts[i].ToLower().StartsWith("0x"))
                    {
                        format[i] = NumberStyles.HexNumber;
                        parts[i] = parts[i].Substring(2);
                    }
                    else
                    {
                        format[i] = NumberStyles.Any;
                    }
                }

                // If anything fails, abort.
                if (!byte.TryParse(parts[0], format[0], null, out fovInfo.byte0)) return false;
                if (!byte.TryParse(parts[1], format[1], null, out fovInfo.byte1)) return false;
                if (!byte.TryParse(parts[2], format[2], null, out fovInfo.byte2)) return false;
                if (!byte.TryParse(parts[3], format[3], null, out fovInfo.byte3)) return false;

                // Everything looks good, so call it good.
                return true;
            }

            /// <summary>
            /// Attempt to parse a string for individual bytes.
            /// </summary>
            /// <param name="toParse">The string to parse, either in decimal (1234) or hex (0xABCD) format.</param>
            /// <param name="fovInfo">An instance of FovInfo with the parsed values.</param>
            /// <returns>True if successful, false otherwise.</returns>
            public static bool TryParseString(string toParse, out FovInfo fovInfo)
            {
                fovInfo = new FovInfo();

                // Trim the string. There should be non-whitespace.
                toParse = toParse.Trim();
                if (toParse.Length <= 0) return false;

                // See if the value was entered as hex, like 0xC4.
                NumberStyles format = NumberStyles.Any;
                if (toParse.ToLower().StartsWith("0x"))
                {
                    toParse = toParse.Substring(2).Trim();
                    format = NumberStyles.HexNumber;
                }

                // Parse to an unsigned int. If it fails, abort.
                uint parsed;
                if (!uint.TryParse(toParse, format, null, out parsed)) return false;

                // Take two bytes at a time.
                fovInfo.byte0 = (byte)((parsed & 0xFF000000) / 0xFF0000);
                fovInfo.byte1 = (byte)((parsed & 0xFF0000) / 0xFF00);
                fovInfo.byte2 = (byte)((parsed & 0xFF00) / 0xFF);
                fovInfo.byte3 = (byte)((parsed & 0xFF));

                // Everything looks good, so call it good.
                return true;
            }

            /// <summary>
            /// Reverses the order of the byte array.
            /// </summary>
            /// <param name="array">The array whose order we're flipping.</param>
            private static void SwapEndianess(ref byte[] array)
            {
                int len = array.Length;
                int max = len - 1;
                int half = len / 2;
                byte temp;

                // Swap everything up to the halfway point.
                for (int i = 0; i < half; i++)
                {
                    temp = array[i];
                    array[i] = array[max - i];
                    array[max - i] = temp;
                }
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
                DefaultFov = new FovInfo();
                Expansion = Expansion.Other;
                FovRatio = 0;
                Name = "";
                Offset = int.MaxValue;
                Size = 0;
                Version = "";
            }

            /// <summary>
            /// Explicit constructor allows setting each property in one go.
            /// </summary>
            /// <param name="baseAspectRatio">The aspect ratio FovRatio was set at.</param>
            /// <param name="defaultFov">The default field of view, as a sequence of bytes.</param>
            /// <param name="expansion">The expansion of the executable.</param>
            /// <param name="fovRatio">The ratio between degrees and WoW angular units.</param>
            /// <param name="name">The friendly name of this WoW executable.</param>
            /// <param name="offset">The offset of the field of view Int32, in bytes.</param>
            /// <param name="size">The size of the file, in bytes.</param>
            /// <param name="version">The version of the file, as a string.</param>
            public FileInfo(float baseAspectRatio, FovInfo defaultFov, Expansion expansion, float fovRatio, string name, int offset, int size, string version)
            {
                BaseAspectRatio = baseAspectRatio;
                DefaultFov = defaultFov;
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

                // Setup comment string.
                string comments = "//";

                // If the trimmed line is empty, abort.
                line = line.Trim();
                if (line == "") return false;

                // Get all the tokens on the string.
                string[] fields = line.Split(',');

                // If there aren't enough tokens, abort.
                if (fields.Length != numberOfFields) return false;

                // Remove the whitespace from each token.
                for (int i = 0; i < numberOfFields; i++) fields[i] = fields[i].Trim();

                // If the first field is a comment, abort.
                if (fields[0].Substring(0,comments.Length) == comments) return false;

                // Try to parse each field.
                try
                {
                    // This order must match the order in ToString exactly.
                    int i = -1; // So we can insert fields without having to adjust a bunch of indices.
                    i++; if (!float.TryParse(fields[i], out BaseAspectRatio)) return false;
                    i++; if (!FovInfo.TryParseTokens(fields[i], out DefaultFov)) return false;
                    i++; if (!Enum.TryParse(fields[i], out Expansion)) return false;
                    i++; if (!float.TryParse(fields[i], out FovRatio)) return false;
                    i++; Name = fields[i];
                    i++;
                    bool isHex = fields[i].ToLower().StartsWith("0x"); // Allow Offset to be entered as hex.
                    NumberStyles format = (isHex) ? NumberStyles.HexNumber : NumberStyles.Any;
                    if (isHex) fields[i] = fields[i].Substring(2);
                    if (!int.TryParse(fields[i], format, null, out Offset)) return false;

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
                    + DefaultFov.ToStringParsable() + ","
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
        private Color normalColor = SystemColors.ControlText;

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
        private FovInfo currentFov = new FovInfo();

        /// <summary>
        /// The current file selected by the user.
        /// </summary>
        private FileInfo currentFile = new FileInfo();

        /// <summary>
        /// True while setting txtNew.Text so it doesn't recursively change things.
        /// </summary>
        private bool settingFov = false;

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
            // Do this here so it's easier to edit other panels in the designer.
            this.Width = 403;
            pnlMain.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            pnlHelp.Anchor = pnlOffsets.Anchor = AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom;
            

            // Load information about supported files.
            SetupFileInfo();
        }

        /// <summary>
        /// Load info about supported files.
        /// Try appdata, then the program folder, then do hardcoded values, in that order.
        /// </summary>
        private void SetupFileInfo()
        {
            // Initialize the list.
            SupportedFiles = new List<FileInfo>();

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
            cboSupportedInfo.Items.Clear();
            for (int i = 0; i < SupportedFiles.Count; i++)
            {
                cboSupportedInfo.Items.Add(SupportedFiles[i].Name);
            }
            if (cboSupportedInfo.Items.Count > 0) cboSupportedInfo.SelectedIndex = 0;
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
                    if (temp.TryParse(lines[i]))
                    {
                        SupportedFiles.Add(temp);
                        FoundRecord = true;
                    }
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
            SupportedFiles.Add(new FileInfo(16 / 9f, new FovInfo(0xDB, 0x0F, 0xC9, 0x3F), Expansion.Vanilla, 41, "Vanilla 1.12.1", 0x4089b4, 4775986, "1:12:1.5875"));
            SupportedFiles.Add(new FileInfo(16 / 9f, new FovInfo(0xDB, 0x0F, 0xC9, 0x3F), Expansion.Tbc, 41, "TBC 2.4.3", 0x4b4004, 8272528, "2:4:3.8606"));
            SupportedFiles.Add(new FileInfo(16 / 9f, new FovInfo(0xDB, 0x0F, 0xC9, 0x3F), Expansion.Wrath, 50, "Wrath 3.3.5a", 0x5e7588, 7704216, "3:3:12340"));
            SupportedFiles.Add(new FileInfo(16 / 9f, new FovInfo(0xDB, 0x0F, 0xC9, 0x3F), Expansion.Mists, 50, "Mists 5.4.8 32bit", 0x936888, 13154864, "5:4:8.18414"));
            SupportedFiles.Add(new FileInfo(16 / 9f, new FovInfo(0xDB, 0x0F, 0xC9, 0x3F), Expansion.Mists, 50, "Mists 5.4.8 64bit", 0xeaead4, 20915760, "5:4:8.18414"));
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


        private void btnHelp_Click(object sender, EventArgs e)
        {
            try
            {
                // Show/hide the help panel, then let the other function handle moving things.
                int w = pnlHelp.Width;
                Size min = this.MinimumSize;
                if (pnlHelp.Visible)
                {
                    pnlHelp.Visible = false;
                    this.MinimumSize = new Size(min.Width - w, min.Height);
                    this.Width -= w;
                    pnlMain.Width += w;
                    btnHelp.Text = "Help >>";
                }
                else
                {
                    pnlHelp.Visible = true;
                    this.Width += w;
                    this.MinimumSize = new Size(min.Width + w, min.Height);
                    pnlMain.Width -= w;
                    btnHelp.Text = "Help <<";
                }
                RepositionPanels();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
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
                    GetFileInfo(txtFilename.Text); // This puts the size and version into currentFile.
                    int match = GetMatchingExecutable();
                    if (match >= 0)
                    {
                        cboSupportedInfo.SelectedIndex = match;
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

        private void cboFileVersion_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearOutput();

                // Update all the fields for the selected item.
                FileInfo fi = SupportedFiles[cboSupportedInfo.SelectedIndex];
                txtAspect.Text = fi.BaseAspectRatio.ToString();
                txtDefaultFov.Text = GetExpandedFov(fi.DefaultFov.ToFloat());
                txtExpansion.Text = ExpansionNames[(int)fi.Expansion];
                txtFovRatio.Text = fi.FovRatio.ToString();
                txtOffset.Text = string.Format("{0} ({1})", GetHex(fi.Offset), fi.Offset);
                txtFilesizeSupported.Text = GetExpandedFileSize(fi.Size);
                txtVersionSupported.Text = fi.Version;

                // If the current filename doesn't point to a valid file, abort.
                if (!isFilenameValid) return;

                // See if the selected file matched the selected file info.
                if (fi.Matches(currentFile.Size, currentFile.Version))
                {
                    DisplayMessage("Selected file info matches the selected executable.");
                }
                else
                {
                    DisplayError("Selected file info doesn't match the selected executable.");
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
                if (settingFov) return;

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

                currentFov = SupportedFiles[cboSupportedInfo.SelectedIndex].DefaultFov;
                settingFov = true;
                txtNew.Text = WanToDeg(currentFov.ToFloat()).ToString();
                DisplayMessage("(" + currentFov.ToFloat().ToString() + ")");
                settingFov = false;
                isFovValid = true;
                if (isFilenameValid) btnApply.Enabled = true;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnRefreshOffset_Click(object sender, EventArgs e)
        {
            try
            {
                // Store the currently-selected index, if one exists.
                int currentIndex = -1;
                if (cboSupportedInfo.Items.Count > 0)
                {
                    currentIndex = cboSupportedInfo.SelectedIndex;
                }

                // Refresh the info from the file.
                SetupFileInfo();

                // Attempt to go back to the previously-selected index.
                if (currentIndex >= 0 && currentIndex < cboSupportedInfo.Items.Count)
                {
                    cboSupportedInfo.SelectedIndex = currentIndex;
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnOffsets_Click(object sender, EventArgs e)
        {
            try
            {
                // Show/hide the offset panel, then let the other function handle moving things.
                int w = pnlOffsets.Width;
                Size min = this.MinimumSize;
                if (pnlOffsets.Visible)
                {
                    pnlOffsets.Visible = false;
                    this.MinimumSize = new Size(min.Width - w, min.Height);
                    this.Width -= w;
                    pnlMain.Width += w;
                    btnOffsets.Text = ">>";
                }
                else
                {
                    pnlOffsets.Visible = true;
                    this.Width += w;
                    this.MinimumSize = new Size(min.Width + w, min.Height);
                    pnlMain.Width -= w;
                    btnOffsets.Text = "<<";
                }
                RepositionPanels();
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
        private void GetFileInfo(string filename)
        {
            // TODO: Check if file is 32-bit or 64-bit then act appropriately. (May be un-required.)

            // Get the filesize so we can compare it to known executables.
            System.IO.FileInfo fi = new System.IO.FileInfo(txtFilename.Text); // Qualify the name so we're not conflicting with the local FileInfo class.
            int fileSize = (int)fi.Length;
            txtFilesize.Text = GetExpandedFileSize(fileSize);

            // Get the version to compare.
            string version = GetPrettyVersionInfo(txtFilename.Text);
            txtVersion.Text = version;

            // Set the known info so the calling function can see if it's a match for anything.
            currentFile.Size = fileSize;
            currentFile.Version = version;
        }

        /// <summary>
        /// Find an executable in the supported list that matches relevant file info.
        /// </summary>
        /// <param name="current">The executable to match against.</param>
        /// <returns>The index of the supported executable if found, or -1 if no match was found.</returns>
        private int GetMatchingExecutable()
        {
            // Start with the selected executable.
            int index = cboSupportedInfo.SelectedIndex;
            if (index >= 0 && SupportedFiles[index].Matches(currentFile))
            {
                return cboSupportedInfo.SelectedIndex;
            }

            // Now look through all the supported executables.
            for (int i = 0; i < SupportedFiles.Count; i++)
            {
                if (SupportedFiles[i].Matches(currentFile)) return i;
            }

            // We found nothing.
            return -1;
        }

        /// <summary>
        /// Gets all relevant info from the selected file and puts it on the screen.
        /// </summary>
        private void GetCurrentWanBytes()
        {
            int supportedIndex = cboSupportedInfo.SelectedIndex;

            // Get the entire file as a byte array.
            byte[] fileBytes = File.ReadAllBytes(txtFilename.Text);

            // Get the fov bytes from the selected offset.
            try
            {
                int offset = SupportedFiles[supportedIndex].Offset;
                GetFovFromOffset(ref fileBytes, offset); // Stores offset in the currentFov var.
                float fovWan = currentFov.ToFloat();
                txtCurrent.Text = GetExpandedFov(fovWan);
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

            // Make a backup of the executable.
            BackupFile(txtFilename.Text, fileBytes);

            // Set the new fov in the bytes.
            SetFovAtOffset(ref fileBytes, SupportedFiles[cboSupportedInfo.SelectedIndex].Offset);

            // Save the bytes back to the executable.
            File.WriteAllBytes(txtFilename.Text, fileBytes);

            // We're done, yay.
            DisplayMessage("Update success!");
        }

        /// <summary>
        /// Given a filename, create a backup filename and save the given bytes to it.
        /// </summary>
        /// <param name="filename">The original filename.</param>
        /// <param name="fileBytes">The bytes to save.</param>
        private void BackupFile(string filename, byte[] fileBytes)
        {
            // Get a datetime string like YYYY-MM-DD hh.mm.ss, formatted for the current time.
            DateTime timestamp = DateTime.Now;
            int year = timestamp.Year;
            int month = timestamp.Month;
            int day = timestamp.Day;
            int hour = timestamp.Hour;
            int minute = timestamp.Minute;
            int second = timestamp.Second;
            string timestampString = String.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}.{4:D2}.{5:D2}", year, month, day, hour, minute, second);

            // If we can't find a valid name in 1000 tries, don't worry about it.
            for (int i = 0; i < 1000; i++)
            {
                // Add the datetime string, plus a number between 0 and 999 and a backup prefix, to the original filename.
                filename += "." + timestampString + "." + i.ToString() + ".bak";

                // If it doesn't already exist, write to this filename.
                if (!File.Exists(filename))
                {
                    File.WriteAllBytes(filename, fileBytes);
                    break;
                }
            }
            // If we make it to this point, there were already 1000 other backup files made in the current second.
            // If there were that many files, something probably broke, so just quit.
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
            // TODO: Use aspect ratio to make this more accurate.
            float fovRatio = SupportedFiles[cboSupportedInfo.SelectedIndex].FovRatio;
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
            // TODO: Use aspect ratio to make this more accurate.
            float fovRatio = SupportedFiles[cboSupportedInfo.SelectedIndex].FovRatio;
            return fovDeg / fovRatio;
        }

        /// <summary>
        /// Takes a field of view, in WoW angular units, and converts
        /// it to a string with degrees and the raw value.
        /// </summary>
        /// <param name="fovWan">The field of view to convert, in WoW angular units.</param>
        /// <returns>The expanded string with both units.</returns>
        private string GetExpandedFov(float fovWan)
        {
            return string.Format("{0:f2}° ({1} raw)", WanToDeg(fovWan), fovWan);
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

        /// <summary>
        /// Takes a filesize and converts it to a pretty size plus the raw size in bytes.
        /// </summary>
        /// <param name="fileSize">The filesize, in bytes.</param>
        /// <returns>A pretty string with the raw size in parentheses.</returns>
        private string GetExpandedFileSize(int fileSize)
        {
            return String.Format("{0} ({1} bytes)", GetPrettyFileSize(fileSize), fileSize);
        }

        /// <summary>
        /// Takes a filename and gets a pretty version string.
        /// </summary>
        /// <param name="filename">The filename of the file whose version to get.</param>
        /// <returns>A prettified version string.</returns>
        private string GetPrettyVersionInfo(string filename)
        {
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(filename);
            int major = fvi.FileMajorPart;
            int minor = fvi.FileMinorPart;
            int rev = fvi.FileBuildPart;
            int prv = fvi.FilePrivatePart;
            return String.Format("{0}:{1}:{2}.{3}", major, minor, rev, prv);
        }

        /// <summary>
        /// Converts a decimal value into a hex string with the 0x prefix.
        /// </summary>
        /// <param name="dec">The decimal value to convert.</param>
        /// <returns>A hex value in a formatted string.</returns>
        private string GetHex(int dec)
        {
            string hex = Convert.ToString(dec, 16);
            return "0x" + hex;
        }

        /// <summary>
        /// Move the help and offset panels as needed when they're visible.
        /// </summary>
        private void RepositionPanels()
        {
            // Help panel always goes right next to the main panel.
            pnlHelp.Left = pnlMain.Left + pnlMain.Width;

            // Offset panel goes to the far right.
            int helpOffset = (pnlHelp.Visible) ? pnlHelp.Width : 0;
            pnlOffsets.Left = pnlHelp.Left + helpOffset;
        }


        /// <summary>
        /// Holds offsets for matching bytes on the offsets panel.
        /// </summary>
        private List<int> offsets = new List<int>(0);

        /// <summary>
        /// Stores a true/false value indicating whether the data at this offset has been modified.
        /// </summary>
        private List<bool> offsetsModified = new List<bool>(0);

        /// <summary>
        /// Stores the filename we searching in the offsets panel, in case it gets changed on the main panel.
        /// </summary>
        private string offsetsFilename = "";

        private void btnFromDefault_Click(object sender, EventArgs e)
        {
            try
            {
                ClearOutput();

                if (SupportedFiles != null && cboSupportedInfo.SelectedIndex < SupportedFiles.Count)
                {
                    FileInfo fi = SupportedFiles[cboSupportedInfo.SelectedIndex];

                    txtBytes.Text = fi.DefaultFov.ToString();
                }
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                ClearOutput();

                // If there's not a file to load, abort.
                if (!isFilenameValid) return;

                // Store the filename for later.
                offsetsFilename = txtFilename.Text;

                // Get the search bytes. If it fails, abort.
                FovInfo bytesToSearch;
                if (!FovInfo.TryParseString(txtBytes.Text, out bytesToSearch)) return;

                // Get the entire file as a byte array.
                byte[] fileBytes = File.ReadAllBytes(offsetsFilename);

                // Ready our data.
                offsets.Clear();
                offsetsModified.Clear();
                lbxOffsets.Items.Clear();

                // Loop through the array. Start byte can't go past 4th from the end.
                for (int i = 0; i < (fileBytes.Length - 3); i++)
                {
                    // If any byte doesn't match, go to the next set of bytes.
                    if (fileBytes[i] != bytesToSearch.byte0) continue;
                    if (fileBytes[i+1] != bytesToSearch.byte1) continue;
                    if (fileBytes[i+2] != bytesToSearch.byte2) continue;
                    if (fileBytes[i+3] != bytesToSearch.byte3) continue;

                    // If all the bytes matched, record this offset.
                    offsets.Add(i);
                    offsetsModified.Add(false);
                    lbxOffsets.Items.Add(String.Format("0x{0:X}", i));
                }

                // Setup the buttons if items were found.
                bool hasItems = (offsets.Count > 0);
                if (!hasItems) DisplayMessage("No matches found.");
                btnReset.Enabled
                    = btnSetAll.Enabled 
                    = btnSetSelected.Enabled 
                    = btnRevertAll.Enabled
                    = hasItems;
                txtBytes.Enabled = btnFromDefault.Enabled = !hasItems;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            try
            {
                ClearOutput();

                // Clear the data.
                offsets.Clear();
                offsetsModified.Clear();
                lbxOffsets.Items.Clear();
                btnReset.Enabled
                    = btnSetAll.Enabled
                    = btnSetSelected.Enabled
                    = btnRevertAll.Enabled
                    = false;
                txtBytes.Enabled = btnFromDefault.Enabled = true;
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        // From https://stackoverflow.com/a/63327860/5313933
        private void lbxOffsets_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Can't process a non-existent item.
            if (e.Index < 0) return;

            // 1. Get the item
            string selectedItem = lbxOffsets.Items[e.Index].ToString();

            // 2. Choose font 
            Font font = new Font("Microsoft Sans Serif", 8.25f);

            // 3. Choose colour
            SolidBrush solidBrush;
            if (offsetsModified[e.Index]) solidBrush = new SolidBrush(Color.Red);
            else solidBrush = new SolidBrush(SystemColors.WindowText);

            // 4. Get bounds
            int left = e.Bounds.Left;
            int top = e.Bounds.Top;

            // 5. Use Draw the background within the bounds
            e.DrawBackground();

            // 6. Colorize listbox items
            e.Graphics.DrawString(selectedItem, font, solidBrush, left, top);
        }

        private void btnFromFov_Click(object sender, EventArgs e)
        {
            try
            {
                ClearOutput();

                float fovTemp;
                if (!float.TryParse(txtNew.Text, out fovTemp)) return;
                FovInfo fov = new FovInfo(fovTemp);
                txtNewBytes.Text = fov.ToString();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnSetAll_Click(object sender, EventArgs e)
        {
            try
            {
                ClearOutput();

                // If there's no output value, quit.
                FovInfo fovToWrite;
                if (!FovInfo.TryParseString(txtNewBytes.Text, out fovToWrite)) return;

                // Get the entire file as a byte array.
                byte[] fileBytes = File.ReadAllBytes(offsetsFilename);

                // Make a backup of the executable.
                BackupFile(offsetsFilename, fileBytes);

                // Go through each offset in the list.
                for (int i = 0; i < offsets.Count; i++)
                {
                    // Set the bytes at this offset.
                    fileBytes[offsets[i]] = fovToWrite.byte0;
                    fileBytes[offsets[i] + 1] = fovToWrite.byte1;
                    fileBytes[offsets[i] + 2] = fovToWrite.byte2;
                    fileBytes[offsets[i] + 3] = fovToWrite.byte3;

                    // Tell the listbox this item's been modified.
                    offsetsModified[i] = true;
                }

                // Save the bytes back to the executable.
                File.WriteAllBytes(offsetsFilename, fileBytes);

                // Refresh the listbox colors.
                lbxOffsets.Invalidate();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnSetSelected_Click(object sender, EventArgs e)
        {
            try
            {
                ClearOutput();

                // If there's no output value, quit.
                FovInfo fovToWrite;
                if (!FovInfo.TryParseString(txtNewBytes.Text, out fovToWrite)) return;

                // Get the entire file as a byte array.
                byte[] fileBytes = File.ReadAllBytes(offsetsFilename);

                // Make a backup of the executable.
                BackupFile(offsetsFilename, fileBytes);

                // Go through each selected offset in the listbox.
                for (int i = 0; i < lbxOffsets.SelectedIndices.Count; i++)
                {
                    // i tells us which selected index we're on. Use that to get the offset index.
                    int j = lbxOffsets.SelectedIndices[i];

                    // Set the bytes at this offset.
                    fileBytes[offsets[j]] = fovToWrite.byte0;
                    fileBytes[offsets[j] + 1] = fovToWrite.byte1;
                    fileBytes[offsets[j] + 2] = fovToWrite.byte2;
                    fileBytes[offsets[j] + 3] = fovToWrite.byte3;

                    // Tell the listbox this item's been modified.
                    offsetsModified[j] = true;
                }

                // Save the bytes back to the executable.
                File.WriteAllBytes(offsetsFilename, fileBytes);

                // Refresh the listbox colors.
                lbxOffsets.Invalidate();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void btnRevertAll_Click(object sender, EventArgs e)
        {
            try
            {
                ClearOutput();

                // If there's no output value, quit. If this happens, there's a problem though.
                FovInfo bytesToSearch;
                if (!FovInfo.TryParseString(txtBytes.Text, out bytesToSearch)) return;

                // Get the entire file as a byte array.
                byte[] fileBytes = File.ReadAllBytes(offsetsFilename);

                // Make a backup of the executable.
                BackupFile(offsetsFilename, fileBytes);

                // Go through each offset in the list.
                for (int i = 0; i < offsets.Count; i++)
                {
                    // Set the bytes at this offset.
                    fileBytes[offsets[i]] = bytesToSearch.byte0;
                    fileBytes[offsets[i] + 1] = bytesToSearch.byte1;
                    fileBytes[offsets[i] + 2] = bytesToSearch.byte2;
                    fileBytes[offsets[i] + 3] = bytesToSearch.byte3;

                    // Tell the listbox this item's now unmodified.
                    offsetsModified[i] = false;
                }

                // Save the bytes back to the executable.
                File.WriteAllBytes(offsetsFilename, fileBytes);

                // Refresh the listbox colors.
                lbxOffsets.Invalidate();
            }
            catch (Exception ex)
            {
                DisplayError(ex.Message);
            }
        }
    }
}
