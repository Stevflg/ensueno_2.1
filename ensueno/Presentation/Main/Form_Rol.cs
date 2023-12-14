using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ensueno.Presentation.Main
{
    public partial class Form_Rol : Form
    {
        public Form_Rol(Color color)
        {
            InitializeComponent();
            SetComboBoxHeight();
            this.BackColor = color;
        }

        private void Form_Rol_Load(object sender, EventArgs e)
        {

        }

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

        private void comboBoxForms_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SetComboBoxHeight();
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
                SetComboBoxHeight();
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


    }
}
