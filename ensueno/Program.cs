using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aplicacion.Initial;
using ensueno.Presentation.Login;
using ensueno.Presentation.Main;
using Microsoft.EntityFrameworkCore;
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
