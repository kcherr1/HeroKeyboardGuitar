using System;

namespace HeroKeyboardGuitar;
public class ScreenSwapHandler
{
    public delegate void ScreenHandler();

    // Events 
    public event ScreenHandler Title;
    public event ScreenHandler SongSelect;
    public event ScreenHandler SongManage_hub;
    public event ScreenHandler SongManage_add;
    public event ScreenHandler SongManage_delete;
    public event ScreenHandler update_SongManage_options;
    public event ScreenHandler Settings;
    public event ScreenHandler Quit;

    // Used for broadcasting messages to the Main form
    public void gotoTitle() => Title?.Invoke();
    public void gotoSongSelect() => SongSelect?.Invoke();
    public void gotoSongManage_hub() => SongManage_hub?.Invoke();

    public void gotoSongManage_add() => SongManage_add?.Invoke();
    public void gotoSongManage_delete() => SongManage_delete?.Invoke();
    public void goUpdate_SongManage() => update_SongManage_options?.Invoke();
    public void gotoSettings() => Settings?.Invoke();
    public void goToQuit() => Quit?.Invoke();
}
