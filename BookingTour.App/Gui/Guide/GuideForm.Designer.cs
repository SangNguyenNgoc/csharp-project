using System.ComponentModel;

namespace BookingTour.App.Gui.Guide;

partial class GuideForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        ComponentResourceManager resources = new ComponentResourceManager(typeof(GuideForm));
        leftPanel = new Panel();
        label1 = new Label();
        refreshButton = new Button();
        dataGridView1 = new DataGridView();
        id = new DataGridViewTextBoxColumn();
        username = new DataGridViewTextBoxColumn();
        name = new DataGridViewTextBoxColumn();
        email = new DataGridViewTextBoxColumn();
        phoneNumber = new DataGridViewTextBoxColumn();
        role = new DataGridViewTextBoxColumn();
        action = new DataGridViewImageColumn();
        searchButton = new FontAwesome.Sharp.IconButton();
        searchTextbox = new TextBox();
        titleLabel = new Label();
        refershButton = new FontAwesome.Sharp.IconButton();
        createAccountButton = new FontAwesome.Sharp.IconButton();
        panel1 = new Panel();
        tourList = new ListView();
        Tour = new ColumnHeader();
        Start = new ColumnHeader();
        End = new ColumnHeader();
        addLanguageButton = new Button();
        languageList = new ListView();
        Language = new ColumnHeader();
        leftPanel.SuspendLayout();
        ((ISupportInitialize)dataGridView1).BeginInit();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // leftPanel
        // 
        leftPanel.Controls.Add(label1);
        leftPanel.Controls.Add(refreshButton);
        leftPanel.Controls.Add(dataGridView1);
        leftPanel.Controls.Add(searchButton);
        leftPanel.Controls.Add(searchTextbox);
        leftPanel.Controls.Add(titleLabel);
        leftPanel.Controls.Add(refershButton);
        leftPanel.Controls.Add(createAccountButton);
        leftPanel.Dock = DockStyle.Top;
        leftPanel.Location = new Point(0, 0);
        leftPanel.Name = "leftPanel";
        leftPanel.Size = new Size(958, 304);
        leftPanel.TabIndex = 0;
        leftPanel.Paint += leftPanel_Paint;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label1.Location = new Point(12, 16);
        label1.Name = "label1";
        label1.Size = new Size(222, 18);
        label1.TabIndex = 12;
        label1.Text = "Danh sách hướng dẫn viên";
        // 
        // refreshButton
        // 
        refreshButton.Location = new Point(853, 12);
        refreshButton.Name = "refreshButton";
        refreshButton.Size = new Size(93, 29);
        refreshButton.TabIndex = 11;
        refreshButton.Text = "Làm mới";
        refreshButton.UseVisualStyleBackColor = true;
        refreshButton.Click += refreshButton_Click;
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
        dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, username, name, email, phoneNumber, role, action });
        dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
        dataGridViewCellStyle3.BackColor = SystemColors.Window;
        dataGridViewCellStyle3.Font = new Font("Segoe UI", 10F);
        dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
        dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
        dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
        dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
        dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
        dataGridView1.Dock = DockStyle.Bottom;
        dataGridView1.Location = new Point(0, 47);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridView1.RowTemplate.Height = 35;
        dataGridView1.Size = new Size(958, 257);
        dataGridView1.TabIndex = 1;
        dataGridView1.CurrentCellChanged += dataGridView1_SelectionChanged;
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
        // username
        // 
        username.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        username.DataPropertyName = "Username";
        username.HeaderText = "Mã nhân viên";
        username.Name = "username";
        username.ReadOnly = true;
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
        // role
        // 
        role.DataPropertyName = "Role";
        role.FillWeight = 50F;
        role.HeaderText = "Vai trò";
        role.Name = "role";
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
        searchButton.Location = new Point(723, -195);
        searchButton.Name = "searchButton";
        searchButton.Size = new Size(79, 10);
        searchButton.TabIndex = 10;
        searchButton.Text = "Tìm";
        searchButton.UseVisualStyleBackColor = false;
        // 
        // searchTextbox
        // 
        searchTextbox.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
        searchTextbox.Location = new Point(486, -192);
        searchTextbox.Name = "searchTextbox";
        searchTextbox.Size = new Size(231, 25);
        searchTextbox.TabIndex = 9;
        // 
        // titleLabel
        // 
        titleLabel.AutoSize = true;
        titleLabel.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        titleLabel.Location = new Point(-8, -196);
        titleLabel.Name = "titleLabel";
        titleLabel.Size = new Size(173, 18);
        titleLabel.TabIndex = 8;
        titleLabel.Text = "Danh sách tài khoản";
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
        refershButton.Location = new Point(808, -196);
        refershButton.Name = "refershButton";
        refershButton.Size = new Size(79, 10);
        refershButton.TabIndex = 6;
        refershButton.Text = "Làm mới";
        refershButton.UseVisualStyleBackColor = false;
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
        createAccountButton.Location = new Point(887, -196);
        createAccountButton.Name = "createAccountButton";
        createAccountButton.Size = new Size(79, 10);
        createAccountButton.TabIndex = 7;
        createAccountButton.Text = "Mới";
        createAccountButton.UseVisualStyleBackColor = false;
        // 
        // panel1
        // 
        panel1.Controls.Add(tourList);
        panel1.Controls.Add(addLanguageButton);
        panel1.Controls.Add(languageList);
        panel1.Dock = DockStyle.Bottom;
        panel1.Location = new Point(0, 330);
        panel1.Name = "panel1";
        panel1.Size = new Size(958, 250);
        panel1.TabIndex = 1;
        // 
        // tourList
        // 
        tourList.Columns.AddRange(new ColumnHeader[] { Tour, Start, End });
        tourList.Dock = DockStyle.Right;
        tourList.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        tourList.GridLines = true;
        tourList.Location = new Point(412, 0);
        tourList.Name = "tourList";
        tourList.Size = new Size(546, 250);
        tourList.TabIndex = 2;
        tourList.UseCompatibleStateImageBehavior = false;
        // 
        // Tour
        // 
        Tour.Text = "Tour đã hướng dẫn";
        Tour.Width = 300;
        // 
        // Start
        // 
        Start.Text = "Ngày BD";
        Start.Width = 100;
        // 
        // End
        // 
        End.Text = "Ngày KT";
        End.Width = 100;
        // 
        // addLanguageButton
        // 
        addLanguageButton.Location = new Point(219, 14);
        addLanguageButton.Name = "addLanguageButton";
        addLanguageButton.Size = new Size(90, 30);
        addLanguageButton.TabIndex = 1;
        addLanguageButton.Text = "Thêm";
        addLanguageButton.UseVisualStyleBackColor = true;
        addLanguageButton.Click += addLanguageButton_Click;
        // 
        // languageList
        // 
        languageList.Columns.AddRange(new ColumnHeader[] { Language });
        languageList.Dock = DockStyle.Left;
        languageList.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        languageList.GridLines = true;
        languageList.Location = new Point(0, 0);
        languageList.Name = "languageList";
        languageList.Size = new Size(213, 250);
        languageList.TabIndex = 0;
        languageList.UseCompatibleStateImageBehavior = false;
        // 
        // Language
        // 
        Language.Text = "Ngôn ngữ thành thạo";
        Language.Width = 200;
        // 
        // GuideForm
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.FromArgb(244, 243, 247);
        ClientSize = new Size(958, 580);
        Controls.Add(panel1);
        Controls.Add(leftPanel);
        Name = "GuideForm";
        Text = "GuideForm";
        Load += GuideForm_Load;
        leftPanel.ResumeLayout(false);
        leftPanel.PerformLayout();
        ((ISupportInitialize)dataGridView1).EndInit();
        panel1.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private Panel leftPanel;
    private FontAwesome.Sharp.IconButton searchButton;
    private TextBox searchTextbox;
    private Label titleLabel;
    private FontAwesome.Sharp.IconButton refershButton;
    private FontAwesome.Sharp.IconButton createAccountButton;
    private Button refreshButton;
    private DataGridView dataGridView1;
    private Label label1;
    private DataGridViewTextBoxColumn id;
    private DataGridViewTextBoxColumn username;
    private DataGridViewTextBoxColumn name;
    private DataGridViewTextBoxColumn email;
    private DataGridViewTextBoxColumn phoneNumber;
    private DataGridViewTextBoxColumn role;
    private DataGridViewImageColumn action;
    private Panel panel1;
    private ListView languageList;
    private ColumnHeader Language;
    private Button addLanguageButton;
    private ListView tourList;
    private ColumnHeader Tour;
    private ColumnHeader Start;
    private ColumnHeader End;
}