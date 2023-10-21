namespace Parte_Visual
{
    partial class FrmNewGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNewGame));
            this.btnOK = new System.Windows.Forms.Button();
            this.cbsize = new System.Windows.Forms.ComboBox();
            this.nudinitial = new System.Windows.Forms.NumericUpDown();
            this.nudfinal = new System.Windows.Forms.NumericUpDown();
            this.nudholes = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nudinitial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudfinal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudholes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.ForeColor = System.Drawing.Color.Black;
            this.btnOK.Location = new System.Drawing.Point(275, 291);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(59, 39);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // cbsize
            // 
            this.cbsize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbsize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbsize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.cbsize.FormattingEnabled = true;
            this.cbsize.Items.AddRange(new object[] {
            "(8x8)",
            "(10x10)",
            "(13x13)",
            "(16x16)"});
            this.cbsize.Location = new System.Drawing.Point(242, 102);
            this.cbsize.Name = "cbsize";
            this.cbsize.Size = new System.Drawing.Size(92, 24);
            this.cbsize.TabIndex = 1;
            // 
            // nudinitial
            // 
            this.nudinitial.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudinitial.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nudinitial.Location = new System.Drawing.Point(187, 160);
            this.nudinitial.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudinitial.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudinitial.Name = "nudinitial";
            this.nudinitial.Size = new System.Drawing.Size(52, 26);
            this.nudinitial.TabIndex = 6;
            this.nudinitial.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nudfinal
            // 
            this.nudfinal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudfinal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nudfinal.Location = new System.Drawing.Point(282, 160);
            this.nudfinal.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.nudfinal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudfinal.Name = "nudfinal";
            this.nudfinal.Size = new System.Drawing.Size(52, 26);
            this.nudfinal.TabIndex = 7;
            this.nudfinal.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // nudholes
            // 
            this.nudholes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.nudholes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.nudholes.Location = new System.Drawing.Point(282, 216);
            this.nudholes.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.nudholes.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nudholes.Name = "nudholes";
            this.nudholes.Size = new System.Drawing.Size(52, 26);
            this.nudholes.TabIndex = 10;
            this.nudholes.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // FrmNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::Parte_Visual.Properties.Resources.New_Game1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(336, 342);
            this.Controls.Add(this.nudholes);
            this.Controls.Add(this.nudfinal);
            this.Controls.Add(this.nudinitial);
            this.Controls.Add(this.cbsize);
            this.Controls.Add(this.btnOK);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FrmNewGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewGame_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.nudinitial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudfinal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudholes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ComboBox cbsize;
        private System.Windows.Forms.NumericUpDown nudinitial;
        private System.Windows.Forms.NumericUpDown nudfinal;
        private System.Windows.Forms.NumericUpDown nudholes;
    }
}