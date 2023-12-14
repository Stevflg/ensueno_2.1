using System;
using System.Windows.Forms;
using Aplicacion.Initial;
using ensueno.Presentation.Login;
using Persistencia.Context;

namespace ensueno
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        /// 

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
            var context =new EnsuenoContext();
            context.Database.EnsureCreated();
            AddData adt = new AddData();
            if(adt.validarDb()) MessageBox.Show(adt.CargarDatos(), "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Run(new Form_login());
        }
    }
}
