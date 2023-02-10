namespace Game
{
    partial class GameBoard
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
            this.lblP1 = new System.Windows.Forms.Label();
            this.lblP2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblP1
            // 
            this.lblP1.AutoSize = true;
            this.lblP1.Location = new System.Drawing.Point(587, 226);
            this.lblP1.Name = "lblP1";
            this.lblP1.Size = new System.Drawing.Size(79, 15);
            this.lblP1.TabIndex = 0;
            this.lblP1.Text = "Player 1 score";
            // 
            // lblP2
            // 
            this.lblP2.AutoSize = true;
            this.lblP2.Location = new System.Drawing.Point(587, 261);
            this.lblP2.Name = "lblP2";
            this.lblP2.Size = new System.Drawing.Size(79, 15);
            this.lblP2.TabIndex = 1;
            this.lblP2.Text = "Player 2 score";
            // 
            // GameBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblP2);
            this.Controls.Add(this.lblP1);
            this.Name = "GameBoard";
            this.Text = "GameBoard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Label lblP1;
        public Label lblP2;
    }
}