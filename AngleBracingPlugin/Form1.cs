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

    
    public partial class AngleBraceFrm : TSD.PluginFormBase
    {
        public AngleBraceFrm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

# region okApplyModifyGetOnOffCancel
        private void okApplyModifyGetOnOffCancel1_ApplyClicked(object sender, EventArgs e)
        {
            this.Apply();
        }

        private void okApplyModifyGetOnOffCancel1_CancelClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void okApplyModifyGetOnOffCancel1_GetClicked(object sender, EventArgs e)
        {
            this.Get();
        }

        private void okApplyModifyGetOnOffCancel1_ModifyClicked(object sender, EventArgs e)
        {
            this.Modify();
        }

        private void okApplyModifyGetOnOffCancel1_OkClicked(object sender, EventArgs e)
        {
            this.Apply();
            this.Close();
        }

        private void okApplyModifyGetOnOffCancel1_OnOffClicked(object sender, EventArgs e)
        {
            this.ToggleSelection();
        }
        #endregion
        
        // Combobox for setting angle bracing connection to single angle or double angle
        private void AngleBracingType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (AngleBracingType.SelectedIndex)
            {
                // If single angle bracing
                case 0: SetAttributeValue(AngleBracingType, 0);
                break;
                // If double angle bracing
                case 1:
                    SetAttributeValue(AngleBracingType, 1);
                    break;
                // Default to single angle bracing
                default:
                    SetAttributeValue(AngleBracingType, 0);
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
                    SetAttributeValue(AngleBracingProfile, 0);
                    break;
                // 1 = L4X4X3/8
                case 1:
                    SetAttributeValue(AngleBracingProfile, 1);
                    break;
                // 2 = L5X5X1/2 
                case 2:
                    SetAttributeValue(AngleBracingProfile, 2);
                    break;
                // default to 0 = L3X3X1/4 
                default:
                    SetAttributeValue(AngleBracingProfile, 0);
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
                    SetAttributeValue(AnglePosition, 0);
                    // Hide option for angle offset
                    lbl_AngleOffset.Visible = false;
                    AngleOffset.Visible = false;
                    break;
                // 0 = Angle is offset
                case 1:
                    SetAttributeValue(AnglePosition, 1);
                    // Show option for angle offset
                    lbl_AngleOffset.Visible = true;
                    AngleOffset.Visible = true;
                    break;
                // default to centered
                default:
                    SetAttributeValue(AnglePosition, 0);
                    // Hide option for angle offset
                    lbl_AngleOffset.Visible = false;
                    AngleOffset.Visible = false;
                    break;
            }
        }

        // Textbox to set distance for angle offset if that option is chosen
        private void AngleOffset_TextChanged(object sender, EventArgs e)
        {
            double angleOffset;
            bool offsetEntered;

            // Check to see if AngleOffset value is null or 0
            offsetEntered = Double.TryParse(AngleOffset.Text, out angleOffset);

            // If conversion was successful and value is greater than 0
            if (offsetEntered && angleOffset != 0.0)
            {
                // set attribute value to value entered by user
                SetAttributeValue(AngleOffset, angleOffset);
            }
            else
            {
                // default value to -1 to leave the angle centered.
                SetAttributeValue(AngleOffset, -1);
            }
        }
    }
}
