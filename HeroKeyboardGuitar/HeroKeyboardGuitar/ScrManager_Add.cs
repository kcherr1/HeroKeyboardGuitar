using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace HeroKeyboardGuitar;

internal partial class ScrManager_Add : UserControl
{
    private string SONGS_ROOT_PATH = $"{Application.StartupPath}../../../Songs/";
    private GenreType[] genreArray;
    private int currentGenreIndex;
    public ScreenSwapHandler handler;
    private string songFilepath;
    private string songGenre;
    private string songBeatpath;


    public ScrManager_Add()
    {
        genreArray = (GenreType[])Enum.GetValues(typeof(GenreType));
        currentGenreIndex = -1;
        InitializeComponent();
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        ScrSongSelect frmSongSelect = new();
        frmSongSelect.Show();
    }

    private void ScrManager_Add_Load(object sender, EventArgs e)
    {
        songFilepath = "";
        songGenre = "";
        songBeatpath = "";
    }

    private void btn_backClicked(object sender, EventArgs e)
    {
        handler.gotoSongManage_hub();
        handler.goUpdate_SongManage();
    }

    private void btn_SelectSongFileClicked(object sender, EventArgs e)
    {
        setFieldtoFilepath(ref this.songFilepath, ".wav");
    }

    private void btn_SelectGenreClicked(object sender, EventArgs e)
    {
        if (currentGenreIndex == genreArray.Length - 1 || currentGenreIndex == -1)
        {
            currentGenreIndex = 0;
        }
        else
        {
            currentGenreIndex++;
        }
        songGenre = genreArray[currentGenreIndex].ToString();
        btn_SelectGenre.Text = songGenre;
        songGenre.ToLower();
    }

    private void btn_SelectMapClicked(object sender, EventArgs e)
    {
        setFieldtoFilepath(ref this.songBeatpath, ".txt");
    }

    private void btn_CreateSongClicked(object sender, EventArgs e)
    {
        if (songFilepath != "" && songBeatpath != "" && songGenre != "")
        {
            DialogResult confirmation = MessageBox.Show("Any songs that share the name will be overwritten. Do you want to proceed?",
                                        "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (confirmation == DialogResult.Yes)
            {
                string songName = $"{ Path.GetFileNameWithoutExtension(songFilepath)}_{songGenre.ToLower()}";
                string pathName = Path.Combine(SONGS_ROOT_PATH, songName);
                var directoryInfo = System.IO.Directory.CreateDirectory(pathName);
                string newFolderPath = directoryInfo.FullName;
                string songCopiedFile = Path.Combine(newFolderPath, "audio.wav");
                string beatCopiedFile = Path.Combine(newFolderPath, "beat.txt");
                File.Copy(songFilepath, songCopiedFile, true);
                File.Copy(songBeatpath, beatCopiedFile, true);
                MessageBox.Show("Song Succesfully Added!");
            }
        }
        else
        {
            string message = "";
            Dictionary<string, string> fieldsMap = new()
            {
                { "Song", songFilepath },
                { "Genre", songGenre},
                { "Beat Map", songBeatpath }
            };
            foreach (KeyValuePair<string,string> pair in fieldsMap)
            {
                if (pair.Value.Equals(""))
                {
                    message += $"{pair.Key} is invalid \n";
                }
            }
            MessageBox.Show(message);
        }
    }

    private void setFieldtoFilepath(ref string field, string extension)
    {
        string filter = extension + "|";
        string input = getFileFromUser(filter);
        int extensionStartIndex = input.LastIndexOf('.');
        if (input != "" && input.Substring(extensionStartIndex).Equals(extension))
        {
            field = input;
        }
    }
    private String getFileFromUser(string filter)
    {
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = filter;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            return dialog.FileName;
        }
        else
        {
            return "";
        }
    }

}
