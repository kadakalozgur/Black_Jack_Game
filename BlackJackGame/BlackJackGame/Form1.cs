using System.Media;

namespace BlackJackGame
{
    public partial class Form1 : Form
    {

        SoundPlayer menuMusic;

        bool isMuted = false;
        public Form1()
        {
            InitializeComponent(); 

            menuMusic = new SoundPlayer(Resources.menumusic);
            menuMusic.PlayLooping();

            Stream cursor = new MemoryStream(Resources.cursor);
            this.Cursor = new Cursor(cursor);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.BackgroundImageLayout = ImageLayout.Stretch;

            var buttonPlay = setmainmenubutton(Resources.playbutton,Resources.playhoverbutton);
            var buttonQuit = setmainmenubutton(Resources.quitbutton, Resources.quithoverbutton);

            buttonPlay.Click += (s, e) =>
            {

                menuMusic.Stop();

                var gameForm = new Form2();

                gameForm.Owner = this;

                this.Hide();

                gameForm.Show();
                
            };

            buttonQuit.Click += (s, e) =>
            {

                menuMusic.Stop();

                Application.Exit();

            };

            this.Controls.Add(buttonPlay);
            this.Controls.Add(buttonQuit);

            int spacing = 20;

            buttonPlay.Width = 400;
            buttonPlay.Height = 100;
            buttonQuit.Width = 400;
            buttonQuit.Height = 100;

            int rightMargin = (int)(this.ClientSize.Width * 0.15);

            int totalButtonHeight = buttonPlay.Height + spacing + buttonQuit.Height;
            int startY = this.ClientSize.Height - totalButtonHeight - 250; 

            buttonPlay.Left = this.ClientSize.Width - rightMargin - buttonPlay.Width;
            buttonPlay.Top = startY;

            buttonQuit.Left = buttonPlay.Left;
            buttonQuit.Top = buttonPlay.Bottom + spacing;

            //Settings Button//

            var buttonSettings = setmainmenubutton(Resources.settingsbutton, Resources.settingsbuttonhover);

            buttonSettings.Width = 50;
            buttonSettings.Height = 50;
            buttonSettings.Top = 20;
            buttonSettings.Left = this.ClientSize.Width - buttonSettings.Width - 20;

            buttonSettings.Click += (s, e) =>
            {

                var settings = new SettingsForm(menuMusic,isMuted);

                settings.ShowDialog();

                isMuted = settings.IsMuted;

            };

            this.Controls.Add(buttonSettings);
        }

        private PictureBox setmainmenubutton(Image defaultImg, Image hoverImg)
        {

            PictureBox button = new PictureBox();

            button.Image = defaultImg;
            button.SizeMode = PictureBoxSizeMode.StretchImage;

            button.MouseEnter += (s, e) =>
            {

                button.Image = hoverImg;

                Stream cursor = new MemoryStream(Resources.cursorhover);
                this.Cursor = new Cursor(cursor);

            };

            button.MouseLeave += (s, e) =>
            {

                button.Image = defaultImg;

                Stream cursor = new MemoryStream(Resources.cursor);
                this.Cursor = new Cursor(cursor);

            };

            return button;

        }
    }
}
