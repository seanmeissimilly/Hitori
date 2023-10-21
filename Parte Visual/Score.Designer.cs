namespace Parte_Visual
{
    partial class FrScore
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrScore));
            this.tboxname = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbnames = new System.Windows.Forms.Label();
            this.lbtimes = new System.Windows.Forms.Label();
            this.lbsizes = new System.Windows.Forms.Label();
            this.lbwrite = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tboxname
            // 
            this.tboxname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tboxname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tboxname.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxname.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.tboxname.Location = new System.Drawing.Point(255, 560);
            this.tboxname.MaxLength = 10;
            this.tboxname.Name = "tboxname";
            this.tboxname.Size = new System.Drawing.Size(150, 26);
            this.tboxname.TabIndex = 0;
            this.tboxname.Text = "NONE";
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.Navy;
            this.btnOK.Location = new System.Drawing.Point(411, 562);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(43, 24);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbnames
            // 
            this.lbnames.BackColor = System.Drawing.Color.Transparent;
            this.lbnames.Location = new System.Drawing.Point(58, 138);
            this.lbnames.Name = "lbnames";
            this.lbnames.Size = new System.Drawing.Size(239, 399);
            this.lbnames.TabIndex = 4;
            this.lbnames.Paint += new System.Windows.Forms.PaintEventHandler(this.lbmanes_Paint);
            // 
            // lbtimes
            // 
            this.lbtimes.BackColor = System.Drawing.Color.Transparent;
            this.lbtimes.Location = new System.Drawing.Point(362, 138);
            this.lbtimes.Name = "lbtimes";
            this.lbtimes.Size = new System.Drawing.Size(134, 399);
            this.lbtimes.TabIndex = 5;
            this.lbtimes.Paint += new System.Windows.Forms.PaintEventHandler(this.lbtimes_Paint);
            // 
            // lbsizes
            // 
            this.lbsizes.BackColor = System.Drawing.Color.Transparent;
            this.lbsizes.Location = new System.Drawing.Point(574, 138);
            this.lbsizes.Name = "lbsizes";
            this.lbsizes.Size = new System.Drawing.Size(134, 399);
            this.lbsizes.TabIndex = 6;
            this.lbsizes.Paint += new System.Windows.Forms.PaintEventHandler(this.lbsizes_Paint);
            // 
            // lbwrite
            // 
            this.lbwrite.BackColor = System.Drawing.Color.Transparent;
            this.lbwrite.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbwrite.Location = new System.Drawing.Point(12, 560);
            this.lbwrite.Name = "lbwrite";
            this.lbwrite.Size = new System.Drawing.Size(225, 26);
            this.lbwrite.TabIndex = 7;
            this.lbwrite.Text = "Please, Write your name:";
            // 
            // FrScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Parte_Visual.Properties.Resources.High_Scores_Hitori_mejorado;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(754, 608);
            this.Controls.Add(this.lbwrite);
            this.Controls.Add(this.lbsizes);
            this.Controls.Add(this.lbtimes);
            this.Controls.Add(this.lbnames);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.tboxname);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrScore";
            this.Text = "High Scores";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxname;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lbnames;
        private System.Windows.Forms.Label lbtimes;
        private System.Windows.Forms.Label lbsizes;
        private System.Windows.Forms.Label lbwrite;
    }
}