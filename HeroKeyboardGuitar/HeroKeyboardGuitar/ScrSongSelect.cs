using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace HeroKeyboardGuitar
{
    internal partial class ScrSongSelect : UserControl
    {
        public ScreenSwapHandler handler;
        private readonly string SONGS_ROOT_PATH = $"{Application.StartupPath}../../../Songs/";

        public ScrSongSelect()
        {
            InitializeComponent();
        }

        private void FrmSongSelect_Load(object sender, EventArgs e)
        {
            int top = 180;
            int left = 125;
            const int size = 300;
            const int spacing = 50;
            foreach (var songFolderPath in Directory.GetDirectories(SONGS_ROOT_PATH))
            {
                string songDirectoryName = Path.GetFileNameWithoutExtension(songFolderPath);
                var songName = songDirectoryName.Split('_')[0];
                GenreType genre;
                if (!Enum.TryParse(songDirectoryName.Split('_')[1], true, out genre))
                {
                    genre = GenreType.COUNTRY;
                }
                Button btnSong = new()
                {
                    BackgroundImage = Game.GetBg(genre),
                    BackgroundImageLayout = ImageLayout.Stretch,
                    Width = size,
                    Height = size,
                    Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(songName.ToLower()),
                    TextAlign = ContentAlignment.BottomCenter,
                    Font = new Font("Arial", 30),
                    ForeColor = Color.Cyan,
                    Top = top,
                    Left = left,
                };
                left += size + spacing;
                btnSong.Click += (e, sender) =>
                {
                    Game.SetCurSong(songFolderPath, genre);
                    FrmGame frmMain = new();
                    frmMain.Show();
                };
                Controls.Add(btnSong);
            }
        }
        private void btn_BackClick(object sender, EventArgs e)
        {
            handler.gotoTitle();
        }
    }
}
