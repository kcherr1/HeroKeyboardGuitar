namespace HeroKeyboardGuitar {
    partial class FrmGame {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tmrPlay = new System.Windows.Forms.Timer(components);
            fret1 = new System.Windows.Forms.PictureBox();
            lblScore = new System.Windows.Forms.Label();
            tmrScoreShrink = new System.Windows.Forms.Timer(components);
            panBg = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            fret2 = new System.Windows.Forms.PictureBox();
            fret3 = new System.Windows.Forms.PictureBox();
            fret4 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)fret1).BeginInit();
            panBg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fret2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fret3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fret4).BeginInit();
            SuspendLayout();
            // 
            // tmrPlay
            // 
            tmrPlay.Interval = 50;
            tmrPlay.Tick += tmrPlay_Tick;
            // 
            // fret1
            // 
            fret1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            fret1.BackgroundImage = Properties.Resources._default;
            fret1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            fret1.Location = new System.Drawing.Point(372, 498);
            fret1.Name = "fret1";
            fret1.Size = new System.Drawing.Size(120, 120);
            fret1.TabIndex = 3;
            fret1.TabStop = false;
            // 
            // lblScore
            // 
            lblScore.BackColor = System.Drawing.Color.Transparent;
            lblScore.Dock = System.Windows.Forms.DockStyle.Bottom;
            lblScore.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            lblScore.ForeColor = System.Drawing.Color.White;
            lblScore.Location = new System.Drawing.Point(0, 391);
            lblScore.Name = "lblScore";
            lblScore.Size = new System.Drawing.Size(1237, 89);
            lblScore.TabIndex = 5;
            lblScore.Text = "0";
            lblScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrScoreShrink
            // 
            tmrScoreShrink.Enabled = true;
            tmrScoreShrink.Tick += tmrScoreShrink_Tick;
            // 
            // panBg
            // 
            panBg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            panBg.Controls.Add(fret4);
            panBg.Controls.Add(fret3);
            panBg.Controls.Add(fret2);
            panBg.Controls.Add(lblScore);
            panBg.Dock = System.Windows.Forms.DockStyle.Top;
            panBg.Location = new System.Drawing.Point(0, 0);
            panBg.Name = "panBg";
            panBg.Size = new System.Drawing.Size(1237, 480);
            panBg.TabIndex = 6;
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.BackColor = System.Drawing.Color.Gray;
            panel1.Location = new System.Drawing.Point(0, 498);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1237, 179);
            panel1.TabIndex = 7;
            panel1.Paint += panel1_Paint;
            // 
            // fret2
            // 
            fret2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            fret2.BackgroundImage = Properties.Resources._default;
            fret2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            fret2.Location = new System.Drawing.Point(372, 336);
            fret2.Name = "fret2";
            fret2.Size = new System.Drawing.Size(120, 120);
            fret2.TabIndex = 6;
            fret2.TabStop = false;
            // 
            // fret3
            // 
            fret3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            fret3.BackgroundImage = Properties.Resources._default;
            fret3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            fret3.Location = new System.Drawing.Point(372, 164);
            fret3.Name = "fret3";
            fret3.Size = new System.Drawing.Size(120, 120);
            fret3.TabIndex = 7;
            fret3.TabStop = false;
            // 
            // fret4
            // 
            fret4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            fret4.BackgroundImage = Properties.Resources._default;
            fret4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            fret4.Location = new System.Drawing.Point(372, 12);
            fret4.Name = "fret4";
            fret4.Size = new System.Drawing.Size(120, 120);
            fret4.TabIndex = 8;
            fret4.TabStop = false;
            fret4.Click += pictureBox3_Click;
            // 
            // FrmGame
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1237, 644);
            Controls.Add(panBg);
            Controls.Add(fret1);
            Controls.Add(panel1);
            Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Name = "FrmGame";
            Text = "Play Song";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            FormClosing += FrmMain_FormClosing;
            Load += FrmMain_Load;
            KeyDown += FrmMain_KeyDown;
            KeyPress += FrmMain_KeyPress;
            KeyUp += FrmMain_KeyUp;
            ((System.ComponentModel.ISupportInitialize)fret1).EndInit();
            panBg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)fret2).EndInit();
            ((System.ComponentModel.ISupportInitialize)fret3).EndInit();
            ((System.ComponentModel.ISupportInitialize)fret4).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer tmrPlay;
        private System.Windows.Forms.PictureBox fret1;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Timer tmrScoreShrink;
        private System.Windows.Forms.Panel panBg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox fret4;
        private System.Windows.Forms.PictureBox fret3;
        private System.Windows.Forms.PictureBox fret2;
    }
}
