﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ensueno.Presentation.Main
{
    public partial class Form_invoice_create : Form
    {
        public Form_invoice_create()
        {
            InitializeComponent();
            Apply_dark_mode();
            this.Select();
            Button_yes.Select();
        }
        private void Apply_dark_mode()
        {
            if (Properties.Settings.Default.dark_mode)
            {
                this.BackColor = Color.FromArgb(31, 31, 31);
            }
            else
            {
                this.BackColor = Color.FromArgb(238, 238, 238);
            }
        }

        private void Button_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_yes_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception) { }
        }

        private void Form_invoice_create_Load(object sender, EventArgs e)
        {

        }
    }
}
