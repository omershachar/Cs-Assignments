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
using System.IO;
using System.Media;

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

        private Timer danceTimer = new Timer();
        private int danceStep = 0;

        private void ClosetForm_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = $"Welcome, {currentUser.First_name}";
            baseLeft = closetPictureBox.Left; // שמור את המיקום ההתחלתי
            LoadDancingGif(); // נטען את הגיף
            PlayOdeToWardrobe();
            StartClosetDance();
        }
        private void LoadDancingGif()
        {
            string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Images", "A_looping_GIF_features_a_dancing_wardrobe_icon_set.png");

            if (File.Exists(imagePath))
            {
                closetPictureBox.Image = Image.FromFile(imagePath);
                ImageAnimator.Animate(closetPictureBox.Image, (s, e) => closetPictureBox.Invalidate());
            }
            else
            {
                MessageBox.Show("Dancing wardrobe image not found.");
            }
        }


        private void ClosetForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void PlayOdeToWardrobe()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Sounds", "Ode to John's Wardrobe.wav");

            if (File.Exists(path))
            {
                SoundPlayer player = new SoundPlayer(path);
                player.Play(); // Use PlaySync() if you want it to block until finished
            }
            else
            {
                MessageBox.Show("Could not find the wardrobe anthem.");
            }
        }


        private void StartClosetDance()
        {
            danceTimer.Interval = 200;
            danceTimer.Tick += DanceStep;
            danceTimer.Start();
        }

        private void DanceStep(object sender, EventArgs e)
        {
            danceStep++;
            closetPictureBox.Left = baseLeft + (int)(5 * Math.Sin(danceStep));
        }

        private int baseLeft = 0; 


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
