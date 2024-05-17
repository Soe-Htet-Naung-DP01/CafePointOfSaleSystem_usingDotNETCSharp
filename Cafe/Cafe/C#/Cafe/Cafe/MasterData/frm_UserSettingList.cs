using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cafe.MasterData;
using Cafe.DBA;

namespace Cafe.MasterData
{
    public partial class frm_UserSettingList : Form
    {
        public frm_UserSettingList()
        {
            InitializeComponent();
        }

        clsUserSetting obj_clsUserSetting = new clsUserSetting();
        clsMainDB obj_clsMainDB = new clsMainDB();
        frmUserSetting frm = new frmUserSetting();
        string SPString = "";

        private void ShowData()
        {
            SPString = string.Format("SP_Select_UserSetting N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            dgvUserSetting.DataSource = obj_clsMainDB.SelectData(SPString);
            dgvUserSetting.Columns[0].Width = (dgvUserSetting.Width / 100) * 10;
            dgvUserSetting.Columns[1].Visible = true;
            dgvUserSetting.Columns[1].Width = (dgvUserSetting.Width / 100) * 20;
            dgvUserSetting.Columns[2].Width = (dgvUserSetting.Width / 100) * 25;
            dgvUserSetting.Columns[3].Visible = false;
            dgvUserSetting.Columns[3].Width = (dgvUserSetting.Width / 100) * 75;
            dgvUserSetting.Columns[4].Width = (dgvUserSetting.Width / 100) * 20;
        }

        private void ShowEntry()
        {
            if (dgvUserSetting.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no Data");
            }
            else
            {
                frm.UserID = Convert.ToInt32(dgvUserSetting.CurrentRow.Cells["UserID"].Value.ToString());
                frm.txtUserName.Text = dgvUserSetting.CurrentRow.Cells["UserName"].Value.ToString();
                frm.txtPassword.Text = dgvUserSetting.CurrentRow.Cells["Password"].Value.ToString();
                frm.txtConfirmPassword.Text = dgvUserSetting.CurrentRow.Cells["Password"].Value.ToString();
                frm.UserLevel = dgvUserSetting.CurrentRow.Cells["UserLevel"].Value.ToString();
                frm._IsEdit = true;
                frm.ShowDialog();
                ShowData();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmUserSetting frm = new frmUserSetting();
            frm.ShowDialog();
            ShowData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ShowEntry();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvUserSetting.CurrentRow.Cells[0].Value.ToString() == string.Empty)
            {
                MessageBox.Show("There is no data");
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    obj_clsUserSetting.USERID = Convert.ToInt32(dgvUserSetting.CurrentRow.Cells["UserID"].Value.ToString());
                    obj_clsUserSetting.ACTION = 2;
                    obj_clsUserSetting.SaveData();
                    MessageBox.Show("Successfully Deleted");
                    ShowData();
                }
            }
        }

        private void frm_UserSettingList_Load(object sender, EventArgs e)
        {
            ShowData();
        }

        private void dgvUserSetting_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ShowEntry();
        }
    }
}
