namespace Cafe.MasterData
{
    partial class DeliveryReg
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryReg));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDeliveryManName = new System.Windows.Forms.TextBox();
            this.txtDeliveryManNRC = new System.Windows.Forms.TextBox();
            this.txtDeliveryManPhone = new System.Windows.Forms.TextBox();
            this.txtDeliveryManAddress = new System.Windows.Forms.TextBox();
            this.dgvDeliveryMan = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryMan)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "DeliveryManName :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Delivery Phone :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(344, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Delivery Address :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(105, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "DeliveryMan\'s NRC :";
            // 
            // txtDeliveryManName
            // 
            this.txtDeliveryManName.Location = new System.Drawing.Point(166, 60);
            this.txtDeliveryManName.Name = "txtDeliveryManName";
            this.txtDeliveryManName.Size = new System.Drawing.Size(142, 20);
            this.txtDeliveryManName.TabIndex = 1;
            // 
            // txtDeliveryManNRC
            // 
            this.txtDeliveryManNRC.Location = new System.Drawing.Point(166, 95);
            this.txtDeliveryManNRC.Name = "txtDeliveryManNRC";
            this.txtDeliveryManNRC.Size = new System.Drawing.Size(142, 20);
            this.txtDeliveryManNRC.TabIndex = 3;
            // 
            // txtDeliveryManPhone
            // 
            this.txtDeliveryManPhone.Location = new System.Drawing.Point(495, 60);
            this.txtDeliveryManPhone.Name = "txtDeliveryManPhone";
            this.txtDeliveryManPhone.Size = new System.Drawing.Size(142, 20);
            this.txtDeliveryManPhone.TabIndex = 4;
            // 
            // txtDeliveryManAddress
            // 
            this.txtDeliveryManAddress.Location = new System.Drawing.Point(495, 97);
            this.txtDeliveryManAddress.Name = "txtDeliveryManAddress";
            this.txtDeliveryManAddress.Size = new System.Drawing.Size(142, 20);
            this.txtDeliveryManAddress.TabIndex = 5;
            // 
            // dgvDeliveryMan
            // 
            this.dgvDeliveryMan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeliveryMan.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvDeliveryMan.Location = new System.Drawing.Point(0, 167);
            this.dgvDeliveryMan.Name = "dgvDeliveryMan";
            this.dgvDeliveryMan.Size = new System.Drawing.Size(670, 152);
            this.dgvDeliveryMan.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 140);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(169, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "DeliveryMan List ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(470, 138);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(361, 138);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // DeliveryReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(670, 319);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dgvDeliveryMan);
            this.Controls.Add(this.txtDeliveryManAddress);
            this.Controls.Add(this.txtDeliveryManPhone);
            this.Controls.Add(this.txtDeliveryManNRC);
            this.Controls.Add(this.txtDeliveryManName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "DeliveryReg";
            this.Text = "DeliveryMan Register & List";
            this.Load += new System.EventHandler(this.DeliveryReg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeliveryMan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvDeliveryMan;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.TextBox txtDeliveryManName;
        public System.Windows.Forms.TextBox txtDeliveryManNRC;
        public System.Windows.Forms.TextBox txtDeliveryManPhone;
        public System.Windows.Forms.TextBox txtDeliveryManAddress;
    }
}