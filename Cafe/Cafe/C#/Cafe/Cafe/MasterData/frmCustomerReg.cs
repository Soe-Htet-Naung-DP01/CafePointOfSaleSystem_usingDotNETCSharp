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
namespace Cafe.MasterData
{
    public partial class frmCustomerReg : Form
    {
        clsCustomer obj_clsCustomer = new clsCustomer();
        public int _CustomerID = 0;
        string SPString = "";
        clsMainDB  obj_clsMainDB = new clsMainDB();
        public bool _isEdit = false;

      
        public frmCustomerReg()
        {
            InitializeComponent();
        }

       

        private void frmCustomerReg_Load(object sender, EventArgs e)
        {
            ShowData();
            txtCustomerName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (txtCustomerName.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Please Type Customer Name");
                txtCustomerName.Focus();
            }
            else if (txtCustomerAddress.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Please Type Customer Address");
                txtCustomerAddress.Focus();
            }
            else if (txtCustomerPhone.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Please Type Customer PhoneNumber");
                txtCustomerPhone.Focus();
            }
            else if (txtCustomerPhone.Text == "")
            {
                MessageBox.Show("Enter PhoneNumber");
                txtCustomerPhone.Clear();
                txtCustomerPhone.Focus();
            }
            else
            {
                obj_clsCustomer.CUSTOMERID = _CustomerID;
                obj_clsCustomer.CUSTOMERNAME = txtCustomerName.Text;
                obj_clsCustomer.CUSTOMERADDRESS = txtCustomerAddress.Text;
                obj_clsCustomer.CUSTOMERPHONE = txtCustomerPhone.Text;

                if (_isEdit)
                {
                    obj_clsCustomer.CUSTOMERID = _CustomerID;
                    obj_clsCustomer.ACTION = 1;
                    obj_clsCustomer.SaveData();
                    MessageBox.Show("Successfully Edit", "Successfully", MessageBoxButtons.OK);

                }
                else
                {
                    obj_clsCustomer.ACTION = 0;
                    obj_clsCustomer.SaveData();
                    MessageBox.Show("Congratulation ! You got a new Customer!!", "Successfully Save!");
                }
            }
            txtCustomerAddress.Clear();
            txtCustomerName.Clear();
            txtCustomerPhone.Clear();
            txtCustomerName.Focus();
            ShowData();
        }
        private void ShowData()
        {
            SPString = string.Format("SP_Select_Customer N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            dgvCustomer.DataSource = obj_clsMainDB.SelectData(SPString);

            dgvCustomer.Columns[0].Visible = false;
            dgvCustomer.Columns[1].Visible = false;
            dgvCustomer.Columns[2].Width = (dgvCustomer.Width / 100) * 20;
            dgvCustomer.Columns[3].Width = (dgvCustomer.Width / 100) * 40;
            dgvCustomer.Columns[4].Width = (dgvCustomer.Width / 100) * 40;
        }
       

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowData();
        }


    }
}
