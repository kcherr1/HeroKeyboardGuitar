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
            btn_songManage = new System.Windows.Forms.Button();
            btn_settings = new System.Windows.Forms.Button();
            btn_quit = new System.Windows.Forms.Button();
            btn_Start = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btn_songManage
            // 
            btn_songManage.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_songManage.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            btn_songManage.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btn_songManage.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btn_songManage.ForeColor = System.Drawing.Color.Black;
            btn_songManage.Location = new System.Drawing.Point(502, 460);
            btn_songManage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btn_songManage.Name = "btn_songManage";
            btn_songManage.Size = new System.Drawing.Size(492, 120);
            btn_songManage.TabIndex = 1;
            btn_songManage.Text = "Manage Songs";
            btn_songManage.UseVisualStyleBackColor = false;
            btn_songManage.Click += btn_songManageClicked;
            // 
            // btn_settings
            // 
            btn_settings.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_settings.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            btn_settings.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btn_settings.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btn_settings.ForeColor = System.Drawing.Color.Black;
            btn_settings.Location = new System.Drawing.Point(502, 605);
            btn_settings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btn_settings.Name = "btn_settings";
            btn_settings.Size = new System.Drawing.Size(492, 120);
            btn_settings.TabIndex = 2;
            btn_settings.Text = "Settings";
            btn_settings.UseVisualStyleBackColor = false;
            btn_settings.Click += btn_settingsClicked;
            // 
            // btn_quit
            // 
            btn_quit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btn_quit.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            btn_quit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btn_quit.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btn_quit.ForeColor = System.Drawing.Color.Black;
            btn_quit.Location = new System.Drawing.Point(502, 750);
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
            btn_Start.Location = new System.Drawing.Point(502, 315);
            btn_Start.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btn_Start.Name = "btn_Start";
            btn_Start.Size = new System.Drawing.Size(492, 120);
            btn_Start.TabIndex = 4;
            btn_Start.Text = "Start";
            btn_Start.UseVisualStyleBackColor = false;
            btn_Start.Click += btn_startClicked;
            // 
            // FrmTitle
            // 
            //AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            //AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.title;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            Controls.Add(btn_Start);
            Controls.Add(btn_quit);
            Controls.Add(btn_settings);
            Controls.Add(btn_songManage);
            DoubleBuffered = true;
            //Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "FrmTitle";
            Size = new System.Drawing.Size(1405, 885);
            Load += FrmTitle_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btn_songManage;
        private System.Windows.Forms.Button btn_settings;
        private System.Windows.Forms.Button btn_quit;
        private System.Windows.Forms.Button btn_Start;
    }
}