
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
            this.lblFilename.Location = new System.Drawing.Point(8, 6);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(94, 13);
            this.lblFilename.TabIndex = 0;
            this.lblFilename.Text = "WoW Executable:";
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.Location = new System.Drawing.Point(8, 22);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(325, 20);
            this.txtFilename.TabIndex = 0;
            this.txtFilename.TextChanged += new System.EventHandler(this.txtFilename_TextChanged);
            // 
            // btnFilename
            // 
            this.btnFilename.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFilename.Location = new System.Drawing.Point(339, 22);
            this.btnFilename.Name = "btnFilename";
            this.btnFilename.Size = new System.Drawing.Size(25, 20);
            this.btnFilename.TabIndex = 2;
            this.btnFilename.Text = "...";
            this.btnFilename.UseVisualStyleBackColor = true;
            this.btnFilename.Click += new System.EventHandler(this.btnFilename_Click);
            // 
            // txtCurrent
            // 
            this.txtCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurrent.Location = new System.Drawing.Point(8, 139);
            this.txtCurrent.Name = "txtCurrent";
            this.txtCurrent.ReadOnly = true;
            this.txtCurrent.Size = new System.Drawing.Size(356, 20);
            this.txtCurrent.TabIndex = 8;
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(8, 123);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(66, 13);
            this.lblCurrent.TabIndex = 3;
            this.lblCurrent.Text = "Current FoV:";
            // 
            // txtNew
            // 
            this.txtNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNew.Location = new System.Drawing.Point(5, 491);
            this.txtNew.Name = "txtNew";
            this.txtNew.Size = new System.Drawing.Size(288, 20);
            this.txtNew.TabIndex = 28;
            this.txtNew.TextChanged += new System.EventHandler(this.txtNew_TextChanged);
            // 
            // lblNew
            // 
            this.lblNew.AutoSize = true;
            this.lblNew.Location = new System.Drawing.Point(5, 475);
            this.lblNew.Name = "lblNew";
            this.lblNew.Size = new System.Drawing.Size(54, 13);
            this.lblNew.TabIndex = 5;
            this.lblNew.Text = "New FoV:";
            // 
            // btnApply
            // 
            this.btnApply.Enabled = false;
            this.btnApply.Location = new System.Drawing.Point(5, 517);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 32;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnDefault
            // 
            this.btnDefault.Location = new System.Drawing.Point(299, 491);
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
            this.txtOutput.Location = new System.Drawing.Point(86, 519);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(275, 20);
            this.txtOutput.TabIndex = 34;
            // 
            // cboSupportedInfo
            // 
            this.cboSupportedInfo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSupportedInfo.FormattingEnabled = true;
            this.cboSupportedInfo.Location = new System.Drawing.Point(5, 178);
            this.cboSupportedInfo.Name = "cboSupportedInfo";
            this.cboSupportedInfo.Size = new System.Drawing.Size(356, 21);
            this.cboSupportedInfo.TabIndex = 10;
            this.cboSupportedInfo.SelectedIndexChanged += new System.EventHandler(this.cboFileVersion_SelectedIndexChanged);
            // 
            // txtFilesize
            // 
            this.txtFilesize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilesize.Location = new System.Drawing.Point(8, 61);
            this.txtFilesize.Name = "txtFilesize";
            this.txtFilesize.ReadOnly = true;
            this.txtFilesize.Size = new System.Drawing.Size(356, 20);
            this.txtFilesize.TabIndex = 4;
            // 
            // lblFilesize
            // 
            this.lblFilesize.AutoSize = true;
            this.lblFilesize.Location = new System.Drawing.Point(8, 45);
            this.lblFilesize.Name = "lblFilesize";
            this.lblFilesize.Size = new System.Drawing.Size(44, 13);
            this.lblFilesize.TabIndex = 11;
            this.lblFilesize.Text = "Filesize:";
            // 
            // txtVersion
            // 
            this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersion.Location = new System.Drawing.Point(8, 100);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(356, 20);
            this.txtVersion.TabIndex = 6;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(8, 84);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(45, 13);
            this.lblVersion.TabIndex = 13;
            this.lblVersion.Text = "Version:";
            // 
            // lblSupportedInfo
            // 
            this.lblSupportedInfo.AutoSize = true;
            this.lblSupportedInfo.Location = new System.Drawing.Point(5, 162);
            this.lblSupportedInfo.Name = "lblSupportedInfo";
            this.lblSupportedInfo.Size = new System.Drawing.Size(120, 13);
            this.lblSupportedInfo.TabIndex = 15;
            this.lblSupportedInfo.Text = "Supported Executables:";
            // 
            // txtAspect
            // 
            this.txtAspect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAspect.Location = new System.Drawing.Point(5, 218);
            this.txtAspect.Name = "txtAspect";
            this.txtAspect.ReadOnly = true;
            this.txtAspect.Size = new System.Drawing.Size(356, 20);
            this.txtAspect.TabIndex = 12;
            // 
            // lblAspect
            // 
            this.lblAspect.AutoSize = true;
            this.lblAspect.Location = new System.Drawing.Point(5, 202);
            this.lblAspect.Name = "lblAspect";
            this.lblAspect.Size = new System.Drawing.Size(98, 13);
            this.lblAspect.TabIndex = 16;
            this.lblAspect.Text = "Base Aspect Ratio:";
            // 
            // txtDefaultFov
            // 
            this.txtDefaultFov.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDefaultFov.Location = new System.Drawing.Point(5, 257);
            this.txtDefaultFov.Name = "txtDefaultFov";
            this.txtDefaultFov.ReadOnly = true;
            this.txtDefaultFov.Size = new System.Drawing.Size(356, 20);
            this.txtDefaultFov.TabIndex = 14;
            // 
            // lblDefaultFov
            // 
            this.lblDefaultFov.AutoSize = true;
            this.lblDefaultFov.Location = new System.Drawing.Point(5, 241);
            this.lblDefaultFov.Name = "lblDefaultFov";
            this.lblDefaultFov.Size = new System.Drawing.Size(66, 13);
            this.lblDefaultFov.TabIndex = 18;
            this.lblDefaultFov.Text = "Default FoV:";
            // 
            // txtExpansion
            // 
            this.txtExpansion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtExpansion.Location = new System.Drawing.Point(5, 296);
            this.txtExpansion.Name = "txtExpansion";
            this.txtExpansion.ReadOnly = true;
            this.txtExpansion.Size = new System.Drawing.Size(356, 20);
            this.txtExpansion.TabIndex = 16;
            // 
            // lblExpansion
            // 
            this.lblExpansion.AutoSize = true;
            this.lblExpansion.Location = new System.Drawing.Point(5, 280);
            this.lblExpansion.Name = "lblExpansion";
            this.lblExpansion.Size = new System.Drawing.Size(59, 13);
            this.lblExpansion.TabIndex = 20;
            this.lblExpansion.Text = "Expansion:";
            // 
            // txtFovRatio
            // 
            this.txtFovRatio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFovRatio.Location = new System.Drawing.Point(5, 335);
            this.txtFovRatio.Name = "txtFovRatio";
            this.txtFovRatio.ReadOnly = true;
            this.txtFovRatio.Size = new System.Drawing.Size(356, 20);
            this.txtFovRatio.TabIndex = 18;
            // 
            // lblFovRatio
            // 
            this.lblFovRatio.AutoSize = true;
            this.lblFovRatio.Location = new System.Drawing.Point(5, 319);
            this.lblFovRatio.Name = "lblFovRatio";
            this.lblFovRatio.Size = new System.Drawing.Size(57, 13);
            this.lblFovRatio.TabIndex = 22;
            this.lblFovRatio.Text = "FoV Ratio:";
            // 
            // txtOffset
            // 
            this.txtOffset.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOffset.Location = new System.Drawing.Point(5, 374);
            this.txtOffset.Name = "txtOffset";
            this.txtOffset.ReadOnly = true;
            this.txtOffset.Size = new System.Drawing.Size(328, 20);
            this.txtOffset.TabIndex = 20;
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(5, 358);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(38, 13);
            this.lblOffset.TabIndex = 24;
            this.lblOffset.Text = "Offset:";
            // 
            // txtFilesizeSupported
            // 
            this.txtFilesizeSupported.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilesizeSupported.Location = new System.Drawing.Point(5, 413);
            this.txtFilesizeSupported.Name = "txtFilesizeSupported";
            this.txtFilesizeSupported.ReadOnly = true;
            this.txtFilesizeSupported.Size = new System.Drawing.Size(356, 20);
            this.txtFilesizeSupported.TabIndex = 24;
            // 
            // lblFilesizeSupported
            // 
            this.lblFilesizeSupported.AutoSize = true;
            this.lblFilesizeSupported.Location = new System.Drawing.Point(5, 397);
            this.lblFilesizeSupported.Name = "lblFilesizeSupported";
            this.lblFilesizeSupported.Size = new System.Drawing.Size(44, 13);
            this.lblFilesizeSupported.TabIndex = 26;
            this.lblFilesizeSupported.Text = "Filesize:";
            // 
            // txtVersionSupported
            // 
            this.txtVersionSupported.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersionSupported.Location = new System.Drawing.Point(5, 452);
            this.txtVersionSupported.Name = "txtVersionSupported";
            this.txtVersionSupported.ReadOnly = true;
            this.txtVersionSupported.Size = new System.Drawing.Size(356, 20);
            this.txtVersionSupported.TabIndex = 26;
            // 
            // lblVersionSupported
            // 
            this.lblVersionSupported.AutoSize = true;
            this.lblVersionSupported.Location = new System.Drawing.Point(5, 436);
            this.lblVersionSupported.Name = "lblVersionSupported";
            this.lblVersionSupported.Size = new System.Drawing.Size(45, 13);
            this.lblVersionSupported.TabIndex = 28;
            this.lblVersionSupported.Text = "Version:";
            // 
            // btnRefreshOffset
            // 
            this.btnRefreshOffset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshOffset.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshOffset.Location = new System.Drawing.Point(339, 373);
            this.btnRefreshOffset.Name = "btnRefreshOffset";
            this.btnRefreshOffset.Size = new System.Drawing.Size(25, 20);
            this.btnRefreshOffset.TabIndex = 22;
            this.btnRefreshOffset.Text = "⟳";
            this.btnRefreshOffset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRefreshOffset.UseVisualStyleBackColor = true;
            this.btnRefreshOffset.Click += new System.EventHandler(this.btnRefreshOffset_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 548);
            this.Controls.Add(this.btnRefreshOffset);
            this.Controls.Add(this.txtVersionSupported);
            this.Controls.Add(this.lblVersionSupported);
            this.Controls.Add(this.txtFilesizeSupported);
            this.Controls.Add(this.lblFilesizeSupported);
            this.Controls.Add(this.txtOffset);
            this.Controls.Add(this.lblOffset);
            this.Controls.Add(this.txtFovRatio);
            this.Controls.Add(this.lblFovRatio);
            this.Controls.Add(this.txtExpansion);
            this.Controls.Add(this.lblExpansion);
            this.Controls.Add(this.txtDefaultFov);
            this.Controls.Add(this.lblDefaultFov);
            this.Controls.Add(this.txtAspect);
            this.Controls.Add(this.lblAspect);
            this.Controls.Add(this.lblSupportedInfo);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.txtFilesize);
            this.Controls.Add(this.lblFilesize);
            this.Controls.Add(this.cboSupportedInfo);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnDefault);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.txtNew);
            this.Controls.Add(this.lblNew);
            this.Controls.Add(this.txtCurrent);
            this.Controls.Add(this.lblCurrent);
            this.Controls.Add(this.btnFilename);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.lblFilename);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WoW FoV Changer";
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}

