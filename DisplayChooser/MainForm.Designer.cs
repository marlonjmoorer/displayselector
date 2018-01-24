namespace DisplaySelector
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BookButton = new System.Windows.Forms.Button();
            this.TentButton = new System.Windows.Forms.Button();
            this.LayflatButton = new System.Windows.Forms.Button();
            this.MobileButton = new System.Windows.Forms.Button();
            this.WedgeButton = new System.Windows.Forms.Button();
            this.LaptopButton = new System.Windows.Forms.Button();
            this.ModeText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.RotateMainBtn = new System.Windows.Forms.Button();
            this.RotateRemoteBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BookButton);
            this.panel1.Controls.Add(this.TentButton);
            this.panel1.Controls.Add(this.LayflatButton);
            this.panel1.Controls.Add(this.MobileButton);
            this.panel1.Controls.Add(this.WedgeButton);
            this.panel1.Controls.Add(this.LaptopButton);
            this.panel1.Location = new System.Drawing.Point(12, 60);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(321, 160);
            this.panel1.TabIndex = 0;
            // 
            // BookButton
            // 
            this.BookButton.Location = new System.Drawing.Point(230, 83);
            this.BookButton.Name = "BookButton";
            this.BookButton.Size = new System.Drawing.Size(88, 70);
            this.BookButton.TabIndex = 5;
            this.BookButton.Tag = "5";
            this.BookButton.Text = "Book";
            this.BookButton.UseVisualStyleBackColor = true;
            this.BookButton.Click += new System.EventHandler(this.ChangeDisplay);
            // 
            // TentButton
            // 
            this.TentButton.Location = new System.Drawing.Point(116, 83);
            this.TentButton.Name = "TentButton";
            this.TentButton.Size = new System.Drawing.Size(88, 70);
            this.TentButton.TabIndex = 4;
            this.TentButton.Tag = "4";
            this.TentButton.Text = "Tent";
            this.TentButton.UseVisualStyleBackColor = true;
            this.TentButton.Click += new System.EventHandler(this.ChangeDisplay);
            // 
            // LayflatButton
            // 
            this.LayflatButton.Location = new System.Drawing.Point(3, 83);
            this.LayflatButton.Name = "LayflatButton";
            this.LayflatButton.Size = new System.Drawing.Size(88, 70);
            this.LayflatButton.TabIndex = 3;
            this.LayflatButton.Tag = "3";
            this.LayflatButton.Text = "Layflat";
            this.LayflatButton.UseVisualStyleBackColor = true;
            this.LayflatButton.Click += new System.EventHandler(this.ChangeDisplay);
            // 
            // MobileButton
            // 
            this.MobileButton.Location = new System.Drawing.Point(230, 3);
            this.MobileButton.Name = "MobileButton";
            this.MobileButton.Size = new System.Drawing.Size(88, 70);
            this.MobileButton.TabIndex = 2;
            this.MobileButton.Tag = "2";
            this.MobileButton.Text = "Mobile";
            this.MobileButton.UseVisualStyleBackColor = true;
            this.MobileButton.Click += new System.EventHandler(this.ChangeDisplay);
            // 
            // WedgeButton
            // 
            this.WedgeButton.Location = new System.Drawing.Point(116, 0);
            this.WedgeButton.Name = "WedgeButton";
            this.WedgeButton.Size = new System.Drawing.Size(88, 70);
            this.WedgeButton.TabIndex = 1;
            this.WedgeButton.Tag = "1";
            this.WedgeButton.Text = "Wedge";
            this.WedgeButton.UseVisualStyleBackColor = true;
            this.WedgeButton.Click += new System.EventHandler(this.ChangeDisplay);
            // 
            // LaptopButton
            // 
            this.LaptopButton.Location = new System.Drawing.Point(3, 3);
            this.LaptopButton.Name = "LaptopButton";
            this.LaptopButton.Size = new System.Drawing.Size(88, 70);
            this.LaptopButton.TabIndex = 0;
            this.LaptopButton.Tag = "0";
            this.LaptopButton.Text = "Laptop";
            this.LaptopButton.UseVisualStyleBackColor = true;
            this.LaptopButton.Click += new System.EventHandler(this.ChangeDisplay);
            // 
            // ModeText
            // 
            this.ModeText.Location = new System.Drawing.Point(128, 20);
            this.ModeText.Name = "ModeText";
            this.ModeText.ReadOnly = true;
            this.ModeText.Size = new System.Drawing.Size(100, 20);
            this.ModeText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mode";
            // 
            // RotateMainBtn
            // 
            this.RotateMainBtn.Location = new System.Drawing.Point(15, 227);
            this.RotateMainBtn.Name = "RotateMainBtn";
            this.RotateMainBtn.Size = new System.Drawing.Size(140, 23);
            this.RotateMainBtn.TabIndex = 3;
            this.RotateMainBtn.Text = "Rotate Main";
            this.RotateMainBtn.UseVisualStyleBackColor = true;
            this.RotateMainBtn.Click += new System.EventHandler(this.RotateMainBtn_Click);
            // 
            // RotateRemoteBtn
            // 
            this.RotateRemoteBtn.Location = new System.Drawing.Point(186, 227);
            this.RotateRemoteBtn.Name = "RotateRemoteBtn";
            this.RotateRemoteBtn.Size = new System.Drawing.Size(144, 23);
            this.RotateRemoteBtn.TabIndex = 4;
            this.RotateRemoteBtn.Text = "Rotate Remote";
            this.RotateRemoteBtn.UseVisualStyleBackColor = true;
            this.RotateRemoteBtn.Click += new System.EventHandler(this.RotateRemoteBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 262);
            this.Controls.Add(this.RotateRemoteBtn);
            this.Controls.Add(this.RotateMainBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ModeText);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button BookButton;
        private System.Windows.Forms.Button TentButton;
        private System.Windows.Forms.Button LayflatButton;
        private System.Windows.Forms.Button MobileButton;
        private System.Windows.Forms.Button WedgeButton;
        private System.Windows.Forms.Button LaptopButton;
        private System.Windows.Forms.TextBox ModeText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RotateMainBtn;
        private System.Windows.Forms.Button RotateRemoteBtn;
    }
}

