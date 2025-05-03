using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Assignment4.Models;

namespace Assignment4
{
    public partial class ViewClosetForm : Form
    {
        private List<ClothingItem> closetItems;

        public ViewClosetForm(List<ClothingItem> items)
        {
            InitializeComponent();
            closetItems = items;
            SetupListView();
            LoadClothes();
        }

        private void SetupListView()
        {
            listViewClothes.View = View.Details;
            listViewClothes.FullRowSelect = true;
            listViewClothes.GridLines = true;
            listViewClothes.Columns.Add("Name", 100);
            listViewClothes.Columns.Add("Color", 80);
            listViewClothes.Columns.Add("Size", 60);
            listViewClothes.Columns.Add("Status", 100);
            listViewClothes.Columns.Add("Seasons", 100);
        }

        private void LoadClothes()
        {
            listViewClothes.Items.Clear();

            foreach (var item in closetItems)
            {
                var row = new ListViewItem(item.Name);
                row.SubItems.Add(item.Color_code);
                row.SubItems.Add(item.Size.ToString());
                row.SubItems.Add(item.Status.ToString());
                row.SubItems.Add(item.Seasons.ToString());
                listViewClothes.Items.Add(row);
            }

            if (closetItems.Count == 0)
            {
                lblEmpty.Text = "Your closet is empty.";
                lblEmpty.Visible = true;
            }
            else
            {
                lblEmpty.Visible = false;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
