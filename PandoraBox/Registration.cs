using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PandoraBox
{
    public partial class Registration : Form
    {
        Model1 m1 = new Model1();
        public Registration()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label4_Click(object sender, EventArgs e)
        {

        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Models.User user = new Models.User();
            user.Email = email_tb.Text;
            user.UName = username_tb.Text;
            user.Password = password_tb.Text;
            m1.Users.Add(user);
            m1.SaveChanges();
            Login l = new Login();
            l.Show();
            this.Hide();

        }
    }
}
