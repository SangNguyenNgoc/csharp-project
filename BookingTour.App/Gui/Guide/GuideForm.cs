using BookingTour.App.Bus;
using BookingTour.App.Gui.Utils;
using BookingTour.App.Models;
using FontAwesome.Sharp;

namespace BookingTour.App.Gui.Guide;

public partial class GuideForm : Form
{
    public GuideForm()
    {
        InitializeComponent();
        LoadGuideData(null);
        Loadlanguage();
        LoadTour();
    }

    private void ScaleControls(Control parent, float scaleFactor)
    {
        foreach (Control control in parent.Controls)
        {
            switch (control)
            {
                case DataGridView dataGridView:
                {
                    dataGridView.Font = new Font(dataGridView.Font.FontFamily, dataGridView.Font.Size * scaleFactor);
                    foreach (DataGridViewRow row in dataGridView.Rows) row.Height = (int)(row.Height * scaleFactor);
                    dataGridView.ColumnHeadersHeight = (int)(dataGridView.ColumnHeadersHeight * scaleFactor);
                    break;
                }
                case IconButton iconButton:
                    iconButton.IconSize = (int)(iconButton.IconSize * scaleFactor);
                    break;
            }

            if (control.HasChildren) ScaleControls(control, scaleFactor);
        }
    }

    private void LoadGuideData(ICollection<User>? data)
    {
        dataGridView1.Rows.Clear();
        try
        {
            data ??= UserBus.Instance.GetAllUsersByRole(3);

            foreach (var user in data)
                dataGridView1.Rows.Add(
                    user.Id,
                    user.Username,
                    user.Name,
                    user.Email,
                    user.PhoneNumber,
                    user.Role?.Name
                );
        }
        catch (System.Exception ex)
        {
            // Hiển thị lỗi nếu có
            MessageBox.Show($@"Lỗi khi tải dữ liệu: {ex.Message}", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        if (dataGridView1.Rows.Count <= 0 || dataGridView1.Columns.Count <= 0) return;
        dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
        dataGridView1.Rows[0].Selected = true;
    }

    private void Loadlanguage()
    {
        languageList.Items.Clear();
        if (dataGridView1.CurrentRow == null) return;
        var selectedRow = dataGridView1.CurrentRow;
        var accountId = (int)selectedRow.Cells["Id"].Value;
        var guides = GuideBus.Instance.GetAllGuidesByAccount(accountId);

        languageList.View = View.Details;

        foreach (var guide in guides) languageList.Items.Add(guide.Language);
    }

    private void LoadTour()
    {
        tourList.Items.Clear();
        if (dataGridView1.CurrentRow == null) return;
        var selectedRow = dataGridView1.CurrentRow;
        var accountId = (int)selectedRow.Cells["Id"].Value;
        var tours = TourBus.Instance.GetToursOfGuide(accountId);
        tourList.View = View.Details;
        foreach (var tour in tours)
        {
            var item = new ListViewItem(tour.Itinerary!.Name);
            item.SubItems.Add(tour.DateStart.ToString());
            item.SubItems.Add(tour.DateEnd.ToString());
            tourList.Items.Add(item);
        }
    }

    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentRow == null) return;
        Loadlanguage();
        LoadTour();
    }


    private void refreshButton_Click(object sender, EventArgs e)
    {
    }

    private void leftPanel_Paint(object sender, PaintEventArgs e)
    {
    }

    private void GuideForm_Load(object sender, EventArgs e)
    {
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        ScaleControls(this, scaleFactor);
    }

    private void addLanguageButton_Click(object sender, EventArgs e)
    {
        if (dataGridView1.CurrentRow == null) return;
        using var form = new SelectLanguageForm();
        if (form.ShowDialog() != DialogResult.OK) return; 
        var selectedLanguage = form.SelectedLanguage;
        var selectedRow = dataGridView1.CurrentRow;
        var accountId = (int)selectedRow.Cells["Id"].Value;

        var guide = new Models.Guide
        {
            Id = 0,
            Language = selectedLanguage,
            AccountId = accountId,
            Account = null
        };

        GuideBus.Instance.AddGuide(guide);
        Loadlanguage();

    }
}