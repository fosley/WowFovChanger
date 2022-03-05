
namespace WowFovChanger
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofdMain = new System.Windows.Forms.OpenFileDialog();
            this.lblFilename = new System.Windows.Forms.Label();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnFilename = new System.Windows.Forms.Button();
            this.txtCurrent = new System.Windows.Forms.TextBox();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.txtNew = new System.Windows.Forms.TextBox();
            this.lblNew = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.cboSupportedInfo = new System.Windows.Forms.ComboBox();
            this.txtFilesize = new System.Windows.Forms.TextBox();
            this.lblFilesize = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblSupportedInfo = new System.Windows.Forms.Label();
            this.txtAspect = new System.Windows.Forms.TextBox();
            this.lblAspect = new System.Windows.Forms.Label();
            this.txtDefaultFov = new System.Windows.Forms.TextBox();
            this.lblDefaultFov = new System.Windows.Forms.Label();
            this.txtExpansion = new System.Windows.Forms.TextBox();
            this.lblExpansion = new System.Windows.Forms.Label();
            this.txtFovRatio = new System.Windows.Forms.TextBox();
            this.lblFovRatio = new System.Windows.Forms.Label();
            this.txtOffset = new System.Windows.Forms.TextBox();
            this.lblOffset = new System.Windows.Forms.Label();
            this.txtFilesizeSupported = new System.Windows.Forms.TextBox();
            this.lblFilesizeSupported = new System.Windows.Forms.Label();
            this.txtVersionSupported = new System.Windows.Forms.TextBox();
            this.lblVersionSupported = new System.Windows.Forms.Label();
            this.btnRefreshOffset = new System.Windows.Forms.Button();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.btnOffsets = new System.Windows.Forms.Button();
            this.btnHelp = new System.Windows.Forms.Button();
            this.pnlHelp = new System.Windows.Forms.Panel();
            this.txtHelp6 = new System.Windows.Forms.Label();
            this.lblHelp5 = new System.Windows.Forms.Label();
            this.lblHelp4 = new System.Windows.Forms.Label();
            this.lblHelp3 = new System.Windows.Forms.Label();
            this.lblHelp2 = new System.Windows.Forms.Label();
            this.lblHelp1 = new System.Windows.Forms.Label();
            this.pnlOffsets = new System.Windows.Forms.Panel();
            this.btnFromDefault = new System.Windows.Forms.Button();
            this.btnFromFov = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNewBytes = new System.Windows.Forms.TextBox();
            this.lbxOffsets = new System.Windows.Forms.ListBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblBytes = new System.Windows.Forms.Label();
            this.txtBytes = new System.Windows.Forms.TextBox();
            this.btnSetAll = new System.Windows.Forms.Button();
            this.btnSetSelected = new System.Windows.Forms.Button();
            this.btnRevertAll = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlHelp.SuspendLayout();
            this.pnlOffsets.SuspendLayout();
            this.SuspendLayout();
            // 
            // ofdMain
            // 
            this.ofdMain.FileName = "openFileDialog1";
            this.ofdMain.Filter = "WoW Program|Wow*.exe|All Programs|*.exe";
            // 
            // lblFilename
            // 
            this.lblFilename.AutoSize = true;
            this.lblFilename.Location = new System.Drawing.Point(3, 10);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(94, 13);
            this.lblFilename.TabIndex = 0;
            this.lblFilename.Text = "WoW Executable:";
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Location = new System.Drawing.Point(3, 26);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(342, 20);
            this.txtFilename.TabIndex = 1;
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            // 
            // btnFilename
            // 
            this.btnFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilename.Location = new System.Drawing.Point(347, 25);
            this.btnFilename.Name = "btnFilename";
            this.btnFilename.Size = new System.Drawing.Size(35, 20);
            this.btnFilename.TabIndex = 2;
            this.btnFilename.Text = "...";
            this.btnFilename.UseVisualStyleBackColor = true;
            this.btnFilename.Click += new System.EventHandler(this.btnFilename_Click);
            // 
            // txtCurrent
            // 
            this.txtCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrent.Location = new System.Drawing.Point(3, 143);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.ReadOnly = true;
            this.txtCurrent.Size = new System.Drawing.Size(379, 20);
            this.txtCurrent.TabIndex = 8;
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(3, 127);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(66, 13);
            this.lblCurrent.TabIndex = 3;
            this.lblCurrent.Text = "Current FoV:";
            // 
            // txtNew
            // 
            this.txtNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNew.Location = new System.Drawing.Point(3, 495);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(315, 20);
            this.txtNew.TabIndex = 28;
            this.txtNew.TextChanged += new System.EventHandler(this.txtNew_TextChanged);
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(0, 479);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(54, 13);
            this.lblNew.TabIndex = 5;
            this.lblNew.Text = "New FoV:";
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(3, 521);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 32;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDefault.Location = new System.Drawing.Point(320, 494);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(62, 20);
            this.btnDefault.TabIndex = 30;
            this.btnDefault.Text = "Default";
            this.btnDefault.UseVisualStyleBackColor = true;
            this.btnDefault.Click += new System.EventHandler(this.btnDefault_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.ForeColor = System.Drawing.Color.Maroon;
            this.txtOutput.Location = new System.Drawing.Point(81, 523);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(301, 19);
            this.txtOutput.TabIndex = 34;
            // 
            // cboSupportedInfo
            // 
            this.cboSupportedInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSupportedInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupportedInfo.FormattingEnabled = true;
            this.cboSupportedInfo.Location = new System.Drawing.Point(3, 182);
            this.cboSupportedInfo.Name = "cboSupportedInfo";
            this.cboSupportedInfo.Size = new System.Drawing.Size(379, 21);
            this.cboSupportedInfo.TabIndex = 10;
            this.cboSupportedInfo.SelectedIndexChanged += new System.EventHandler(this.cboFileVersion_SelectedIndexChanged);
            // 
            // txtFilesize
            // 
            this.txtFilesize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilesize.Location = new System.Drawing.Point(3, 65);
            this.txtFilesize.Name = "txtFilesize";
            this.txtFilesize.ReadOnly = true;
            this.txtFilesize.Size = new System.Drawing.Size(379, 20);
            this.txtFilesize.TabIndex = 4;
            // 
            // lblFilesize
            // 
            this.lblFilesize.AutoSize = true;
            this.lblFilesize.Location = new System.Drawing.Point(3, 49);
            this.lblFilesize.Name = "lblFilesize";
            this.lblFilesize.Size = new System.Drawing.Size(44, 13);
            this.lblFilesize.TabIndex = 11;
            this.lblFilesize.Text = "Filesize:";
            // 
            // txtVersion
            // 
            this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersion.Location = new System.Drawing.Point(3, 104);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(379, 20);
            this.txtVersion.TabIndex = 6;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(3, 88);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 13);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "Version:";
            // 
            // lblSupportedInfo
            // 
            this.lblSupportedInfo.AutoSize = true;
            this.lblSupportedInfo.Location = new System.Drawing.Point(0, 166);
            this.lblSupportedInfo.Name = "lblSupportedInfo";
            this.lblSupportedInfo.Size = new System.Drawing.Size(120, 13);
            this.lblSupportedInfo.TabIndex = 15;
            this.lblSupportedInfo.Text = "Supported Executables:";
            // 
            // txtAspect
            // 
            this.txtAspect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAspect.Location = new System.Drawing.Point(3, 222);
            this.txtAspect.Name = "txtAspect";
            this.txtAspect.ReadOnly = true;
            this.txtAspect.Size = new System.Drawing.Size(379, 20);
            this.txtAspect.TabIndex = 12;
            // 
            // lblAspect
            // 
            this.lblAspect.AutoSize = true;
            this.lblAspect.Location = new System.Drawing.Point(0, 206);
            this.lblAspect.Name = "lblAspect";
            this.lblAspect.Size = new System.Drawing.Size(98, 13);
            this.lblAspect.TabIndex = 16;
            this.lblAspect.Text = "Base Aspect Ratio:";
            // 
            // txtDefaultFov
            // 
            this.txtDefaultFov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultFov.Location = new System.Drawing.Point(3, 261);
            this.txtDefaultFov.Name = "txtDefaultFov";
            this.txtDefaultFov.ReadOnly = true;
            this.txtDefaultFov.Size = new System.Drawing.Size(379, 20);
            this.txtDefaultFov.TabIndex = 14;
            // 
            // lblDefaultFov
            // 
            this.lblDefaultFov.AutoSize = true;
            this.lblDefaultFov.Location = new System.Drawing.Point(0, 245);
            this.lblDefaultFov.Name = "lblDefaultFov";
            this.lblDefaultFov.Size = new System.Drawing.Size(66, 13);
            this.lblDefaultFov.TabIndex = 18;
            this.lblDefaultFov.Text = "Default FoV:";
            // 
            // txtExpansion
            // 
            this.txtExpansion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpansion.Location = new System.Drawing.Point(3, 300);
            this.txtExpansion.Name = "txtExpansion";
            this.txtExpansion.ReadOnly = true;
            this.txtExpansion.Size = new System.Drawing.Size(379, 20);
            this.txtExpansion.TabIndex = 16;
            // 
            // lblExpansion
            // 
            this.lblExpansion.AutoSize = true;
            this.lblExpansion.Location = new System.Drawing.Point(0, 284);
            this.lblExpansion.Name = "lblExpansion";
            this.lblExpansion.Size = new System.Drawing.Size(59, 13);
            this.lblExpansion.TabIndex = 20;
            this.lblExpansion.Text = "Expansion:";
            // 
            // txtFovRatio
            // 
            this.txtFovRatio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFovRatio.Location = new System.Drawing.Point(3, 339);
            this.txtFovRatio.Name = "txtFovRatio";
            this.txtFovRatio.ReadOnly = true;
            this.txtFovRatio.Size = new System.Drawing.Size(379, 20);
            this.txtFovRatio.TabIndex = 18;
            // 
            // lblFovRatio
            // 
            this.lblFovRatio.AutoSize = true;
            this.lblFovRatio.Location = new System.Drawing.Point(0, 323);
            this.lblFovRatio.Name = "lblFovRatio";
            this.lblFovRatio.Size = new System.Drawing.Size(57, 13);
            this.lblFovRatio.TabIndex = 22;
            this.lblFovRatio.Text = "FoV Ratio:";
            // 
            // txtOffset
            // 
            this.txtOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOffset.Location = new System.Drawing.Point(3, 378);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.ReadOnly = true;
            this.txtOffset.Size = new System.Drawing.Size(342, 20);
            this.txtOffset.TabIndex = 20;
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(0, 362);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(38, 13);
            this.lblOffset.TabIndex = 24;
            this.lblOffset.Text = "Offset:";
            // 
            // txtFilesizeSupported
            // 
            this.txtFilesizeSupported.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilesizeSupported.Location = new System.Drawing.Point(3, 417);
            this.txtFilesizeSupported.Name = "txtFilesizeSupported";
            this.txtFilesizeSupported.ReadOnly = true;
            this.txtFilesizeSupported.Size = new System.Drawing.Size(379, 20);
            this.txtFilesizeSupported.TabIndex = 24;
            // 
            // lblFilesizeSupported
            // 
            this.lblFilesizeSupported.AutoSize = true;
            this.lblFilesizeSupported.Location = new System.Drawing.Point(0, 401);
            this.lblFilesizeSupported.Name = "lblFilesizeSupported";
            this.lblFilesizeSupported.Size = new System.Drawing.Size(44, 13);
            this.lblFilesizeSupported.TabIndex = 26;
            this.lblFilesizeSupported.Text = "Filesize:";
            // 
            // txtVersionSupported
            // 
            this.txtVersionSupported.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersionSupported.Location = new System.Drawing.Point(3, 456);
            this.txtVersionSupported.Name = "txtVersionSupported";
            this.txtVersionSupported.ReadOnly = true;
            this.txtVersionSupported.Size = new System.Drawing.Size(379, 20);
            this.txtVersionSupported.TabIndex = 26;
            // 
            // lblVersionSupported
            // 
            this.lblVersionSupported.AutoSize = true;
            this.lblVersionSupported.Location = new System.Drawing.Point(0, 440);
            this.lblVersionSupported.Name = "lblVersionSupported";
            this.lblVersionSupported.Size = new System.Drawing.Size(45, 13);
            this.lblVersionSupported.TabIndex = 28;
            this.lblVersionSupported.Text = "Version:";
            // 
            // btnRefreshOffset
            // 
            this.btnRefreshOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshOffset.Location = new System.Drawing.Point(347, 368);
            this.btnRefreshOffset.Name = "btnRefreshOffset";
            this.btnRefreshOffset.Size = new System.Drawing.Size(35, 20);
            this.btnRefreshOffset.TabIndex = 22;
            this.btnRefreshOffset.Text = "⟳";
            this.btnRefreshOffset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefreshOffset.UseVisualStyleBackColor = true;
            this.btnRefreshOffset.Click += new System.EventHandler(this.btnRefreshOffset_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlMain.Controls.Add(this.btnOffsets);
            this.pnlMain.Controls.Add(this.btnHelp);
            this.pnlMain.Controls.Add(this.lblFilename);
            this.pnlMain.Controls.Add(this.btnDefault);
            this.pnlMain.Controls.Add(this.btnRefreshOffset);
            this.pnlMain.Controls.Add(this.txtFilename);
            this.pnlMain.Controls.Add(this.txtVersionSupported);
            this.pnlMain.Controls.Add(this.btnFilename);
            this.pnlMain.Controls.Add(this.lblVersionSupported);
            this.pnlMain.Controls.Add(this.lblCurrent);
            this.pnlMain.Controls.Add(this.txtFilesizeSupported);
            this.pnlMain.Controls.Add(this.txtCurrent);
            this.pnlMain.Controls.Add(this.lblFilesizeSupported);
            this.pnlMain.Controls.Add(this.lblNew);
            this.pnlMain.Controls.Add(this.txtOffset);
            this.pnlMain.Controls.Add(this.txtNew);
            this.pnlMain.Controls.Add(this.lblOffset);
            this.pnlMain.Controls.Add(this.btnApply);
            this.pnlMain.Controls.Add(this.txtFovRatio);
            this.pnlMain.Controls.Add(this.lblFovRatio);
            this.pnlMain.Controls.Add(this.txtOutput);
            this.pnlMain.Controls.Add(this.txtExpansion);
            this.pnlMain.Controls.Add(this.cboSupportedInfo);
            this.pnlMain.Controls.Add(this.lblExpansion);
            this.pnlMain.Controls.Add(this.lblFilesize);
            this.pnlMain.Controls.Add(this.txtDefaultFov);
            this.pnlMain.Controls.Add(this.txtFilesize);
            this.pnlMain.Controls.Add(this.lblDefaultFov);
            this.pnlMain.Controls.Add(this.lblVersion);
            this.pnlMain.Controls.Add(this.txtAspect);
            this.pnlMain.Controls.Add(this.txtVersion);
            this.pnlMain.Controls.Add(this.lblAspect);
            this.pnlMain.Controls.Add(this.lblSupportedInfo);
            this.pnlMain.Location = new System.Drawing.Point(2, 3);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(385, 546);
            this.pnlMain.TabIndex = 35;
            // 
            // btnOffsets
            // 
            this.btnOffsets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOffsets.Location = new System.Drawing.Point(347, 387);
            this.btnOffsets.Name = "btnOffsets";
            this.btnOffsets.Size = new System.Drawing.Size(35, 20);
            this.btnOffsets.TabIndex = 23;
            this.btnOffsets.Text = ">>";
            this.btnOffsets.UseVisualStyleBackColor = true;
            this.btnOffsets.Click += new System.EventHandler(this.btnOffsets_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHelp.Location = new System.Drawing.Point(307, 2);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(75, 20);
            this.btnHelp.TabIndex = 0;
            this.btnHelp.Text = "Help >>";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // pnlHelp
            // 
            this.pnlHelp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlHelp.Controls.Add(this.txtHelp6);
            this.pnlHelp.Controls.Add(this.lblHelp5);
            this.pnlHelp.Controls.Add(this.lblHelp4);
            this.pnlHelp.Controls.Add(this.lblHelp3);
            this.pnlHelp.Controls.Add(this.lblHelp2);
            this.pnlHelp.Controls.Add(this.lblHelp1);
            this.pnlHelp.Location = new System.Drawing.Point(390, 3);
            this.pnlHelp.Name = "pnlHelp";
            this.pnlHelp.Size = new System.Drawing.Size(261, 546);
            this.pnlHelp.TabIndex = 36;
            this.pnlHelp.Visible = false;
            // 
            // txtHelp6
            // 
            this.txtHelp6.AutoSize = true;
            this.txtHelp6.Location = new System.Drawing.Point(3, 526);
            this.txtHelp6.Name = "txtHelp6";
            this.txtHelp6.Size = new System.Drawing.Size(51, 13);
            this.txtHelp6.TabIndex = 5;
            this.txtHelp6.Text = "Hit apply.";
            // 
            // lblHelp5
            // 
            this.lblHelp5.AutoSize = true;
            this.lblHelp5.Location = new System.Drawing.Point(3, 507);
            this.lblHelp5.Name = "lblHelp5";
            this.lblHelp5.Size = new System.Drawing.Size(256, 13);
            this.lblHelp5.TabIndex = 4;
            this.lblHelp5.Text = "The Default button resets to the exact, original bytes.";
            // 
            // lblHelp4
            // 
            this.lblHelp4.AutoSize = true;
            this.lblHelp4.Location = new System.Drawing.Point(3, 494);
            this.lblHelp4.Name = "lblHelp4";
            this.lblHelp4.Size = new System.Drawing.Size(181, 13);
            this.lblHelp4.TabIndex = 3;
            this.lblHelp4.Text = "Enter a new field of view, in degrees.";
            // 
            // lblHelp3
            // 
            this.lblHelp3.AutoSize = true;
            this.lblHelp3.Location = new System.Drawing.Point(3, 198);
            this.lblHelp3.Name = "lblHelp3";
            this.lblHelp3.Size = new System.Drawing.Size(173, 13);
            this.lblHelp3.TabIndex = 2;
            this.lblHelp3.Text = "This should generally be automatic.";
            // 
            // lblHelp2
            // 
            this.lblHelp2.AutoSize = true;
            this.lblHelp2.Location = new System.Drawing.Point(3, 185);
            this.lblHelp2.Name = "lblHelp2";
            this.lblHelp2.Size = new System.Drawing.Size(247, 13);
            this.lblHelp2.TabIndex = 1;
            this.lblHelp2.Text = "Select from one of the supported executable types.";
            // 
            // lblHelp1
            // 
            this.lblHelp1.AutoSize = true;
            this.lblHelp1.Location = new System.Drawing.Point(3, 29);
            this.lblHelp1.Name = "lblHelp1";
            this.lblHelp1.Size = new System.Drawing.Size(155, 13);
            this.lblHelp1.TabIndex = 0;
            this.lblHelp1.Text = "Select an executable to modify.";
            // 
            // pnlOffsets
            // 
            this.pnlOffsets.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlOffsets.Controls.Add(this.btnReset);
            this.pnlOffsets.Controls.Add(this.btnRevertAll);
            this.pnlOffsets.Controls.Add(this.btnSetSelected);
            this.pnlOffsets.Controls.Add(this.btnSetAll);
            this.pnlOffsets.Controls.Add(this.btnFromDefault);
            this.pnlOffsets.Controls.Add(this.btnFromFov);
            this.pnlOffsets.Controls.Add(this.label1);
            this.pnlOffsets.Controls.Add(this.txtNewBytes);
            this.pnlOffsets.Controls.Add(this.lbxOffsets);
            this.pnlOffsets.Controls.Add(this.btnSearch);
            this.pnlOffsets.Controls.Add(this.lblBytes);
            this.pnlOffsets.Controls.Add(this.txtBytes);
            this.pnlOffsets.Location = new System.Drawing.Point(390, 3);
            this.pnlOffsets.Name = "pnlOffsets";
            this.pnlOffsets.Size = new System.Drawing.Size(261, 546);
            this.pnlOffsets.TabIndex = 37;
            this.pnlOffsets.Visible = false;
            // 
            // btnFromDefault
            // 
            this.btnFromDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromDefault.Location = new System.Drawing.Point(196, 25);
            this.btnFromDefault.Name = "btnFromDefault";
            this.btnFromDefault.Size = new System.Drawing.Size(62, 20);
            this.btnFromDefault.TabIndex = 102;
            this.btnFromDefault.Text = "Default";
            this.btnFromDefault.UseVisualStyleBackColor = true;
            this.btnFromDefault.Click += new System.EventHandler(this.btnFromDefault_Click);
            // 
            // btnFromFov
            // 
            this.btnFromFov.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFromFov.Location = new System.Drawing.Point(196, 455);
            this.btnFromFov.Name = "btnFromFov";
            this.btnFromFov.Size = new System.Drawing.Size(62, 20);
            this.btnFromFov.TabIndex = 112;
            this.btnFromFov.Text = "From FoV";
            this.btnFromFov.UseVisualStyleBackColor = true;
            this.btnFromFov.Click += new System.EventHandler(this.btnFromFov_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "New value:";
            // 
            // txtNewBytes
            // 
            this.txtNewBytes.Location = new System.Drawing.Point(6, 456);
            this.txtNewBytes.Name = "txtNewBytes";
            this.txtNewBytes.Size = new System.Drawing.Size(188, 20);
            this.txtNewBytes.TabIndex = 110;
            // 
            // lbxOffsets
            // 
            this.lbxOffsets.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lbxOffsets.FormattingEnabled = true;
            this.lbxOffsets.Location = new System.Drawing.Point(6, 81);
            this.lbxOffsets.Name = "lbxOffsets";
            this.lbxOffsets.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbxOffsets.Size = new System.Drawing.Size(252, 355);
            this.lbxOffsets.TabIndex = 108;
            this.lbxOffsets.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.lbxOffsets_DrawItem);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(6, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 104;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblBytes
            // 
            this.lblBytes.AutoSize = true;
            this.lblBytes.Location = new System.Drawing.Point(3, 10);
            this.lblBytes.Name = "lblBytes";
            this.lblBytes.Size = new System.Drawing.Size(68, 13);
            this.lblBytes.TabIndex = 1;
            this.lblBytes.Text = "Bytes to find:";
            // 
            // txtBytes
            // 
            this.txtBytes.Location = new System.Drawing.Point(6, 26);
            this.txtBytes.Name = "txtBytes";
            this.txtBytes.Size = new System.Drawing.Size(188, 20);
            this.txtBytes.TabIndex = 100;
            // 
            // btnSetAll
            // 
            this.btnSetAll.Enabled = false;
            this.btnSetAll.Location = new System.Drawing.Point(6, 479);
            this.btnSetAll.Name = "btnSetAll";
            this.btnSetAll.Size = new System.Drawing.Size(75, 23);
            this.btnSetAll.TabIndex = 114;
            this.btnSetAll.Text = "Set All";
            this.btnSetAll.UseVisualStyleBackColor = true;
            this.btnSetAll.Click += new System.EventHandler(this.btnSetAll_Click);
            // 
            // btnSetSelected
            // 
            this.btnSetSelected.Enabled = false;
            this.btnSetSelected.Location = new System.Drawing.Point(87, 479);
            this.btnSetSelected.Name = "btnSetSelected";
            this.btnSetSelected.Size = new System.Drawing.Size(90, 23);
            this.btnSetSelected.TabIndex = 116;
            this.btnSetSelected.Text = "Set Selected";
            this.btnSetSelected.UseVisualStyleBackColor = true;
            this.btnSetSelected.Click += new System.EventHandler(this.btnSetSelected_Click);
            // 
            // btnRevertAll
            // 
            this.btnRevertAll.Enabled = false;
            this.btnRevertAll.Location = new System.Drawing.Point(183, 479);
            this.btnRevertAll.Name = "btnRevertAll";
            this.btnRevertAll.Size = new System.Drawing.Size(75, 23);
            this.btnRevertAll.TabIndex = 118;
            this.btnRevertAll.Text = "Revert All";
            this.btnRevertAll.UseVisualStyleBackColor = true;
            this.btnRevertAll.Click += new System.EventHandler(this.btnRevertAll_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(87, 52);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 106;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 549);
            this.Controls.Add(this.pnlOffsets);
            this.Controls.Add(this.pnlHelp);
            this.Controls.Add(this.pnlMain);
            this.MinimumSize = new System.Drawing.Size(167, 588);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WoW FoV Changer";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.pnlHelp.ResumeLayout(false);
            this.pnlHelp.PerformLayout();
            this.pnlOffsets.ResumeLayout(false);
            this.pnlOffsets.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofdMain;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button btnFilename;
        private System.Windows.Forms.TextBox txtCurrent;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.TextBox txtNew;
        private System.Windows.Forms.Label lblNew;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.ComboBox cboSupportedInfo;
        private System.Windows.Forms.TextBox txtFilesize;
        private System.Windows.Forms.Label lblFilesize;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblSupportedInfo;
        private System.Windows.Forms.TextBox txtAspect;
        private System.Windows.Forms.Label lblAspect;
        private System.Windows.Forms.TextBox txtDefaultFov;
        private System.Windows.Forms.Label lblDefaultFov;
        private System.Windows.Forms.TextBox txtExpansion;
        private System.Windows.Forms.Label lblExpansion;
        private System.Windows.Forms.TextBox txtFovRatio;
        private System.Windows.Forms.Label lblFovRatio;
        private System.Windows.Forms.TextBox txtOffset;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.TextBox txtFilesizeSupported;
        private System.Windows.Forms.Label lblFilesizeSupported;
        private System.Windows.Forms.TextBox txtVersionSupported;
        private System.Windows.Forms.Label lblVersionSupported;
        private System.Windows.Forms.Button btnRefreshOffset;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Button btnHelp;
        private System.Windows.Forms.Panel pnlHelp;
        private System.Windows.Forms.Label txtHelp6;
        private System.Windows.Forms.Label lblHelp5;
        private System.Windows.Forms.Label lblHelp4;
        private System.Windows.Forms.Label lblHelp3;
        private System.Windows.Forms.Label lblHelp2;
        private System.Windows.Forms.Label lblHelp1;
        private System.Windows.Forms.Panel pnlOffsets;
        private System.Windows.Forms.Button btnOffsets;
        private System.Windows.Forms.Button btnFromDefault;
        private System.Windows.Forms.Button btnFromFov;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNewBytes;
        private System.Windows.Forms.ListBox lbxOffsets;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblBytes;
        private System.Windows.Forms.TextBox txtBytes;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRevertAll;
        private System.Windows.Forms.Button btnSetSelected;
        private System.Windows.Forms.Button btnSetAll;
    }
}

