using ITRACKC2_BSIT3D_SAMPLE_APP.Functions;
using ITRACKC2_BSIT3D_SAMPLE_APP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITRACKC2_BSIT3D_SAMPLE_APP
{
    public partial class FormRegister : Form
    {
        private List<string> optionals;
        public FormRegister()
        {
            InitializeComponent();
            optionals = new List<string>()
            {
                "TxtMiddleName"
            };
        }

        public bool ValidateInput()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox txtbox)
                {
                    if (optionals.Contains(txtbox.Name))
                    {
                        continue;
                    }
                    if (txtbox.Text.Trim(' ') == "")
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                User user = new User()
                {
                    FirstName = Convert.ToString(TxtFirstName.Text),
                    MiddleName = Convert.ToString(TxtMiddleName.Text),
                    LastName = Convert.ToString(TxtLastName.Text),
                    Username = Convert.ToString(TxtUsername.Text),
                    Password = Convert.ToString(TxtPassword.Text),
                };

                UserFunction userfunction = new UserFunction();

                if (userfunction.Register(user))
                {
                    MessageBox.Show("Registered success");
                }
                else
                {
                    MessageBox.Show("failed to register");
                }
            }
            else
            {
                MessageBox.Show("Enter all required fields.");
            }
        }
    }
}
