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
    public partial class frm_ProfitLoss : Form
    {
        public frm_ProfitLoss()
        {
            InitializeComponent();
        }

        clsMainDB obj_clsMainDB = new clsMainDB();

        DataTable DTData = new DataTable();
        DataTable DTPurchase = new DataTable();
        DataTable DTSale = new DataTable();
        DataTable DTMenu = new DataTable();
        DataTable DT = new DataTable();
        DataRow DRData;

        String SPString = "";
        int GrandPurchaseTotal, GrandSaleTotal, GrandProfitLoss;

        private void ShowData()
        {
            GrandPurchaseTotal = GrandSaleTotal = GrandProfitLoss = 0;

            SPString = string.Format("SP_Select_ProfitLoss N'{0}', N'{1}', N'{2}', N'{3}'", dtpStartDate.Value.ToShortDateString(), dtpEndDate.Value.ToShortDateString(), "0", "2");
            DT = obj_clsMainDB.SelectData(SPString);
            int DateDiff = Convert.ToInt32(DT.Rows[0]["No"]);
            if (DateDiff < 0)
            {
                MessageBox.Show("Please check Start Date and End Date!");
                dtpStartDate.Text = DateTime.Now.ToShortDateString();
                dtpEndDate.Text = DateTime.Now.ToShortDateString();
                return;
            }

            SPString = string.Format("SP_Select_ProfitLoss N'{0}', N'{1}', N'{2}', N'{3}'", txtMenuName.Text, dtpStartDate.Value.ToShortDateString(), dtpEndDate.Value.ToShortDateString(), "0");
            DTPurchase = obj_clsMainDB.SelectData(SPString);

            SPString = string.Format("SP_Select_ProfitLoss N'{0}', N'{1}', N'{2}', N'{3}'", txtMenuName.Text, dtpStartDate.Value.ToShortDateString(), dtpEndDate.Value.ToShortDateString(), "1");
            DTSale = obj_clsMainDB.SelectData(SPString);

            SPString = string.Format("SP_Select_Menu N'{0}', N'{1}', N'{2}'", txtMenuName.Text, "0", "2");
            DTMenu = obj_clsMainDB.SelectData(SPString);

            DTData.Rows.Clear();
            DTData.Columns.Clear();
            DTData.Columns.Add("No");
            DTData.Columns.Add("MenuName");
            DTData.Columns.Add("OnHandQty");
            DTData.Columns.Add("PurchaseTotal");
            DTData.Columns.Add("SaleTotal");
            DTData.Columns.Add("Profit/Loss");

            foreach (DataRow DRMenu in DTMenu.Rows)
            {
                DRData = DTData.NewRow();
                DRData["No"] = DRMenu["No"];
                DRData["MenuName"] = DRMenu["MenuName"];
                DRData["OnHandQty"] = DRMenu["Qty"];

                DataRow[] DRPurchase = DTPurchase.Select("MenuName = '" + DRData["MenuName"] + "'");
                if (DRPurchase.Length > 0)
                    DRData["PurchaseTotal"] = DRPurchase[0]["PurchaseTotal"];
                else
                    DRData["PurchaseTotal"] = "0";

                DataRow[] DRSale = DTSale.Select("MenuName = '" + DRData["MenuName"] + "'");
                if (DRSale.Length > 0)
                    DRData["SaleTotal"] = DRSale[0]["SaleTotal"];
                else
                    DRData["SaleTotal"] = "0";

                int PurchaseTotal = Convert.ToInt32(DRData["PurchaseTotal"]);
                int SaleTotal = Convert.ToInt32(DRData["SaleTotal"]);
                int ProfitLoss = SaleTotal - PurchaseTotal;

                GrandPurchaseTotal += PurchaseTotal;
                GrandSaleTotal += SaleTotal;
                GrandProfitLoss += ProfitLoss;

                DRData["Profit/Loss"] = ProfitLoss.ToString();

                DTData.Rows.Add(DRData);
            }

            DRData = DTData.NewRow();
            DRData["OnHandQty"] = "Grand Total";
            DRData["PurchaseTotal"] = GrandPurchaseTotal.ToString();
            DRData["SaleTotal"] = GrandSaleTotal.ToString();
            DRData["Profit/Loss"] = GrandProfitLoss.ToString();
            DTData.Rows.Add(DRData);

            dgvProfitLoss.DataSource = DTData;

            dgvProfitLoss.Columns[0].Width = (dgvProfitLoss.Width / 100) * 10;
            dgvProfitLoss.Columns[1].Width = (dgvProfitLoss.Width / 100) * 30;
            dgvProfitLoss.Columns[2].Width = (dgvProfitLoss.Width / 100) * 10;
            dgvProfitLoss.Columns[3].Width = (dgvProfitLoss.Width / 100) * 10;
            dgvProfitLoss.Columns[4].Width = (dgvProfitLoss.Width / 100) * 10;
            dgvProfitLoss.Columns[5].Width = (dgvProfitLoss.Width / 100) * 10;

            int LastIndex = dgvProfitLoss.Rows.Count - 1;
            dgvProfitLoss.Rows[LastIndex].DefaultCellStyle.BackColor = Color.Yellow;
        }

        private void frm_ProfitLoss_Load(object sender, EventArgs e)
        {
            ShowData();

            SPString = String.Format("SP_Select_Menu N'{0}', N'{1}', N'{2}'", "0", "0", "0");
            obj_clsMainDB.TextBoxData(ref txtMenuName, SPString, "MenuName");
        }

        private void txtMenuName_TextChanged(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ShowData();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            txtMenuName.Text = "";
            dtpStartDate.Text = DateTime.Now.ToShortDateString();
            dtpEndDate.Text = DateTime.Now.ToShortDateString();
            ShowData();
        }
    }
}
