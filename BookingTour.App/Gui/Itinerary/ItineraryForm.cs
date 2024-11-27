using BookingTour.App.Gui.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookingTour.App.Bus;

namespace BookingTour.App.Gui.Itinerary;

public partial class ItineraryForm : Form
{
    private readonly List<string> _vehicles = new List<string> { "Xe Bus", "Xe khách", "Xe ô tô", "Xe lửa" };

    
    public ItineraryForm()
    {
        InitializeComponent();
        LoadItineraryData(null);
    }

    private void ScaleControls(Control parent, float scaleFactor)
    {
        foreach (Control control in parent.Controls)
        {
            if (control is DataGridView dataGridView)
            {
                dataGridView.Font = new Font(dataGridView.Font.FontFamily, dataGridView.Font.Size * scaleFactor);
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    row.Height = (int)(row.Height * scaleFactor);
                }
                dataGridView.ColumnHeadersHeight = (int)(dataGridView.ColumnHeadersHeight * scaleFactor);
            }
            if (control is FontAwesome.Sharp.IconButton iconButton)
            {
                iconButton.IconSize = (int)(iconButton.IconSize * scaleFactor);
            }
            if (control.HasChildren)
            {
                ScaleControls(control, scaleFactor);
            }
        }
    }

    private void ItineraryForm_Load(object sender, EventArgs e)
    {
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        ScaleControls(this, scaleFactor);
    }

    private void searchButton_Click(object sender, EventArgs e)
    {
        var keywords = searchTextbox.Text.Trim().ToLower();
        var keywordList = keywords.Split(' ');
        var filteredData = ItineraryBus.Instance.GetAllItineraries().Where(itinerary =>
            keywordList.All(keyword =>
                itinerary.Name!.Contains(keyword, StringComparison.CurrentCultureIgnoreCase) ||
                itinerary.Vehicle!.Contains(keyword, StringComparison.CurrentCultureIgnoreCase)
            )
        ).ToList();
        LoadItineraryData(filteredData);
        searchTextbox.Text = "";
    }

    private void refreshButton_Click(object sender, EventArgs e)
    {
        LoadItineraryData(null);
        var scaleFactor = GuiUtils.GetScaleInScreen(this);
        dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, dataGridView1.Font.Size * scaleFactor);
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            
            row.Height = (int)(row.Height * scaleFactor);
        }
    }

    private void createAccountButton_Click(object sender, EventArgs e)
    {
        var form = new AddItineraryForm(_vehicles, null);

        if (form.ShowDialog() != DialogResult.OK) return;
        var itinerary = new Models.Itinerary
        {
            Id = 0,
            Name = form.ItineraryName!,
            NumberOfDays = form.NumberOfDays!.Value,
            Vehicle = form.Vehicle,
            Description = form.Description,
            Capacity = form.Capacity,
            ItineraryDetails = null,
            Tours = null
        };
        ItineraryBus.Instance.CreateItinerary(itinerary);
        LoadItineraryData(null);
    }

    private void LoadItineraryData(List<Models.Itinerary>? data)
    {
        dataGridView1.Rows.Clear();
        try
        {
            data ??= ItineraryBus.Instance.GetAllItineraries();

            foreach (var itinerary in data)
            {
                dataGridView1.Rows.Add(
                    itinerary.Id,
                    itinerary.Name,
                    itinerary.NumberOfDays,
                    itinerary.Vehicle,
                    itinerary.Capacity
                );
            }
        }
        catch (System.Exception ex)
        {
            // Hiển thị lỗi nếu có
            MessageBox.Show($@"Lỗi khi tải dữ liệu: {ex.Message}", @"Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
        // ReSharper disable once InvertIf
        if (e.ColumnIndex == dataGridView1.Columns["Action"]!.Index && e.RowIndex >= 0)
        {
            var itineraryId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
            var data = ItineraryBus.Instance.GetItineraryById(itineraryId);
            using var form = new AddItineraryForm(_vehicles, data);
            if (form.ShowDialog() != DialogResult.OK) return;
            var itinerary = new Models.Itinerary
            {
                Id = itineraryId,
                Name = form.ItineraryName!,
                NumberOfDays = form.NumberOfDays!.Value,
                Vehicle = form.Vehicle,
                Description = form.Description,
                Capacity = form.Capacity,
                ItineraryDetails = null,
                Tours = null
            };
            ItineraryBus.Instance.UpdateItinerary(itinerary);
            LoadItineraryData(null);
        }
    }
}
