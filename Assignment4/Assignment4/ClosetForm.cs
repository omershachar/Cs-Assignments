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
        private User currentUser;
        private User[] users;
        private List<ClothingItem> closetItems = new List<ClothingItem>();
        public ClosetForm(User currentUser, User[] users)
        {
            InitializeComponent();
            this.currentUser = currentUser;
            this.users = users;
        }

        private void ClosetForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {currentUser.First_name}";
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
            using (AddClothingForm addForm = new AddClothingForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    //Create new ClothingItem from user input
                    ClothingItem newItem = new ClothingItem
                        (
                        currentUser.User_id,
                        addForm.ItemName,
                        addForm.ColorCode,
                        addForm.Seasons,
                        addForm.Size,
                        10, //price
                        false, //favorite
                        addForm.Status,
                        "", //type
                        "" //brand
                        );
                    closetItems.Add(newItem); // Add the new item to the closet
                }
            }
        }

        

        private void btnView_Click(object sender, EventArgs e)
        {
            ViewClosetForm viewForm = new ViewClosetForm(closetItems);
            viewForm.ShowDialog(); // opens closet viewer
        }
    }
}
