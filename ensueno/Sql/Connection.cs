using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ensueno.Sql
{
    internal class Connection
    {        
        public bool Connect()
        {
            try
            {
                if (Properties.Settings.Default.connection.State == ConnectionState.Closed)
                {
                    Properties.Settings.Default.connection.Open();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        public void Disconnect()
        {
            try
            {
                if (Properties.Settings.Default.connection.State == ConnectionState.Open)
                {
                    Properties.Settings.Default.connection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public SqlConnection Get_connection()
        {
            return Properties.Settings.Default.connection;
        }
    }
}
