using System;
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
    public partial class MedicineStaff : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        String pmIDSelected = "";
        public MedicineStaff()
        {
            InitializeComponent();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            int idx = gridView1.FocusedRowHandle;
            if (gridView1.GetRowCellValue(idx, gridView1.Columns[0]) != null)
            {
                pmIDSelected = gridView1.GetRowCellValue(idx, gridView1.Columns[0]).ToString();
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (pmIDSelected != "")
            {
                DetailMedicine dmd = new DetailMedicine();
                PetMedicineModel pmm = new PetMedicineModel();

                PetMedicine med = pmm.getPetMedicine(pmIDSelected);

                dmd.txtPmdId.Text = med.pm_id;
                dmd.txtPmdName.Text = med.pm_name;
                dmd.txtPmdSaleprices.Text = med.pm_salePrice.ToString();
                dmd.txtPmdAmount.Text = med.pm_amount.ToString();
                dmd.txtPmdDescript.Text = med.pm_description;

                if (med.pm_status == "Active") { dmd.txtPmdStatus.ForeColor = Color.Green; }
                else { dmd.txtPmdStatus.ForeColor = Color.Red; }

                dmd.txtPmdStatus.Text = med.pm_status;

                dmd.lbldetail.Text = "Pet's Food detail for '" + med.pm_name + "'";

                String projectPath = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\.."));
                String pathImage = projectPath + "\\img\\" + med.pm_image;
                Image img = Image.FromFile(pathImage);
                dmd.ptbimage.Image = pmm.ResizeImage(img, 440, 440);

                dmd.ShowDialog();
            }
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            PetMedicineModel pmm = new PetMedicineModel();
          
            petStoreDataSet3BindingSource.DataSource = pmm.GetAllPetMedicineToArrayList();
            gridControl1.DataSource = petStoreDataSet3BindingSource ;
        }
    }
}