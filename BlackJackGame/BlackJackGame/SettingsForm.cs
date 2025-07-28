using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BlackJackGame
{
    public partial class SettingsForm : Form
    {

        SoundPlayer _musicPlayer;

        bool _isMuted;
        public SettingsForm(SoundPlayer musicPlayer,bool isMuted)
        {
            InitializeComponent();

            _musicPlayer = musicPlayer;
            _isMuted = isMuted;

            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.None;

            Stream cursor = new MemoryStream(Resources.cursor);
            this.Cursor = new Cursor(cursor);

        }

        public bool IsMuted
        {

            get 
            {

                return _isMuted; 
            
            }

        }


        private void SettingsForm_Load(object sender, EventArgs e)
        {

            if (_isMuted)
            {

                musicpicturebox.Image = Resources.musicon;

            }

            else
            {

                musicpicturebox.Image = Resources.musicoff;

            }

            closepicturebox.Click += (s, e) =>
            {

                this.Close();

            };

            musicpicturebox.Click += (s, e) =>
            {

                if (_isMuted)
                {

                    _musicPlayer.PlayLooping();
                    musicpicturebox.Image = Resources.musicoff;
                    _isMuted = false;

                }
                else
                {

                    _musicPlayer.Stop();
                    musicpicturebox.Image = Resources.musicon;
                    _isMuted = true;

                }

            };

        }
    }
}
