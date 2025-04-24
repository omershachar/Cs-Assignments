namespace Assignment4
{
    partial class ClosetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClosetForm));
            this.lblWelcomeMsg = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblWelcomeMsg
            // 
            this.lblWelcomeMsg.AutoSize = true;
            this.lblWelcomeMsg.Location = new System.Drawing.Point(12, 24);
            this.lblWelcomeMsg.Name = "lblWelcomeMsg";
            this.lblWelcomeMsg.Size = new System.Drawing.Size(157, 20);
            this.lblWelcomeMsg.TabIndex = 0;
            this.lblWelcomeMsg.Text = "Welcome <this.user>";
            // 
            // ClosetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblWelcomeMsg);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ClosetForm";
            this.Tag = "";
            this.Text = "ClosetForm";
            this.Load += new System.EventHandler(this.ClosetForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcomeMsg;
    }
}

