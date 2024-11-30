using BookingTour.App.Gui.Utils;

namespace BookingTour.App.Gui.Guide;

public partial class SelectLanguageForm : Form
{
    private ComboBox _comboBoxLanguages;
    private Button _btnOk;
    private Button _btnCancel;

    public string SelectedLanguage { get; private set; } 

    public SelectLanguageForm()
    {
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        this.Text = "Chọn ngôn ngữ";
        this.Size = new System.Drawing.Size((int) (300 * scaleFactor),(int) (200 * scaleFactor));
        this.StartPosition = FormStartPosition.CenterParent;

        // ComboBox chứa các ngôn ngữ
        _comboBoxLanguages = new ComboBox
        {
            Location = new System.Drawing.Point(50, 30),
            Size = new System.Drawing.Size(200, 30),
            DropDownStyle = ComboBoxStyle.DropDownList
        };

        // Danh sách ngôn ngữ thông dụng
        _comboBoxLanguages.Items.AddRange(new[]
        {
            "English", "French", "Spanish", "German", "Chinese", "Japanese", "Russian", "Arabic", "Portuguese", "Hindi"
        });
        _comboBoxLanguages.SelectedIndex = 0; // Mặc định chọn ngôn ngữ đầu tiên
        this.Controls.Add(_comboBoxLanguages);

        // Nút OK
        _btnOk = new Button
        {
            Text = "OK",
            Location = new System.Drawing.Point(50, 100),
            Size = new System.Drawing.Size(80, 30)
        };
        _btnOk.Click += (sender, e) =>
        {
            SelectedLanguage = _comboBoxLanguages.SelectedItem.ToString(); // Lấy ngôn ngữ được chọn
            this.DialogResult = DialogResult.OK;
            this.Close();
        };
        this.Controls.Add(_btnOk);

        // Nút Cancel
        _btnCancel = new Button
        {
            Text = "Cancel",
            Location = new System.Drawing.Point(170, 100),
            Size = new System.Drawing.Size(80, 30)
        };
        _btnCancel.Click += (sender, e) => this.Close();
        this.Controls.Add(_btnCancel);
        
        GuiUtils.ScaleControls(this, scaleFactor);
    }
}
