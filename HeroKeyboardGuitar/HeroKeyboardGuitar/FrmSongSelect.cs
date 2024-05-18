using ScottPlot.Colormaps;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Windows.Forms;

namespace HeroKeyboardGuitar {

    internal partial class FrmSongSelect : Form
    {
        private readonly string SONGS_ROOT_PATH = $"{Application.StartupPath}../../../Songs/";
        Dictionary<string, HeroKeyboardGuitar.GenreType> songs = new Dictionary<string, HeroKeyboardGuitar.GenreType>();

        public FrmSongSelect()
        {
            InitializeComponent();
            comboBox1.Text = "--Select--";
            comboBox2.Text = "--Select--";
            comboBox3.Text = "--Select--";
        }


        private void FrmSongSelect_Load(object sender, EventArgs e)
        {

            // Add music to combo boxes (AKA dropdown menus)
            foreach (var songFilePath in Directory.GetFiles(SONGS_ROOT_PATH))
            {
                var song = Path.GetFileNameWithoutExtension(songFilePath);
                var songName = song.Split('_')[0];
                GenreType genre;
                if (!Enum.TryParse(song.Split('_')[1], true, out genre))
                {
                    genre = GenreType.COUNTRY;
                }

                var filePath = songFilePath;
                if (genre == GenreType.ROCK || genre == GenreType.RNB)
                {
                    comboBox1.Items.Add(genre);

                }
                else if (genre == GenreType.POP)
                {
                    comboBox2.Items.Add(genre);
                }
                else { comboBox3.Items.Add(genre); }

                songs.Add(filePath, genre);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\Picture2.jpg");
            comboBox1.Visible = true;
            if (comboBox2.Visible || comboBox3.Visible)
            {
                comboBox2.Visible = false;
                comboBox3.Visible = false;
            }
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox2.SelectedText = "--Select--";
            comboBox3.SelectedText = "--Select--";

        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\Picture3.jpg");
            comboBox2.Visible = true;
            if (comboBox1.Visible || comboBox3.Visible)
            {
                comboBox1.Visible = false;
                comboBox3.Visible = false;
            }
            comboBox1.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox1.SelectedText = "--Select--";
            comboBox3.SelectedText = "--Select--";

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\ezgif-1-453554342f.gif");
            comboBox3.Visible = true;
            if (comboBox1.Visible || comboBox2.Visible)
            {
                comboBox1.Visible = false;
                comboBox2.Visible = false;
            }
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox1.SelectedText = "--Select--";
            comboBox2.SelectedText = "--Select--";


        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\rnb - Copy.jpeg");
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\Picture1.jpg");

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\pop - Copy.jpeg");
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\Picture4.jpg");

        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\mario.jpg");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;

        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = null;
            pictureBox3.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\Picture6.jpg");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void comboBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\Picture2.jpg");

        }

        private void comboBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\Picture2.jpg");

        }

        private void comboBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\Picture2.jpg");
            comboBox1.Visible = false;

        }

        private void comboBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\Picture3.jpg");

        }

        private void comboBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\Picture3.jpg");

        }

        private void comboBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\Picture3.jpg");
            comboBox2.Visible = false;
        }

        private void comboBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\ezgif-1-453554342f.gif");

        }

        private void comboBox3_MouseHover(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\ezgif-1-453554342f.gif");

        }

        private void comboBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Image.FromFile("C:\\Users\\Colin\\Documents\\GitHub\\Team1HeroKeyboardGuitar\\HeroKeyboardGuitar\\HeroKeyboardGuitar\\Resources\\ezgif-1-453554342f.gif");
            comboBox3.Visible = false;


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button btnSong = new()
            {
                BackColor = Color.Cyan,
                Width = 200,
                Height = 50,

                Text = "Start " + comboBox1.SelectedItem + "!!!",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 20),
                ForeColor = Color.White,
                Location = new Point(454, 494)
            };
            btnSong.Click += (e, sender) =>
            {
                ;
                Game.SetCurSong(songs.FirstOrDefault(x => x.Value == (HeroKeyboardGuitar.GenreType)comboBox1.SelectedItem).Key, (HeroKeyboardGuitar.GenreType)comboBox1.SelectedItem);
                FrmMain frmMain = new();
                frmMain.Show();
            };
            if (comboBox1.SelectedText == "--Select--")
            {
                Controls.Remove(btnSong);
            }
            else
            {
                Controls.Add(btnSong);

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            var matches = this.Controls.Find("btnSong", true);
            if (matches != null)
            {
                Controls.Remove(btnSong);
            }
            */

            Button btnSong = new()
            {
                BackColor = Color.Cyan,
                Width = 200,
                Height = 50,

                Text = "Start " + comboBox2.SelectedItem + "!!!",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 20),
                ForeColor = Color.White,
                Location = new Point(454, 494)
            };
            btnSong.Click += (e, sender) =>
            {
                ;
                Game.SetCurSong(songs.FirstOrDefault(x => x.Value == (HeroKeyboardGuitar.GenreType)comboBox2.SelectedItem).Key, (HeroKeyboardGuitar.GenreType)comboBox2.SelectedItem);
                FrmMain frmMain = new();
                frmMain.Show();
            };
            if (comboBox2.SelectedText == "--Select--")
            {
                Controls.Remove(btnSong);
            }
            else
            {
                Controls.Add(btnSong);

            }
        }
    }
}
