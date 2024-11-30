using BookingTour.App.Bus;
using BookingTour.App.Models;

namespace BookingTour.App.Gui.Account;

public partial class AddAccountForm : Form
{
    private readonly AccountForm _parentForm;
    private readonly int? _userId;

    public AddAccountForm(AccountForm parentForm, int? userId)
    {
        InitializeComponent();
        _parentForm = parentForm;
        _userId = userId;
    }

    private void AddAccountForm_Load(object sender, EventArgs e)
    {
        usernameLabel.Focus();
        var roles = RoleBus.Instance.GetAllRoles();
        roleComboBox.DataSource = roles;
        roleComboBox.DisplayMember = "Name";
        roleComboBox.ValueMember = "Id";

        roleComboBox.SelectedIndex = 0;
        roleComboBox.SelectedIndexChanged += roleComboBox_SelectedIndexChanged;
        if (_userId != null)
        {
            InitData();
        }
    }

    private void roleComboBox_SelectedIndexChanged(object? sender, EventArgs e)
    {
        Role selectedRole = (Role)roleComboBox.SelectedItem!;

        //MessageBox.Show($@"Bạn đã chọn vai trò: {selectedRole.Name}, Id: {selectedRole.Id}");
    }

    private void saveButton_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(usernameTextbox.Text))
        {
            MessageBox.Show(@"Username không được để trống!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(nameTextbox.Text))
        {
            MessageBox.Show(@"Name không được để trống!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(mailTextbox.Text) || !IsValidEmail(mailTextbox.Text))
        {
            MessageBox.Show(@"Email không hợp lệ!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(phoneTextbox.Text) || !IsValidPhone(phoneTextbox.Text))
        {
            MessageBox.Show(@"Số điện thoại không hợp lệ!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(passTextbox.Text))
        {
            MessageBox.Show(@"Password không được để trống!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if (roleComboBox.SelectedIndex == -1)
        {
            MessageBox.Show(@"Vui lòng chọn vai trò!", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        if(_userId == null)
        {
            var user = new Models.User
            {
                Id = 0,
                Password = passTextbox.Text,
                RoleId = (int)roleComboBox.SelectedValue!,
                Role = null,
                Username = usernameTextbox.Text,
                Name = nameTextbox.Text,
                Email = mailTextbox.Text,
                PhoneNumber = phoneTextbox.Text,
                IsBlock = false,
                Bills = null,
                Guides = null
            };
            UserBus.Instance.CreateUser(user);
            MessageBox.Show(@"Người dùng đã được lưu thành công!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ResetParentForm();
        }
        else
        {
            var user = new Models.User
            {
                Id = _userId.Value,
                Password = passTextbox.Text,
                RoleId = (int)roleComboBox.SelectedValue!,
                Role = null,
                Username = usernameTextbox.Text,
                Name = nameTextbox.Text,
                Email = mailTextbox.Text,
                PhoneNumber = phoneTextbox.Text,
                IsBlock = false,
                Bills = null,
                Guides = null
            };
            UserBus.Instance.UpdateUser(user);
            MessageBox.Show(@"Người dùng đã được chỉnh sửa thành công!", @"Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        ClearForm();
    }

    private bool IsValidEmail(string email)
    {
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    private bool IsValidPhone(string phone)
    {
        return phone.All(char.IsDigit) && phone.Length is >= 10 and <= 15;
    }

    private void ClearForm()
    {
        usernameTextbox.Clear();
        nameTextbox.Clear();
        mailTextbox.Clear();
        phoneTextbox.Clear();
        passTextbox.Clear();
        roleComboBox.SelectedIndex = -1;
    }

    private void ResetParentForm()
    {
        _parentForm?.LoadUserData(null);
    }

    private void cancelButton_Click(object sender, EventArgs e)
    {
        this.Close();
    }

    private void InitData()
    {
        var user = UserBus.Instance.GetUserById(_userId!.Value);
        usernameTextbox.Text = user.Username;
        nameTextbox.Text = user.Name;
        mailTextbox.Text = user.Email;
        phoneTextbox.Text = user.PhoneNumber;
        passTextbox.PasswordChar = '\0';
        passTextbox.Text = user.Password;
        roleComboBox.SelectedValue = user.RoleId;
    }
}
