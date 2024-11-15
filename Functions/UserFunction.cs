﻿using ITRACKC2_BSIT3D_SAMPLE_APP.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ITRACKC2_BSIT3D_SAMPLE_APP.Functions
{
    public class UserFunction : DatabaseConnection
    {
        public bool Register(User user)
        {
            try
            {
                using (var connection = SqlConn())
                {
                    connection.Open();
                    string query = @"insert into users (first_name, middle_name, last_name, username, password) values (@first_name, @middle_name, @last_name, @username, hashbytes('sha2_512', @password));";
                    using (var command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@first_name", SqlDbType.VarChar).Value = user.FirstName;
                        command.Parameters.Add("@middle_name", SqlDbType.VarChar).Value = user.FirstName;
                        command.Parameters.Add("@last_name", SqlDbType.VarChar).Value = user.LastName;
                        command.Parameters.Add("@username", SqlDbType.VarChar).Value = user.Username;
                        command.Parameters.Add("@password", SqlDbType.VarChar).Value = user.Password;

                        return command.ExecuteNonQuery() == 1;
                    }
                }
            }
            catch (SqlException se)
            {
                // Handle unique exception properly
                throw new Exception("Username already exists.");
            }
        }

        public bool Login(string username, string password)
        {
            using (var connection = SqlConn())
            {
                connection.Open();
                string query = @"select * from users where username=@username and password=hashbytes('sha2_512', @password);";
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                    command.Parameters.Add("@password", SqlDbType.VarChar).Value = password;

                    using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                    {
                        return reader.Read();
                    }
                }
            }
        }
    }
}
