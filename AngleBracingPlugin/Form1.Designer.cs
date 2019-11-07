namespace AngleBracingPlugin
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.lbl_Offset1 = new System.Windows.Forms.Label();
            this.lbl_Offset2 = new System.Windows.Forms.Label();
            this.lbl_Offset3 = new System.Windows.Forms.Label();
            this.lbl_Offset4 = new System.Windows.Forms.Label();
            this.FirstOffset = new System.Windows.Forms.TextBox();
            this.SecondOffset = new System.Windows.Forms.TextBox();
            this.ThirdOffset = new System.Windows.Forms.TextBox();
            this.FourthOffset = new System.Windows.Forms.TextBox();
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
            this.okApplyModifyGetOnOffCancel1.Location = new System.Drawing.Point(0, 459);
            this.okApplyModifyGetOnOffCancel1.Margin = new System.Windows.Forms.Padding(5);
            this.okApplyModifyGetOnOffCancel1.Name = "okApplyModifyGetOnOffCancel1";
            this.okApplyModifyGetOnOffCancel1.Size = new System.Drawing.Size(879, 36);
            this.okApplyModifyGetOnOffCancel1.TabIndex = 0;
            this.okApplyModifyGetOnOffCancel1.OkClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel1_OkClicked_1);
            this.okApplyModifyGetOnOffCancel1.ApplyClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel1_ApplyClicked_1);
            this.okApplyModifyGetOnOffCancel1.ModifyClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel1_ModifyClicked_1);
            this.okApplyModifyGetOnOffCancel1.GetClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel1_GetClicked_1);
            this.okApplyModifyGetOnOffCancel1.OnOffClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel1_OnOffClicked_1);
            this.okApplyModifyGetOnOffCancel1.CancelClicked += new System.EventHandler(this.OkApplyModifyGetOnOffCancel1_CancelClicked_1);
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
            this.saveLoad1.Margin = new System.Windows.Forms.Padding(5);
            this.saveLoad1.Name = "saveLoad1";
            this.saveLoad1.SaveAsText = "";
            this.saveLoad1.Size = new System.Drawing.Size(879, 53);
            this.saveLoad1.TabIndex = 1;
            this.saveLoad1.UserDefinedHelpFilePath = null;
            // 
            // lbl_AngleBracingType
            // 
            this.structuresExtender.SetAttributeName(this.lbl_AngleBracingType, null);
            this.structuresExtender.SetAttributeTypeName(this.lbl_AngleBracingType, null);
            this.lbl_AngleBracingType.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.lbl_AngleBracingType, null);
            this.lbl_AngleBracingType.Location = new System.Drawing.Point(32, 60);
            this.lbl_AngleBracingType.Name = "lbl_AngleBracingType";
            this.lbl_AngleBracingType.Size = new System.Drawing.Size(136, 17);
            this.lbl_AngleBracingType.TabIndex = 2;
            this.lbl_AngleBracingType.Text = "Angle Bracing Type:";
            // 
            // AngleBracingType
            // 
            this.structuresExtender.SetAttributeName(this.AngleBracingType, "AngleBracingType");
            this.structuresExtender.SetAttributeTypeName(this.AngleBracingType, "Integer");
            this.structuresExtender.SetBindPropertyName(this.AngleBracingType, "SelectedIndex");
            this.AngleBracingType.FormattingEnabled = true;
            this.AngleBracingType.Items.AddRange(new object[] {
            "Single",
            "Double"});
            this.AngleBracingType.Location = new System.Drawing.Point(175, 57);
            this.AngleBracingType.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.AngleBracingType.Name = "AngleBracingType";
            this.AngleBracingType.Size = new System.Drawing.Size(121, 24);
            this.AngleBracingType.TabIndex = 3;
            this.AngleBracingType.SelectedIndexChanged += new System.EventHandler(this.AngleBracingType_SelectedIndexChanged);
            // 
            // lbl_AngleProfile
            // 
            this.structuresExtender.SetAttributeName(this.lbl_AngleProfile, null);
            this.structuresExtender.SetAttributeTypeName(this.lbl_AngleProfile, null);
            this.lbl_AngleProfile.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.lbl_AngleProfile, null);
            this.lbl_AngleProfile.Location = new System.Drawing.Point(320, 61);
            this.lbl_AngleProfile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_AngleProfile.Name = "lbl_AngleProfile";
            this.lbl_AngleProfile.Size = new System.Drawing.Size(96, 17);
            this.lbl_AngleProfile.TabIndex = 4;
            this.lbl_AngleProfile.Text = "Angle Profile: ";
            // 
            // AngleBracingProfile
            // 
            this.structuresExtender.SetAttributeName(this.AngleBracingProfile, "AngleBracingProfile");
            this.structuresExtender.SetAttributeTypeName(this.AngleBracingProfile, "Integer");
            this.structuresExtender.SetBindPropertyName(this.AngleBracingProfile, "SelectedIndex");
            this.AngleBracingProfile.FormattingEnabled = true;
            this.AngleBracingProfile.Items.AddRange(new object[] {
            "L3X3X1/4",
            "L4X4X3/8",
            "L5X5X1/2"});
            this.AngleBracingProfile.Location = new System.Drawing.Point(424, 58);
            this.AngleBracingProfile.Margin = new System.Windows.Forms.Padding(4);
            this.AngleBracingProfile.Name = "AngleBracingProfile";
            this.AngleBracingProfile.Size = new System.Drawing.Size(145, 24);
            this.AngleBracingProfile.TabIndex = 5;
            this.AngleBracingProfile.SelectedIndexChanged += new System.EventHandler(this.AngleBracingProfile_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.structuresExtender.SetAttributeName(this.pictureBox1, null);
            this.structuresExtender.SetAttributeTypeName(this.pictureBox1, null);
            this.structuresExtender.SetBindPropertyName(this.pictureBox1, null);
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(9, 171);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(407, 279);
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
            this.pictureBox2.Location = new System.Drawing.Point(458, 171);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(408, 279);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lbl_AnglePosition
            // 
            this.structuresExtender.SetAttributeName(this.lbl_AnglePosition, null);
            this.structuresExtender.SetAttributeTypeName(this.lbl_AnglePosition, null);
            this.lbl_AnglePosition.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.lbl_AnglePosition, null);
            this.lbl_AnglePosition.Location = new System.Drawing.Point(601, 61);
            this.lbl_AnglePosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_AnglePosition.Name = "lbl_AnglePosition";
            this.lbl_AnglePosition.Size = new System.Drawing.Size(102, 17);
            this.lbl_AnglePosition.TabIndex = 8;
            this.lbl_AnglePosition.Text = "Angle Position:";
            // 
            // AnglePosition
            // 
            this.structuresExtender.SetAttributeName(this.AnglePosition, "AnglePosition");
            this.structuresExtender.SetAttributeTypeName(this.AnglePosition, "Integer");
            this.structuresExtender.SetBindPropertyName(this.AnglePosition, "SelectedIndex");
            this.AnglePosition.FormattingEnabled = true;
            this.AnglePosition.Items.AddRange(new object[] {
            "Centered",
            "Offset"});
            this.AnglePosition.Location = new System.Drawing.Point(711, 57);
            this.AnglePosition.Margin = new System.Windows.Forms.Padding(4);
            this.AnglePosition.Name = "AnglePosition";
            this.AnglePosition.Size = new System.Drawing.Size(160, 24);
            this.AnglePosition.TabIndex = 9;
            this.AnglePosition.SelectedIndexChanged += new System.EventHandler(this.AnglePosition_SelectedIndexChanged);
            // 
            // AngleOffset
            // 
            this.structuresExtender.SetAttributeName(this.AngleOffset, "AngleOffset");
            this.structuresExtender.SetAttributeTypeName(this.AngleOffset, "String");
            this.structuresExtender.SetBindPropertyName(this.AngleOffset, "Text");
            this.AngleOffset.Location = new System.Drawing.Point(131, 91);
            this.AngleOffset.Margin = new System.Windows.Forms.Padding(4);
            this.AngleOffset.Name = "AngleOffset";
            this.AngleOffset.Size = new System.Drawing.Size(132, 22);
            this.AngleOffset.TabIndex = 10;
            this.AngleOffset.Visible = false;
            this.AngleOffset.TextChanged += new System.EventHandler(this.AngleOffset_TextChanged);
            // 
            // lbl_AngleOffset
            // 
            this.structuresExtender.SetAttributeName(this.lbl_AngleOffset, null);
            this.structuresExtender.SetAttributeTypeName(this.lbl_AngleOffset, null);
            this.lbl_AngleOffset.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.lbl_AngleOffset, null);
            this.lbl_AngleOffset.Location = new System.Drawing.Point(32, 95);
            this.lbl_AngleOffset.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_AngleOffset.Name = "lbl_AngleOffset";
            this.lbl_AngleOffset.Size = new System.Drawing.Size(90, 17);
            this.lbl_AngleOffset.TabIndex = 11;
            this.lbl_AngleOffset.Text = "Angle Offset:";
            this.lbl_AngleOffset.Visible = false;
            // 
            // lbl_Offset1
            // 
            this.structuresExtender.SetAttributeName(this.lbl_Offset1, null);
            this.structuresExtender.SetAttributeTypeName(this.lbl_Offset1, null);
            this.lbl_Offset1.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.lbl_Offset1, null);
            this.lbl_Offset1.Location = new System.Drawing.Point(475, 96);
            this.lbl_Offset1.Name = "lbl_Offset1";
            this.lbl_Offset1.Size = new System.Drawing.Size(62, 17);
            this.lbl_Offset1.TabIndex = 12;
            this.lbl_Offset1.Text = "Offset 1:";
            // 
            // lbl_Offset2
            // 
            this.structuresExtender.SetAttributeName(this.lbl_Offset2, null);
            this.structuresExtender.SetAttributeTypeName(this.lbl_Offset2, null);
            this.lbl_Offset2.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.lbl_Offset2, null);
            this.lbl_Offset2.Location = new System.Drawing.Point(475, 134);
            this.lbl_Offset2.Name = "lbl_Offset2";
            this.lbl_Offset2.Size = new System.Drawing.Size(62, 17);
            this.lbl_Offset2.TabIndex = 12;
            this.lbl_Offset2.Text = "Offset 2:";
            // 
            // lbl_Offset3
            // 
            this.structuresExtender.SetAttributeName(this.lbl_Offset3, null);
            this.structuresExtender.SetAttributeTypeName(this.lbl_Offset3, null);
            this.lbl_Offset3.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.lbl_Offset3, null);
            this.lbl_Offset3.Location = new System.Drawing.Point(699, 95);
            this.lbl_Offset3.Name = "lbl_Offset3";
            this.lbl_Offset3.Size = new System.Drawing.Size(62, 17);
            this.lbl_Offset3.TabIndex = 12;
            this.lbl_Offset3.Text = "Offset 3:";
            // 
            // lbl_Offset4
            // 
            this.structuresExtender.SetAttributeName(this.lbl_Offset4, null);
            this.structuresExtender.SetAttributeTypeName(this.lbl_Offset4, null);
            this.lbl_Offset4.AutoSize = true;
            this.structuresExtender.SetBindPropertyName(this.lbl_Offset4, null);
            this.lbl_Offset4.Location = new System.Drawing.Point(699, 133);
            this.lbl_Offset4.Name = "lbl_Offset4";
            this.lbl_Offset4.Size = new System.Drawing.Size(62, 17);
            this.lbl_Offset4.TabIndex = 12;
            this.lbl_Offset4.Text = "Offset 4:";
            // 
            // FirstOffset
            // 
            this.structuresExtender.SetAttributeName(this.FirstOffset, "FirstOffset");
            this.structuresExtender.SetAttributeTypeName(this.FirstOffset, "String");
            this.structuresExtender.SetBindPropertyName(this.FirstOffset, "Text");
            this.FirstOffset.Location = new System.Drawing.Point(543, 92);
            this.FirstOffset.Name = "FirstOffset";
            this.FirstOffset.Size = new System.Drawing.Size(100, 22);
            this.FirstOffset.TabIndex = 13;
            this.FirstOffset.TextChanged += new System.EventHandler(this.FirstOffset_TextChanged);
            // 
            // SecondOffset
            // 
            this.structuresExtender.SetAttributeName(this.SecondOffset, "SecondOffset");
            this.structuresExtender.SetAttributeTypeName(this.SecondOffset, "String");
            this.structuresExtender.SetBindPropertyName(this.SecondOffset, "Text");
            this.SecondOffset.Location = new System.Drawing.Point(543, 131);
            this.SecondOffset.Name = "SecondOffset";
            this.SecondOffset.Size = new System.Drawing.Size(100, 22);
            this.SecondOffset.TabIndex = 14;
            this.SecondOffset.TextChanged += new System.EventHandler(this.SecondOffset_TextChanged);
            // 
            // ThirdOffset
            // 
            this.structuresExtender.SetAttributeName(this.ThirdOffset, "ThirdOffset");
            this.structuresExtender.SetAttributeTypeName(this.ThirdOffset, "String");
            this.structuresExtender.SetBindPropertyName(this.ThirdOffset, "Text");
            this.ThirdOffset.Location = new System.Drawing.Point(767, 91);
            this.ThirdOffset.Name = "ThirdOffset";
            this.ThirdOffset.Size = new System.Drawing.Size(100, 22);
            this.ThirdOffset.TabIndex = 15;
            this.ThirdOffset.TextChanged += new System.EventHandler(this.ThirdOffset_TextChanged);
            // 
            // FourthOffset
            // 
            this.structuresExtender.SetAttributeName(this.FourthOffset, "FourthOffset");
            this.structuresExtender.SetAttributeTypeName(this.FourthOffset, "String");
            this.structuresExtender.SetBindPropertyName(this.FourthOffset, "Text");
            this.FourthOffset.Location = new System.Drawing.Point(767, 130);
            this.FourthOffset.Name = "FourthOffset";
            this.FourthOffset.Size = new System.Drawing.Size(100, 22);
            this.FourthOffset.TabIndex = 16;
            this.FourthOffset.TextChanged += new System.EventHandler(this.FourthOffset_TextChanged);
            // 
            // Form1
            // 
            this.structuresExtender.SetAttributeName(this, null);
            this.structuresExtender.SetAttributeTypeName(this, null);
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.structuresExtender.SetBindPropertyName(this, null);
            this.ClientSize = new System.Drawing.Size(879, 495);
            this.Controls.Add(this.FourthOffset);
            this.Controls.Add(this.ThirdOffset);
            this.Controls.Add(this.SecondOffset);
            this.Controls.Add(this.FirstOffset);
            this.Controls.Add(this.lbl_Offset4);
            this.Controls.Add(this.lbl_Offset3);
            this.Controls.Add(this.lbl_Offset2);
            this.Controls.Add(this.lbl_Offset1);
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
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
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
        private System.Windows.Forms.Label lbl_Offset1;
        private System.Windows.Forms.Label lbl_Offset2;
        private System.Windows.Forms.Label lbl_Offset3;
        private System.Windows.Forms.Label lbl_Offset4;
        private System.Windows.Forms.TextBox FirstOffset;
        private System.Windows.Forms.TextBox SecondOffset;
        private System.Windows.Forms.TextBox ThirdOffset;
        private System.Windows.Forms.TextBox FourthOffset;
    }
}

