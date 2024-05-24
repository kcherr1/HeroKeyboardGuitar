namespace HeroKeyboardGuitar
{
    partial class FrmScoreInput
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
            btn_upload = new System.Windows.Forms.Button();
            btn_ignore = new System.Windows.Forms.Button();
            txtPlayerID = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // btn_upload
            // 
            btn_upload.Location = new System.Drawing.Point(134, 338);
            btn_upload.Name = "btn_upload";
            btn_upload.Size = new System.Drawing.Size(138, 75);
            btn_upload.TabIndex = 0;
            btn_upload.Text = "UPLOAD";
            btn_upload.UseVisualStyleBackColor = true;
            btn_upload.Click += this.btn_upload_Click;
            // 
            // btn_ignore
            // 
            btn_ignore.Location = new System.Drawing.Point(521, 338);
            btn_ignore.Name = "btn_ignore";
            btn_ignore.Size = new System.Drawing.Size(138, 75);
            btn_ignore.TabIndex = 1;
            btn_ignore.Text = "IGNORE";
            btn_ignore.UseVisualStyleBackColor = true;
            btn_ignore.Click += this.btn_ignore_Click;
            // 
            // txtPlayerID
            // 
            txtPlayerID.Location = new System.Drawing.Point(270, 178);
            txtPlayerID.Name = "txtPlayerID";
            txtPlayerID.Size = new System.Drawing.Size(259, 23);
            txtPlayerID.TabIndex = 2;
            txtPlayerID.MaxLength = 3;
            // 
            // FrmScoreInput
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(txtPlayerID);
            Controls.Add(btn_ignore);
            Controls.Add(btn_upload);
            Name = "FrmScoreInput";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btn_upload;
        private System.Windows.Forms.Button btn_ignore;
        private System.Windows.Forms.TextBox txtPlayerID;
    }
}