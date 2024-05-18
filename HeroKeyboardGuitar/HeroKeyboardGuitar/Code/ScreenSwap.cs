using System;

namespace HeroKeyboardGuitar;
public class ScreenSwapHandler
{
    public delegate void ScreenHandler();

    // Events 
    public event ScreenHandler Title;
    public event ScreenHandler SongSelect;
    public event ScreenHandler SongManage;
    public event ScreenHandler Settings;
    public event ScreenHandler Quit;

    // Used for broadcasting messages to the Main form
    public void gotoTitle() => Title?.Invoke();
    public void gotoSongSelect() => SongSelect?.Invoke();
    public void gotoSongManage() => SongManage?.Invoke();
    public void gotoSettings() => Settings?.Invoke();
    public void goToQuit() => Quit?.Invoke();
}
