namespace BookingTour.App.Gui.BillGui
{
    partial class AddBillForm
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            dgvPassenger = new DataGridView();
            idKH = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            join = new DataGridViewCheckBoxColumn();
            titleLabel = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            totalpriceTextbox = new TextBox();
            userIdTextBox = new TextBox();
            cancelButton = new Button();
            saveButton = new Button();
            dgvTour = new DataGridView();
            idTour = new DataGridViewTextBoxColumn();
            nameTour = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            choose = new DataGridViewCheckBoxColumn();
            buttonPDF = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPassenger).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTour).BeginInit();
            SuspendLayout();
            // 
            // dgvPassenger
            // 
            dgvPassenger.AllowUserToAddRows = false;
            dgvPassenger.BackgroundColor = Color.FromArgb(244, 243, 247);
            dgvPassenger.BorderStyle = BorderStyle.None;
            dgvPassenger.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPassenger.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPassenger.ColumnHeadersHeight = 35;
            dgvPassenger.Columns.AddRange(new DataGridViewColumn[] { idKH, name, join });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPassenger.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPassenger.Location = new Point(12, 40);
            dgvPassenger.Name = "dgvPassenger";
            dgvPassenger.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPassenger.RowTemplate.Height = 35;
            dgvPassenger.Size = new Size(358, 505);
            dgvPassenger.TabIndex = 10;
            dgvPassenger.CellContentClick += dgvPassenger_CellContentClick;
            // 
            // idKH
            // 
            idKH.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            idKH.DataPropertyName = "Id";
            idKH.FillWeight = 30F;
            idKH.HeaderText = "STT";
            idKH.Name = "idKH";
            idKH.ReadOnly = true;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name.DataPropertyName = "Name";
            name.HeaderText = "Họ và tên";
            name.Name = "name";
            // 
            // join
            // 
            join.HeaderText = "";
            join.Name = "join";
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(12, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(190, 18);
            titleLabel.TabIndex = 11;
            titleLabel.Text = "Danh sách khách hàng";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(429, 9);
            label1.Name = "label1";
            label1.Size = new Size(45, 18);
            label1.TabIndex = 12;
            label1.Text = "Tour";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(429, 172);
            label3.Name = "label3";
            label3.Size = new Size(0, 18);
            label3.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(429, 414);
            label4.Name = "label4";
            label4.Size = new Size(84, 18);
            label4.TabIndex = 15;
            label4.Text = "Tổng tiền";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(429, 466);
            label5.Name = "label5";
            label5.Size = new Size(97, 18);
            label5.TabIndex = 16;
            label5.Text = "Người xuất";
            // 
            // totalpriceTextbox
            // 
            totalpriceTextbox.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalpriceTextbox.Location = new Point(539, 410);
            totalpriceTextbox.Name = "totalpriceTextbox";
            totalpriceTextbox.ReadOnly = true;
            totalpriceTextbox.Size = new Size(295, 27);
            totalpriceTextbox.TabIndex = 20;
            // 
            // userIdTextBox
            // 
            userIdTextBox.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            userIdTextBox.Location = new Point(539, 457);
            userIdTextBox.Name = "userIdTextBox";
            userIdTextBox.ReadOnly = true;
            userIdTextBox.Size = new Size(295, 27);
            userIdTextBox.TabIndex = 21;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = Color.FromArgb(153, 27, 27);
            cancelButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelButton.ForeColor = SystemColors.ButtonHighlight;
            cancelButton.Location = new Point(737, 507);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(97, 38);
            cancelButton.TabIndex = 22;
            cancelButton.Text = "Hủy";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            // 
            // saveButton
            // 
            saveButton.BackColor = Color.FromArgb(21, 128, 61);
            saveButton.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveButton.ForeColor = SystemColors.ButtonHighlight;
            saveButton.Location = new Point(475, 507);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(96, 38);
            saveButton.TabIndex = 23;
            saveButton.Text = "Lưu";
            saveButton.UseVisualStyleBackColor = false;
            saveButton.Click += saveButton_Click;
            // 
            // dgvTour
            // 
            dgvTour.AllowUserToAddRows = false;
            dgvTour.BackgroundColor = Color.FromArgb(244, 243, 247);
            dgvTour.BorderStyle = BorderStyle.None;
            dgvTour.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvTour.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvTour.ColumnHeadersHeight = 35;
            dgvTour.Columns.AddRange(new DataGridViewColumn[] { idTour, nameTour, price, choose });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvTour.DefaultCellStyle = dataGridViewCellStyle4;
            dgvTour.Location = new Point(429, 40);
            dgvTour.Name = "dgvTour";
            dgvTour.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTour.RowTemplate.Height = 35;
            dgvTour.Size = new Size(441, 364);
            dgvTour.TabIndex = 24;
            dgvTour.CellContentClick += dgvTour_CellContentClick;
            dgvTour.CellValueChanged += dgvTour_CellValueChanged;
            dgvTour.CurrentCellDirtyStateChanged += dgvTour_CurrentCellDirtyStateChanged;
            // 
            // idTour
            // 
            idTour.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            idTour.DataPropertyName = "Id";
            idTour.FillWeight = 30F;
            idTour.HeaderText = "STT";
            idTour.Name = "idTour";
            idTour.ReadOnly = true;
            // 
            // nameTour
            // 
            nameTour.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nameTour.DataPropertyName = "Name";
            nameTour.HeaderText = "Name";
            nameTour.Name = "nameTour";
            // 
            // price
            // 
            price.HeaderText = "Giá";
            price.Name = "price";
            // 
            // choose
            // 
            choose.HeaderText = "";
            choose.Name = "choose";
            // 
            // buttonPDF
            // 
            buttonPDF.BackColor = Color.FromArgb(21, 128, 61);
            buttonPDF.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPDF.ForeColor = SystemColors.ButtonHighlight;
            buttonPDF.Location = new Point(604, 507);
            buttonPDF.Name = "buttonPDF";
            buttonPDF.Size = new Size(96, 38);
            buttonPDF.TabIndex = 25;
            buttonPDF.Text = "PDF";
            buttonPDF.UseVisualStyleBackColor = false;
            buttonPDF.Click += buttonPDF_Click;
            // 
            // AddBillForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 557);
            Controls.Add(buttonPDF);
            Controls.Add(dgvTour);
            Controls.Add(cancelButton);
            Controls.Add(saveButton);
            Controls.Add(userIdTextBox);
            Controls.Add(totalpriceTextbox);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(titleLabel);
            Controls.Add(dgvPassenger);
            Name = "AddBillForm";
            Text = "AddBillForm";
            Load += AddBillForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPassenger).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTour).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPassenger;
        private Label titleLabel;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox totalpriceTextbox;
        private TextBox userIdTextBox;
        private Button cancelButton;
        private Button saveButton;
        private DataGridView dgvTour;
        private DataGridViewTextBoxColumn idKH;
        private DataGridViewTextBoxColumn name;
        private DataGridViewCheckBoxColumn join;
        private DataGridViewTextBoxColumn idTour;
        private DataGridViewTextBoxColumn nameTour;
        private DataGridViewTextBoxColumn price;
        private DataGridViewCheckBoxColumn choose;
        private Button buttonPDF;
    }
}