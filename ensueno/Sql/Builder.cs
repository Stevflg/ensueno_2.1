﻿using System.Data.SqlClient;

namespace ensueno.Sql
{
    internal class Builder
    {
        private readonly SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        public void Build(string user, string password)
        {
            //builder.DataSource = Properties.Settings.Default.data_source;
            //builder.InitialCatalog = Properties.Settings.Default.initial_catalog;
            //builder.PersistSecurityInfo = true;
            ////builder.UserID = user;
            ////builder.Password = password;
            //Properties.Settings.Default.connection = new SqlConnection(builder.ConnectionString);
            builder.DataSource = Properties.Settings.Default.data_source;
            builder.InitialCatalog = Properties.Settings.Default.initial_catalog;
            builder.PersistSecurityInfo = true;
            //builder.UserID = user;
            //builder.Password = password;
            Properties.Settings.Default.connection = new SqlConnection(builder.ConnectionString);
        }
    }
}
