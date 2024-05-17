using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Cafe.DBA;
using Cafe.MasterData;

namespace Cafe.MasterData
{
    public partial class frm_Purchase : Form
    {
        public frm_Purchase()
        {
            InitializeComponent();
        }

        clsPurchase obj_clsPurchase = new clsPurchase();
        clsPurchaseDetail obj_clsPurchaseDetail = new clsPurchaseDetail();
        clsMenu obj_clsItem = new clsMenu();
        clsMainDB obj_clsMainDB = new clsMainDB();

        DataTable DT = new DataTable();
        DataTable DTPurchase = new DataTable();
        int _PurchaseID = 0;
        string SPString = "";
        int Count = 0;

        private void CreateTable()
        {
            DTPurchase.Rows.Clear();
            DTPurchase.Columns.Clear();
            DTPurchase.Columns.Add("MenuID");
            DTPurchase.Columns.Add("MenuName");
            DTPurchase.Columns.Add("Qty");
            DTPurchase.Columns.Add("Price");
            DTPurchase.Columns.Add("Total");
            dgvPurchase.DataSource = DTPurchase;
        }

        public void ShowData()
        {
            SPString = string.Format("SP_Select_Supplier N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.AddCombo(ref cboSup, SPString, "SupplierName", "SupplierID");

            SPString = string.Format("SP_Select_Menu N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.AddCombo(ref cboMenu, SPString, "MenuName", "MenuID");

            SPString = string.Format("SP_Select_UserSetting N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.AddCombo(ref cboSta, SPString, "UserName", "UserID");
        }

        private void frm_Purchase_Load(object sender, EventArgs e)
        {
            CreateTable();
            ShowData();
        }

        private void cboMenu_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtQty.Text = "";
            txtPrice.Text = "";
            txtQty.Focus();
        }

        private void CalculateTotal()
        {
            int Total = 0;
            if (DTPurchase.Rows.Count > 0)
            {
                foreach (DataRow DR in DTPurchase.Rows)
                    Total += Convert.ToInt32(DR["Total"]);
            }
            lblTotalAmount.Text = Total.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int OK = 0;
            if (Convert.ToInt32(cboMenu.SelectedValue.ToString()) == 0)
            {
                MessageBox.Show("Please Choose Menu");
                cboMenu.Focus();
            }
            else if (txtQty.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Qty");
                txtQty.Focus();
            }
            else if (int.TryParse(txtQty.Text, out OK) == false)
            {
                MessageBox.Show("Qty should be Number");
                txtQty.Focus();
                txtQty.SelectAll();
            }
            else if (Convert.ToInt32(txtQty.Text.Trim().ToString()) <= 0 || Convert.ToInt32(txtQty.Text.Trim().ToString()) > 10000)
            {
                MessageBox.Show("Qty should be between 1 and 10 thousand");
                txtQty.Focus();
                txtQty.SelectAll();
            }
            else if (txtPrice.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please Type Price");
                txtPrice.Focus();
            }
            else if (int.TryParse(txtPrice.Text, out OK) == false)
            {
                MessageBox.Show("Price should be Number");
                txtPrice.Focus();
                txtPrice.SelectAll();
            }
            else if (Convert.ToInt32(txtPrice.Text.Trim().ToString()) <= 100 || Convert.ToInt32(txtQty.Text.Trim().ToString()) > 10000000)
            {
                MessageBox.Show("Price should be between 1 hundred and 100-Lakh");
                txtPrice.Focus();
                txtPrice.SelectAll();
            }
            else
            {
                if (DTPurchase.Rows.Count > 0)
                {
                    DataRow[] Arr_DR = DTPurchase.Select("MenuID = " + cboMenu.SelectedValue.ToString() + "");
                    Count = Arr_DR.Length;
                    if (Count != 0)
                    {
                        MessageBox.Show("This Record is already exist");
                        return;
                    }
                }
                DataRow DR = DTPurchase.NewRow();
                DR["MenuID"] = cboMenu.SelectedValue.ToString();
                DR["MenuName"] = cboMenu.Text;
                DR["Qty"] = txtQty.Text;
                DR["Price"] = txtPrice.Text;
                DR["Total"] = Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtPrice.Text);
                DTPurchase.Rows.Add(DR);
                dgvPurchase.DataSource = DTPurchase;
                cboMenu.SelectedIndex = 0;
                CalculateTotal();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (DTPurchase.Rows.Count <= 0)
            {
                MessageBox.Show("There is no data");
            }
            else if (dgvPurchase.CurrentRow.Cells["MenuID"].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no data");
            }
            else
            {
                DataRow[] Arr_DR = DTPurchase.Select("MenuID = " + dgvPurchase.CurrentRow.Cells["MenuID"].Value.ToString() + "");
                DataRow DR = Arr_DR[0];
                DR.Delete();
                dgvPurchase.DataSource = DTPurchase;
                CalculateTotal();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SPString = string.Format("SP_Select_Purchase N'{0}', N'{1}', N'{2}'", dtpDate.Text, "0", "2");
            DT = obj_clsMainDB.SelectData(SPString);
            int DateDiff = Convert.ToInt32(DT.Rows[0]["No"]);
            if (DateDiff > 0)
            {
                MessageBox.Show("Please check Purchase date");
                dtpDate.Text = DateTime.Now.ToShortDateString();
            }
            else if (DateDiff <= -7)
            {
                MessageBox.Show("Please check Purchase date");
                dtpDate.Text = DateTime.Now.ToShortDateString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboSup.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please choose Supplier");
                cboSup.Focus();
            }
            else if (cboSta.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Please choose Staff");
                cboSta.Focus();
            }
            else if (DTPurchase.Rows.Count <= 0)
            {
                MessageBox.Show("There is no data");
            }
            else
            {
                obj_clsPurchase.PDATE = dtpDate.Text;
                obj_clsPurchase.SUPID = Convert.ToInt32(cboSup.SelectedValue.ToString());
                obj_clsPurchase.TOTALAMT = Convert.ToInt32(lblTotalAmount.Text);
                obj_clsPurchase.USERID = Convert.ToInt32(cboSta.SelectedValue.ToString());
                obj_clsPurchase.ACTION = 0;
                obj_clsPurchase.SaveData();

                SPString = string.Format("SP_Select_Purchase N'{0}', N'{1}',N'{2}'", "0", "0", "1");
                DT = obj_clsMainDB.SelectData(SPString);
                _PurchaseID = Convert.ToInt32(DT.Rows[0]["PurchaseID"].ToString());

                for (int i = 0; i < DTPurchase.Rows.Count; i++)
                {
                    obj_clsPurchaseDetail.PID = _PurchaseID;
                    obj_clsPurchaseDetail.MENUID = DTPurchase.Rows[i]["MenuID"].ToString();
                    obj_clsPurchaseDetail.PQTY = Convert.ToInt32(DTPurchase.Rows[i]["Qty"].ToString());
                    obj_clsPurchaseDetail.PPRICE = Convert.ToInt32(DTPurchase.Rows[i]["Price"].ToString());
                    obj_clsPurchaseDetail.ACTION = 0;
                    obj_clsPurchaseDetail.SaveData();

                    obj_clsItem.MENUID = Convert.ToInt32(DTPurchase.Rows[i]["MenuID"].ToString());
                    obj_clsItem.QTY = Convert.ToInt32(DTPurchase.Rows[i]["Qty"].ToString());
                    obj_clsItem.PRICE = Convert.ToInt32(DTPurchase.Rows[i]["Price"].ToString());
                    obj_clsItem.ACTION = 3;
                    obj_clsItem.SaveData();
                }
                MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK);
                this.Close();
            }
        }


    }
}
