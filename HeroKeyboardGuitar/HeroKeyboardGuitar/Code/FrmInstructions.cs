using System;
using System.Windows.Forms;

namespace HeroKeyboardGuitar;


public partial class FrmInstructions : Form
{
    private Label instructionsLabel;

    public FrmInstructions()
    {
        instructionsLabel = new Label();
        instructionsLabel.Text = "How to Play:\n\n" +
                                    "1. Select a song and difficulty from the drop down menus.\n" +
                                    "2. Press the start button to begin the game.\n" +
                                    "3. Time the space bar presses until the note is about to reach the green circle.\n" +
                                    "4. Win!";
        instructionsLabel.AutoSize = true;

        this.Controls.Add(instructionsLabel);

        this.Text = "Instructions";
        this.StartPosition = FormStartPosition.CenterParent;
        this.AutoSize = true;
    }
}

