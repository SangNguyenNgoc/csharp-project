using BookingTour.App.Bus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookingTour.App.Context;

namespace BookingTour.App.Gui;

public partial class LoginForm : Form
{

    public LoginForm()
    {
        InitializeComponent();
    }

    private void LoginForm_Load(object sender, EventArgs e)
    {
        using var g = CreateGraphics();
        var dpiX = g.DpiX; 
        var scaleFactor = dpiX / 96.0f;
        textBoxName.Focus();
        //ScaleControls(this, scaleFactor);
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


            if (control is FontAwesome.Sharp.IconButton iconButton)
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

    private void label3_Click(object sender, EventArgs e)
    {

    }

    private void buttonSubmit_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(textBoxPass.Text) || string.IsNullOrEmpty(textBoxName.Text)) return;
        var user = UserBus.Instance.Login(textBoxName.Text, textBoxPass.Text);
        if (user != null) 
        {
            MessageBox.Show(@"Đăng nhập thành công!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Session.Set("CurrentUser", user);
            Close();
        }
        else
        {
            MessageBox.Show(@"Mật khẩu không đúng!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}