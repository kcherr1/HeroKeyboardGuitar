namespace HeroKeyboardGuitar {
    partial class ScrTitle {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btn_addSongs = new System.Windows.Forms.Button();
            btn_quit = new System.Windows.Forms.Button();
            btn_Start = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btn_addSongs
            // 
            btn_addSongs.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_addSongs.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            btn_addSongs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btn_addSongs.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btn_addSongs.ForeColor = System.Drawing.Color.Black;
            btn_addSongs.Location = new System.Drawing.Point(502, 492);
            btn_addSongs.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btn_addSongs.Name = "btn_addSongs";
            btn_addSongs.Size = new System.Drawing.Size(492, 120);
            btn_addSongs.TabIndex = 1;
            btn_addSongs.Text = "Add Songs";
            btn_addSongs.UseVisualStyleBackColor = false;
            btn_addSongs.Click += btn_addSongClicked;
            // 
            // btn_quit
            // 
            btn_quit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_quit.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            btn_quit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btn_quit.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btn_quit.ForeColor = System.Drawing.Color.Black;
            btn_quit.Location = new System.Drawing.Point(502, 677);
            btn_quit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btn_quit.Name = "btn_quit";
            btn_quit.Size = new System.Drawing.Size(492, 120);
            btn_quit.TabIndex = 3;
            btn_quit.Text = "Quit";
            btn_quit.UseVisualStyleBackColor = false;
            btn_quit.Click += btn_quitClicked;
            // 
            // btn_Start
            // 
            btn_Start.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_Start.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            btn_Start.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btn_Start.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btn_Start.ForeColor = System.Drawing.Color.Black;
            btn_Start.Location = new System.Drawing.Point(502, 301);
            btn_Start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new System.Drawing.Size(492, 120);
            btn_Start.TabIndex = 4;
            btn_Start.Text = "Start";
            btn_Start.UseVisualStyleBackColor = false;
            btn_Start.Click += btn_startClicked;
            // 
            // ScrTitle
            // 
            BackgroundImage = Properties.Resources.title;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Controls.Add(btn_Start);
            Controls.Add(btn_quit);
            Controls.Add(btn_addSongs);
            DoubleBuffered = true;
            Name = "ScrTitle";
            Size = new System.Drawing.Size(1405, 885);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btn_addSongs;
        private System.Windows.Forms.Button btn_quit;
        private System.Windows.Forms.Button btn_Start;
    }
}