// Class: Forms Utility Functions
// Provides common UI functionality:
//   - Input validation and key press filtering
//   - Enum extraction from control tags
//   - Standardized message boxes for common scenarios
// Used across all forms for consistent user experience

using System;
using System.Drawing;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;


namespace DVLD.Global_Classes
{
    internal static class clsFormsUtility
    {
        // Input types for text box validation
        public enum enInputType
        {
            None = 0,
            Numbers = 1,
            Letters = 2,
            LettersAndSpaces = 3,
            LettersAndNumbers = 4,
            All = 5,
            Email = 6
        }

        // Changing the data gride view header (titles) color !
        public static void SetDGVHeaderColor(DataGridView dgv, Color backColor)
        {
            if (dgv == null)
                return;

            dgv.EnableHeadersVisualStyles = false;

            // ===== Headers Styling =====
            dgv.ColumnHeadersDefaultCellStyle.BackColor = backColor;
            dgv.ColumnHeadersDefaultCellStyle.SelectionBackColor = backColor;

            dgv.ColumnHeadersDefaultCellStyle.ForeColor = SystemColors.ControlLightLight;
            dgv.ColumnHeadersDefaultCellStyle.SelectionForeColor = SystemColors.ControlLightLight;

            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
   
            dgv.ColumnHeadersHeight = 36; // Slightly taller headers

            // ===== Rows Styling =====
            dgv.DefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Regular);
            dgv.DefaultCellStyle.ForeColor = Color.Black;
            dgv.DefaultCellStyle.SelectionForeColor = Color.FromArgb(26, 45, 80);

            dgv.RowTemplate.Height = 30; // Slightly taller rows
        }


        // Filters key presses based on input type
        public static void txtBox_KeyPress(object sender, KeyPressEventArgs e, enInputType InputType)
        {
            switch (InputType)
            {
                case enInputType.None:
                    e.Handled = true;
                    break;

                case enInputType.All:
                    e.Handled = false;
                    break;

                case enInputType.Numbers:
                    e.Handled = !char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Back);
                    break;

                case enInputType.Letters:
                    e.Handled = !char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back);
                    break;

                case enInputType.LettersAndSpaces:
                    e.Handled = !char.IsLetter(e.KeyChar) && !(e.KeyChar == (char)Keys.Back) && !(e.KeyChar == (char)Keys.Space);
                    break;

                case enInputType.LettersAndNumbers:
                    e.Handled = !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == (char)Keys.Back);
                    break;

                case enInputType.Email:
                    e.Handled = !Regex.IsMatch(e.KeyChar.ToString(), @"[a-zA-Z0-9@._\-+]") && !(e.KeyChar == (char)Keys.Back);
                    break;

                default:
                    break;
            }
        }


        // Gets enum value from ToolStripMenuItem tag
        public static T GetEnumType_TSMI<T>(object sender)
        {
            ToolStripMenuItem TSMI = (ToolStripMenuItem)sender;
            int TSMITag = (Convert.ToInt32(TSMI.Tag));

            return (T)(Enum.ToObject(typeof(T), TSMITag));
        }

        // Gets enum value from Control tag
        public static T GetEnumType<T>(object sender)
        {
            Control Ctrl = (Control)sender;
            int CtrlTag = (Convert.ToInt32(Ctrl.Tag));

            return (T)Enum.ToObject(typeof(T), CtrlTag);
        }


        // Standardized message boxes
        public static void MsgBoxStub(string FeatureName = "Stub")
        {
            MessageBox.Show("This feature is not implemented yet.   ", FeatureName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static void MsgBoxInfo(string Body, string Title)
        {
            MessageBox.Show($"{Body}   ", Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void MsgBoxError(string Body, string Title)
        {
            MessageBox.Show($"{Body}   ", Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void MsgBoxExclamation(string Body, string Title)
        {
            MessageBox.Show($"{Body}   ", Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        public static bool MsgBoxConfirm(string Body)
        {
            return MessageBox.Show(
                Body,
                "Confirm",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question) == DialogResult.Yes;
        }

        public static void MsgBoxActionSucceeded(string Action, string RecordName = "Record")
        {
            MessageBox.Show(
                $"The {RecordName} has been {Action} Successfully.",
                "Successful",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        public static void MsgBoxActionFailed(string Action, string RecordName = "Record")
        {
            MessageBox.Show(
                $"The {Action} could not be Completed.\n" +
                $"The {RecordName} may no longer exist or {Action} failed.",
                "Failed",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}