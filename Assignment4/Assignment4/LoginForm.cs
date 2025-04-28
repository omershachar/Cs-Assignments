using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment4.Models;

namespace Assignment4
{
    public partial class LoginForm : Form
    {
        private User[] users; // Declare the users array
        public LoginForm(User[] users)
        {
            InitializeComponent();
            this.users = users;
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            int index = CheckCredentials(email, password);
            if (index != -1)
            {
                string userId = users[index].User_id;
                this.Hide(); //close login
                ClosetForm main = new ClosetForm(userId, users); //passing user info
                main.Show();
            }
            else
            {
                lblError.Text = "Invalid email or password.";
            }

        }
        private int CheckCredentials(string email, string pass)
        {
            for (int i = 0; i < users.Length; i++)
            {
                if (users[i].Email == email && users[i].Password == pass)
                {
                    return i; // Return the index of the user
                }
            }
            return -1; // Return -1 if no match is found
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string userId = users[0].User_id;
            this.Hide(); //hide login
            ClosetForm main = new ClosetForm(userId, users); //passing user info
            main.Show();
        }
    }
}
