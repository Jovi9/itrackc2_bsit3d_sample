using ITRACKC2_BSIT3D_SAMPLE_APP.Functions;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            FormRegister formRegister = new FormRegister();
            formRegister.ShowDialog();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string username = TxtUsername.Text;
            string password = TxtPassword.Text;
            if (username.Trim(' ') == "" || password.Trim(' ') == "")
            {
                MessageBox.Show("ENter username and password");
            }
            else
            {
                //login
                UserFunction userfunciton = new UserFunction();
                if (userfunciton.Login(username, password))
                {
                    MessageBox.Show("Authenticated");
                }
                else
                {
                    MessageBox.Show("Incorrect username or password");

                }
            }
        }
    }
}
