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
    public partial class frmDeliList : Form
    {
        public frmDeliList()
        {
            InitializeComponent();
        }

        clsDelivery obj_Delivery = new clsDelivery();
        clsMainDB obj_clsMainDB = new clsMainDB();
        string SPString = "";
        DeliveryReg frm = new DeliveryReg();


        private void ShowEntry()
        {
            if (dgvDeli.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no Data");
            }
            else
            {
                frm._DeliveryID = Convert.ToInt32(dgvDeli.CurrentRow.Cells["DeliveryManID"].Value.ToString());
                frm.txtDeliveryManName.Text = dgvDeli.CurrentRow.Cells["DeliveryManName"].Value.ToString();
                frm.txtDeliveryManAddress.Text = dgvDeli.CurrentRow.Cells["DeliveryManAddress"].Value.ToString();
                frm.txtDeliveryManPhone.Text = dgvDeli.CurrentRow.Cells["DeliveryManPhone"].Value.ToString();
                frm.txtDeliveryManNRC.Text = dgvDeli.CurrentRow.Cells["DeliveryManNRC"].Value.ToString();
                frm._isEdit = true;
                frm.ShowDialog();
                ShowData();
            }
        }

        private void ShowData()
        {
            SPString = string.Format("SP_Select_DeliveryMan N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            dgvDeli.DataSource = obj_clsMainDB.SelectData(SPString);
            dgvDeli.Columns[0].Width = (dgvDeli.Width / 100) * 10;
            dgvDeli.Columns[1].Visible = true;
            dgvDeli.Columns[1].Width = (dgvDeli.Width / 100) * 20;
            dgvDeli.Columns[2].Width = (dgvDeli.Width / 100) * 20;
            dgvDeli.Columns[3].Width = (dgvDeli.Width / 100) * 20;
            dgvDeli.Columns[4].Width = (dgvDeli.Width / 100) * 20;
            dgvDeli.Columns[5].Width = (dgvDeli.Width / 100) * 10;

        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            DeliveryReg frm = new DeliveryReg();
            frm.ShowDialog();
            SPString = string.Format("SP_Select_DeliveryMan N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            dgvDeli.DataSource = obj_clsMainDB.SelectData(SPString);
        }

        private void tsbEdit_Click_1(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void tsbDelete_Click_1(object sender, EventArgs e)
        {
            if (dgvDeli.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no data");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj_Delivery.DELIVERYMANID = Convert.ToInt32(dgvDeli.CurrentRow.Cells["DeliveryManID"].Value.ToString());
                    obj_Delivery.ACTION = 2;
                    obj_Delivery.SaveData();
                    MessageBox.Show("Successfully Deleted");
                    ShowData();
                }
            }
        }

        private void frmDeliList_Load(object sender, EventArgs e)
        {
            ShowData();
        }
    }
}
