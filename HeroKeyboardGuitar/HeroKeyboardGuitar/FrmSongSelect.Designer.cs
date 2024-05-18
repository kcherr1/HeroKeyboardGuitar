namespace HeroKeyboardGuitar {
    partial class FrmSongSelect {
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
            btn_Back = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btn_Back
            // 
            btn_Back.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Top;
            btn_Back.BackColor = System.Drawing.Color.Red;
            btn_Back.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btn_Back.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btn_Back.ForeColor = System.Drawing.Color.Black;
            btn_Back.Location = new System.Drawing.Point(3, 4);
            btn_Back.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new System.Drawing.Size(262, 120);
            btn_Back.TabIndex = 5;
            btn_Back.Text = "Back";
            btn_Back.UseVisualStyleBackColor = false;
            btn_Back.Click += btn_BackClick;
            // 
            // FrmSongSelect
            // 
            //AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            //AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Black;
            Controls.Add(btn_Back);
            //Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "FrmSongSelect";
            Size = new System.Drawing.Size(1211, 753);
            Load += FrmSongSelect_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_Back;
    }
}