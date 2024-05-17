using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cafe.MasterData;
using Cafe.DBA;

namespace Cafe.MasterData
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            Thread t = new Thread(new ThreadStart(StartForm));
            t.Start();
            Thread.Sleep(1500);

            InitializeComponent();
            t.Abort();
        }

        public void StartForm()
        {
            Application.Run(new frmLoading());
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMenu frm = new frmMenu();
            frm.ShowDialog();
        }

        private void supplierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_Supplier frm = new frm_Supplier();
            frm.ShowDialog();
        }

        private void userToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_UserSettingList frm = new frm_UserSettingList();
            frm.ShowDialog();
        }

        private void purchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_PurchaseList frm = new frm_PurchaseList();
            frm.ShowDialog();
        }

        private void saleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSaleList frm = new frmSaleList();
            frm.ShowDialog();
        }

        private void profitLossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_ProfitLoss frm = new frm_ProfitLoss();
            frm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (logINToolStripMenuItem.Text == "LogOut")
            {
                if (MessageBox.Show("Are you sure you want to log out?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    logINToolStripMenuItem.Text = "LogIN";
                    ShowMenu("");
                }
                return;
            }
            clsMainDB obj_clsMainDB = new clsMainDB();
            frmLogin obj_frmLogIn = new frmLogin();
            DataTable DT = new DataTable();
            String UserName = "";
            String Password = "";

        Start:
            obj_frmLogIn.txtUserName.Text = UserName;
            obj_frmLogIn.txtPassword.Text = Password;
            if (obj_frmLogIn.ShowDialog() == DialogResult.OK)
            {
                if (obj_frmLogIn.txtUserName.Text.Trim().ToString() == string.Empty)
                {
                    MessageBox.Show("Please Type User Name.");
                    obj_frmLogIn.txtUserName.Focus();
                    goto Start;
                }
                UserName = obj_frmLogIn.txtUserName.Text;
                if (obj_frmLogIn.txtPassword.Text.Trim().ToString() == string.Empty)
                {
                    MessageBox.Show("Please Type Password.");
                    obj_frmLogIn.txtPassword.Focus();
                    goto Start;

                }
                Password = obj_frmLogIn.txtPassword.Text;
                String SPString = string.Format("SP_Select_UserSetting N'{0}',N'{1}',N'{2}'", obj_frmLogIn.txtUserName.Text.Trim().ToString(), obj_frmLogIn.txtPassword.Text.Trim().ToString(), "1");

                DT = obj_clsMainDB.SelectData(SPString);
                if (DT.Rows.Count > 0)
                {
                    Program.UserID = Convert.ToInt32(DT.Rows[0]["UserID"].ToString());
                    string UserLevel = DT.Rows[0]["UserLevel"].ToString();
                    logINToolStripMenuItem.Text = "LogOut";
                    ShowMenu(UserLevel);
                }
                else
                {
                    MessageBox.Show("Invalid User Name and Password");
                    goto Start;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ShowMenu("");
        }

        public void ShowMenu(string UserLevel)
        {
            string[] Arr_UserLevel = UserLevel.Split(',');
            for (int i = 1; i < menuStrip1.Items.Count; i++)
            {
                ToolStripMenuItem MainMenu = (ToolStripMenuItem)menuStrip1.Items[i];
                foreach (ToolStripMenuItem SubMenu in MainMenu.DropDownItems)
                {
                    SubMenu.Enabled = false;
                    foreach (string Menu in Arr_UserLevel)
                    {
                        if (SubMenu.Text.ToString() == Menu.ToString())
                        {
                            SubMenu.Enabled = true;
                            break;
                        }
                    }
                }
            }
        }

        private void mnuLogIn_Click(object sender, EventArgs e)
        {
            
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void orderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmOrderVoucherList frm = new frmOrderVoucherList();
            frm.ShowDialog();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCustomerList frm = new frmCustomerList();
            frm.ShowDialog();
        }

        private void deliveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDeliList frm = new frmDeliList();
            frm.ShowDialog();
        }
    }
}
