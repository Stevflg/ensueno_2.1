using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ensueno.Sql.Stored_procedures
{
    internal class Employees : Connection
    {
        private SqlCommand command;
        private SqlDataAdapter data_adapter;
        private DataTable data_table;
        private DataRow data_row;
        public DataTable Read()
        {

            try
            {
                Connect();
                command = new SqlCommand("exec employees_read")
                {
                    Connection = Get_connection()
                };
                data_adapter = new SqlDataAdapter(command);
                data_table = new DataTable();
                data_adapter.Fill(data_table);
                return data_table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Disconnect();
            }
        }
        public DataTable Read_history()
        {
            try
            {
                Connect();
                command = new SqlCommand("exec employees_read_history")
                {
                    Connection = Get_connection()
                };
                data_adapter = new SqlDataAdapter(command);
                data_table = new DataTable();
                data_adapter.Fill(data_table);
                return data_table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Disconnect();
            }
        }
        public DataTable Read_by_name(string name)
        {

            try
            {
                Connect();
                command = new SqlCommand($"exec employees_read_by_name '{name}'")
                {
                    Connection = Get_connection()
                };
                data_adapter = new SqlDataAdapter(command);
                data_table = new DataTable();
                data_adapter.Fill(data_table);
                return data_table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Disconnect();
            }
        }
        public DataTable Read_by_last_name(string last_name)
        {

            try
            {
                Connect();
                command = new SqlCommand($"exec employees_read_by_last_name '{last_name}'")
                {
                    Connection = Get_connection()
                };
                data_adapter = new SqlDataAdapter(command);
                data_table = new DataTable();
                data_adapter.Fill(data_table);
                return data_table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Disconnect();
            }
        }        
        public DataTable Validate_id_card(string id_card)
        {

            try
            {
                Connect();
                command = new SqlCommand($"exec employees_validate_id_card '{id_card}'")
                {
                    Connection = Get_connection()
                };
                data_adapter = new SqlDataAdapter(command);
                data_table = new DataTable();
                data_adapter.Fill(data_table);
                return data_table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Disconnect();
            }
        }
        public DataTable Validate_update_id_card(int id, string id_card)
        {

            try
            {
                Connect();
                command = new SqlCommand($"exec employees_validate_update_id_card {id},'{id_card}'")
                {
                    Connection = Get_connection()
                };
                data_adapter = new SqlDataAdapter(command);
                data_table = new DataTable();
                data_adapter.Fill(data_table);
                return data_table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Disconnect();
            }
        }
        public DataTable Clients_validate_id_card(string id_card)
        {

            try
            {
                Connect();
                command = new SqlCommand($"exec clients_validate_id_card '{id_card}'")
                {
                    Connection = Get_connection()
                };
                data_adapter = new SqlDataAdapter(command);
                data_table = new DataTable();
                data_adapter.Fill(data_table);
                return data_table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Disconnect();
            }
        }
        public DataTable Validate_user(string user)
        {

            try
            {
                Connect();
                command = new SqlCommand($"exec employee_validate_user '{user}'")
                {
                    Connection = Get_connection()
                };
                data_adapter = new SqlDataAdapter(command);
                data_table = new DataTable();
                data_adapter.Fill(data_table);
                return data_table;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Disconnect();
            }
        }                        
        public DataRow Validate_user_login(string user)
        {
            try
            {
                Connect();
                command = new SqlCommand($"exec employee_validate_user '{user}'")
                {
                    Connection = Get_connection()
                };
                data_table = new DataTable();
                data_adapter = new SqlDataAdapter(command);
                data_adapter.Fill(data_table);
                data_row = data_table.Rows[0];
                return data_row;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                Disconnect();
            }
        }
        public bool Create(string id_card, string name, string last_name, string phone, string address, string user, string password, bool admin)
        {
            try
            {
                Connect();
                command = new SqlCommand($"exec employee_create '{id_card}','{name}','{last_name}','{phone}','{address}','{user}',{admin}")
                {
                    Connection = Get_connection()
                };
                command.ExecuteNonQuery();
                command = new SqlCommand($"create login {user} with password = '{password}'")
                {
                    Connection = Get_connection()
                };
                command.ExecuteNonQuery();
                command = new SqlCommand($"exec [sys].[sp_addsrvrolemember] {user}, 'sysadmin'")
                {
                    Connection = Get_connection()
                };
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Disconnect();
            }
        }

        public bool Update(int id, string id_card, string name, string last_name, string phone, string address, string user, string password, bool admin)
        {
            try
            {
                Connect();                
                command = new SqlCommand($"alter login {user} with password = '{password}'")
                {
                    Connection = Get_connection()
                };
                command.ExecuteNonQuery();                
                command = new SqlCommand($"exec employee_update {id},'{id_card}','{name}','{last_name}','{phone}','{address}',{admin}")
                {
                    Connection = Get_connection()
                };
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Disconnect();
            }
        }
        public bool Delete(int id, string user)
        {
            try
            {
                Connect();
                command = new SqlCommand($"exec employee_deactivate {id}")
                {
                    Connection = Get_connection()
                };
                command.ExecuteNonQuery();
                command = new SqlCommand($"alter login {user} disable")
                {
                    Connection = Get_connection()
                };
                command.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Disconnect();
            }
        }
        public bool Restore(int id, string user, string password)
        {
            try
            {
                Connect();
                command = new SqlCommand($"alter login {user} enable")
                {
                    Connection = Get_connection()
                };
                command.ExecuteNonQuery();
                command = new SqlCommand($"alter login {user} with password = '{password}'")
                {
                    Connection = Get_connection()
                };
                command.ExecuteNonQuery();
                command = new SqlCommand($"exec employee_activate {id}")
                {
                    Connection = Get_connection()
                };
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                Disconnect();
            }
        }
    }
}
