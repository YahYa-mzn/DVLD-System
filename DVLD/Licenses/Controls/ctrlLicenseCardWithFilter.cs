using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Global_Classes;
using DVLD_BLL;

namespace DVLD.Licenses.Controls
{
    public partial class ctrlLicenseCardWithFilter : UserControl
    {
        public delegate void delLoadInfoInParent();
        public event delLoadInfoInParent LoadInfoInParent;

        public delegate void delResetInfoInParent();
        public event delResetInfoInParent ResetInfoInParent;

        public clsLicense License { get; private set; } = null;
        private clsFormsUtility.enInputType _InputType { get; set; } = clsFormsUtility.enInputType.None;


        public void DisableSearching()
        {
            txtBoxFilter.ReadOnly = true;
            btnFindLicense.Enabled = false;
            btnReset.Enabled = false;
        }
        public void Reset()
        {
            License = null;

            CtrlLicenseCard.LoadLicenseInfo(License);
            ResetInfoInParent?.Invoke();

            txtBoxFilter.Clear();
        }

        public bool LoadLicenseInfo(clsLicense License)
        {
            if (License == null)
            {
                Reset();
                return false;
            }

            this.License = License;

            CtrlLicenseCard.LoadLicenseInfo(License);
            LoadInfoInParent?.Invoke(); // loads info in parent container 
                                        // loads licenseID, fees... 

            return true;
        }
        void Find()
        {
            if (CmbBoxFilter.SelectedIndex == 0)
            {
                License = (!string.IsNullOrEmpty(txtBoxFilter.Text.Trim()))
                          ? clsLicense.Find(Convert.ToInt16(txtBoxFilter.Text.Trim()))
                          : null;
            }

            else
            {
                License = (!string.IsNullOrEmpty(txtBoxFilter.Text.Trim()))
                          ? clsLicense.Find(txtBoxFilter.Text.Trim())
                          : null;
            }

            if (License == null) clsFormsUtility.MsgBoxError($"License with LicenseID {txtBoxFilter.Text} was not found.", "Not Found");
            
            LoadLicenseInfo(License);
        }

        public ctrlLicenseCardWithFilter()
        {
            InitializeComponent();

            CmbBoxFilter.SelectedIndex = CmbBoxFilter.FindString("SerialNumber");
        }


        void txtBoxFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                Find();
                return;
            }

            clsFormsUtility.txtBox_KeyPress(sender, e, _InputType);
        }
        void btnReset_Click(object sender, EventArgs e) => Reset();

        void btnFindLicense_Click(object sender, EventArgs e) => Find();

        void CmbBoxFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtBoxFilter.Clear();

            switch (CmbBoxFilter.SelectedIndex)
            {
                // if licenseID
                case 0:
                    _InputType = clsFormsUtility.enInputType.Numbers;
                    break;

                // if serialnumber
                case 1:
                    _InputType = clsFormsUtility.enInputType.All;
                    break;

                default:
                    break;
            }
        }
    }
}
