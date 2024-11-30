namespace BookingTour.App.Gui.Statistic
{
    partial class StatisticForm
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
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            dataGridView1 = new DataGridView();
            panel3 = new Panel();
            yearSelect3 = new ComboBox();
            tabPage2 = new TabPage();
            panel2 = new Panel();
            yearSelect2 = new ComboBox();
            cartesianChart2 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            tabPage3 = new TabPage();
            panel1 = new Panel();
            yearSelect = new ComboBox();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel3.SuspendLayout();
            tabPage2.SuspendLayout();
            panel2.SuspendLayout();
            tabPage3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(998, 617);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.FromArgb(244, 243, 247);
            tabPage1.Controls.Add(dataGridView1);
            tabPage1.Controls.Add(panel3);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(990, 589);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Chuyến đi";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Bottom;
            dataGridView1.Location = new Point(3, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(984, 545);
            dataGridView1.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.Controls.Add(yearSelect3);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(984, 32);
            panel3.TabIndex = 3;
            // 
            // yearSelect3
            // 
            yearSelect3.Dock = DockStyle.Right;
            yearSelect3.FormattingEnabled = true;
            yearSelect3.Location = new Point(766, 0);
            yearSelect3.Name = "yearSelect3";
            yearSelect3.Size = new Size(218, 23);
            yearSelect3.TabIndex = 0;
            yearSelect3.SelectedIndexChanged += yearSelect3_SelectedIndexChanged;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel2);
            tabPage2.Controls.Add(cartesianChart2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(990, 589);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Lịch trình";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(yearSelect2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(984, 32);
            panel2.TabIndex = 2;
            // 
            // yearSelect2
            // 
            yearSelect2.Dock = DockStyle.Right;
            yearSelect2.FormattingEnabled = true;
            yearSelect2.Location = new Point(766, 0);
            yearSelect2.Name = "yearSelect2";
            yearSelect2.Size = new Size(218, 23);
            yearSelect2.TabIndex = 0;
            yearSelect2.SelectedIndexChanged += yearSelect2_SelectedIndexChanged;
            // 
            // cartesianChart2
            // 
            cartesianChart2.Dock = DockStyle.Bottom;
            cartesianChart2.Location = new Point(3, 56);
            cartesianChart2.Name = "cartesianChart2";
            cartesianChart2.Size = new Size(984, 530);
            cartesianChart2.TabIndex = 1;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel1);
            tabPage3.Controls.Add(cartesianChart1);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(990, 589);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Tổng doanh thu";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(yearSelect);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(984, 32);
            panel1.TabIndex = 1;
            // 
            // yearSelect
            // 
            yearSelect.Dock = DockStyle.Right;
            yearSelect.FormattingEnabled = true;
            yearSelect.Location = new Point(766, 0);
            yearSelect.Name = "yearSelect";
            yearSelect.Size = new Size(218, 23);
            yearSelect.TabIndex = 0;
            yearSelect.SelectedIndexChanged += YearSelect_SelectedIndexChanged;
            // 
            // cartesianChart1
            // 
            cartesianChart1.Dock = DockStyle.Bottom;
            cartesianChart1.Location = new Point(3, 56);
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(984, 530);
            cartesianChart1.TabIndex = 0;
            // 
            // StatisticForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 617);
            Controls.Add(tabControl1);
            Name = "StatisticForm";
            Text = "StatisticForm";
            Load += StatisticForm_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel3.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private Panel panel1;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
        private ComboBox yearSelect;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart2;
        private Panel panel2;
        private ComboBox yearSelect2;
        private Panel panel3;
        private ComboBox yearSelect3;
        private DataGridView dataGridView1;
    }
}