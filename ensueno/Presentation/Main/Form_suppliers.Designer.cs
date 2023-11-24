namespace ensueno.Presentation.Main
{
    partial class Form_suppliers
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
            components = new System.ComponentModel.Container();
            guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(components);
            LabelTest = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // guna2BorderlessForm1
            // 
            guna2BorderlessForm1.ContainerControl = this;
            guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            guna2BorderlessForm1.HasFormShadow = false;
            guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // LabelTest
            // 
            LabelTest.AutoSize = true;
            LabelTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            LabelTest.ForeColor = System.Drawing.SystemColors.GrayText;
            LabelTest.Location = new System.Drawing.Point(187, 110);
            LabelTest.Name = "LabelTest";
            LabelTest.Size = new System.Drawing.Size(267, 24);
            LabelTest.TabIndex = 1;
            LabelTest.Text = "Etiqueta de Prueba (Suppliers)";
            // 
            // Form_suppliers
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(992, 577);
            Controls.Add(LabelTest);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Name = "Form_suppliers";
            Text = "Form_suppliers";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label LabelTest;
    }
}