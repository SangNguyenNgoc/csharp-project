namespace BookingTour.App.Gui.BillGui
{
    partial class BillForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillForm));
            titleLabel = new Label();
            searchButton = new FontAwesome.Sharp.IconButton();
            searchTextbox = new TextBox();
            refershButton = new FontAwesome.Sharp.IconButton();
            createBillButton = new FontAwesome.Sharp.IconButton();
            dgvBill = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            total_passenger = new DataGridViewTextBoxColumn();
            total_price = new DataGridViewTextBoxColumn();
            invoice_issuer = new DataGridViewTextBoxColumn();
            action = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)dgvBill).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(12, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(162, 18);
            titleLabel.TabIndex = 3;
            titleLabel.Text = "Danh sách hóa đơn";
            // 
            // searchButton
            // 
            searchButton.BackColor = Color.Transparent;
            searchButton.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            searchButton.FlatAppearance.BorderSize = 2;
            searchButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchButton.ForeColor = Color.FromArgb(64, 64, 64);
            searchButton.IconChar = FontAwesome.Sharp.IconChar.None;
            searchButton.IconColor = Color.Black;
            searchButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            searchButton.Location = new Point(842, 9);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(79, 29);
            searchButton.TabIndex = 8;
            searchButton.Text = "Tìm";
            searchButton.UseVisualStyleBackColor = false;
            // 
            // searchTextbox
            // 
            searchTextbox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchTextbox.Location = new Point(605, 12);
            searchTextbox.Name = "searchTextbox";
            searchTextbox.Size = new Size(231, 25);
            searchTextbox.TabIndex = 7;
            // 
            // refershButton
            // 
            refershButton.BackColor = Color.Transparent;
            refershButton.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            refershButton.FlatAppearance.BorderSize = 2;
            refershButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            refershButton.ForeColor = SystemColors.ActiveCaptionText;
            refershButton.IconChar = FontAwesome.Sharp.IconChar.None;
            refershButton.IconColor = Color.Black;
            refershButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            refershButton.Location = new Point(927, 8);
            refershButton.Name = "refershButton";
            refershButton.Size = new Size(79, 29);
            refershButton.TabIndex = 5;
            refershButton.Text = "Làm mới";
            refershButton.UseVisualStyleBackColor = false;
            // 
            // createBillButton
            // 
            createBillButton.BackColor = Color.FromArgb(21, 128, 61);
            createBillButton.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            createBillButton.FlatAppearance.BorderSize = 2;
            createBillButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createBillButton.ForeColor = SystemColors.ButtonFace;
            createBillButton.IconChar = FontAwesome.Sharp.IconChar.None;
            createBillButton.IconColor = Color.Black;
            createBillButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            createBillButton.Location = new Point(1006, 8);
            createBillButton.Name = "createBillButton";
            createBillButton.Size = new Size(79, 29);
            createBillButton.TabIndex = 6;
            createBillButton.Text = "Mới";
            createBillButton.UseVisualStyleBackColor = false;
            createBillButton.Click += createBillButton_Click;
            // 
            // dgvBill
            // 
            dgvBill.AllowUserToAddRows = false;
            dgvBill.BackgroundColor = Color.FromArgb(244, 243, 247);
            dgvBill.BorderStyle = BorderStyle.None;
            dgvBill.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBill.ColumnHeadersHeight = 35;
            dgvBill.Columns.AddRange(new DataGridViewColumn[] { id, total_passenger, total_price, invoice_issuer, action });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvBill.DefaultCellStyle = dataGridViewCellStyle3;
            dgvBill.Location = new Point(12, 44);
            dgvBill.Name = "dgvBill";
            dgvBill.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBill.RowTemplate.Height = 35;
            dgvBill.Size = new Size(1073, 550);
            dgvBill.TabIndex = 10;
            dgvBill.CellContentClick += dgvBill_CellContentClick_1;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            id.DataPropertyName = "Id";
            id.FillWeight = 30F;
            id.HeaderText = "STT";
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // total_passenger
            // 
            total_passenger.HeaderText = "Tổng Khách Hàng";
            total_passenger.Name = "total_passenger";
            total_passenger.Width = 200;
            // 
            // total_price
            // 
            total_price.HeaderText = "Tổng tiền";
            total_price.Name = "total_price";
            total_price.Width = 200;
            // 
            // invoice_issuer
            // 
            invoice_issuer.HeaderText = "Người xuất";
            invoice_issuer.Name = "invoice_issuer";
            invoice_issuer.Width = 300;
            // 
            // action
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = resources.GetObject("dataGridViewCellStyle2.NullValue");
            dataGridViewCellStyle2.Padding = new Padding(8);
            action.DefaultCellStyle = dataGridViewCellStyle2;
            action.HeaderText = "";
            action.Image = (Image)resources.GetObject("action.Image");
            action.ImageLayout = DataGridViewImageCellLayout.Zoom;
            action.Name = "action";
            action.Resizable = DataGridViewTriState.True;
            // 
            // BillForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1101, 603);
            Controls.Add(dgvBill);
            Controls.Add(searchButton);
            Controls.Add(searchTextbox);
            Controls.Add(refershButton);
            Controls.Add(createBillButton);
            Controls.Add(titleLabel);
            Name = "BillForm";
            Text = "BillForm";
            ((System.ComponentModel.ISupportInitialize)dgvBill).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private FontAwesome.Sharp.IconButton searchButton;
        private TextBox searchTextbox;
        private FontAwesome.Sharp.IconButton refershButton;
        private FontAwesome.Sharp.IconButton createBillButton;
        private DataGridView dgvBill;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn total_passenger;
        private DataGridViewTextBoxColumn total_price;
        private DataGridViewTextBoxColumn invoice_issuer;
        private DataGridViewImageColumn action;
    }
}