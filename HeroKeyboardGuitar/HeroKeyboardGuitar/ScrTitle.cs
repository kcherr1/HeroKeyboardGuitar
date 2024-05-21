using System;
using System.Windows.Forms;

namespace HeroKeyboardGuitar;

internal partial class ScrTitle : UserControl
{
    public ScreenSwapHandler handler;
    public ScrTitle()
    {
        InitializeComponent();
    }

    private void btn_startClicked(object sender, EventArgs e)
    {
        handler.gotoSongSelect();
    }

    private void btn_addSongClicked(object sender, EventArgs e)
    {
        handler.gotoSongManage_add();
    }

 
    private void btn_quitClicked(object sender, EventArgs e)
    {
        handler.goToQuit();     
    }
}
