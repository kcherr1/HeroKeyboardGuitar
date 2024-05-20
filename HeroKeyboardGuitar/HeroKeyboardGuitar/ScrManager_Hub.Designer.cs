using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;

namespace HeroKeyboardGuitar
{
    partial class ScrManager_Hub
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
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
            btn_delete = new Button();
            btn_back = new Button();
            btn_Add = new Button();
            SuspendLayout();
            // 
            // btn_delete
            // 
            btn_delete.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_delete.BackColor = Color.DarkOrange;
            btn_delete.FlatStyle = FlatStyle.Popup;
            btn_delete.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            btn_delete.ForeColor = Color.Black;
            btn_delete.Location = new Point(502, 392);
            btn_delete.Margin = new Padding(3, 4, 3, 4);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(492, 120);
            btn_delete.TabIndex = 1;
            btn_delete.Text = "Delete Songs";
            btn_delete.UseVisualStyleBackColor = false;
            btn_delete.Click += btn_deleteClicked;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.Red;
            btn_back.FlatStyle = FlatStyle.Popup;
            btn_back.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            btn_back.ForeColor = Color.Black;
            btn_back.Location = new Point(-11, 4);
            btn_back.Margin = new Padding(3, 4, 3, 4);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(326, 120);
            btn_back.TabIndex = 2;
            btn_back.Text = "Back";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_backClicked;
            // 
            // btn_Add
            // 
            btn_Add.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btn_Add.BackColor = Color.Lime;
            btn_Add.FlatStyle = FlatStyle.Popup;
            btn_Add.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Add.ForeColor = Color.Black;
            btn_Add.Location = new Point(502, 166);
            btn_Add.Margin = new Padding(3, 4, 3, 4);
            btn_Add.Name = "btn_Add";
            btn_Add.Size = new Size(492, 120);
            btn_Add.TabIndex = 4;
            btn_Add.Text = "Add Songs";
            btn_Add.UseVisualStyleBackColor = false;
            btn_Add.Click += btn_addClicked;
            // 
            // ScrManager_Hub
            // 
            BackgroundImage = Properties.Resources.song_manager;
            BackgroundImageLayout = ImageLayout.Stretch;
            Controls.Add(btn_Add);
            Controls.Add(btn_back);
            Controls.Add(btn_delete);
            DoubleBuffered = true;
            Name = "ScrManager_Hub";
            Size = new Size(1405, 885);
            Load += ScrManager_Hub_Load;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_back;
        private System.Windows.Forms.Button btn_Add;
    }
}
