namespace BookingTour.App.Gui.Itinerary
{
    partial class ItineraryDetailForm
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
            typeDetailGridView = new DataGridView();
            panel1 = new Panel();
            createAccountButton = new FontAwesome.Sharp.IconButton();
            refershButton = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)typeDetailGridView).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // typeDetailGridView
            // 
            typeDetailGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            typeDetailGridView.Dock = DockStyle.Bottom;
            typeDetailGridView.Location = new Point(0, 70);
            typeDetailGridView.Name = "typeDetailGridView";
            typeDetailGridView.Size = new Size(998, 547);
            typeDetailGridView.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(refershButton);
            panel1.Controls.Add(createAccountButton);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(998, 64);
            panel1.TabIndex = 1;
            // 
            // createAccountButton
            // 
            createAccountButton.BackColor = Color.FromArgb(21, 128, 61);
            createAccountButton.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            createAccountButton.FlatAppearance.BorderSize = 2;
            createAccountButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            createAccountButton.ForeColor = SystemColors.ButtonFace;
            createAccountButton.IconChar = FontAwesome.Sharp.IconChar.None;
            createAccountButton.IconColor = Color.Black;
            createAccountButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            createAccountButton.Location = new Point(907, 32);
            createAccountButton.Name = "createAccountButton";
            createAccountButton.Size = new Size(79, 29);
            createAccountButton.TabIndex = 8;
            createAccountButton.Text = "Mới";
            createAccountButton.UseVisualStyleBackColor = false;
            createAccountButton.Click += createAccountButton_Click;
            // 
            // refershButton
            // 
            refershButton.BackColor = Color.Transparent;
            refershButton.FlatAppearance.BorderColor = Color.FromArgb(21, 128, 61);
            refershButton.FlatAppearance.BorderSize = 2;
            refershButton.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            refershButton.ForeColor = SystemColors.ActiveCaptionText;
            refershButton.IconChar = FontAwesome.Sharp.IconChar.None;
            refershButton.IconColor = Color.Black;
            refershButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            refershButton.Location = new Point(822, 32);
            refershButton.Name = "refershButton";
            refershButton.Size = new Size(79, 29);
            refershButton.TabIndex = 7;
            refershButton.Text = "Làm mới";
            refershButton.UseVisualStyleBackColor = false;
            refershButton.Click += refershButton_Click;
            // 
            // ItineraryDetailForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(998, 617);
            Controls.Add(panel1);
            Controls.Add(typeDetailGridView);
            Name = "ItineraryDetailForm";
            Text = "ItineraryDetailForm";
            ((System.ComponentModel.ISupportInitialize)typeDetailGridView).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView typeDetailGridView;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton createAccountButton;
        private FontAwesome.Sharp.IconButton refershButton;
    }
}