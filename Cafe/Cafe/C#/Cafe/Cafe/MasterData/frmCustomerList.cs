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
using Cafe.MasterData;

namespace Cafe.MasterData
{
    public partial class frmCustomerList : Form
    {
        public frmCustomerList()
        {
            InitializeComponent();
        }
        clsCustomer obj_Customer = new clsCustomer();
        clsMainDB obj_clsMainDB = new clsMainDB();
        string SPString = "";
        frmCustomerReg frm = new frmCustomerReg();
        

        private void ShowEntry()
        {
            if (dgvCustomer.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no Data");
            }
            else
            {
                frm._CustomerID = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["CustomerID"].Value.ToString());
                frm.txtCustomerName.Text = dgvCustomer.CurrentRow.Cells["CustomerName"].Value.ToString();
                frm.txtCustomerAddress.Text = dgvCustomer.CurrentRow.Cells["CustomerAddress"].Value.ToString();
                frm.txtCustomerPhone.Text = dgvCustomer.CurrentRow.Cells["CustomerPhone"].Value.ToString();
                frm._isEdit = true;
                frm.ShowDialog();
                ShowData();
            }
        }

        private void ShowData()
        {
            SPString = string.Format("SP_Select_Customer N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            dgvCustomer.DataSource = obj_clsMainDB.SelectData(SPString);
            dgvCustomer.Columns[0].Width = (dgvCustomer.Width / 100) * 10;
            dgvCustomer.Columns[1].Visible = true;
            dgvCustomer.Columns[1].Width = (dgvCustomer.Width / 100) * 20;
            dgvCustomer.Columns[2].Width = (dgvCustomer.Width / 100) * 25;
            dgvCustomer.Columns[3].Width = (dgvCustomer.Width / 100) * 25;
            dgvCustomer.Columns[4].Width = (dgvCustomer.Width / 100) * 20;
        }

        private void tsbEdit_Click(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no data");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj_Customer.CUSTOMERID = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["CustomerID"].Value.ToString());
                    obj_Customer.ACTION = 2;
                    obj_Customer.SaveData();
                    MessageBox.Show("Successfully Deleted");
                    ShowData();
                }
            }
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            frmCustomerReg frm = new frmCustomerReg();
            frm.ShowDialog();
            SPString = string.Format("SP_Select_Customer N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            dgvCustomer.DataSource = obj_clsMainDB.SelectData(SPString);
        }

        private void frmCustomerList_Load(object sender, EventArgs e)
        {
            ShowData();
        }

   
    }
}
