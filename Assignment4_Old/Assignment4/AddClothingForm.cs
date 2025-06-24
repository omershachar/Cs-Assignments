using System;
using System.Windows.Forms;
using Assignment4.Models; // for enums like Size, Status

namespace Assignment4
{
    public partial class AddClothingForm : Form
    {
        public string ItemName { get; private set; }
        public string ColorCode { get; private set; }
        public Size Size { get; private set; }
        public Status Status { get; private set; }
        public Seasons Seasons { get; private set; }

        public AddClothingForm()
        {
            InitializeComponent();
            InitializeDropdowns();
        }

        private void InitializeDropdowns()
        {
            comboSize.DataSource = Enum.GetValues(typeof(Size));
            comboStatus.DataSource = Enum.GetValues(typeof(Status));
            comboSeasons.DataSource = Enum.GetValues(typeof(Seasons));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) || string.IsNullOrWhiteSpace(txtColor.Text))
            {
                MessageBox.Show("Please fill out all fields.");
                return;
            }

            ItemName = txtName.Text.Trim();
            ColorCode = txtColor.Text.Trim();

            if (!ColorCode.StartsWith("#") || ColorCode.Length != 7)
            {
                MessageBox.Show("Color code must be in the format #rrggbb.");
                return;
            }

            Size = (Size)comboSize.SelectedItem;
            Status = (Status)comboStatus.SelectedItem;
            Seasons = (Seasons)comboSeasons.SelectedItem;

            this.DialogResult = DialogResult.OK;
            this.Close(); // ✅ closes cleanly, no zombie
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
