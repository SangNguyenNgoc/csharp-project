using FontAwesome.Sharp;
using System.Diagnostics;
using BookingTour.App.Models;
using MySqlX.XDevAPI;
using Session = BookingTour.App.Context.Session;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

namespace BookingTour.App.Gui;

public partial class MainForm : Form
{

    private IconButton? _currentButton;
    private readonly Panel _leftBorderBtn;

    public MainForm()
    {
        InitializeComponent();
        _leftBorderBtn = new Panel
        {
            Size = new Size(4, 40)
        };
        panelMenu.Controls.Add(_leftBorderBtn);
        AutoScaleMode = AutoScaleMode.Dpi;
        InitLeftMenu();
        InitializeDropdownButton();
    }

    private void InitializeDropdownButton()
    {
        ContextMenuStrip contextMenu = new();
        contextMenu.Items.Add("Thông tin");
        contextMenu.Items.Add("Đăng xuất").Click += (s, ev) => Logout();

        accountButton.Click += (sender, e) => {
            contextMenu.Show(accountButton, new Point(-(contextMenu.Width-accountButton.Width), accountButton.Height));
        };
    }

    private void InitLeftMenu()
    {
        var role = Session.Get<User>("CurrentUser")?.Role?.Name;
        if (role == "ADMIN")
        {
            panelMenu.Controls.Add(iconButtonAccount);
            panelMenu.Controls.Add(iconButtonLocation);
            panelMenu.Controls.Add(iconButtonService);
            panelMenu.Controls.Add(iconButtonSchedule);
        }
        if (role == "ADMIN" || role == "STAFF")
        {
            panelMenu.Controls.Add(iconButtonBill);
            panelMenu.Controls.Add(iconButtonCustomer);
            panelMenu.Controls.Add(iconButtonTravel);
        }
       
        panelMenu.Controls.Add(panelLogo);

    }

    private void ActiveButton(object senderBtn)
    {
        var color = Color.FromArgb(20, 184, 166);
        DisableButton();
        _currentButton = (IconButton)senderBtn;
        _currentButton.BackColor = Color.FromArgb(26, 34, 49);
        _currentButton.TextAlign = ContentAlignment.MiddleCenter;
        _currentButton.IconColor = color;
        _currentButton.Padding = new Padding(20, 0, 0, 0);

        _leftBorderBtn.BackColor = color;
        _leftBorderBtn.Location = new Point(0, _currentButton.Location.Y);
        _leftBorderBtn.Visible = true;
        _leftBorderBtn.BringToFront();
    }

    private void DisableButton()
    {
        if (_currentButton == null) return;
        var color = Color.FromArgb(20, 184, 166);
        _currentButton.BackColor = Color.FromArgb(30, 40, 59);
        _currentButton.ForeColor = Color.White;
        _currentButton.TextAlign = ContentAlignment.MiddleLeft;
        _currentButton.IconColor = color;
        _currentButton.Padding = new Padding(10, 0, 0, 0);
        _currentButton.TextImageRelation = TextImageRelation.ImageBeforeText;
        _currentButton.ImageAlign = ContentAlignment.MiddleLeft;

    }

    private void iconButtonTravel_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
    }

    private void iconButtonCustomer_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
    }

    private void iconButtonBill_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
    }

    private void iconButtonSchedule_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
    }

    private void iconButtonService_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
    }

    private void iconButtonLocation_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
    }

    private void iconButtonAccount_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
    }

    private void panelMenu_Paint(object sender, PaintEventArgs e)
    {

    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        using var g = this.CreateGraphics();
        var dpiX = g.DpiX;  // Lấy DPI của màn hình hiện tại
        var scaleFactor = dpiX / 96.0f; // Tính tỷ lệ so với DPI chuẩn (96 DPI)

        ScaleControls(this, scaleFactor);
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        Application.Exit();
    }

    private void ScaleControls(Control parent, float scaleFactor)
    {
        foreach (Control control in parent.Controls)
        {
            // Điều chỉnh kích thước và vị trí
            control.Width = (int)(control.Width * scaleFactor);
            control.Height = (int)(control.Height * scaleFactor);
            control.Location = new Point((int)(control.Location.X * scaleFactor),
                                         (int)(control.Location.Y * scaleFactor));


            if (control is IconButton iconButton)
            {
                iconButton.IconSize = (int)(iconButton.IconSize * scaleFactor);
            }

            // Nếu control có children, gọi đệ quy
            if (control.HasChildren)
            {
                ScaleControls(control, scaleFactor);
            }
        }
    }

    private void Logout()
    {
        Session.Remove("CurrentUser");
        DialogResult = DialogResult.Abort;
        Close();
    }
}