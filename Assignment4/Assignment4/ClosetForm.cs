using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Assignment4.Models;

namespace Assignment4
{
    public partial class ClosetForm : Form
    {
        private string userId;
        private User[] users;
        public ClosetForm(string userId, User[] users)
        {
            InitializeComponent();
            this.userId = userId;
            this.users = users;
        }

        private void ClosetForm_Load(object sender, EventArgs e)
        {

        }

        private void ClosetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
