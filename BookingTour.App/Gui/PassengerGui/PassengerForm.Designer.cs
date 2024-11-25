namespace BookingTour.App.Gui.PassengerGui
{
    partial class PassengerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PassengerForm));
            titleLabel = new Label();
            searchButton = new FontAwesome.Sharp.IconButton();
            searchTextbox = new TextBox();
            refershButton = new FontAwesome.Sharp.IconButton();
            createPassengerButton = new FontAwesome.Sharp.IconButton();
            dgvPassenger = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            phoneNumber = new DataGridViewTextBoxColumn();
            age = new DataGridViewTextBoxColumn();
            action = new DataGridViewImageColumn();
            ImportExcel = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dgvPassenger).BeginInit();
            SuspendLayout();
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(12, 9);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(190, 18);
            titleLabel.TabIndex = 3;
            titleLabel.Text = "Danh sách khách hàng";
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
            searchButton.Location = new Point(854, 12);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(79, 29);
            searchButton.TabIndex = 8;
            searchButton.Text = "Tìm";
            searchButton.UseVisualStyleBackColor = false;
            // 
            // searchTextbox
            // 
            searchTextbox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchTextbox.Location = new Point(617, 15);
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
            refershButton.Location = new Point(939, 11);
            refershButton.Name = "refershButton";
            refershButton.Size = new Size(79, 29);
            refershButton.TabIndex = 5;
            refershButton.Text = "Làm mới";
            refershButton.UseVisualStyleBackColor = false;
            // 
            // createPassengerButton
            // 
            createPassengerButton.BackColor = Color.FromArgb(21, 128, 61);
            createPassengerButton.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            createPassengerButton.FlatAppearance.BorderSize = 2;
            createPassengerButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createPassengerButton.ForeColor = SystemColors.ButtonFace;
            createPassengerButton.IconChar = FontAwesome.Sharp.IconChar.None;
            createPassengerButton.IconColor = Color.Black;
            createPassengerButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            createPassengerButton.Location = new Point(1018, 11);
            createPassengerButton.Name = "createPassengerButton";
            createPassengerButton.Size = new Size(79, 29);
            createPassengerButton.TabIndex = 6;
            createPassengerButton.Text = "Mới";
            createPassengerButton.UseVisualStyleBackColor = false;
            createPassengerButton.Click += createPassengerButton_Click;
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
            dgvPassenger.Columns.AddRange(new DataGridViewColumn[] { id, name, email, phoneNumber, age, action });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvPassenger.DefaultCellStyle = dataGridViewCellStyle3;
            dgvPassenger.Location = new Point(12, 47);
            dgvPassenger.Name = "dgvPassenger";
            dgvPassenger.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPassenger.RowTemplate.Height = 35;
            dgvPassenger.Size = new Size(1085, 550);
            dgvPassenger.TabIndex = 9;
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
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name.DataPropertyName = "Name";
            name.HeaderText = "Họ và tên";
            name.Name = "name";
            // 
            // email
            // 
            email.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            email.DataPropertyName = "Email";
            email.HeaderText = "Email";
            email.Name = "email";
            // 
            // phoneNumber
            // 
            phoneNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            phoneNumber.DataPropertyName = "PhoneNumber";
            phoneNumber.HeaderText = "Số điện thoại";
            phoneNumber.Name = "phoneNumber";
            // 
            // age
            // 
            age.DataPropertyName = "Age";
            age.FillWeight = 50F;
            age.HeaderText = "Tuổi";
            age.Name = "age";
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
            action.Width = 50;
            // 
            // ImportExcel
            // 
            ImportExcel.BackColor = Color.FromArgb(21, 128, 61);
            ImportExcel.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            ImportExcel.FlatAppearance.BorderSize = 2;
            ImportExcel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ImportExcel.ForeColor = SystemColors.ButtonFace;
            ImportExcel.IconChar = FontAwesome.Sharp.IconChar.None;
            ImportExcel.IconColor = Color.Black;
            ImportExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ImportExcel.Location = new Point(532, 12);
            ImportExcel.Name = "ImportExcel";
            ImportExcel.Size = new Size(79, 29);
            ImportExcel.TabIndex = 10;
            ImportExcel.Text = "Import";
            ImportExcel.UseVisualStyleBackColor = false;
            ImportExcel.Click += ImportExcel_Click;
            // 
            // PassengerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1111, 593);
            Controls.Add(ImportExcel);
            Controls.Add(dgvPassenger);
            Controls.Add(searchButton);
            Controls.Add(searchTextbox);
            Controls.Add(refershButton);
            Controls.Add(createPassengerButton);
            Controls.Add(titleLabel);
            Name = "PassengerForm";
            Text = "PassengerForm";
            ((System.ComponentModel.ISupportInitialize)dgvPassenger).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label titleLabel;
        private FontAwesome.Sharp.IconButton searchButton;
        private TextBox searchTextbox;
        private FontAwesome.Sharp.IconButton refershButton;
        private FontAwesome.Sharp.IconButton createPassengerButton;
        private DataGridView dgvPassenger;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn phoneNumber;
        private DataGridViewTextBoxColumn age;
        private DataGridViewImageColumn action;
        private FontAwesome.Sharp.IconButton ImportExcel;
    }
}