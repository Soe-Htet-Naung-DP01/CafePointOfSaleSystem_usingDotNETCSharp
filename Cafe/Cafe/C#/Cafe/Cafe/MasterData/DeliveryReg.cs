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
    public partial class DeliveryReg : Form
    {
        clsDelivery obj_clsDelivery = new clsDelivery();
        public int _DeliveryID = 0;
        string SPString = "";
        clsMainDB obj_clsMainDB = new clsMainDB();
        public bool _isEdit = false;

        public DeliveryReg()
        {
            InitializeComponent();
        }

        private void DeliveryReg_Load(object sender, EventArgs e)
        {
            ShowData();
            txtDeliveryManName.Focus();
        }

        private void ShowData()
        {
            SPString = string.Format("SP_Select_DeliveryMan N'{0}',N'{1}',N'{2}'", "0", "0", "0");
            dgvDeliveryMan.DataSource = obj_clsMainDB.SelectData(SPString);

            dgvDeliveryMan.Columns[0].Visible = false;
            dgvDeliveryMan.Columns[1].Visible = false;
            dgvDeliveryMan.Columns[2].Width = (dgvDeliveryMan.Width / 100) * 20;
            dgvDeliveryMan.Columns[3].Width = (dgvDeliveryMan.Width / 100) * 20;
            dgvDeliveryMan.Columns[4].Width = (dgvDeliveryMan.Width / 100) * 40;
            dgvDeliveryMan.Columns[5].Width = (dgvDeliveryMan.Width / 100) * 20;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtDeliveryManName.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Please Type Delivery Man Name");
                txtDeliveryManName.Focus();
            }
            else if (txtDeliveryManAddress.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Please Type Delivery Man Address");
                txtDeliveryManAddress.Focus();
            }
            else if (txtDeliveryManNRC.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Please Type Delivery Man's NRC. Example: 11/HaHaHa(React)49200R500");
                txtDeliveryManPhone.Focus();
            }
            else if (txtDeliveryManPhone.Text.Trim().ToString() == "")
            {
                MessageBox.Show("Please Type Delivery Man's PhoneNumber");
                txtDeliveryManPhone.Focus();
                txtDeliveryManPhone.Clear();
                txtDeliveryManPhone.Focus();
            }

            else
            {
                obj_clsDelivery.DELIVERYMANID = _DeliveryID;
                obj_clsDelivery.DELIVERYMANNAME = txtDeliveryManName.Text;
                obj_clsDelivery.DELIVERYMANADDRESS = txtDeliveryManAddress.Text;
                obj_clsDelivery.DELIVERYMANPHONE = txtDeliveryManPhone.Text;
                obj_clsDelivery.DELIVERYMANNRC = txtDeliveryManNRC.Text;

                if (_isEdit)
                {
                    obj_clsDelivery.DELIVERYMANID = _DeliveryID;
                    obj_clsDelivery.ACTION = 1;
                    obj_clsDelivery.SaveData();
                    MessageBox.Show("Successfully Edit", "Successfully", MessageBoxButtons.OK);

                }
                else
                {
                    obj_clsDelivery.ACTION = 0;
                    obj_clsDelivery.SaveData();
                    MessageBox.Show("Congratulation ! You got a new Delivery Man!!", "Successfully Save!");
                }
            }
            txtDeliveryManAddress.Clear();
            txtDeliveryManName.Clear();
            txtDeliveryManPhone.Clear();
            txtDeliveryManNRC.Clear();
            txtDeliveryManName.Focus();
            ShowData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
