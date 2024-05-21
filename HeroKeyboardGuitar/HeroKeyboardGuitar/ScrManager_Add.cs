using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;

namespace HeroKeyboardGuitar;

internal partial class ScrManager_Add : UserControl{

    private const int MAX_SONG_AMOUNT = 5;
    private string SONGS_ROOT_PATH = $"{Application.StartupPath}../../../Songs/";
    private GenreType[] genreArray;
    private int currentGenreIndex;
    public ScreenSwapHandler handler;
    private string audioPath;
    private string songGenre;
    private string beatPath;


    public ScrManager_Add()
    {
        genreArray = (GenreType[])Enum.GetValues(typeof(GenreType));
        currentGenreIndex = -1;
        InitializeComponent();
    }

    private void ScrManager_Add_Load(object sender, EventArgs e)
    {
        audioPath = "";
        songGenre = "";
        beatPath = "";
    }

    private void btn_backClicked(object sender, EventArgs e)
    {
        handler.gotoTitle();
        handler.goUpdate_SongManage();
    }

    private void btn_SelectSongFileClicked(object sender, EventArgs e)
    {
        setFileandUpdateButton(ref audioPath, ".wav", btn_SelectSongFile);
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
        setFileandUpdateButton(ref beatPath, ".txt", btn_selectMap);
    }

    private void btn_CreateSongClicked(object sender, EventArgs e)
    {
        if (isPathFull(SONGS_ROOT_PATH))
        {
            MessageBox.Show(@"Too many songs in the folder. Maximum amount is 5. Try deleting a song folder 
                               from the Delete button in Manage Songs and then come back.",
                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        bool validSongFile = Path.GetExtension(audioPath) == ".wav";
        bool validGenre = songGenre != "";
        bool validBeatMap = Path.GetExtension(beatPath) == ".txt";
            if (validSongFile && validGenre && validBeatMap)
            {
                DialogResult confirmation = MessageBox.Show("Any songs that share the same name and genre will be overwritten. Do you want to " +
                                            "proceed?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (confirmation == DialogResult.Yes)
                {
                    string songName = Path.GetFileNameWithoutExtension(audioPath);
                    string folderName = $"{songName}_{songGenre.ToLower()}";
                    string newFolderPath = Path.Combine(SONGS_ROOT_PATH, folderName);
                    System.IO.Directory.CreateDirectory(newFolderPath);
                    string songCopiedFile = Path.Combine(newFolderPath, "audio.wav");
                    string beatCopiedFile = Path.Combine(newFolderPath, "beat.txt");
                    File.Copy(audioPath, songCopiedFile, true);
                    File.Copy(beatPath, beatCopiedFile, true);
                    MessageBox.Show("Song Succesfully Added!");
                }

            }
            else
            {
                string message = "";
                Dictionary<string, bool> fieldsMap = new()
                {
                    { "Song", validSongFile },
                    { "Genre", validGenre},
                    { "Beat Map", validBeatMap }
                };
                foreach (KeyValuePair<string, bool> pair in fieldsMap)
                {
                    if (!pair.Value)
                    {
                        message += $"{pair.Key} is not the right file type.\n";
                    }
                }
                message += "Refer to the parantheses section for the button(s)";
                MessageBox.Show(message);
            }
    }

    private void setFileandUpdateButton(ref string field, string extension, Button button)
    {
        string filter = extension + "|";
        OpenFileDialog dialog = new OpenFileDialog();
        dialog.Filter = filter;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            field = dialog.FileName;
            button.Text = $"{Path.GetFileName(field)}\nClick to change {extension} file.";
        }
    }
    

    private bool isPathFull(string path)
    {
        String[] subdirectories = Directory.GetDirectories(path);
        return subdirectories.Length >= MAX_SONG_AMOUNT;
    }
}
