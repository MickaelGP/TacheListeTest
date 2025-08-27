using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTacheConsole
{
    public class DatabaseTest
    {
        private SqlConnection ConnectionString = new SqlConnection("Data Source=LAPTOP-STBV0HF1\\SQLSERVE22DEV;Initial Catalog=master;Persist Security Info=True;User ID=sa;Password=wumzor-wegcA8-qohnyk;Trust Server Certificate=True");
        public void CreateDBTest()
        {
            SqlCommand cmd = new SqlCommand("CREATE DATABASE listeTacheTests", ConnectionString);
            ConnectionString.Open();
            cmd.ExecuteNonQuery();
            ConnectionString.Close();

        }

        public void CreateTableTest()
        {
            string request = "USE listeTacheTests; " +
                " CREATE TABLE taches (tacheId INT IDENTITY NOT NULL, tacheNom VARCHAR(15) NOT NULL, tacheDescription VARCHAR(255) NOT NULL, tacheCreation DATETIME NOT NULL, tacheTerminer DATETIME NULL);" +
                " ALTER TABLE tache ADD CONSTRAINT PK_tacheId PRIMARY KEY (tacheId) ";
            SqlCommand cmd = new SqlCommand(request, ConnectionString);
            ConnectionString.Open();
            cmd.ExecuteNonQuery();
            ConnectionString.Close();
        }

        public void DropDatabase()
        {
            string request = "USE master; DROP DATABASE listeTacheTests; ";

            SqlCommand cmd = new SqlCommand(request, ConnectionString);
            ConnectionString.Open();
            cmd.ExecuteNonQuery();
            ConnectionString.Close();
        }
    }
}
