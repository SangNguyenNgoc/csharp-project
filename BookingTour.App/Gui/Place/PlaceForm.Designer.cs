namespace BookingTour.App.Gui.Place
{
    partial class PlaceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaceForm));
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            action = new DataGridViewImageColumn();
            searchButton = new FontAwesome.Sharp.IconButton();
            searchTextbox = new TextBox();
            titleLabel = new Label();
            refershButton = new FontAwesome.Sharp.IconButton();
            createPlaceButton = new Button();
            dataGridView2 = new DataGridView();
            AcId = new DataGridViewTextBoxColumn();
            AcName = new DataGridViewTextBoxColumn();
            AcAction = new DataGridViewImageColumn();
            label1 = new Label();
            addActivityButton = new Button();
            searchActivityButton = new FontAwesome.Sharp.IconButton();
            searchActivityTextbox = new TextBox();
            refreshActivityButton = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.BackgroundColor = Color.FromArgb(244, 243, 247);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 35;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, name, action });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Location = new Point(13, 86);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView1.RowTemplate.Height = 35;
            dataGridView1.Size = new Size(420, 505);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
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
            name.HeaderText = "Tên địa điểm";
            name.Name = "name";
            // 
            // action
            // 
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.NullValue = null;
            dataGridViewCellStyle2.Padding = new Padding(8);
            action.DefaultCellStyle = dataGridViewCellStyle2;
            action.HeaderText = "";
            action.Image = (Image)resources.GetObject("action.Image");
            action.ImageLayout = DataGridViewImageCellLayout.Zoom;
            action.Name = "action";
            action.Resizable = DataGridViewTriState.True;
            action.Width = 50;
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
            searchButton.Location = new Point(204, 51);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(52, 29);
            searchButton.TabIndex = 9;
            searchButton.Text = "Tìm";
            searchButton.UseVisualStyleBackColor = false;
            searchButton.Click += searchButton_Click;
            // 
            // searchTextbox
            // 
            searchTextbox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchTextbox.Location = new Point(13, 54);
            searchTextbox.Name = "searchTextbox";
            searchTextbox.Size = new Size(185, 25);
            searchTextbox.TabIndex = 8;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(12, 24);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(166, 18);
            titleLabel.TabIndex = 7;
            titleLabel.Text = "Danh sách địa điểm";
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
            refershButton.Location = new Point(273, 50);
            refershButton.Name = "refershButton";
            refershButton.Size = new Size(79, 29);
            refershButton.TabIndex = 5;
            refershButton.Text = "Làm mới";
            refershButton.UseVisualStyleBackColor = false;
            refershButton.Click += refreshButton_Click;
            // 
            // createPlaceButton
            // 
            createPlaceButton.BackColor = Color.FromArgb(21, 128, 61);
            createPlaceButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createPlaceButton.ForeColor = SystemColors.ButtonHighlight;
            createPlaceButton.Location = new Point(358, 51);
            createPlaceButton.Name = "createPlaceButton";
            createPlaceButton.Size = new Size(75, 29);
            createPlaceButton.TabIndex = 11;
            createPlaceButton.Text = "Mới";
            createPlaceButton.UseVisualStyleBackColor = false;
            createPlaceButton.Click += createPlaceButton_Click;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.BackgroundColor = Color.FromArgb(244, 243, 247);
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView2.ColumnHeadersHeight = 35;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { AcId, AcName, AcAction });
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Window;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle6.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.False;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridView2.Location = new Point(453, 86);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView2.RowTemplate.Height = 35;
            dataGridView2.Size = new Size(533, 505);
            dataGridView2.TabIndex = 12;
            dataGridView2.CellContentClick += DataGridView2_CellContentClick;
            // 
            // AcId
            // 
            AcId.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AcId.DataPropertyName = "Id";
            AcId.FillWeight = 26.5306129F;
            AcId.HeaderText = "STT";
            AcId.Name = "AcId";
            AcId.ReadOnly = true;
            // 
            // AcName
            // 
            AcName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            AcName.DataPropertyName = "Name";
            AcName.FillWeight = 103.4694F;
            AcName.HeaderText = "Tên hoạt động";
            AcName.Name = "AcName";
            // 
            // AcAction
            // 
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.Padding = new Padding(8);
            AcAction.DefaultCellStyle = dataGridViewCellStyle5;
            AcAction.HeaderText = "";
            AcAction.Image = (Image)resources.GetObject("AcAction.Image");
            AcAction.ImageLayout = DataGridViewImageCellLayout.Zoom;
            AcAction.Name = "AcAction";
            AcAction.Resizable = DataGridViewTriState.True;
            AcAction.Width = 50;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(453, 24);
            label1.Name = "label1";
            label1.Size = new Size(268, 18);
            label1.TabIndex = 13;
            label1.Text = "Danh sách hoạt động tương ứng";
            // 
            // addActivityButton
            // 
            addActivityButton.BackColor = Color.FromArgb(21, 128, 61);
            addActivityButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addActivityButton.ForeColor = SystemColors.ButtonHighlight;
            addActivityButton.Location = new Point(911, 50);
            addActivityButton.Name = "addActivityButton";
            addActivityButton.Size = new Size(75, 29);
            addActivityButton.TabIndex = 17;
            addActivityButton.Text = "Mới";
            addActivityButton.UseVisualStyleBackColor = false;
            addActivityButton.Click += addActivityButton_Click;
            // 
            // searchActivityButton
            // 
            searchActivityButton.BackColor = Color.Transparent;
            searchActivityButton.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            searchActivityButton.FlatAppearance.BorderSize = 2;
            searchActivityButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchActivityButton.ForeColor = Color.FromArgb(64, 64, 64);
            searchActivityButton.IconChar = FontAwesome.Sharp.IconChar.None;
            searchActivityButton.IconColor = Color.Black;
            searchActivityButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            searchActivityButton.Location = new Point(687, 50);
            searchActivityButton.Name = "searchActivityButton";
            searchActivityButton.Size = new Size(52, 29);
            searchActivityButton.TabIndex = 16;
            searchActivityButton.Text = "Tìm";
            searchActivityButton.UseVisualStyleBackColor = false;
            searchActivityButton.Click += searchActivityButton_Click;
            // 
            // searchActivityTextbox
            // 
            searchActivityTextbox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchActivityTextbox.Location = new Point(453, 51);
            searchActivityTextbox.Name = "searchActivityTextbox";
            searchActivityTextbox.Size = new Size(228, 25);
            searchActivityTextbox.TabIndex = 15;
            // 
            // refreshActivityButton
            // 
            refreshActivityButton.BackColor = Color.Transparent;
            refreshActivityButton.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            refreshActivityButton.FlatAppearance.BorderSize = 2;
            refreshActivityButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            refreshActivityButton.ForeColor = SystemColors.ActiveCaptionText;
            refreshActivityButton.IconChar = FontAwesome.Sharp.IconChar.None;
            refreshActivityButton.IconColor = Color.Black;
            refreshActivityButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            refreshActivityButton.Location = new Point(826, 49);
            refreshActivityButton.Name = "refreshActivityButton";
            refreshActivityButton.Size = new Size(79, 29);
            refreshActivityButton.TabIndex = 14;
            refreshActivityButton.Text = "Làm mới";
            refreshActivityButton.UseVisualStyleBackColor = false;
            refreshActivityButton.Click += refreshActivityButton_Click;
            // 
            // PlaceForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(244, 243, 247);
            ClientSize = new Size(998, 617);
            Controls.Add(addActivityButton);
            Controls.Add(searchActivityButton);
            Controls.Add(searchActivityTextbox);
            Controls.Add(refreshActivityButton);
            Controls.Add(label1);
            Controls.Add(dataGridView2);
            Controls.Add(createPlaceButton);
            Controls.Add(searchButton);
            Controls.Add(searchTextbox);
            Controls.Add(titleLabel);
            Controls.Add(refershButton);
            Controls.Add(dataGridView1);
            Name = "PlaceForm";
            Text = "PlaceForm";
            Load += PlaceForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewImageColumn action;
        private FontAwesome.Sharp.IconButton searchButton;
        private TextBox searchTextbox;
        private Label titleLabel;
        private FontAwesome.Sharp.IconButton refershButton;
        private Button createPlaceButton;
        private DataGridView dataGridView2;
        private Label label1;
        private Button addActivityButton;
        private FontAwesome.Sharp.IconButton searchActivityButton;
        private TextBox searchActivityTextbox;
        private FontAwesome.Sharp.IconButton refreshActivityButton;
        private DataGridViewTextBoxColumn AcId;
        private DataGridViewTextBoxColumn AcName;
        private DataGridViewImageColumn AcAction;
    }
}