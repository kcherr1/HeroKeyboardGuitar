namespace HeroKeyboardGuitar
{
    partial class FrmHub
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
            SuspendLayout();
            // 
            // Hub
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1405, 885);
            DoubleBuffered = true;
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Hub";
            Text = "Hero Keyboard Guitar";
            Load += Scr_Load;
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnStart;
    }
}