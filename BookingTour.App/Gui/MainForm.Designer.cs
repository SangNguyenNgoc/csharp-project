using BookingTour.App.Context;
using BookingTour.App.Models;
using FontAwesome.Sharp;

namespace BookingTour.App.Gui
{
    partial class MainForm
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
            panelMenu = new Panel();
            panelLogo = new Panel();
            logoButton = new FontAwesome.Sharp.IconButton();
            iconButtonAccount = new FontAwesome.Sharp.IconButton();
            iconButtonGuide = new FontAwesome.Sharp.IconButton();
            iconButtonLocation = new FontAwesome.Sharp.IconButton();
            iconButtonService = new FontAwesome.Sharp.IconButton();
            iconButtonStatistic = new FontAwesome.Sharp.IconButton();
            iconButtonSchedule = new FontAwesome.Sharp.IconButton();
            iconButtonBill = new FontAwesome.Sharp.IconButton();
            iconButtonCustomer = new FontAwesome.Sharp.IconButton();
            iconButtonTravel = new FontAwesome.Sharp.IconButton();
            iconSplitButton1 = new FontAwesome.Sharp.IconSplitButton();
            panelTop = new Panel();
            accountButton = new FontAwesome.Sharp.IconButton();
            mySqlConnection1 = new MySqlConnector.MySqlConnection();
            contentPanel = new Panel();
            titleLabel = new Label();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(30, 40, 59);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(170, 661);
            panelMenu.TabIndex = 0;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(logoButton);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(170, 79);
            panelLogo.TabIndex = 0;
            // 
            // logoButton
            // 
            logoButton.BackColor = Color.FromArgb(30, 40, 59);
            logoButton.Dock = DockStyle.Top;
            logoButton.FlatAppearance.BorderSize = 0;
            logoButton.FlatStyle = FlatStyle.Flat;
            logoButton.Font = new Font("Berlin Sans FB Demi", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoButton.ForeColor = SystemColors.Control;
            logoButton.IconChar = FontAwesome.Sharp.IconChar.CaretDown;
            logoButton.IconColor = Color.Gray;
            logoButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            logoButton.IconSize = 20;
            logoButton.Location = new Point(0, 0);
            logoButton.Name = "logoButton";
            logoButton.Size = new Size(170, 51);
            logoButton.TabIndex = 0;
            logoButton.Text = "TRAVEL LIFE";
            logoButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            logoButton.UseVisualStyleBackColor = false;
            // 
            // iconButtonAccount
            // 
            iconButtonAccount.Cursor = Cursors.Hand;
            iconButtonAccount.Dock = DockStyle.Top;
            iconButtonAccount.FlatAppearance.BorderSize = 0;
            iconButtonAccount.FlatStyle = FlatStyle.Flat;
            iconButtonAccount.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            iconButtonAccount.ForeColor = SystemColors.Control;
            iconButtonAccount.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            iconButtonAccount.IconColor = Color.FromArgb(20, 184, 166);
            iconButtonAccount.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonAccount.IconSize = 20;
            iconButtonAccount.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonAccount.Location = new Point(0, 319);
            iconButtonAccount.Name = "iconButtonAccount";
            iconButtonAccount.Padding = new Padding(10, 0, 0, 0);
            iconButtonAccount.Size = new Size(170, 40);
            iconButtonAccount.TabIndex = 7;
            iconButtonAccount.Text = "   Tài khoản";
            iconButtonAccount.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonAccount.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonAccount.UseVisualStyleBackColor = true;
            iconButtonAccount.Click += iconButtonAccount_Click;
            //
            // iconButtonGuide
            //
            iconButtonGuide.Cursor = Cursors.Hand;
            iconButtonGuide.Dock = DockStyle.Top;
            iconButtonGuide.FlatAppearance.BorderSize = 0;
            iconButtonGuide.FlatStyle = FlatStyle.Flat;
            iconButtonGuide.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            iconButtonGuide.ForeColor = SystemColors.Control;
            iconButtonGuide.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            iconButtonGuide.IconColor = Color.FromArgb(20, 184, 166);
            iconButtonGuide.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonGuide.IconSize = 20;
            iconButtonGuide.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonGuide.Location = new Point(0, 319);
            iconButtonGuide.Name = "iconButtonGuide";
            iconButtonGuide.Padding = new Padding(10, 0, 0, 0);
            iconButtonGuide.Size = new Size(170, 40);
            iconButtonGuide.TabIndex = 7;
            iconButtonGuide.Text = "   Hướng dẫn viên";
            iconButtonGuide.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonGuide.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonGuide.UseVisualStyleBackColor = true;
            iconButtonGuide.Click += iconButtonGuide_Click;
            // 
            // iconButtonLocation
            // 
            iconButtonLocation.Cursor = Cursors.Hand;
            iconButtonLocation.Dock = DockStyle.Top;
            iconButtonLocation.FlatAppearance.BorderSize = 0;
            iconButtonLocation.FlatStyle = FlatStyle.Flat;
            iconButtonLocation.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            iconButtonLocation.ForeColor = SystemColors.Control;
            iconButtonLocation.IconChar = FontAwesome.Sharp.IconChar.LocationArrow;
            iconButtonLocation.IconColor = Color.FromArgb(20, 184, 166);
            iconButtonLocation.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonLocation.IconSize = 20;
            iconButtonLocation.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonLocation.Location = new Point(0, 279);
            iconButtonLocation.Name = "iconButtonLocation";
            iconButtonLocation.Padding = new Padding(10, 0, 0, 0);
            iconButtonLocation.Size = new Size(170, 40);
            iconButtonLocation.TabIndex = 6;
            iconButtonLocation.Text = "   Địa điểm";
            iconButtonLocation.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonLocation.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonLocation.UseVisualStyleBackColor = true;
            iconButtonLocation.Click += iconButtonLocation_Click;
            // 
            // iconButtonService
            // 
            iconButtonService.Cursor = Cursors.Hand;
            iconButtonService.Dock = DockStyle.Top;
            iconButtonService.FlatAppearance.BorderSize = 0;
            iconButtonService.FlatStyle = FlatStyle.Flat;
            iconButtonService.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            iconButtonService.ForeColor = SystemColors.Control;
            iconButtonService.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            iconButtonService.IconColor = Color.FromArgb(20, 184, 166);
            iconButtonService.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonService.IconSize = 20;
            iconButtonService.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonService.Location = new Point(0, 239);
            iconButtonService.Name = "iconButtonService";
            iconButtonService.Padding = new Padding(10, 0, 0, 0);
            iconButtonService.Size = new Size(170, 40);
            iconButtonService.TabIndex = 5;
            iconButtonService.Text = "   Dịch vụ";
            iconButtonService.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonService.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonService.UseVisualStyleBackColor = true;
            iconButtonService.Click += iconButtonService_Click;
            // 
            // iconButtonStatistic
            // 
            iconButtonService.Cursor = Cursors.Hand;
            iconButtonService.Dock = DockStyle.Top;
            iconButtonService.FlatAppearance.BorderSize = 0;
            iconButtonService.FlatStyle = FlatStyle.Flat;
            iconButtonService.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            iconButtonService.ForeColor = SystemColors.Control;
            iconButtonService.IconChar = FontAwesome.Sharp.IconChar.ChartSimple;
            iconButtonService.IconColor = Color.FromArgb(20, 184, 166);
            iconButtonService.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonService.IconSize = 20;
            iconButtonService.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonService.Location = new Point(0, 239);
            iconButtonService.Name = "iconButtonStatistic";
            iconButtonService.Padding = new Padding(10, 0, 0, 0);
            iconButtonService.Size = new Size(170, 40);
            iconButtonService.TabIndex = 5;
            iconButtonService.Text = "   Thống kê";
            iconButtonService.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonService.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonService.UseVisualStyleBackColor = true;
            iconButtonService.Click += iconButtonStatistic_Click;
            // 
            // iconButtonSchedule
            // 
            iconButtonSchedule.Cursor = Cursors.Hand;
            iconButtonSchedule.Dock = DockStyle.Top;
            iconButtonSchedule.FlatAppearance.BorderSize = 0;
            iconButtonSchedule.FlatStyle = FlatStyle.Flat;
            iconButtonSchedule.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            iconButtonSchedule.ForeColor = SystemColors.Control;
            iconButtonSchedule.IconChar = FontAwesome.Sharp.IconChar.CalendarWeek;
            iconButtonSchedule.IconColor = Color.FromArgb(20, 184, 166);
            iconButtonSchedule.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonSchedule.IconSize = 20;
            iconButtonSchedule.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonSchedule.Location = new Point(0, 199);
            iconButtonSchedule.Name = "iconButtonSchedule";
            iconButtonSchedule.Padding = new Padding(10, 0, 0, 0);
            iconButtonSchedule.Size = new Size(170, 40);
            iconButtonSchedule.TabIndex = 4;
            iconButtonSchedule.Text = "   Lịch trình";
            iconButtonSchedule.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonSchedule.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonSchedule.UseVisualStyleBackColor = true;
            iconButtonSchedule.Click += iconButtonSchedule_Click;
            // 
            // iconButtonBill
            // 
            iconButtonBill.Cursor = Cursors.Hand;
            iconButtonBill.Dock = DockStyle.Top;
            iconButtonBill.FlatAppearance.BorderSize = 0;
            iconButtonBill.FlatStyle = FlatStyle.Flat;
            iconButtonBill.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            iconButtonBill.ForeColor = SystemColors.Control;
            iconButtonBill.IconChar = FontAwesome.Sharp.IconChar.CreditCard;
            iconButtonBill.IconColor = Color.FromArgb(20, 184, 166);
            iconButtonBill.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonBill.IconSize = 20;
            iconButtonBill.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonBill.Location = new Point(0, 159);
            iconButtonBill.Name = "iconButtonBill";
            iconButtonBill.Padding = new Padding(10, 0, 0, 0);
            iconButtonBill.Size = new Size(170, 40);
            iconButtonBill.TabIndex = 3;
            iconButtonBill.Text = "   Hóa đơn";
            iconButtonBill.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonBill.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonBill.UseVisualStyleBackColor = true;
            iconButtonBill.Click += iconButtonBill_Click;
            // 
            // iconButtonCustomer
            // 
            iconButtonCustomer.Cursor = Cursors.Hand;
            iconButtonCustomer.Dock = DockStyle.Top;
            iconButtonCustomer.FlatAppearance.BorderSize = 0;
            iconButtonCustomer.FlatStyle = FlatStyle.Flat;
            iconButtonCustomer.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            iconButtonCustomer.ForeColor = SystemColors.Control;
            iconButtonCustomer.IconChar = FontAwesome.Sharp.IconChar.User;
            iconButtonCustomer.IconColor = Color.FromArgb(20, 184, 166);
            iconButtonCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonCustomer.IconSize = 20;
            iconButtonCustomer.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonCustomer.Location = new Point(0, 119);
            iconButtonCustomer.Name = "iconButtonCustomer";
            iconButtonCustomer.Padding = new Padding(10, 0, 0, 0);
            iconButtonCustomer.Size = new Size(170, 40);
            iconButtonCustomer.TabIndex = 2;
            iconButtonCustomer.Text = "   Khách hàng";
            iconButtonCustomer.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonCustomer.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonCustomer.UseVisualStyleBackColor = true;
            iconButtonCustomer.Click += iconButtonCustomer_Click;
            // 
            // iconButtonTravel
            // 
            iconButtonTravel.Cursor = Cursors.Hand;
            iconButtonTravel.Dock = DockStyle.Top;
            iconButtonTravel.FlatAppearance.BorderSize = 0;
            iconButtonTravel.FlatStyle = FlatStyle.Flat;
            iconButtonTravel.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold);
            iconButtonTravel.ForeColor = SystemColors.Control;
            iconButtonTravel.IconChar = FontAwesome.Sharp.IconChar.Subway;
            iconButtonTravel.IconColor = Color.FromArgb(20, 184, 166);
            iconButtonTravel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButtonTravel.IconSize = 20;
            iconButtonTravel.ImageAlign = ContentAlignment.MiddleLeft;
            iconButtonTravel.Location = new Point(0, 79);
            iconButtonTravel.Name = "iconButtonTravel";
            iconButtonTravel.Padding = new Padding(10, 0, 0, 0);
            iconButtonTravel.Size = new Size(170, 40);
            iconButtonTravel.TabIndex = 1;
            iconButtonTravel.Text = "   Chuyến đi";
            iconButtonTravel.TextAlign = ContentAlignment.MiddleLeft;
            iconButtonTravel.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButtonTravel.UseVisualStyleBackColor = true;
            iconButtonTravel.Click += iconButtonTravel_Click;
            // 
            // iconSplitButton1
            // 
            iconSplitButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            iconSplitButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconSplitButton1.IconColor = Color.Black;
            iconSplitButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconSplitButton1.IconSize = 48;
            iconSplitButton1.Name = "iconSplitButton1";
            iconSplitButton1.Rotation = 0D;
            iconSplitButton1.Size = new Size(23, 23);
            iconSplitButton1.Text = "iconSplitButton1";
            // 
            // panelTop
            // 
            panelTop.BackColor = Color.White;
            panelTop.Controls.Add(titleLabel);
            panelTop.Controls.Add(accountButton);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(170, 0);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(0, 0, 20, 0);
            panelTop.Size = new Size(1014, 50);
            panelTop.TabIndex = 1;
            // 
            // accountButton
            // 
            accountButton.Dock = DockStyle.Right;
            accountButton.FlatAppearance.BorderSize = 0;
            accountButton.FlatStyle = FlatStyle.Flat;
            accountButton.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            accountButton.IconColor = Color.Black;
            accountButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            accountButton.IconSize = 36;
            accountButton.Location = new Point(853, 0);
            accountButton.Name = "accountButton";
            accountButton.Size = new Size(141, 50);
            accountButton.TabIndex = 1;
            accountButton.Text = "Tên người dùng";
            accountButton.TextImageRelation = TextImageRelation.TextBeforeImage;
            accountButton.UseVisualStyleBackColor = true;
            // 
            // mySqlConnection1
            // 
            mySqlConnection1.ProvideClientCertificatesCallback = null;
            mySqlConnection1.ProvidePasswordCallback = null;
            mySqlConnection1.RemoteCertificateValidationCallback = null;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = SystemColors.Control;
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(170, 50);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1014, 611);
            contentPanel.TabIndex = 2;
            // 
            // titleLabel
            // 
            titleLabel.AutoSize = true;
            titleLabel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.Location = new Point(15, 14);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(64, 21);
            titleLabel.TabIndex = 2;
            titleLabel.Text = "Tiêu đề";
            // 
            // MainForm
            // 
            BackColor = SystemColors.Control;
            ClientSize = new Size(1184, 661);
            Controls.Add(contentPanel);
            Controls.Add(panelTop);
            Controls.Add(panelMenu);
            Cursor = Cursors.Hand;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += MainForm_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion


        private Panel panelMenu;
        private FontAwesome.Sharp.IconButton iconButtonTravel;
        private Panel panelLogo;
        private FontAwesome.Sharp.IconButton iconButtonService;
        private FontAwesome.Sharp.IconButton iconButtonSchedule;
        private FontAwesome.Sharp.IconButton iconButtonBill;
        private FontAwesome.Sharp.IconButton iconButtonCustomer;
        private FontAwesome.Sharp.IconButton iconButtonAccount;
        private FontAwesome.Sharp.IconButton iconButtonLocation;
        private FontAwesome.Sharp.IconButton iconButtonGuide;
        private FontAwesome.Sharp.IconButton iconButtonStatistic;
        private FontAwesome.Sharp.IconSplitButton iconSplitButton1;
        private Panel panelTop;
        private FontAwesome.Sharp.IconButton logoButton;
        private FontAwesome.Sharp.IconButton accountButton;
        private MySqlConnector.MySqlConnection mySqlConnection1;
        private Panel contentPanel;
        private Label titleLabel;
    }
}