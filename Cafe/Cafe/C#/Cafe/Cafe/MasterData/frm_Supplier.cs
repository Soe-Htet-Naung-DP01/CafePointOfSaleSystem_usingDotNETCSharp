using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cafe.DBA;

namespace Cafe
{
    public partial class frm_Supplier : Form
    {
        public frm_Supplier()
        {
            InitializeComponent();
        }

        clsSupplier obj_clsSupplier = new clsSupplier();
        clsMainDB obj_clsMainDB = new clsMainDB();

        DataTable DT = new DataTable();
        public bool _IsEdit = false;
        public int _SupplierID = 0;
        string SPString = "";

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Name.");
                txtName.Focus();
            }
            else if (txtPhone.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Phone.");
                txtPhone.Focus();
            }
            else if (txtAddress.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Address.");
                txtAddress.Focus();
            }
            else
            {
                SPString = string.Format("SP_Select_Supplier N'{0}', N'{1}', N'{2}'", txtName.Text.Trim().ToString(), txtAddress.Text.Trim().ToString(), "1");
                DT = obj_clsMainDB.SelectData(SPString);
                if ((DT.Rows.Count > 0) && (DT.Rows[0]["SupplierID"].ToString() != _SupplierID.ToString()))
                {
                    MessageBox.Show("This Supplier already exists");
                    txtName.Focus();
                    txtName.SelectAll();
                }
                else
                {
                    obj_clsSupplier.SID = Convert.ToInt32(_SupplierID);
                    obj_clsSupplier.SNAME = txtName.Text;
                    obj_clsSupplier.ADDRESS = txtAddress.Text;
                    obj_clsSupplier.PHONE = txtPhone.Text;
                    obj_clsSupplier.UPDATE = lblUpdateDate.Text;

                    if (_IsEdit)
                    {
                        obj_clsSupplier.ACTION = 1;
                        obj_clsSupplier.SaveData();
                        MessageBox.Show("Successfully Edit", "Successfully", MessageBoxButtons.OK);
                        
                    }
                    else
                    {
                        obj_clsSupplier.ACTION = 0;
                        obj_clsSupplier.SaveData();
                        MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK);
                        
                    }
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void frm_Supplier_Load(object sender, EventArgs e)
        {
            ShowData();
            string Day = string.Format("{0:D2}", DateTime.Now.Day);
            string Month = string.Format("{0:D2}", DateTime.Now.Month);
            string Year = string.Format("{0:D2}", DateTime.Now.Year);
            lblUpdateDate.Text = Month + "/" + Day + "/" + Year;
            txtName.Focus();
        }

        private void ShowData()
        {
            SPString = string.Format("SP_Select_Supplier N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            dgvSupplierList.DataSource = obj_clsMainDB.SelectData(SPString);

            dgvSupplierList.Columns[0].Width = (dgvSupplierList.Width / 100) * 10;
            dgvSupplierList.Columns[1].Visible = false;
            dgvSupplierList.Columns[2].Width = (dgvSupplierList.Width / 100) * 20;
            dgvSupplierList.Columns[3].Width = (dgvSupplierList.Width / 100) * 30;
            dgvSupplierList.Columns[4].Width = (dgvSupplierList.Width / 100) * 20;
            dgvSupplierList.Columns[5].Width = (dgvSupplierList.Width / 100) * 20;
        }

    }
}
