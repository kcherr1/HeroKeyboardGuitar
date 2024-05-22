﻿namespace HeroKeyboardGuitar {
    partial class FrmTitle {
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
            btnStart = new System.Windows.Forms.Button();
            open_instructions = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            btnStart.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            btnStart.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            btnStart.ForeColor = System.Drawing.Color.Black;
            btnStart.Location = new System.Drawing.Point(468, 377);
            btnStart.Name = "btnStart";
            btnStart.Size = new System.Drawing.Size(170, 90);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = false;
            btnStart.Click += btnStart_Click;
            // 
            // open_instructions
            // 
            open_instructions.BackColor = System.Drawing.Color.FromArgb(192, 255, 255);
            open_instructions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            open_instructions.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            open_instructions.Location = new System.Drawing.Point(1, 503);
            open_instructions.Name = "open_instructions";
            open_instructions.Size = new System.Drawing.Size(162, 61);
            open_instructions.TabIndex = 1;
            open_instructions.Text = "Instructions";
            open_instructions.UseVisualStyleBackColor = false;
            open_instructions.Click += open_instructions_Click;
            // 
            // FrmTitle
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.title;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            ClientSize = new System.Drawing.Size(1060, 565);
            Controls.Add(open_instructions);
            Controls.Add(btnStart);
            DoubleBuffered = true;
            Name = "FrmTitle";
            Text = "Hero Keyboard Guitar";
            Load += FrmTitle_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button open_instructions;
    }
}