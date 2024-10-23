using PandoraBox.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PandoraBox
{
    public partial class Login : Form
    {
        Model1 m = new Model1();
        public static User Cuser;
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User us=m.Users.SingleOrDefault(u => u.UName == uname.Text && u.Password == pass.Text);

            //bool temp = false;
            if (us != null)
            {
               // MessageBox.Show("Login Successful!");
                Cuser = us;
                Main obj = new Main();
                if (obj == null)
                {
                    obj.Parent = this;
                }
                obj.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Invalid User!Re-enter Username and Password");
            }
            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void LinkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration res = new Registration();
            res.Show();
            linkLabel1.LinkVisited = true;
            this.Hide();
        }
    }
}
