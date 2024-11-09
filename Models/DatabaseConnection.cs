using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ITRACKC2_BSIT3D_SAMPLE_APP.Models
{
    public abstract class DatabaseConnection
    {
        private string _connectionString;
        private string DATABASE = "itrackc2_bsit3d";
        private string SERVER = "(local)\\sqlexpress";
        private string USERNAME = "server_admin";
        private string PASSWORD = "admin1234";

        public DatabaseConnection()
        {
            _connectionString = $"SERVER={SERVER};DATABASE={DATABASE};USER ID={USERNAME};PASSWORD={PASSWORD}";
        }
        protected SqlConnection SqlConn()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
