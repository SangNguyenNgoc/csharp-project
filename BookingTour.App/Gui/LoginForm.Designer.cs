namespace BookingTour.App.Gui
{
    partial class LoginForm
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
            label1 = new Label();
            labelName = new Label();
            textBoxName = new TextBox();
            labelPass = new Label();
            textBoxPass = new TextBox();
            label5 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            panel2 = new Panel();
            panel3 = new Panel();
            label3 = new Label();
            buttonSubmit = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Font = new Font("Stencil", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(100, 60);
            label1.Name = "label1";
            label1.Size = new Size(268, 78);
            label1.TabIndex = 1;
            label1.Text = "TRAVEL";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelName
            // 
            labelName.AutoSize = true;
            labelName.BackColor = Color.FromArgb(30, 40, 59);
            labelName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelName.ForeColor = SystemColors.ButtonFace;
            labelName.Location = new Point(84, 245);
            labelName.Name = "labelName";
            labelName.Size = new Size(145, 25);
            labelName.TabIndex = 2;
            labelName.Text = "MÃ NHÂN VIÊN";
            // 
            // textBoxName
            // 
            textBoxName.BackColor = Color.FromArgb(30, 40, 59);
            textBoxName.BorderStyle = BorderStyle.None;
            textBoxName.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxName.ForeColor = SystemColors.Info;
            textBoxName.Location = new Point(90, 282);
            textBoxName.Name = "textBoxName";
            textBoxName.PlaceholderText = "MSNV";
            textBoxName.Size = new Size(300, 26);
            textBoxName.TabIndex = 3;
            // 
            // labelPass
            // 
            labelPass.AutoSize = true;
            labelPass.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelPass.ForeColor = SystemColors.ButtonFace;
            labelPass.Location = new Point(100, 355);
            labelPass.Name = "labelPass";
            labelPass.Size = new Size(0, 25);
            labelPass.TabIndex = 2;
            // 
            // textBoxPass
            // 
            textBoxPass.BackColor = Color.FromArgb(30, 40, 59);
            textBoxPass.BorderStyle = BorderStyle.None;
            textBoxPass.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBoxPass.ForeColor = SystemColors.Info;
            textBoxPass.Location = new Point(90, 392);
            textBoxPass.Name = "textBoxPass";
            textBoxPass.PasswordChar = '*';
            textBoxPass.PlaceholderText = "*********";
            textBoxPass.Size = new Size(300, 26);
            textBoxPass.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.IndianRed;
            label5.Location = new Point(222, 245);
            label5.Name = "label5";
            label5.Size = new Size(20, 25);
            label5.TabIndex = 2;
            label5.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.IndianRed;
            label4.Location = new Point(182, 355);
            label4.Name = "label4";
            label4.Size = new Size(20, 25);
            label4.TabIndex = 2;
            label4.Text = "*";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Silver;
            panel1.Location = new Point(90, 314);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 2);
            panel1.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(84, 355);
            label2.Name = "label2";
            label2.Size = new Size(105, 25);
            label2.TabIndex = 2;
            label2.Text = "MẬT KHẨU";
            // 
            // panel2
            // 
            panel2.BackColor = Color.Silver;
            panel2.Location = new Point(90, 314);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 2);
            panel2.TabIndex = 4;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Silver;
            panel3.Location = new Point(90, 424);
            panel3.Name = "panel3";
            panel3.Size = new Size(300, 2);
            panel3.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(20, 184, 166);
            label3.Location = new Point(162, 174);
            label3.Name = "label3";
            label3.Size = new Size(155, 32);
            label3.TabIndex = 5;
            label3.Text = "ĐĂNG NHẬP";
            label3.Click += label3_Click;
            // 
            // buttonSubmit
            // 
            buttonSubmit.BackColor = Color.FromArgb(20, 184, 166);
            buttonSubmit.FlatAppearance.BorderSize = 0;
            buttonSubmit.FlatStyle = FlatStyle.Flat;
            buttonSubmit.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonSubmit.ForeColor = SystemColors.ButtonFace;
            buttonSubmit.Location = new Point(90, 469);
            buttonSubmit.Name = "buttonSubmit";
            buttonSubmit.Size = new Size(300, 40);
            buttonSubmit.TabIndex = 8;
            buttonSubmit.Text = "Đăng nhập";
            buttonSubmit.UseVisualStyleBackColor = false;
            buttonSubmit.Click += buttonSubmit_Click;
            // 
            // LoginForm
            // 
            AcceptButton = buttonSubmit;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 40, 59);
            ClientSize = new Size(464, 611);
            Controls.Add(label2);
            Controls.Add(buttonSubmit);
            Controls.Add(label3);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(textBoxName);
            Controls.Add(textBoxPass);
            Controls.Add(labelPass);
            Controls.Add(label4);
            Controls.Add(label5);
            Controls.Add(labelName);
            Controls.Add(label1);
            Cursor = Cursors.Hand;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label labelName;
        private TextBox textBoxName;
        private Label labelPass;
        private TextBox textBoxPass;
        private Label label5;
        private Label label4;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private Panel panel3;
        private Label label3;
        private Button buttonSubmit;
    }
}