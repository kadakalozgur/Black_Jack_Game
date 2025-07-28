namespace BlackJackGame
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            closepicturebox = new PictureBox();
            musicpicturebox = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)closepicturebox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)musicpicturebox).BeginInit();
            SuspendLayout();
            // 
            // closepicturebox
            // 
            closepicturebox.Image = Resources.close;
            closepicturebox.Location = new Point(285, 236);
            closepicturebox.Name = "closepicturebox";
            closepicturebox.Size = new Size(38, 38);
            closepicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            closepicturebox.TabIndex = 2;
            closepicturebox.TabStop = false;
            // 
            // musicpicturebox
            // 
            musicpicturebox.Location = new Point(144, 131);
            musicpicturebox.Name = "musicpicturebox";
            musicpicturebox.Size = new Size(81, 76);
            musicpicturebox.SizeMode = PictureBoxSizeMode.StretchImage;
            musicpicturebox.TabIndex = 3;
            musicpicturebox.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.ForeColor = Color.FromArgb(248, 199, 130);
            label1.Location = new Point(144, 210);
            label1.Name = "label1";
            label1.Size = new Size(81, 34);
            label1.TabIndex = 4;
            label1.Text = "Music";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Resources.settingsbackground;
            ClientSize = new Size(366, 307);
            Controls.Add(label1);
            Controls.Add(musicpicturebox);
            Controls.Add(closepicturebox);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SettingsForm";
            Text = "SettingsForm";
            Load += SettingsForm_Load;
            ((System.ComponentModel.ISupportInitialize)closepicturebox).EndInit();
            ((System.ComponentModel.ISupportInitialize)musicpicturebox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private PictureBox closepicturebox;
        private PictureBox musicpicturebox;
        private Label label1;
    }
}