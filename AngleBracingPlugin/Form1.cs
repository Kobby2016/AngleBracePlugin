using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// Tekla Structures Namespaces
using TSM = Tekla.Structures.Model;
using TSD = Tekla.Structures.Dialog;
using TSDT = Tekla.Structures.Datatype;
using T3D = Tekla.Structures.Geometry3d;
using TSMUI = Tekla.Structures.Model.UI;
using Tekla.Structures.Plugins;


namespace AngleBracingPlugin
{

    
    public partial class Form1 : TSD.PluginFormBase
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        #region okApplyModifyGetOnOffCancel
        private void OkApplyModifyGetOnOffCancel1_OkClicked_1(object sender, EventArgs e)
        {
            this.Apply();
            this.Close();

        }

        private void OkApplyModifyGetOnOffCancel1_ApplyClicked_1(object sender, EventArgs e)
        {
            this.Apply();
        }

        private void OkApplyModifyGetOnOffCancel1_ModifyClicked_1(object sender, EventArgs e)
        {
            this.Modify();
        }

        private void OkApplyModifyGetOnOffCancel1_GetClicked_1(object sender, EventArgs e)
        {
            this.Get();
        }

        private void OkApplyModifyGetOnOffCancel1_OnOffClicked_1(object sender, EventArgs e)
        {
            this.ToggleSelection();
        }

        private void OkApplyModifyGetOnOffCancel1_CancelClicked_1(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        // Combobox for setting angle bracing connection to single angle or double angle
        private void AngleBracingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AngleBracingType.SelectedIndex)
            {
                // If single angle bracing
                case 0: SetAttributeValue(AngleBracingType, new TSDT.Integer(0));
                break;
                // If double angle bracing
                case 1:
                    SetAttributeValue(AngleBracingType, new TSDT.Integer(1));
                    break;
                // Default to single angle bracing
                default:
                    SetAttributeValue(AngleBracingType, new TSDT.Integer(0));
                    break;
            }
        }

        // Combobox for setting angle profile
        private void AngleBracingProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AngleBracingProfile.SelectedIndex)
            {
                // Three options for angle profile within plugin

                // 0 = L3X3X1/4 
                case 0:
                    SetAttributeValue(AngleBracingProfile, new TSDT.Integer(0));
                    break;
                // 1 = L4X4X3/8
                case 1:
                    SetAttributeValue(AngleBracingProfile, new TSDT.Integer(1));
                    break;
                // 2 = L5X5X1/2 
                case 2:
                    SetAttributeValue(AngleBracingProfile, new TSDT.Integer(2));
                    break;
                // default to 0 = L3X3X1/4 
                default:
                    SetAttributeValue(AngleBracingProfile, new TSDT.Integer(0));
                    break;
            }
        }

        // Combobox for setting angle to centered or offset
        private void AnglePosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AnglePosition.SelectedIndex)
            {
                // 0 = Angle is centered
                case 0:
                    SetAttributeValue(AnglePosition, new TSDT.Integer(0));
                    // Hide option for angle offset
                    lbl_AngleOffset.Visible = false;
                    AngleOffset.Visible = false;
                    break;
                // 0 = Angle is offset
                case 1:
                    SetAttributeValue(AnglePosition, new TSDT.Integer(1));
                    // Show option for angle offset
                    lbl_AngleOffset.Visible = true;
                    AngleOffset.Visible = true;
                    break;
                // default to centered
                default:
                    SetAttributeValue(AnglePosition, new TSDT.Integer(0));
                    // Hide option for angle offset
                    lbl_AngleOffset.Visible = false;
                    AngleOffset.Visible = false;
                    break;
            }
        }

        // Textbox to set distance for angle offset if that option is chosen
        private void AngleOffset_TextChanged(object sender, EventArgs e)
        {
            SetAttributeValue(AngleOffset, AngleOffset.Text);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void FirstOffset_TextChanged(object sender, EventArgs e)
        {
            SetAttributeValue(FirstOffset, FirstOffset.Text);
        }

        private void SecondOffset_TextChanged(object sender, EventArgs e)
        {
            SetAttributeValue(SecondOffset, SecondOffset.Text);
        }

        private void ThirdOffset_TextChanged(object sender, EventArgs e)
        {
            SetAttributeValue(ThirdOffset, ThirdOffset.Text);
        }

        private void FourthOffset_TextChanged(object sender, EventArgs e)
        {
            SetAttributeValue(FourthOffset, FourthOffset.Text);
        }
    }
}
