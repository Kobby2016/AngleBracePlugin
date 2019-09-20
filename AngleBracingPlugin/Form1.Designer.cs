namespace AngleBracingPlugin
{
    partial class AngleBraceFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AngleBraceFrm));
            this.okApplyModifyGetOnOffCancel1 = new Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel();
            this.saveLoad1 = new Tekla.Structures.Dialog.UIControls.SaveLoad();
            this.lbl_AngleBracingType = new System.Windows.Forms.Label();
            this.AngleBracingType = new System.Windows.Forms.ComboBox();
            this.lbl_AngleProfile = new System.Windows.Forms.Label();
            this.AngleBracingProfile = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lbl_AnglePosition = new System.Windows.Forms.Label();
            this.AnglePosition = new System.Windows.Forms.ComboBox();
            this.AngleOffset = new System.Windows.Forms.TextBox();
            this.lbl_AngleOffset = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // okApplyModifyGetOnOffCancel1
            // 
            this.structuresExtender.SetAttributeName(this.okApplyModifyGetOnOffCancel1, null);
            this.structuresExtender.SetAttributeTypeName(this.okApplyModifyGetOnOffCancel1, null);
            this.structuresExtender.SetBindPropertyName(this.okApplyModifyGetOnOffCancel1, null);
            this.okApplyModifyGetOnOffCancel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.okApplyModifyGetOnOffCancel1.Location = new System.Drawing.Point(0, 337);
            this.okApplyModifyGetOnOffCancel1.Name = "okApplyModifyGetOnOffCancel1";
            this.okApplyModifyGetOnOffCancel1.Size = new System.Drawing.Size(634, 29);
            this.okApplyModifyGetOnOffCancel1.TabIndex = 0;
            // 
            // saveLoad1
            // 
            this.structuresExtender.SetAttributeName(this.saveLoad1, null);
            this.structuresExtender.SetAttributeTypeName(this.saveLoad1, null);
            this.saveLoad1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.structuresExtender.SetBindPropertyName(this.saveLoad1, null);
            this.saveLoad1.Dock = System.Windows.Forms.DockStyle.Top;
            this.saveLoad1.HelpFileType = Tekla.Structures.Dialog.UIControls.SaveLoad.HelpFileTypeEnum.General;
            this.saveLoad1.HelpKeyword = "";
            this.saveLoad1.HelpUrl = "";
            this.saveLoad1.Location = new System.Drawing.Point(0, 0);
            this.saveLoad1.Name = "saveLoad1";
            this.saveLoad1.SaveAsText = "";
            this.saveLoad1.Size = new System.Drawing.Size(634, 43);
            this.saveLoad1.TabIndex = 1;
            this.saveLoad1.UserDefinedHelpFilePath = null;
            // 
            // lbl_AngleBracingType
            // 
            this.structuresExtender.SetAttributeName(this.lbl_AngleBracingType, null);
            this.structuresExtender.SetAttributeTypeName(this.lbl_AngleBracingType, null);
            this.lbl_AngleBracingType.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.lbl_AngleBracingType, null);
            this.lbl_AngleBracingType.Location = new System.Drawing.Point(9, 46);
            this.lbl_AngleBracingType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbl_AngleBracingType.Name = "lbl_AngleBracingType";
            this.lbl_AngleBracingType.Size = new System.Drawing.Size(103, 13);
            this.lbl_AngleBracingType.TabIndex = 2;
            this.lbl_AngleBracingType.Text = "Angle Bracing Type:";
            // 
            // AngleBracingType
            // 
            this.structuresExtender.SetAttributeName(this.AngleBracingType, "AngleBracingType");
            this.structuresExtender.SetAttributeTypeName(this.AngleBracingType, "Integer");
            this.structuresExtender.SetBindPropertyName(this.AngleBracingType, null);
            this.AngleBracingType.FormattingEnabled = true;
            this.AngleBracingType.Items.AddRange(new object[] {
            "Single",
            "Double"});
            this.AngleBracingType.Location = new System.Drawing.Point(116, 44);
            this.AngleBracingType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AngleBracingType.Name = "AngleBracingType";
            this.AngleBracingType.Size = new System.Drawing.Size(92, 21);
            this.AngleBracingType.TabIndex = 3;
            // 
            // lbl_AngleProfile
            // 
            this.structuresExtender.SetAttributeName(this.lbl_AngleProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.lbl_AngleProfile, null);
            this.lbl_AngleProfile.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.lbl_AngleProfile, null);
            this.lbl_AngleProfile.Location = new System.Drawing.Point(213, 46);
            this.lbl_AngleProfile.Name = "lbl_AngleProfile";
            this.lbl_AngleProfile.Size = new System.Drawing.Size(72, 13);
            this.lbl_AngleProfile.TabIndex = 4;
            this.lbl_AngleProfile.Text = "Angle Profile: ";
            // 
            // AngleBracingProfile
            // 
            this.structuresExtender.SetAttributeName(this.AngleBracingProfile, "AngleBracingProfile");
            this.structuresExtender.SetAttributeTypeName(this.AngleBracingProfile, "Integer");
            this.structuresExtender.SetBindPropertyName(this.AngleBracingProfile, null);
            this.AngleBracingProfile.FormattingEnabled = true;
            this.AngleBracingProfile.Items.AddRange(new object[] {
            "L3X3X1/4",
            "L4X3X3/8",
            "L5X5X1/2"});
            this.AngleBracingProfile.Location = new System.Drawing.Point(291, 44);
            this.AngleBracingProfile.Name = "AngleBracingProfile";
            this.AngleBracingProfile.Size = new System.Drawing.Size(121, 21);
            this.AngleBracingProfile.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.structuresExtender.SetAttributeName(this.pictureBox1, null);
            this.structuresExtender.SetAttributeTypeName(this.pictureBox1, null);
            this.structuresExtender.SetBindPropertyName(this.pictureBox1, null);
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 104);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(305, 227);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.structuresExtender.SetAttributeName(this.pictureBox2, null);
            this.structuresExtender.SetAttributeTypeName(this.pictureBox2, null);
            this.structuresExtender.SetBindPropertyName(this.pictureBox2, null);
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(317, 104);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(306, 227);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // lbl_AnglePosition
            // 
            this.structuresExtender.SetAttributeName(this.lbl_AnglePosition, null);
            this.structuresExtender.SetAttributeTypeName(this.lbl_AnglePosition, null);
            this.lbl_AnglePosition.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.lbl_AnglePosition, null);
            this.lbl_AnglePosition.Location = new System.Drawing.Point(419, 50);
            this.lbl_AnglePosition.Name = "lbl_AnglePosition";
            this.lbl_AnglePosition.Size = new System.Drawing.Size(77, 13);
            this.lbl_AnglePosition.TabIndex = 8;
            this.lbl_AnglePosition.Text = "Angle Position:";
            // 
            // AnglePosition
            // 
            this.structuresExtender.SetAttributeName(this.AnglePosition, "AnglePosition");
            this.structuresExtender.SetAttributeTypeName(this.AnglePosition, "Integer");
            this.structuresExtender.SetBindPropertyName(this.AnglePosition, null);
            this.AnglePosition.FormattingEnabled = true;
            this.AnglePosition.Items.AddRange(new object[] {
            "Centered",
            "Offset"});
            this.AnglePosition.Location = new System.Drawing.Point(501, 47);
            this.AnglePosition.Name = "AnglePosition";
            this.AnglePosition.Size = new System.Drawing.Size(121, 21);
            this.AnglePosition.TabIndex = 9;
            // 
            // AngleOffset
            // 
            this.structuresExtender.SetAttributeName(this.AngleOffset, "AngleOffset");
            this.structuresExtender.SetAttributeTypeName(this.AngleOffset, "Distance");
            this.structuresExtender.SetBindPropertyName(this.AngleOffset, null);
            this.AngleOffset.Location = new System.Drawing.Point(86, 75);
            this.AngleOffset.Name = "AngleOffset";
            this.AngleOffset.Size = new System.Drawing.Size(100, 20);
            this.AngleOffset.TabIndex = 10;
            // 
            // lbl_AngleOffset
            // 
            this.structuresExtender.SetAttributeName(this.lbl_AngleOffset, null);
            this.structuresExtender.SetAttributeTypeName(this.lbl_AngleOffset, null);
            this.lbl_AngleOffset.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.lbl_AngleOffset, null);
            this.lbl_AngleOffset.Location = new System.Drawing.Point(12, 78);
            this.lbl_AngleOffset.Name = "lbl_AngleOffset";
            this.lbl_AngleOffset.Size = new System.Drawing.Size(68, 13);
            this.lbl_AngleOffset.TabIndex = 11;
            this.lbl_AngleOffset.Text = "Angle Offset:";
            // 
            // AngleBraceFrm
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(634, 366);
            this.Controls.Add(this.lbl_AngleOffset);
            this.Controls.Add(this.AngleOffset);
            this.Controls.Add(this.AnglePosition);
            this.Controls.Add(this.lbl_AnglePosition);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.AngleBracingProfile);
            this.Controls.Add(this.lbl_AngleProfile);
            this.Controls.Add(this.AngleBracingType);
            this.Controls.Add(this.lbl_AngleBracingType);
            this.Controls.Add(this.saveLoad1);
            this.Controls.Add(this.okApplyModifyGetOnOffCancel1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "AngleBraceFrm";
            this.Text = "Angle Bracing";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Tekla.Structures.Dialog.UIControls.OkApplyModifyGetOnOffCancel okApplyModifyGetOnOffCancel1;
        private Tekla.Structures.Dialog.UIControls.SaveLoad saveLoad1;
        private System.Windows.Forms.Label lbl_AngleBracingType;
        private System.Windows.Forms.ComboBox AngleBracingType;
        private System.Windows.Forms.Label lbl_AngleProfile;
        private System.Windows.Forms.ComboBox AngleBracingProfile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lbl_AnglePosition;
        private System.Windows.Forms.ComboBox AnglePosition;
        private System.Windows.Forms.TextBox AngleOffset;
        private System.Windows.Forms.Label lbl_AngleOffset;
    }
}

