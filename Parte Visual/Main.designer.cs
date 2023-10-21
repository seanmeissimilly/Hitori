namespace Parte_Visual
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pbxLienzo = new System.Windows.Forms.PictureBox();
            this.Menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cboxchangecolor = new System.Windows.Forms.ToolStripComboBox();
            this.musicToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewSolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.howToPlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Abrir = new System.Windows.Forms.OpenFileDialog();
            this.Salvar = new System.Windows.Forms.SaveFileDialog();
            this.lbinvalid = new System.Windows.Forms.Label();
            this.clgColor = new System.Windows.Forms.ColorDialog();
            this.reloj = new System.Windows.Forms.Timer(this.components);
            this.lbtime = new System.Windows.Forms.Label();
            this.bthint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLienzo)).BeginInit();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxLienzo
            // 
            this.pbxLienzo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbxLienzo.Cursor = System.Windows.Forms.Cursors.Hand;
            resources.ApplyResources(this.pbxLienzo, "pbxLienzo");
            this.pbxLienzo.Name = "pbxLienzo";
            this.pbxLienzo.TabStop = false;
            this.pbxLienzo.Paint += new System.Windows.Forms.PaintEventHandler(this.pbxLienzo_Paint);
            this.pbxLienzo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbxLienzo_MouseClick);
            // 
            // Menu
            // 
            this.Menu.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            resources.ApplyResources(this.Menu, "Menu");
            this.Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.Menu.Name = "Menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameToolStripMenuItem,
            this.restartGameToolStripMenuItem,
            this.saveGameToolStripMenuItem,
            this.loadGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // newGameToolStripMenuItem
            // 
            this.newGameToolStripMenuItem.Name = "newGameToolStripMenuItem";
            resources.ApplyResources(this.newGameToolStripMenuItem, "newGameToolStripMenuItem");
            this.newGameToolStripMenuItem.Click += new System.EventHandler(this.newGameToolStripMenuItem_Click);
            // 
            // restartGameToolStripMenuItem
            // 
            this.restartGameToolStripMenuItem.Name = "restartGameToolStripMenuItem";
            resources.ApplyResources(this.restartGameToolStripMenuItem, "restartGameToolStripMenuItem");
            this.restartGameToolStripMenuItem.Click += new System.EventHandler(this.restartGameToolStripMenuItem_Click);
            // 
            // saveGameToolStripMenuItem
            // 
            this.saveGameToolStripMenuItem.Name = "saveGameToolStripMenuItem";
            resources.ApplyResources(this.saveGameToolStripMenuItem, "saveGameToolStripMenuItem");
            this.saveGameToolStripMenuItem.Click += new System.EventHandler(this.saveGameToolStripMenuItem_Click);
            // 
            // loadGameToolStripMenuItem
            // 
            this.loadGameToolStripMenuItem.Name = "loadGameToolStripMenuItem";
            resources.ApplyResources(this.loadGameToolStripMenuItem, "loadGameToolStripMenuItem");
            this.loadGameToolStripMenuItem.Click += new System.EventHandler(this.loadGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.colorsToolStripMenuItem,
            this.musicToolStripMenuItem,
            this.viewScoreToolStripMenuItem,
            this.viewSolutionToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            resources.ApplyResources(this.optionsToolStripMenuItem, "optionsToolStripMenuItem");
            // 
            // colorsToolStripMenuItem
            // 
            this.colorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cboxchangecolor});
            this.colorsToolStripMenuItem.Name = "colorsToolStripMenuItem";
            resources.ApplyResources(this.colorsToolStripMenuItem, "colorsToolStripMenuItem");
            // 
            // cboxchangecolor
            // 
            resources.ApplyResources(this.cboxchangecolor, "cboxchangecolor");
            this.cboxchangecolor.Items.AddRange(new object[] {
            resources.GetString("cboxchangecolor.Items"),
            resources.GetString("cboxchangecolor.Items1"),
            resources.GetString("cboxchangecolor.Items2"),
            resources.GetString("cboxchangecolor.Items3"),
            resources.GetString("cboxchangecolor.Items4"),
            resources.GetString("cboxchangecolor.Items5")});
            this.cboxchangecolor.Name = "cboxchangecolor";
            this.cboxchangecolor.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            // 
            // musicToolStripMenuItem
            // 
            this.musicToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onToolStripMenuItem});
            this.musicToolStripMenuItem.Name = "musicToolStripMenuItem";
            resources.ApplyResources(this.musicToolStripMenuItem, "musicToolStripMenuItem");
            // 
            // onToolStripMenuItem
            // 
            this.onToolStripMenuItem.Name = "onToolStripMenuItem";
            resources.ApplyResources(this.onToolStripMenuItem, "onToolStripMenuItem");
            this.onToolStripMenuItem.Click += new System.EventHandler(this.onToolStripMenuItem_Click);
            // 
            // viewScoreToolStripMenuItem
            // 
            this.viewScoreToolStripMenuItem.Name = "viewScoreToolStripMenuItem";
            resources.ApplyResources(this.viewScoreToolStripMenuItem, "viewScoreToolStripMenuItem");
            this.viewScoreToolStripMenuItem.Click += new System.EventHandler(this.viewScoreToolStripMenuItem_Click);
            // 
            // viewSolutionToolStripMenuItem
            // 
            this.viewSolutionToolStripMenuItem.Name = "viewSolutionToolStripMenuItem";
            resources.ApplyResources(this.viewSolutionToolStripMenuItem, "viewSolutionToolStripMenuItem");
            this.viewSolutionToolStripMenuItem.Click += new System.EventHandler(this.viewSolutionToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToPlayToolStripMenuItem,
            this.aboToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // howToPlayToolStripMenuItem
            // 
            this.howToPlayToolStripMenuItem.Name = "howToPlayToolStripMenuItem";
            resources.ApplyResources(this.howToPlayToolStripMenuItem, "howToPlayToolStripMenuItem");
            this.howToPlayToolStripMenuItem.Click += new System.EventHandler(this.howToPlayToolStripMenuItem_Click);
            // 
            // aboToolStripMenuItem
            // 
            this.aboToolStripMenuItem.Name = "aboToolStripMenuItem";
            resources.ApplyResources(this.aboToolStripMenuItem, "aboToolStripMenuItem");
            this.aboToolStripMenuItem.Click += new System.EventHandler(this.aboToolStripMenuItem_Click);
            // 
            // Abrir
            // 
            this.Abrir.FileName = "openFileDialog1";
            resources.ApplyResources(this.Abrir, "Abrir");
            // 
            // Salvar
            // 
            resources.ApplyResources(this.Salvar, "Salvar");
            // 
            // lbinvalid
            // 
            this.lbinvalid.BackColor = System.Drawing.Color.Linen;
            this.lbinvalid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            resources.ApplyResources(this.lbinvalid, "lbinvalid");
            this.lbinvalid.ForeColor = System.Drawing.Color.Red;
            this.lbinvalid.Name = "lbinvalid";
            // 
            // reloj
            // 
            this.reloj.Interval = 1000;
            this.reloj.Tick += new System.EventHandler(this.reloj_Tick);
            // 
            // lbtime
            // 
            resources.ApplyResources(this.lbtime, "lbtime");
            this.lbtime.Name = "lbtime";
            // 
            // bthint
            // 
            resources.ApplyResources(this.bthint, "bthint");
            this.bthint.Name = "bthint";
            this.bthint.UseVisualStyleBackColor = true;
            this.bthint.Click += new System.EventHandler(this.bthint_Click);
            // 
            // FrmMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Linen;
            this.Controls.Add(this.bthint);
            this.Controls.Add(this.lbtime);
            this.Controls.Add(this.lbinvalid);
            this.Controls.Add(this.pbxLienzo);
            this.Controls.Add(this.Menu);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.Menu;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pbxLienzo)).EndInit();
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbxLienzo;
        private System.Windows.Forms.MenuStrip Menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog Abrir;
        private System.Windows.Forms.SaveFileDialog Salvar;
        private System.Windows.Forms.ToolStripMenuItem restartGameToolStripMenuItem;
        private System.Windows.Forms.Label lbinvalid;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem colorsToolStripMenuItem;
        private System.Windows.Forms.ColorDialog clgColor;
        private System.Windows.Forms.Timer reloj;
        private System.Windows.Forms.Label lbtime;
        private System.Windows.Forms.ToolStripMenuItem howToPlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox cboxchangecolor;
        private System.Windows.Forms.ToolStripMenuItem musicToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewSolutionToolStripMenuItem;
        private System.Windows.Forms.Button bthint;
        private System.Windows.Forms.ToolStripMenuItem viewScoreToolStripMenuItem;
    }
}

