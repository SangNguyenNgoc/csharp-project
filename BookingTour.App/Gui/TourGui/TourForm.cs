using BookingTour.App.Bus;
using BookingTour.App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookingTour.App.Gui.TourGui;

    public partial class TourForm : Form
    {
        public TourForm()
        {
            InitializeComponent();
            initExtendFields();
            initCombobox();
            loadTours();
        }

        public void initExtendFields()
        {
            tourGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            typeDetailGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            priceFilterCbb.DropDownStyle = ComboBoxStyle.DropDownList;
            typeDetailCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            startDateFilter.Value = DateTime.Now;
            endDatePicker.Value = DateTime.Now.AddMonths(3);

            startDateFilter.Format = DateTimePickerFormat.Custom;
            startDateFilter.CustomFormat = "dd/MM/yyyy";
            endDatePicker.Format = DateTimePickerFormat.Custom;
            endDatePicker.CustomFormat = "dd/MM/yyyy";
        }

        public void initCombobox()
        {
            // filter price cbb
            priceFilterCbb.Items.Add("< 1tr");
            priceFilterCbb.Items.Add("1 - 5tr");
            priceFilterCbb.Items.Add("5 - 10tr");
            priceFilterCbb.Items.Add("> 10tr");
            priceFilterCbb.SelectedIndex = 0;


            // filter details
            typeDetailCombobox.Items.Add("Itineraty Details");
            typeDetailCombobox.Items.Add("Passengers");
            typeDetailCombobox.Items.Add("Tour guides");
            typeDetailCombobox.SelectedIndex = 0;
        }



        private void searchField_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void endDatePicker_ValueChanged(object sender, EventArgs e)
        {
            loadTours();
        }

        private void startDateFilter_ValueChanged(object sender, EventArgs e)
        {

            loadTours();
        }

        public DateOnly? getStartDateValue()
        {
            return startDateFilter.Value != null ? DateOnly.FromDateTime(startDateFilter.Value) : (DateOnly?)null;
        }

        public DateOnly? getEndDateValue()
        {
            return endDatePicker.Value != null ? DateOnly.FromDateTime(endDatePicker.Value) : (DateOnly?)null;
        }

        public string getSearchKeyword()
        {
            return searchField.Text;
        }
        public int getSelectedTourId()
        {
            if (tourGridView.CurrentRow != null)
            {
                DataGridViewRow selectedRow = tourGridView.CurrentRow;
                return (int)selectedRow.Cells["Id"].Value;
            }
            return -1;
        }

        public int getSelectedTypeDetailIndex()
        {
            return typeDetailCombobox.SelectedIndex;
        }

        public int getMinPriceValue()
        {
            switch (priceFilterCbb.SelectedIndex)
            {
                case 0:
                    return 0;
                case 1:
                    return 1000000;
                case 2:
                    return 5000000;
                case 3:
                    return 10000000;
                default:
                    return 0;
            }
        }

        public int getMaxPriceValue()
        {
            switch (priceFilterCbb.SelectedIndex)
            {
                case 0:
                    return 1000000;
                case 1:
                    return 5000000;
                case 2:
                    return 10000000;
                case 3:
                    return 1000000000;
                default:
                    return 1000000000;
            }
        }



        public void loadTours()
        {
            string keyword = getSearchKeyword();
            DateOnly? startDate = getStartDateValue();
            DateOnly? endDate = getEndDateValue();
            int minPrice = getMinPriceValue();
            int maxPrice = getMaxPriceValue();

            List<Models.Tour> tours = TourBus.Instance.GetPaginatedTours(keyword, startDate, endDate, minPrice, maxPrice);
            tourGridView.Rows.Clear();
            foreach (var tour in tours)
            {
                tourGridView.Rows.Add(
                    tour.Id,
                    tour.Itinerary.Name,
                    tour.DateStart?.ToString("dd/MM/yyyy"),
                    tour.DateEnd?.ToString("dd/MM/yyyy"),
                    tour.Price,
                    tour.Capacity,
                    tour.RemainingSlots
                );
            }
        }

        private void searchField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                loadTours();
            }
        }

        public void loadItineratyDetails(int tourId)
        {
            typeDetailGridView.Rows.Clear();
            typeDetailGridView.Columns.Clear();

            typeDetailGridView.Columns.Add("Activity", "Activity");
            typeDetailGridView.Columns.Add("Place", "Place");
            typeDetailGridView.Columns.Add("Service", "Service");

            List<Models.ItineraryDetail> itineraryDetails = ItineraryDetailBus.Instance.GetItineraryDetailsOfTour(tourId);

            foreach (var itineraryDetail in itineraryDetails)
            {
                typeDetailGridView.Rows.Add(
                    itineraryDetail.Activity.Name,
                    itineraryDetail.Activity.Place.Name,
                    itineraryDetail.Service.Name

                );
            }
        }

        public void loadPassengers(int tourId)
        {
            typeDetailGridView.Rows.Clear();
            typeDetailGridView.Columns.Clear();

            // set column
            typeDetailGridView.Columns.Add("ID", "Id");
            typeDetailGridView.Columns.Add("Name", "Name");
            typeDetailGridView.Columns.Add("Email", "Email");
            typeDetailGridView.Columns.Add("Phone number", "Phone number");
            typeDetailGridView.Columns.Add("Age", "Age");


            List<Models.Passenger> passengers = PassengerBus.Instance.GetPassengersOfTour(tourId);

            foreach (var passenger in passengers)
            {
                typeDetailGridView.Rows.Add(
                    passenger.Id,
                    passenger.Name,
                    passenger.Email,
                    passenger.PhoneNumber,
                    passenger.Age
                );
            }
        }

        public void loadTourGuides(int tourId)
        {
            typeDetailGridView.Rows.Clear();
            typeDetailGridView.Columns.Clear();

            // set column
            typeDetailGridView.Columns.Add("ID", "Id");
            typeDetailGridView.Columns.Add("Name", "Name");
            typeDetailGridView.Columns.Add("Language", "Language");



            List<Models.Guide> guides = GuideBus.Instance.GetGuidesOfTour(tourId);

            foreach (var guide in guides)
            {
                typeDetailGridView.Rows.Add(
                    guide.Id,
                    guide.Account.Name,
                    guide.Language
                );
            }
        }

        private void tourGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (tourGridView.CurrentRow != null)
            {
                DataGridViewRow selectedRow = tourGridView.CurrentRow;

                int tourId = Convert.ToInt32(selectedRow.Cells["Id"].Value);

                switch (getSelectedTypeDetailIndex())
                {
                    case 0:
                        loadItineratyDetails(tourId);
                        break;
                    case 1:
                        loadPassengers(tourId);
                        break;
                    case 2:
                        loadTourGuides(tourId);
                        break;
                }
            }
        }

        private void typeDetailCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tourGridView.CurrentRow != null)
            {
                DataGridViewRow selectedRow = tourGridView.CurrentRow;

                var tourId = selectedRow.Cells["Id"].Value;

                switch (getSelectedTypeDetailIndex())
                {
                    case 0:
                        loadItineratyDetails((int)tourId);
                        break;
                    case 1:
                        loadPassengers((int)tourId);
                        break;
                    case 2:
                        loadTourGuides((int)tourId);
                        break;
                }
            }
        }

        private void priceFilterCbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTours();
        }
    }

