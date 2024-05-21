using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeroKeyboardGuitar
{
    public partial class FrmHub : Form
    {
        private ScreenSwapHandler handler = new();
        private UserControl current_scr;
        private ScrTitle title_scr;
        private ScrSongSelect songSelect_scr;
        private ScrManager_Add songManage_add_scr;

        public FrmHub()
        {
            title_scr = new ScrTitle();
            songSelect_scr = new ScrSongSelect();
            songManage_add_scr = new ScrManager_Add();
            InitializeComponent();
        }

        private void Scr_Load(object sender, EventArgs e)
        {
            // makes sure each of the screens fills up the form
            setupFillAll();
            // adds functionality of the screens to the form
            setupAllScreenControls();
            // assigns behavior to all of the requests for the handler
            subscribeToAllScreenEvents();
            // makes all the screens use the same handlers as the form
            assignHandlerToAllScreens();
            // hides screens that won't be in use for now
            hideAllScreensExceptTitle();
            // assigns the current display to the title screen
            current_scr = title_scr;
        }

        private void hideAllScreensExceptTitle()
        {
            songSelect_scr.Hide();
            songManage_add_scr.Hide();
        }

        private void setupFillAll()
        {
            setupFill(title_scr);
            setupFill(songSelect_scr);
            setupFill(songManage_add_scr);
        }


        private void setupFill(UserControl screen)
        {
            screen.Dock = DockStyle.Fill;
        }

        private void setupAllScreenControls()
        {
            this.Controls.Add(title_scr);
            this.Controls.Add(songSelect_scr);
            this.Controls.Add(songManage_add_scr);
        }

        /// <summary>
        /// Sets each of the screen's handler to this form's handler
        /// so that the form is able to receive any messages of an event happening
        /// </summary>
        private void assignHandlerToAllScreens()
        {
            title_scr.handler = this.handler;
            songSelect_scr.handler = this.handler;
            songManage_add_scr.handler = this.handler;
        }

        /// <summary>
        /// Assigns each event broadcasted to a certain behavior. In this case,
        /// it is logic to swap to another screen.
        /// </summary>
        private void subscribeToAllScreenEvents()
        {
            handler.Title += () => swapScreen(title_scr);
            handler.SongSelect += () => swapScreen(songSelect_scr);
            handler.SongManage_add += () => swapScreen(songManage_add_scr);
            handler.update_SongManage_options += () => updateManagerScreens();
            handler.Quit += () => Application.Exit();

        }

        /// <summary>
        /// Helper Function for swapping screens.
        /// Ensures that the current screen is not being displayed before 
        /// swapping to a different screen and makes sure that its being displayed
        /// </summary>
        /// <param name="screen"></param>
        private void swapScreen(UserControl screen)
        {
            current_scr.Hide();
            current_scr = screen;
            current_scr.Show();

        }

        // need to refactor this later so that way its generalized. Need to be able to update song select too
        private void updateManagerScreens()
        {
            UserControl oldScreen = songManage_add_scr;
            songManage_add_scr = new ScrManager_Add();
            setupFill(songManage_add_scr);
            songManage_add_scr.handler = this.handler;
            this.Controls.Add(songManage_add_scr);
            handler.SongManage_add += () => swapScreen(songManage_add_scr);
            songManage_add_scr.Hide();
            oldScreen.Dispose();
            this.Controls.Remove(oldScreen);
        }

    }

}
