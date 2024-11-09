using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITRACKC2_BSIT3D_SAMPLE_APP.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }


        public string FullName { get; private set; }
        public void SetName(string first_name, string last_name, string middle_name = "")
        {
            if (middle_name.Trim(' ') == "")
            {
                FullName = $"{first_name} {last_name}";
            }
            else
            {
                FullName = $"{first_name} {middle_name} {last_name}";
            }
        }
    }
}
