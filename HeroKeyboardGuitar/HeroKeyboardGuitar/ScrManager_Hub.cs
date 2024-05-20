using System;
using System.Windows.Forms;

namespace HeroKeyboardGuitar;

internal partial class ScrManager_Hub : UserControl
{
    public ScreenSwapHandler handler;
    public ScrManager_Hub()
    {
        InitializeComponent();
    }

    private void btnStart_Click(object sender, EventArgs e)
    {
        ScrSongSelect frmSongSelect = new();
        frmSongSelect.Show();
    }

    private void ScrManager_Hub_Load(object sender, EventArgs e)
    {
        /*
        btnStart.Left = Width / 2 - btnStart.Width / 2;
        btnStart.Top = (int)(Height * 0.65);
        */
    }

    private void btn_startClicked(object sender, EventArgs e)
    {
        handler.gotoSongSelect();
    }

    private void btn_addClicked(object sender, EventArgs e)
    {

    }

    private void btn_deleteClicked(object sender, EventArgs e)
    {

    }

    private void btn_backClicked(object sender, EventArgs e)
    {
        handler.gotoTitle();
    }
}
