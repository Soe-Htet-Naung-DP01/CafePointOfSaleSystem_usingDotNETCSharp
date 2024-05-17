using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cafe.DBA;

namespace Cafe
{
    public partial class frmMenu : Form
    {
        clsMenu obj_clsMenu = new clsMenu();
        clsMainDB obj_clsMainDB = new clsMainDB();

        DataTable DT = new DataTable();
        public bool _IsEdit = false;
        public int _MenuID = 0;
        string SPString = "";

        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            ShowData();
            txtMenuName.Enabled = false;
            txtPrice.Enabled = false;
            txtQty.Enabled = false;
            btnRemove.Enabled = false;
            btnEdit.Enabled = false;
            btnSave.Enabled = false;
            string Day = string.Format("{0:D2}", DateTime.Now.Day);
            string Month = string.Format("{0:D2}", DateTime.Now.Month);
            string Year = string.Format("{0:D2}", DateTime.Now.Year);
            lblUpdateDate.Text = Month + "/" + Day + "/" + Year;
            txtQty.Text = "0"; txtPrice.Text = "0";
            txtMenuName.Focus();
            SPString = String.Format("SP_Select_Menu N'{0}', N'{1}', N'{2}'", "0", "0", "7");
            lblMenuID.Text = obj_clsMainDB.GetMenuID(SPString);
            dgvMenuList.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int Ok;
            if (txtMenuName.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please type Menu Name.");
                txtMenuName.Focus();
            }
            else if (txtQty.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please type Qty.");
                txtQty.Focus();
            }
            else if (int.TryParse(txtQty.Text, out Ok) == false)
            {
                MessageBox.Show("Qty should be a number.");
                txtQty.Focus();
                txtQty.SelectAll();
            }
            else if (Convert.ToInt32(txtQty.Text) < 1 || Convert.ToInt32(txtQty.Text) > 100)
            {
                MessageBox.Show("Qty should be between 1 and 100");
                txtQty.Focus();
                txtQty.SelectAll();
            }
            else if (txtPrice.Text.Trim().ToString() == string.Empty)
            {
                MessageBox.Show("Please type Price.");
                txtPrice.Focus();
            }
            else if (int.TryParse(txtPrice.Text, out Ok) == false)
            {
                MessageBox.Show("Price should be a number.");
                txtPrice.Focus();
                txtPrice.SelectAll();
            }
            else if (Convert.ToInt32(txtPrice.Text) != 0 && (Convert.ToInt32(txtPrice.Text)) < 100 || Convert.ToInt32(txtPrice.Text) > 100000)
            {
                MessageBox.Show("Price should be between one hundred and 1 lakh or 0 Price.");
                txtPrice.Focus();
                txtPrice.SelectAll();
            }
            else
            {
                SPString = string.Format("SP_Select_Menu N'{0}', N'{1}',N'{2}'", txtMenuName.Text.Trim().ToString(), "0", "1");
                DT = obj_clsMainDB.SelectData(SPString);
                if (DT.Rows.Count > 0 && _MenuID != Convert.ToInt32(DT.Rows[0]["MenuID"]))
                {
                    MessageBox.Show("This Menu already exist.");
                    txtMenuName.Focus();
                    txtMenuName.SelectAll();
                }
                else
                {
                    obj_clsMenu.MENUID = _MenuID;
                    obj_clsMenu.MENUNAME = txtMenuName.Text;
                    obj_clsMenu.QTY = Convert.ToInt32(txtQty.Text);
                    obj_clsMenu.PRICE = Convert.ToInt32(txtPrice.Text);
                    obj_clsMenu.UPDATE = lblUpdateDate.Text;
                    if (_IsEdit)
                    {
                        obj_clsMenu.ACTION = 1;
                        obj_clsMenu.SaveData();
                        MessageBox.Show("Successfully Edit", "Successfully", MessageBoxButtons.OK);
                    }
                    else
                    {
                        obj_clsMenu.ACTION = 0;
                        obj_clsMenu.SaveData();
                        MessageBox.Show("Successfully Save", "Successfully", MessageBoxButtons.OK);
                    }
                }
            }
        }

        public void ShowData()
        {
            SPString = string.Format("SP_Select_Menu N'{0}', N'{1}',N'{2}'", "0", "0", "0");
            dgvMenuList.DataSource = obj_clsMainDB.SelectData(SPString);

            dgvMenuList.Columns[0].Width = (dgvMenuList.Width / 100) * 10;
            dgvMenuList.Columns[1].Visible = false;
            dgvMenuList.Columns[2].Width = (dgvMenuList.Width / 100) * 40;
            dgvMenuList.Columns[3].Width = (dgvMenuList.Width / 100) * 10;
            dgvMenuList.Columns[4].Width = (dgvMenuList.Width / 100) * 10;
            dgvMenuList.Columns[5].Width = (dgvMenuList.Width / 100) * 30;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            string MenuID = dgvMenuList.CurrentRow.Cells["MenuID"].Value.ToString();
            if (MenuID == string.Empty)
            {
                MessageBox.Show("There is no data.");
            }
            else if (dgvMenuList.CurrentRow.Cells["Qty"].Value.ToString() != "0")
            {
                MessageBox.Show("This Menu has Qty. Cannot be deleted.");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj_clsMenu.MENUID = Convert.ToInt32(MenuID);
                    obj_clsMenu.ACTION = 2;
                    obj_clsMenu.SaveData();
                    MessageBox.Show("Successfully deleted.");
                    ShowData();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtMenuName.Enabled = true;
            txtPrice.Enabled = true;
            txtQty.Enabled = true;
            btnRemove.Enabled = true;
            btnEdit.Enabled = true;
            btnSave.Enabled = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
