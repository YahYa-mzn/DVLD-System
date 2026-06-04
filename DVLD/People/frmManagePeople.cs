
// Form: Displays and manages all people in the system
// Allows viewing, adding, editing, deleting, and recovering person records
// Supports filtering by different columns and viewing Active/Deleted/All records

using System;
using System.Data;
using System.Windows.Forms;
using DVLD.People;
using DVLD_BLL;
using DVLD.Global_Classes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace DVLD
{
    public partial class frmManagePeople : Form
    {
        // Tags for button identification
        enum enBtn
        {
            AddNew = 1,
            Cancel = 2
        }

        // Context menu items for the data grid view
        enum enCMSItems
        {
            ShowDetails = 1,
            Edit = 2,
            Recover = 4,
            Email = 5,
            Phone = 6
        }

        clsPerson.enReadMode _ReadMode { get; set; } = clsPerson.enReadMode.Active;

        clsPerson.enFilterColumn _FilterColumn { get; set; } = clsPerson.enFilterColumn.None;

        clsFormsUtility.enInputType _InputType { get; set; }

        void AddRowToPeopleList(DataRow Row)
        {
            DGVPeople.Rows.Add
                (
                     Row["PersonID"].ToString(),
                     Row["NationalNo"].ToString(),
                     Row["FirstName"].ToString(),
                     Row["SecondName"].ToString(),
                     Row["ThirdName"].ToString(),
                     Row["LastName"].ToString(),
                     Row["Gender"].ToString(),
                     Convert.ToDateTime(Row["BirthDate"]).ToString("d"),
                     Row["Phone"].ToString(),
                     Row["Email"].ToString(),
                     Row["Nationality"].ToString(),
                     Row["Address"].ToString()
                );
        }
        async void RefreshPeopleList()
        {
            DGVPeople.Rows.Clear();
            DataTable DTPeople = new DataTable();

            // Get filtered or all people based on search text
            DTPeople = clsPerson.GetPeopleList(_ReadMode, _FilterColumn, txtBoxFilter.Text.Trim());

            await Task.Delay(30);

            // Add each person to the grid
            foreach (DataRow Row in DTPeople.Rows)
                AddRowToPeopleList(Row);

            // Update record counts
            lblSystemRecords.Text = clsPerson.GetSystemRecordsNumber(_ReadMode).ToString();
            lblRecords.Text = DTPeople.Rows.Count.ToString();
        }

        public frmManagePeople()
        {
            InitializeComponent();

            clsFormsUtility.SetDGVHeaderColor(DGVPeople, System.Drawing.Color.FromArgb(26, 45, 80));

            // Set default values - this triggers the refresh
            CmbBoxReadMode.SelectedIndex = Convert.ToInt32(_ReadMode);
            CmbBoxFilterBy.SelectedIndex = Convert.ToInt32(_FilterColumn);
        }


        void AddNewPersonForm()
        {
            frmAddNewPerson frm = new frmAddNewPerson();
            frm.ShowDialog();
        }

        void ShowPersonDetailsForm(clsPerson Person)
        {
            if (Person == null) return;

            frmPersonInfo frm = new frmPersonInfo(Person);
            frm.ShowDialog();
        }
        void EditPersonForm(clsPerson Person)
        {
            if (Person == null) return;
            if (Person.IsDeleted())
            {
                clsFormsUtility.MsgBoxError("Cannot edit a deleted person deleted.", "Not Allowed");
                return;
            }

            // If editing current user's person, use the current user's person object
            if (clsGlobal.CurrentUser.Person.IsSameAs(Person))
                Person = clsGlobal.CurrentUser.Person;

            frmEditPersonInfo frm = new frmEditPersonInfo(Person);
            frm.ShowDialog();
        }

        void MoveToTrash(clsPerson Person)
        {
            if (Person == null) return;

            if (Person.IsDeleted())
            {
                clsFormsUtility.MsgBoxError("The Person is already in the trash list.", "Not Allowed");
                return;
            }

            // Check if person has related data (users, licenses, etc.)
            if (!Person.CanDelete())
            {
                clsFormsUtility.MsgBoxError("Cannot move to trash this Person due to a connected data to it.", "Not Allowed");
                return;
            }

            if (!clsFormsUtility.MsgBoxConfirm("Are you sure do you want to move to trash this Person?")) return;

            
            Person.PrepareObjectToDelete(clsPerson.enDeletionType.SoftDelete);
            if (Person.Delete())
            {
                clsFormsUtility.MsgBoxActionSucceeded("moved to Trash", $"Person");
            }
            else
            {
                clsFormsUtility.MsgBoxActionFailed("moving to Trash", $"Person");
            }     
        }
        void DeletePermanently(clsPerson Person)
        {
            if (Person == null) return;

            // Check if person has related data
            if (!Person.CanDelete())
            {
                clsFormsUtility.MsgBoxError("Cannot delete this Person due to a connected data to it.", "Not Allowed");
                return;
            }

            if (!clsFormsUtility.MsgBoxConfirm("The Record will be deleted Permanently from the System \t\n" +
                                               "Are you sure you want to delete this Person?"))
                return;

            
            string ImagePath = Person.ImagePath;
            Person.PrepareObjectToDelete(clsPerson.enDeletionType.PermanentDelete);

            if (Person.Delete())
            {
                // Delete person image from disk
                clsFile.DeleteFile(ImagePath);
                clsFormsUtility.MsgBoxActionSucceeded("Deleted", $"Person");
            }
            else
            {
                clsFormsUtility.MsgBoxActionFailed("Deletion", $"Person");
            }
            
        }
        void Recover(clsPerson Person)
        {
            if (Person == null) return;

            if (!Person.IsDeleted())
            {
                clsFormsUtility.MsgBoxError("The Person is not in the trash list.", "Not Allowed");
                return;
            }
            if (!clsFormsUtility.MsgBoxConfirm("Are you sure do you want to recover this Person?")) return;
            
            if (Person.Recover())
            {
                clsFormsUtility.MsgBoxActionSucceeded("Recovered", $"Person");
            }
            else
            {
                clsFormsUtility.MsgBoxActionFailed("Recovering", $"Person");
            }
        }

        // Placeholder for sending email
        void SendEmail()
        {
            clsFormsUtility.MsgBoxStub();
        }

        // Placeholder for phone call
        void PhoneCall()
        {
            clsFormsUtility.MsgBoxStub();
        }


        void Btn_Click(object sender, EventArgs e)
        {
            // Handles Add New and Cancel button clicks

            enBtn enumTag = clsFormsUtility.GetEnumType<enBtn>(sender);

            switch (enumTag)
            {
                case enBtn.AddNew:
                    AddNewPersonForm();
                    RefreshPeopleList();
                    break;

                case enBtn.Cancel:
                    this.Close();
                    break;

                default:
                    break;
            }
        }

        // Shows context menu when right-clicking a row
        void DGVPeople_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
            {
                DGVPeople.ClearSelection();
                DGVPeople.Rows[e.RowIndex].Selected = true;

                DGVPeople.Tag = e.RowIndex;

                CMSPerson.Show(Cursor.Position);
            }
        }

        // Gets PersonID from the selected row
        clsPerson GetPersonFromSelectedPerson()
        {
            if (DGVPeople.SelectedCells.Count >= 1)
            {
                DataGridViewRow row = DGVPeople.SelectedCells[0].OwningRow;
                int PersonID = Convert.ToInt32(row.Cells["colPersonID"].Value);
                return clsPerson.Find(PersonID);
            }

            return null;
        }

        // Handles context menu item clicks
        void CMSPerson_Click(object sender, EventArgs e)
        {
            enCMSItems enumTag = clsFormsUtility.GetEnumType_TSMI<enCMSItems>(sender);
            clsPerson Person = GetPersonFromSelectedPerson();

            switch (enumTag)
            {
                case enCMSItems.ShowDetails:
                    ShowPersonDetailsForm(Person);
                    break;

                case enCMSItems.Edit:
                    EditPersonForm(Person);
                    break;

                case enCMSItems.Recover:
                    Recover(Person);
                    break;

                case enCMSItems.Email:
                    SendEmail();
                    break;

                case enCMSItems.Phone:
                    PhoneCall();
                    break;

                default:
                    break;
            }

            RefreshPeopleList();
        }

        // Handles delete menu items (Move to Trash or Permanent Delete)
        void CMSPersonDelete_Click(object sender, EventArgs e)
        {
            clsPerson.enDeletionType enumTag = clsFormsUtility.GetEnumType_TSMI<clsPerson.enDeletionType>(sender);
            clsPerson Person = GetPersonFromSelectedPerson();

            switch (enumTag)
            {
                case clsPerson.enDeletionType.SoftDelete:
                    MoveToTrash(Person);
                    break;

                case clsPerson.enDeletionType.PermanentDelete:
                    DeletePermanently(Person);
                    break;

                default:
                    break;
            }

            RefreshPeopleList();
        }


        // Changes filter column and sets input type for validation
        void CmbBoxFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterColumn = (clsPerson.enFilterColumn)CmbBoxFilterBy.SelectedIndex;

            txtBoxFilter.Clear();

            switch (_FilterColumn)
            {
                case clsPerson.enFilterColumn.None:
                    txtBoxFilter.Enabled = false;
                    _InputType = clsFormsUtility.enInputType.None;
                    return;

                case clsPerson.enFilterColumn.PersonID:
                case clsPerson.enFilterColumn.Phone:
                    _InputType = clsFormsUtility.enInputType.Numbers;
                    break;

                case clsPerson.enFilterColumn.NationalNo:
                    _InputType = clsFormsUtility.enInputType.LettersAndNumbers;
                    break;

                case clsPerson.enFilterColumn.FirstName:
                case clsPerson.enFilterColumn.SecondName:
                case clsPerson.enFilterColumn.ThirdName:
                case clsPerson.enFilterColumn.LastName:
                    _InputType = clsFormsUtility.enInputType.Letters;
                    break;

                case clsPerson.enFilterColumn.Email:
                    _InputType = clsFormsUtility.enInputType.Email;
                    break;

                default:
                    _InputType = clsFormsUtility.enInputType.None;
                    break;
            }

            txtBoxFilter.Enabled = true;
            RefreshPeopleList();
        }

        // Changes read mode and updates UI accordingly
        void CmbBoxReadMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            _ReadMode = (clsPerson.enReadMode)CmbBoxReadMode.SelectedIndex;

            switch (_ReadMode)
            {
                case clsPerson.enReadMode.Active:
                    lblSystemRecordstxt.Text = "   # Active Records: ";
                    TSMIEdit.Enabled = true;
                    TSMIDelete_MoveToTrash.Enabled = true;
                    TSMIRecover.Enabled = false;
                    break;

                case clsPerson.enReadMode.All:
                    lblSystemRecordstxt.Text = "         # All Records: ";
                    TSMIEdit.Enabled = true;
                    TSMIDelete_MoveToTrash.Enabled = true;
                    TSMIRecover.Enabled = true;
                    break;

                case clsPerson.enReadMode.Deleted:
                    lblSystemRecordstxt.Text = "# Deleted Records: ";
                    TSMIEdit.Enabled = false;
                    TSMIDelete_MoveToTrash.Enabled = false;
                    TSMIRecover.Enabled = true;
                    break;

                default:
                    break;
            }

            RefreshPeopleList();
        }

        void TxtBox_TextChanged(object sender, EventArgs e) => RefreshPeopleList(); 

        // Prevents invalid characters based on current filter column
        void TxtBox_KeyPress(object sender, KeyPressEventArgs e) => clsFormsUtility.txtBox_KeyPress(sender, e, _InputType);
        void PicBoxRefresh_Click(object sender, EventArgs e) => RefreshPeopleList();


        // Permissions checking !
        private void frmManagePeople_Load(object sender, EventArgs e)
        {
            if (!clsGlobal.HasPermissions(clsUser.enPermissions.PeopleManagement)) this.Close();
        }
    }
}