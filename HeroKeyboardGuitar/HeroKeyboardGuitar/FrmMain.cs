using AudioAnalyzing;
using HeroKeyboardGuitar.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HeroKeyboardGuitar;

internal partial class FrmMain : Form
{
    private bool game_start;
    private Timer game_timer;
    private DateTime game_start_time;
    private float noteSpeed = Game.speed;
    private List<Note> notes;
    private Audio curSong;
    private Score score;
    private DateTime lastSpacePress = DateTime.MinValue;
    public bool isSpacebarHeld = false;
    private bool isTap = false;
    private DateTime spacePressTime;

    // COLIN: Try to get the game to pause 
    public bool isPaused = false;


    // for double buffering
    protected override CreateParams CreateParams
    {
        get
        {
            var cp = base.CreateParams;
            cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
            return cp;
        }
    }

    public FrmMain()
    {
        InitializeComponent();

        // Subscribe to key events
        this.KeyDown += FrmMain_KeyDown;

        // Make sure the form is focused to receive key events
        this.KeyPreview = true;

    }

    public void FrmMain_Load(object sender, EventArgs e)
    {
        score = new();
        lblScore.Text = score.Amount.ToString();
        panBg.BackgroundImage = Game.GetInstance().GetBg();
        panBg.Height = (int)(Height * 0.8);
        curSong = Game.GetInstance().CurSong;
        notes = new();
        foreach (var actionTime in curSong.ActionTimes)
        {
            double x = actionTime * noteSpeed + picTarget.Left + picTarget.Width;
            const int noteSize = 50;
            if (notes.Any(note => (x - note.Pic.Left) < noteSize / 2))
            {
                continue;
            }
            // Create note 
            PictureBox picNote = new()
            {
                BackColor = Color.Black,
                ForeColor = Color.Black,
                Width = noteSize,
                Height = noteSize,
                Top = picTarget.Top + picTarget.Height / 2 - noteSize / 2,
                Left = (int)x,
                BackgroundImage = Resources.marker,
                BackgroundImageLayout = ImageLayout.Stretch,
                Anchor = AnchorStyles.Bottom,
            };
            // Add the control
            Controls.Add(picNote);
            // Add note to the list 
            notes.Add(new(picNote, x));
        }

        ScoreTracker.InsertPlayData("test1", "ABC", "14/50");

        this.Focus();
    }

    private void tmrPlay_Tick(object sender, EventArgs e)
    {
        int index = curSong.GetPosition();
        foreach (var note in notes)
        {

            if (!isPaused)
            {
                // Move the Notes?
                note.Move(tmrPlay.Interval * (noteSpeed * 1.3));
                if (note.CheckMiss(picTarget))
                {
                    score.Miss();
                }
            }
            else
            {
                note.Pause();
            }

        }
        if (index >= curSong.GetNumberOfSamples() - 1)
        {
            tmrPlay.Enabled = false;
            foreach (var note in notes)
            {
                Controls.Remove(note.Pic);
                note.Dispose();
            }
        }
    }

    private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
    {

    }

    /// <summary>
    ///  USER INPUT KEY CONTROLS 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FrmMain_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
        {
            spacePressTime = DateTime.Now;
            isSpacebarHeld = false;
            picTarget.BackgroundImage = Resources.pressed;
        }
        // COLIN: Currently closes the form. Change this to pause the game.
        if (e.KeyCode == Keys.Escape)
        {
            // hard to stop a foreach statement with another foreach statement....
            // Will revist this when sober 
            if (!isPaused)
            {
                isPaused = true;
                Game.GetInstance().CurSong.Stop();
            }
            else
            {
                isPaused = false;
                Game.GetInstance().CurSong.Play();

            }
        }
    }

    private void FrmMain_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Space)
        {
            var duration = (DateTime.Now - spacePressTime).TotalMilliseconds;
            if (duration < 100)
            {
                isTap = true;
                ProcessNoteHitOrMiss();
            }
            else
            {
                isTap = false;
                isSpacebarHeld = true;
                ProcessNoteMiss();
            }
            picTarget.BackgroundImage = Resources._default;
        }
    }

    private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
        Game.GetInstance().CurSong.Stop();
    }

    private void tmrScoreShrink_Tick(object sender, EventArgs e)
    {
        if (lblScore.Font.Size > 20)
        {
            lblScore.Font = new("Arial", lblScore.Font.Size - 1);
        }
    }

    private void ProcessNoteHitOrMiss()
    {
        bool noteHit = false;
        foreach (var note in notes)
        {
            if (note.CheckHit(picTarget, isTap))
            {
                score.Add(1);
                lblScore.Text = score.Amount.ToString();
                lblScore.Font = new Font("Arial", 42);
                noteHit = true;
                break;
            }
        }
        if (!noteHit && isTap)
        {
            score.Deduct(1);
            lblScore.Text = score.Amount.ToString();
        }
    }

    private void ProcessNoteMiss()
    {
        score.Deduct(1);
        lblScore.Text = score.Amount.ToString();

        foreach (var note in notes)
        {
            if (note.CheckMiss(picTarget))
            {
                break;
            }
        }
    }

    private void panBg_Paint(object sender, PaintEventArgs e)
    {
    }

    private void start_button_Click(object sender, EventArgs e)
    {
        Console.WriteLine("game started");
        Game.GetInstance().CurSong.Play();
        game_start = true;
        game_start_time = DateTime.Now;
        tmrPlay.Enabled = true;

        InitializeGameTimer();
        game_timer.Start();

        this.Controls.Remove(start_button);
        start_button.Dispose();
    }

    private void InitializeGameTimer()
    {
        game_timer = new Timer();
        game_timer.Interval = 1000; // Set the interval to 1 second
        game_timer.Tick += GameTimer_Tick;
    }

    private void GameTimer_Tick(object sender, EventArgs e)
    {
        TimeSpan elapsed = DateTime.Now - game_start_time;

        if (elapsed.TotalMilliseconds >= curSong.AudioLengthInMs)
        {
            lblScore.Text = score.Amount.ToString() + "/" + notes.Count().ToString();
            game_timer.Stop(); // Stop the timer if the song is over
            EndGame();
        }
    }

    private void EndGame()
    {
        this.KeyPreview = false;
        Game.GetInstance().CurSong.Stop();
        tmrPlay.Enabled = false;
    }

    private void return_btn_Click(object sender, EventArgs e)
    {
        this.Close();
    }
}
