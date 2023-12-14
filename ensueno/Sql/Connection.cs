using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ensueno.Sql
{
    public class Connection
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

        public static SqlConnection Get_connection()
        {
            return Properties.Settings.Default.connection;
        }
    }
}
