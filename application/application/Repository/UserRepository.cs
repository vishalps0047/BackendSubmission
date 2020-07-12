using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace application.Repository
{
    public class UserRepository
    {
        private readonly ConnectionStrings _connect;

        public UserRepository(IOptions<ConnectionStrings> mySqlConnect)
        {
            _connect = mySqlConnect.Value;
        }
        public DataTable GetUsers()
        {
            try
            {
                string connectionString = _connect.IdentityConnection;
                List<UserResponse> response = new List<UserResponse>();
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                string mySqlQuery = "SELECT * FROM test.aspnetusers";
                var cmd = new MySqlCommand(mySqlQuery, connection);
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = new MySqlCommand(mySqlQuery, connection);
                DataTable table = new DataTable();
                dataAdapter.Fill(table);

                connection.Close();

                return table;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
