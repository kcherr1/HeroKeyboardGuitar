﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace HeroKeyboardGuitar
{
    public partial class FrmInstructions : Form
    {
        private Label instructionsLabel;

        public FrmInstructions()
        {
            instructionsLabel = new Label();
            instructionsLabel.Text = "How to Play:\n\n" +
                                        "1. Select a song and difficulty from the drop-down menu.\n" +
                                        "2. Press the start button or 'Spacebar' to begin the game.\n" +
                                        "3. Time the space bar presses until the note reaches the green circle.\n" +
                                        "4. Have fun!";
            instructionsLabel.AutoSize = true;
            instructionsLabel.Font = new Font("Arial", 12); // Change font and size
            instructionsLabel.TextAlign = ContentAlignment.MiddleLeft; // Align text to left
            instructionsLabel.Padding = new Padding(10); // Add padding around the label

            this.Controls.Add(instructionsLabel);

            this.Text = "Instructions";
            this.StartPosition = FormStartPosition.CenterParent;
            this.AutoSize = true;
        }
    }
}
