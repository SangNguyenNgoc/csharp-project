namespace BookingTour.App.Gui.Tour
{
    partial class TourForm
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
            panel1 = new Panel();
            panel4 = new Panel();
            tourGridView = new DataGridView();
            ID = new DataGridViewTextBoxColumn();
            Itenerary = new DataGridViewTextBoxColumn();
            startDate = new DataGridViewTextBoxColumn();
            endDate = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            capacity = new DataGridViewTextBoxColumn();
            remainingSlots = new DataGridViewTextBoxColumn();
            controlPanel = new Panel();
            priceFilterCbb = new ComboBox();
            endDatePicker = new DateTimePicker();
            startDateFilter = new DateTimePicker();
            searchField = new TextBox();
            panel2 = new Panel();
            panel6 = new Panel();
            typeDetailGridView = new DataGridView();
            panel5 = new Panel();
            typeDetailCombobox = new ComboBox();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tourGridView).BeginInit();
            controlPanel.SuspendLayout();
            panel2.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)typeDetailGridView).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(controlPanel);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1010, 208);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.Controls.Add(tourGridView);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 43);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(20, 5, 20, 5);
            panel4.Size = new Size(1010, 165);
            panel4.TabIndex = 1;
            panel4.Paint += panel4_Paint;
            // 
            // tourGridView
            // 
            tourGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tourGridView.Columns.AddRange(new DataGridViewColumn[] { ID, Itenerary, startDate, endDate, price, capacity, remainingSlots });
            tourGridView.Dock = DockStyle.Fill;
            tourGridView.Location = new Point(20, 5);
            tourGridView.Name = "tourGridView";
            tourGridView.Size = new Size(970, 155);
            tourGridView.TabIndex = 0;
            tourGridView.SelectionChanged += tourGridView_SelectionChanged;
            // 
            // ID
            // 
            ID.HeaderText = "ID";
            ID.Name = "ID";
            // 
            // Itenerary
            // 
            Itenerary.HeaderText = "Itenerary";
            Itenerary.Name = "Itenerary";
            // 
            // startDate
            // 
            startDate.HeaderText = "Start Date";
            startDate.Name = "startDate";
            // 
            // endDate
            // 
            endDate.HeaderText = "End Date";
            endDate.Name = "endDate";
            // 
            // price
            // 
            price.HeaderText = "Price";
            price.Name = "price";
            // 
            // capacity
            // 
            capacity.HeaderText = "Capacity";
            capacity.Name = "capacity";
            // 
            // remainingSlots
            // 
            remainingSlots.HeaderText = "Remaining Slots";
            remainingSlots.Name = "remainingSlots";
            // 
            // controlPanel
            // 
            controlPanel.Controls.Add(priceFilterCbb);
            controlPanel.Controls.Add(endDatePicker);
            controlPanel.Controls.Add(startDateFilter);
            controlPanel.Controls.Add(searchField);
            controlPanel.Dock = DockStyle.Top;
            controlPanel.Location = new Point(0, 0);
            controlPanel.Name = "controlPanel";
            controlPanel.Padding = new Padding(20, 20, 20, 5);
            controlPanel.Size = new Size(1010, 43);
            controlPanel.TabIndex = 0;
            // 
            // priceFilterCbb
            // 
            priceFilterCbb.Dock = DockStyle.Left;
            priceFilterCbb.FormattingEnabled = true;
            priceFilterCbb.Location = new Point(494, 20);
            priceFilterCbb.Margin = new Padding(20);
            priceFilterCbb.Name = "priceFilterCbb";
            priceFilterCbb.Size = new Size(88, 23);
            priceFilterCbb.TabIndex = 3;
            priceFilterCbb.SelectedIndexChanged += priceFilterCbb_SelectedIndexChanged;
            // 
            // endDatePicker
            // 
            endDatePicker.Dock = DockStyle.Left;
            endDatePicker.Location = new Point(333, 20);
            endDatePicker.Margin = new Padding(20, 0, 0, 0);
            endDatePicker.Name = "endDatePicker";
            endDatePicker.Size = new Size(161, 23);
            endDatePicker.TabIndex = 2;
            endDatePicker.ValueChanged += endDatePicker_ValueChanged;
            // 
            // startDateFilter
            // 
            startDateFilter.Dock = DockStyle.Left;
            startDateFilter.Location = new Point(191, 20);
            startDateFilter.Margin = new Padding(20, 0, 0, 0);
            startDateFilter.Name = "startDateFilter";
            startDateFilter.Size = new Size(142, 23);
            startDateFilter.TabIndex = 1;
            startDateFilter.ValueChanged += startDateFilter_ValueChanged;
            // 
            // searchField
            // 
            searchField.Dock = DockStyle.Left;
            searchField.Location = new Point(20, 20);
            searchField.Name = "searchField";
            searchField.Size = new Size(171, 23);
            searchField.TabIndex = 0;
            searchField.KeyDown += searchField_KeyDown;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel5);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 208);
            panel2.Name = "panel2";
            panel2.Size = new Size(1010, 282);
            panel2.TabIndex = 1;
            // 
            // panel6
            // 
            panel6.Controls.Add(typeDetailGridView);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(0, 25);
            panel6.Name = "panel6";
            panel6.Padding = new Padding(20, 0, 20, 20);
            panel6.Size = new Size(1010, 257);
            panel6.TabIndex = 1;
            // 
            // typeDetailGridView
            // 
            typeDetailGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            typeDetailGridView.Dock = DockStyle.Fill;
            typeDetailGridView.Location = new Point(20, 0);
            typeDetailGridView.Name = "typeDetailGridView";
            typeDetailGridView.Size = new Size(970, 237);
            typeDetailGridView.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Controls.Add(typeDetailCombobox);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 0);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(20, 0, 20, 5);
            panel5.Size = new Size(1010, 25);
            panel5.TabIndex = 0;
            // 
            // typeDetailCombobox
            // 
            typeDetailCombobox.AutoCompleteCustomSource.AddRange(new string[] { "Itenerary details", "Tour guides", "Passengers" });
            typeDetailCombobox.Dock = DockStyle.Left;
            typeDetailCombobox.FormattingEnabled = true;
            typeDetailCombobox.Location = new Point(20, 0);
            typeDetailCombobox.Name = "typeDetailCombobox";
            typeDetailCombobox.Size = new Size(159, 23);
            typeDetailCombobox.TabIndex = 0;
            typeDetailCombobox.SelectedIndexChanged += typeDetailCombobox_SelectedIndexChanged;
            // 
            // TourForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1010, 490);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "TourForm";
            Text = "TourForm";
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tourGridView).EndInit();
            controlPanel.ResumeLayout(false);
            controlPanel.PerformLayout();
            panel2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)typeDetailGridView).EndInit();
            panel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private DataGridView tourGridView;
        private Panel controlPanel;
        private TextBox searchField;
        private Panel panel2;
        private DataGridViewTextBoxColumn ID;
        private DataGridViewTextBoxColumn Itenerary;
        private DataGridViewTextBoxColumn startDate;
        private DataGridViewTextBoxColumn endDate;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn capacity;
        private DataGridViewTextBoxColumn remainingSlots;
        private Panel panel6;
        private Panel panel5;
        private ComboBox typeDetailCombobox;
        private DataGridView typeDetailGridView;
        private DateTimePicker startDateFilter;
        private DateTimePicker endDatePicker;
        private ComboBox priceFilterCbb;
    }
}