namespace Parte_Visual
{
    partial class FrSolution
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrSolution));
            this.pbxLienzo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLienzo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxLienzo
            // 
            this.pbxLienzo.BackColor = System.Drawing.Color.Wheat;
            this.pbxLienzo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.pbxLienzo, "pbxLienzo");
            this.pbxLienzo.Name = "pbxLienzo";
            this.pbxLienzo.TabStop = false;
            this.pbxLienzo.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxLienzo_Paint);
            // 
            // FrSolution
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pbxLienzo);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "FrSolution";
            ((System.ComponentModel.ISupportInitialize)(this.pbxLienzo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxLienzo;
    }
}