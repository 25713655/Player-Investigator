namespace Player_Investigator
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.checkButton = new System.Windows.Forms.Button();
            this.keyTextBox = new System.Windows.Forms.TextBox();
            this.IDTextBox = new System.Windows.Forms.TextBox();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.ratingBar = new System.Windows.Forms.ProgressBar();
            this.errorTextBox = new System.Windows.Forms.TextBox();
            this.percentageTextBox = new System.Windows.Forms.TextBox();
            this.playtimeLabel = new System.Windows.Forms.Label();
            this.playtimeTextBox = new System.Windows.Forms.TextBox();
            this.createdLabel = new System.Windows.Forms.Label();
            this.createdTextBox = new System.Windows.Forms.TextBox();
            this.gameSelection = new System.Windows.Forms.ComboBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // checkButton
            // 
            this.checkButton.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkButton.Location = new System.Drawing.Point(12, 12);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(254, 56);
            this.checkButton.TabIndex = 1;
            this.checkButton.Text = "Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // keyTextBox
            // 
            this.keyTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.keyTextBox.Location = new System.Drawing.Point(272, 12);
            this.keyTextBox.Name = "keyTextBox";
            this.keyTextBox.PlaceholderText = "Enter Steam WebAPI key";
            this.keyTextBox.Size = new System.Drawing.Size(500, 25);
            this.keyTextBox.TabIndex = 3;
            // 
            // IDTextBox
            // 
            this.IDTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.IDTextBox.Location = new System.Drawing.Point(272, 43);
            this.IDTextBox.Name = "IDTextBox";
            this.IDTextBox.PlaceholderText = "Enter 64-bit Steam ID";
            this.IDTextBox.Size = new System.Drawing.Size(500, 25);
            this.IDTextBox.TabIndex = 4;
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ratingLabel.Location = new System.Drawing.Point(12, 100);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(94, 37);
            this.ratingLabel.TabIndex = 5;
            this.ratingLabel.Text = "Rating";
            // 
            // ratingBar
            // 
            this.ratingBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.ratingBar.Location = new System.Drawing.Point(150, 140);
            this.ratingBar.MarqueeAnimationSpeed = 0;
            this.ratingBar.Name = "ratingBar";
            this.ratingBar.Size = new System.Drawing.Size(500, 25);
            this.ratingBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ratingBar.TabIndex = 6;
            // 
            // errorTextBox
            // 
            this.errorTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.errorTextBox.Location = new System.Drawing.Point(150, 74);
            this.errorTextBox.Name = "errorTextBox";
            this.errorTextBox.ReadOnly = true;
            this.errorTextBox.Size = new System.Drawing.Size(500, 25);
            this.errorTextBox.TabIndex = 7;
            // 
            // percentageTextBox
            // 
            this.percentageTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.percentageTextBox.Location = new System.Drawing.Point(250, 175);
            this.percentageTextBox.Name = "percentageTextBox";
            this.percentageTextBox.ReadOnly = true;
            this.percentageTextBox.Size = new System.Drawing.Size(300, 25);
            this.percentageTextBox.TabIndex = 8;
            // 
            // playtimeLabel
            // 
            this.playtimeLabel.AutoSize = true;
            this.playtimeLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playtimeLabel.Location = new System.Drawing.Point(12, 250);
            this.playtimeLabel.Name = "playtimeLabel";
            this.playtimeLabel.Size = new System.Drawing.Size(119, 37);
            this.playtimeLabel.TabIndex = 9;
            this.playtimeLabel.Text = "Playtime";
            // 
            // playtimeTextBox
            // 
            this.playtimeTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playtimeTextBox.Location = new System.Drawing.Point(12, 300);
            this.playtimeTextBox.Name = "playtimeTextBox";
            this.playtimeTextBox.ReadOnly = true;
            this.playtimeTextBox.Size = new System.Drawing.Size(150, 25);
            this.playtimeTextBox.TabIndex = 10;
            // 
            // createdLabel
            // 
            this.createdLabel.AutoSize = true;
            this.createdLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createdLabel.Location = new System.Drawing.Point(599, 250);
            this.createdLabel.Name = "createdLabel";
            this.createdLabel.Size = new System.Drawing.Size(173, 37);
            this.createdLabel.TabIndex = 11;
            this.createdLabel.Text = "Date Created";
            // 
            // createdTextBox
            // 
            this.createdTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.createdTextBox.Location = new System.Drawing.Point(547, 300);
            this.createdTextBox.Name = "createdTextBox";
            this.createdTextBox.ReadOnly = true;
            this.createdTextBox.Size = new System.Drawing.Size(225, 25);
            this.createdTextBox.TabIndex = 12;
            // 
            // gameSelection
            // 
            this.gameSelection.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gameSelection.FormattingEnabled = true;
            this.gameSelection.Items.AddRange(new object[] {
            "CS:GO",
            "Dota 2",
            "Apex Legends"});
            this.gameSelection.Location = new System.Drawing.Point(12, 76);
            this.gameSelection.Name = "gameSelection";
            this.gameSelection.Size = new System.Drawing.Size(121, 25);
            this.gameSelection.TabIndex = 13;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usernameLabel.Location = new System.Drawing.Point(290, 250);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(136, 37);
            this.usernameLabel.TabIndex = 14;
            this.usernameLabel.Text = "Username";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usernameTextBox.Location = new System.Drawing.Point(280, 300);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.ReadOnly = true;
            this.usernameTextBox.Size = new System.Drawing.Size(150, 25);
            this.usernameTextBox.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(784, 361);
            this.Controls.Add(this.usernameTextBox);
            this.Controls.Add(this.usernameLabel);
            this.Controls.Add(this.gameSelection);
            this.Controls.Add(this.createdTextBox);
            this.Controls.Add(this.createdLabel);
            this.Controls.Add(this.playtimeTextBox);
            this.Controls.Add(this.playtimeLabel);
            this.Controls.Add(this.percentageTextBox);
            this.Controls.Add(this.errorTextBox);
            this.Controls.Add(this.ratingBar);
            this.Controls.Add(this.ratingLabel);
            this.Controls.Add(this.IDTextBox);
            this.Controls.Add(this.keyTextBox);
            this.Controls.Add(this.checkButton);
            this.Name = "Form1";
            this.Text = "Steam Player Investigator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button checkButton;
        private TextBox keyTextBox;
        private TextBox IDTextBox;
        private Label ratingLabel;
        private ProgressBar ratingBar;
        private TextBox errorTextBox;
        private TextBox percentageTextBox;
        private Label playtimeLabel;
        private TextBox playtimeTextBox;
        private Label createdLabel;
        private TextBox createdTextBox;
        private ComboBox gameSelection;
        private Label usernameLabel;
        private TextBox usernameTextBox;
    }
}