using BookingTour.App.Gui.Account;
using BookingTour.App.Gui.Itinerary;
using BookingTour.App.Gui.BillGui;
using FontAwesome.Sharp;
using BookingTour.App.Models;
using Session = BookingTour.App.Context.Session;
using BookingTour.App.Gui.Place;
using BookingTour.App.Gui.Service;
using BookingTour.App.Gui.Utils;
using BookingTour.App.Gui.Tour;
using BookingTour.App.Gui.TourGui;
using BookingTour.App.Gui.PassengerGui;

namespace BookingTour.App.Gui;

public partial class MainForm : Form
{

    private IconButton? _currentButton;
    private readonly Panel _leftBorderBtn;
    private Form? _currentChildForm;

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

        OpenChildRorm(new TourForm()); // default form
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

        titleLabel.Text = _currentButton.Text;

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

    private void OpenChildRorm(Form form)
    {
        _currentChildForm?.Close();
        _currentChildForm = form;
        form.TopLevel = false;
        form.FormBorderStyle = FormBorderStyle.None;
        form.Dock = DockStyle.Fill;
        contentPanel.Controls.Add(form);
        contentPanel.Tag = form;
        form.BringToFront();
        form.Show();
    }

    private void iconButtonTravel_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
        OpenChildRorm(new TourForm());
    }

    private void iconButtonCustomer_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
        OpenChildRorm(new PassengerForm());
    }

    private void iconButtonBill_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
        OpenChildRorm(new BillForm());
    }

    private void iconButtonSchedule_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
        OpenChildRorm(new ItineraryForm());
    }

    private void iconButtonService_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
        OpenChildRorm(new ServiceForm());
    }

    private void iconButtonLocation_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
        OpenChildRorm(new PlaceForm());
    }

    private void iconButtonAccount_Click(object sender, EventArgs e)
    {
        ActiveButton(sender);
        OpenChildRorm(new AccountForm());
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        ScaleControls(this, scaleFactor);
        accountButton.Text = Session.Get<User>("CurrentUser")?.Name;
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