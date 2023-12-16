using Aplicacion.ProceduresDB;
using Dominio.Database;
using Dominio.DTO;
using ensueno.Presentation.Validations;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ensueno.Presentation.Main
{
    public partial class Form_Rol : Form
    {
        private Username UserSessions;
        public Form_Rol(Color color, Username UserSessios)
        {
            InitializeComponent();
            SetComboBoxHeight();
            this.UserSessions = UserSessios;
            this.BackColor = color;
        }

        private async void Form_Rol_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private async void loadData()
        {
            await Task.Run(() => { ReadRol(); });
            ReadProcedures();
            ReadForm();
            AutocompleteForms();
            AutocompleteProcedures();
        }

        #region Datagrids y Combobox

        #region Combobox
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);
        private const Int32 CB_SETITEMHEIGHT = 0x153;

        private void SetComboBoxHeight()
        {
            SendMessage(comboBoxForms.Handle, CB_SETITEMHEIGHT, -1, 21);
            comboBoxForms.Refresh();
            SendMessage(ComboBoxPermissions.Handle, CB_SETITEMHEIGHT, -1, 21);
            ComboBoxPermissions.Refresh();
        }

        private int formId;
        private async void AutocompleteForms()
        {
            try
            {
                var ListForms = await ProcRolesFormP.ListComboBoxForms();
                this.Invoke(new Action(() =>
                {
                    comboBoxForms.DataSource = ListForms;
                    comboBoxForms.ValueMember = "FormId";
                    comboBoxForms.DisplayMember = "AliasForm";

                    AutoCompleteStringCollection lst = new AutoCompleteStringCollection();
                    for (int i = 0; i < ListForms.Count; i++)
                    {
                        lst.Add(ListForms[i].AliasForm);
                    }
                    comboBoxForms.AutoCompleteCustomSource = lst;
                    comboBoxForms.AutoCompleteMode = AutoCompleteMode.Suggest;
                    comboBoxForms.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    SetComboBoxHeight();
                }));
            }
            catch { }
        }

        private int procedureId;
        private async void AutocompleteProcedures()
        {
            try
            {
                var List = await ProcRolesFormP.ListComboBoxPermisions();
                this.Invoke(new Action(() =>
                {
                    ComboBoxPermissions.DataSource = List;
                    ComboBoxPermissions.ValueMember = "ProcedureId";
                    ComboBoxPermissions.DisplayMember = "ProcedureName";

                    AutoCompleteStringCollection lst = new AutoCompleteStringCollection();
                    for (int i = 0; i < List.Count; i++)
                    {
                        lst.Add(List[i].ProcedureName);
                    }
                    ComboBoxPermissions.AutoCompleteCustomSource = lst;
                    ComboBoxPermissions.AutoCompleteMode = AutoCompleteMode.Suggest;
                    ComboBoxPermissions.AutoCompleteSource = AutoCompleteSource.CustomSource;
                    SetComboBoxHeight();
                }));
            }
            catch { }
        }


        private void comboBoxForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearForm();
                SetComboBoxHeight();
                formId = int.Parse(comboBoxForms.SelectedValue.ToString());
            }
            catch { }
        }

        private void comboBoxForms_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetComboBoxHeight();
            }
            catch { }
        }

        private void ComboBoxPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ClearProcedure();
                SetComboBoxHeight();
                procedureId = int.Parse(ComboBoxPermissions.SelectedValue.ToString());
            }
            catch { }
        }

        private void ComboBoxPermissions_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SetComboBoxHeight();
            }
            catch { }
        }


        #endregion

        #region Datagrids
        private int rolId;
        private void DataGridView_Rols_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DataGridView_Rols.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    ClearTextBoxesRol();
                }
                else
                {

                    TextBox_Id.Text = DataGridView_Rols.Rows[e.RowIndex].Cells[0].Value.ToString();
                    rolId = int.Parse(DataGridView_Rols.Rows[e.RowIndex].Cells[0].Value.ToString());
                    TextBox_Name.Text = DataGridView_Rols.Rows[e.RowIndex].Cells[1].Value.ToString();
                    ReadForm();
                    ReadProcedures();
                    EnabledButtonsRols(true);
                }
            }
            catch (Exception ex)
            {
                ClearTextBoxesRol();
            }
        }

        private void DataGridViewForms_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DataGridViewForms.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    ClearForm();
                }
                else
                {
                    formId = int.Parse(DataGridViewForms.Rows[e.RowIndex].Cells[0].Value.ToString());
                    EnabledButtonsForms(true);
                }
            }
            catch (Exception ex)
            {
                ClearForm();
            }
        }

        private void DataGridViewPermissions_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(DataGridViewPermissions.Rows[e.RowIndex].Cells[0].Value.ToString()))
                {
                    ClearProcedure();
                }
                else
                {
                    procedureId = int.Parse(DataGridViewPermissions.Rows[e.RowIndex].Cells[0].Value.ToString());
                    EnabledButtonsProcedure(true);
                }
            }
            catch (Exception ex)
            {
                ClearProcedure();
            }
        }
        private void ClearTextBoxesRol()
        {
            TextBox_Id.Clear();
            TextBox_Name.Clear();
            EnabledButtonsRols(false);
            rolId = 0;
            ReadForm();
            ReadProcedures();
        }

        private void ClearForm()
        {
            comboBoxForms.Text = "";
            formId = 0;
            EnabledButtonsForms(false);
        }
        private void ClearProcedure()
        {
            ComboBoxPermissions.Text = "";
            procedureId = 0;
            EnabledButtonsProcedure(false);
        }
        private void EnabledButtonsRols(bool state)
        {
            Button_create.Enabled = !state;
            Button_update.Enabled = state;
            ButtonEnabled.Enabled = state;
            Button_disable.Enabled = state;
        }

        private void EnabledButtonsForms(bool state)
        {
            ButtonCreatef.Enabled = !state;
            ButtonDisablef.Enabled = state;
            ButtonEnablef.Enabled = state;
        }

        private void EnabledButtonsProcedure(bool state)
        {
            ButtonCreatep.Enabled = !state;
            Buttondisablep.Enabled = state;
            ButtonEnablep.Enabled = state;
        }

        #endregion


        #endregion

        #region Metodos
        //roles
        private async void ReadRol()
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    pictureBoxRol.Visible = true;
                }));
                var result = await ProcRolesFormP.ListRol();
                rolId = result.First().Id;
                this.Invoke(new Action(() =>
                {
                    rolId = result.First().Id;
                    DataGridView_Rols.DataSource = result;
                    pictureBoxRol.Visible = false;
                }));
            }
            catch { }
        }

        private async void AddRol()
        {
            if (!string.IsNullOrEmpty(TextBox_Name.Text))
            {
                var result = await ProcRolesFormP.AddRol(new Rol
                {
                    RolName = TextBox_Name.Text,
                    CreatedBy = UserSessions.EmployeeId,
                });

                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxesRol();
                    ReadRol();
                }));
            }
            else
            {
                Values val = new Values();
                val.empty_text(TextBox_Name);
            }
        }

        private async void UpdateRol()
        {
            if (!string.IsNullOrEmpty(TextBox_Name.Text))
            {
                var result = await ProcRolesFormP.UpdateRol(new Rol
                {
                    RolId = rolId,
                    RolName = TextBox_Name.Text,
                    UpdatedBy = UserSessions.EmployeeId,
                });

                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxesRol();
                    ReadRol();
                }));
            }
            else
            {
                Values val = new Values();
                val.empty_text(TextBox_Name);
            }
        }

        private async void DisableRol()
        {
            if (rolId != 0)
            {
                var result = await ProcRolesFormP.DisableRol(new Rol
                {
                    RolId = rolId,
                    UpdatedBy = UserSessions.EmployeeId
                });
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxesRol();
                    ReadRol();
                }));
            }
        }

        private async void EnableRol()
        {
            if (rolId != 0)
            {
                var result = await ProcRolesFormP.EnableRol(new Rol
                {
                    RolId = rolId,
                    UpdatedBy = UserSessions.EmployeeId
                });
                this.Invoke(new Action(() =>
                {
                    MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearTextBoxesRol();
                    ReadRol();
                }));
            }
        }

        //Formularios
        private async void ReadForm()
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    pictureBoxForms.Visible = true;
                }));
                var result = await ProcRolesFormP.ListFormRol(new Rol { RolId = rolId });
                this.Invoke(new Action(() =>
                {
                    DataGridViewForms.DataSource = result;
                    pictureBoxForms.Visible = false;
                }));
            }
            catch { }
        }

        private async void AddForm()
        {
            try
            {
                if (formId != 0 && rolId != 0)
                {
                    var result = await ProcRolesFormP.AddFormRol(new FormRol
                    {
                        FormId = formId,
                        RolId = rolId,
                        CreatedBy = UserSessions.EmployeeId
                    });
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        ReadForm();
                    }));
                }
            }
            catch { }
        }

        private async void DisableForm()
        {
            try
            {
                if (formId != 0 && rolId != 0)
                {
                    var result = await ProcRolesFormP.DisableFormRol(new FormRol
                    {
                        FormId = formId,
                        RolId = rolId,
                        UpdatedBy = UserSessions.EmployeeId
                    });
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        ReadForm();
                    }));
                }
            }
            catch { }
        }

        private async void EnableForm()
        {
            try
            {
                if (formId != 0 && rolId != 0)
                {
                    var result = await ProcRolesFormP.EnableFormRol(new FormRol
                    {
                        FormId = formId,
                        RolId = rolId,
                        UpdatedBy = UserSessions.EmployeeId
                    });
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();
                        ReadForm();
                    }));
                }
            }
            catch { }
        }

        //  Permisos
        private async void ReadProcedures()
        {
            try
            {
                this.Invoke(new Action(() =>
                {
                    pictureBoxProcedure.Visible = true;
                }));
                var result = await ProcRolesFormP.ListProcRol
                    (new Rol { RolId = rolId });
                this.Invoke(new Action(() =>
                {
                    DataGridViewPermissions.DataSource = result;
                    pictureBoxProcedure.Visible = false;
                }));
            }
            catch { }
        }

        private async void AddProcedures()
        {
            try
            {
                if (procedureId != 0 && rolId != 0)
                {
                    var result = await ProcRolesFormP.AddProcedureRol(new ProcedureRols
                    {
                        ProcedureId = procedureId,
                        RolId = rolId,
                        CreatedBy = UserSessions.EmployeeId
                    });
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearProcedure();
                        ReadProcedures();
                    }));
                }
            }
            catch { }
        }

        private async void DisableProcedures()
        {
            try
            {
                if (procedureId != 0 && rolId != 0)
                {
                    var result = await ProcRolesFormP.DisableProcedureRol(new ProcedureRols
                    {
                        ProcedureId = formId,
                        RolId = rolId,
                        UpdatedBy = UserSessions.EmployeeId
                    });
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearProcedure();
                        ReadProcedures();
                    }));
                }
            }
            catch { }
        }

        private async void EnableProcedures()
        {
            try
            {
                if (procedureId != 0 && rolId != 0)
                {
                    var result = await ProcRolesFormP.EnableProcedureRol(new ProcedureRols
                    {
                        ProcedureId = formId,
                        RolId = rolId,
                        UpdatedBy = UserSessions.EmployeeId
                    });
                    this.Invoke(new Action(() =>
                    {
                        MessageBox.Show(result, "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearProcedure();
                        ReadProcedures();
                    }));
                }
            }
            catch { }
        }
        #endregion

        #region Events
        private void Button_clear_Click(object sender, EventArgs e)
        {
            ClearTextBoxesRol();
        }

        private void Button_create_Click(object sender, EventArgs e)
        {
            AddRol();
        }

        private void Button_update_Click(object sender, EventArgs e)
        {
            UpdateRol();
        }

        private void ButtonEnabled_Click(object sender, EventArgs e)
        {
            EnableRol();
        }

        private void Button_disable_Click(object sender, EventArgs e)
        {
            DisableRol();
        }

        private void ButtonCreatef_Click(object sender, EventArgs e)
        {
            AddForm();
        }

        private void ButtonDisablef_Click(object sender, EventArgs e)
        {
            DisableForm();
        }

        private void ButtonEnablef_Click(object sender, EventArgs e)
        {
            EnableForm();
        }

        private void ButtonCreatep_Click(object sender, EventArgs e)
        {
            AddProcedures();
        }

        private void Buttondisablep_Click(object sender, EventArgs e)
        {
            DisableProcedures();
        }

        private void ButtonEnablep_Click(object sender, EventArgs e)
        {
            EnableProcedures();
        }
        #endregion
    }
}
