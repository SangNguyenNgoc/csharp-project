namespace BookingTour.App.Gui.Itinerary
{
    partial class ItineraryForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItineraryForm));
            searchButton = new FontAwesome.Sharp.IconButton();
            searchTextbox = new TextBox();
            titleLabel = new Label();
            refershButton = new FontAwesome.Sharp.IconButton();
            createAccountButton = new FontAwesome.Sharp.IconButton();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            numberOfDays = new DataGridViewTextBoxColumn();
            vehicle = new DataGridViewTextBoxColumn();
            capacity = new DataGridViewTextBoxColumn();
            action = new DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
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
            searchButton.Location = new Point(743, 17);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(79, 29);
            searchButton.TabIndex = 10;
            searchButton.Text = "Tìm";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // searchTextbox
            // 
            searchTextbox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchTextbox.Location = new Point(506, 20);
            searchTextbox.Name = "searchTextbox";
            searchTextbox.Size = new Size(231, 25);
            searchTextbox.TabIndex = 9;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(12, 16);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(166, 18);
            titleLabel.TabIndex = 8;
            titleLabel.Text = "Danh sách lịch trình";
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
            refershButton.Location = new Point(828, 16);
            refershButton.Name = "refershButton";
            refershButton.Size = new Size(79, 29);
            refershButton.TabIndex = 6;
            refershButton.Text = "Làm mới";
            refershButton.UseVisualStyleBackColor = false;
            refershButton.Click += refreshButton_Click;
            // 
            // createAccountButton
            // 
            createAccountButton.BackColor = Color.FromArgb(21, 128, 61);
            createAccountButton.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            createAccountButton.FlatAppearance.BorderSize = 2;
            createAccountButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createAccountButton.ForeColor = SystemColors.ButtonFace;
            createAccountButton.IconChar = FontAwesome.Sharp.IconChar.None;
            createAccountButton.IconColor = Color.Black;
            createAccountButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            createAccountButton.Location = new Point(907, 16);
            createAccountButton.Name = "createAccountButton";
            createAccountButton.Size = new Size(79, 29);
            createAccountButton.TabIndex = 7;
            createAccountButton.Text = "Mới";
            createAccountButton.UseVisualStyleBackColor = false;
            createAccountButton.Click += createAccountButton_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(244, 243, 247);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 35;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, name, numberOfDays, vehicle, capacity, action });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(0, 67);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Size = new Size(998, 550);
            dataGridView1.TabIndex = 5;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
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
            name.HeaderText = "Tên";
            name.Name = "name";
            // 
            // numberOfDays
            // 
            numberOfDays.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            numberOfDays.DataPropertyName = "NumberOfDays";
            numberOfDays.HeaderText = "Số ngày đi";
            numberOfDays.Name = "numberOfDays";
            // 
            // vehicle
            // 
            vehicle.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            vehicle.DataPropertyName = "Vehicle";
            vehicle.HeaderText = "Phương tiện";
            vehicle.Name = "vehicle";
            // 
            // capacity
            // 
            capacity.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            capacity.DataPropertyName = "Capacity";
            capacity.HeaderText = "Số lượng người";
            capacity.Name = "capacity";
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
            // ItineraryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 243, 247);
            ClientSize = new Size(998, 617);
            Controls.Add(searchButton);
            Controls.Add(searchTextbox);
            Controls.Add(titleLabel);
            Controls.Add(refershButton);
            Controls.Add(createAccountButton);
            Controls.Add(dataGridView1);
            Name = "ItineraryForm";
            Text = "ItineraryForm";
            Load += ItineraryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FontAwesome.Sharp.IconButton searchButton;
        private TextBox searchTextbox;
        private Label titleLabel;
        private FontAwesome.Sharp.IconButton refershButton;
        private FontAwesome.Sharp.IconButton createAccountButton;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn numberOfDays;
        private DataGridViewTextBoxColumn vehicle;
        private DataGridViewTextBoxColumn capacity;
        private DataGridViewImageColumn action;
    }
}