using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text.Json;
using ScottPlot;
using System.Text;
using System.Text.Json.Serialization;

namespace HeroKeyboardGuitar;

internal partial class ScrManager_Add : UserControl{

    private const int MAX_SONG_AMOUNT = 10;
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
            MessageBox.Show(@"Too many songs in the folder. Maximum amount is 5. Try deleting a song folder" + 
                           "from the Delete button in Manage Songs and then come back.",
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
                MessageBox.Show(newFolderPath);
                    System.IO.Directory.CreateDirectory(newFolderPath);
                    string songCopiedFile = Path.Combine(newFolderPath, "audio.wav");
                    createJSON_mapFromText(beatPath, newFolderPath);
                    //string beatCopiedFile = Path.Combine(newFolderPath, "beat.txt");
                    File.Copy(audioPath, songCopiedFile, true);
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
                message += "Refer to the bottom (parantheses section) for the accepted file type(s)";
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

    private void createJSON_mapFromText(string textFile, string path)
    {
        List<Double> beatTimeList = new();
        string[] lines = File.ReadAllLines(textFile);
        string fullFilePath = Path.Combine(path, "beat.json");        
        MessageBox.Show(fullFilePath);
        using (File.Create(fullFilePath));
        foreach (string line in lines)
        {
            string[] parts = line.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string startTime = parts[0];
            try
            {
                beatTimeList.Add(Double.Parse(startTime) * 1000);
            }
            catch
            {
                MessageBox.Show("The file selected is not in the appropiate format. Are you sure it's exported from Audacity?");
            }
        }
        /*
        Dictionary<String, List<Double>> actionTimes = new()
        {
            { "Action Times", beatTimeList }
        };
        */
        string jsonString = JsonSerializer.Serialize(beatTimeList);
        File.WriteAllText(fullFilePath, jsonString);
    }

    private bool isPathFull(string path)
    {
        String[] subdirectories = Directory.GetDirectories(path);
        return subdirectories.Length >= MAX_SONG_AMOUNT;
    }
}
