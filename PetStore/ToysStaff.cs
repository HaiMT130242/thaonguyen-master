﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using PetStore.Model;
using System.IO;

namespace PetStore
{
    public partial class ToysStaff : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string ptIDSelected = "";
        public ToysStaff()
        {
            InitializeComponent();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int idx = gridView1.FocusedRowHandle;
            if (gridView1.GetRowCellValue(idx, gridView1.Columns[0]) != null)
            {
                ptIDSelected = gridView1.GetRowCellValue(idx, gridView1.Columns[0]).ToString();
            }
        }

        private void btndetail_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (ptIDSelected != "")
            {
                DetailToys dts = new DetailToys();
                PetToysModel ptm = new PetToysModel();

                PetToy toy = ptm.getPetToys(ptIDSelected);

                dts.txtToysId.Text = toy.pt_id;
                dts.txtToysName.Text = toy.pt_name;
                dts.txtToySaleprices.Text = toy.pt_salePrice.ToString();
                dts.txtAmount.Text = toy.pt_amount.ToString();
                dts.txtDescript.Text = toy.pt_description;

                if (toy.pt_status == "Active") { dts.txtstatus.ForeColor = Color.Green; }
                else { dts.txtstatus.ForeColor = Color.Red; }

                dts.txtstatus.Text = toy.pt_status;

                dts.lblDetail.Text = "Pet's Toys detail for '" + toy.pt_name + "'";

                String projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\.."));
                String pathImage = projectPath + "\\img\\" + toy.pt_image;
                Image img = Image.FromFile(pathImage);
                dts.ptbimage.Image = ptm.ResizeImage(img, 440, 440);

                dts.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please choose a Toys to view detail !!!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnrefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            PetToysModel ptm = new PetToysModel();

            petStoreDataSet4BindingSource.DataSource = ptm.GetAllPetToysToArrayList();
            gridControl1.DataSource = petStoreDataSet4BindingSource;
        }
    }
}