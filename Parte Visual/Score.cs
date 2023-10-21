using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Parte_Visual
{
    /// <summary>
    /// Formulario de los mejores scores.
    /// </summary>
    public partial class FrScore : Form
    {
        #region Variables y constructores.
        //Variables utilizadas.
        private readonly double time;
        private readonly FrmMain main;
        private bool pasotime;

        //Constructores.
        public FrScore(FrmMain main)
        {
            InitializeComponent();
            this.main = main;

            //Oculto los componentes para que el usuario no pueda escribir.
            tboxname.Visible = false; 
            btnOK.Visible = false;
            lbwrite.Visible = false;
        }

        public FrScore(FrmMain main, double time)
        {
            InitializeComponent();
            this.time = time;
            this.main = main;
            pasotime = true;
        }
        #endregion
        #region Componentes

        //Boton Ok.
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (pasotime)
            {
                /*Reviso si me escribieron espacios en blanco y los sustituyo por '_'
                (para no tener problemas cuando intente parsear desde el txt) y adiciono el nuevo records.*/
                main.game.AddNewScore(time, tboxname.Text.Aggregate("", (current, t) => current + ((t == ' ') ? '_' : t)), main.size);
            }
            pasotime = false;
            Refresh(); //Refresco el formulario.
        }

        //Evento pintar names.
        private void lbmanes_Paint(object sender, PaintEventArgs e)
        {
            var paint = e.Graphics;
            var records = main.game.BestRecords.ToList();
            var width = lbnames.Width / 10 + 19;

            for (var i = 0; i < records.Count; i++)
                //Si el nombre tiene el cararter '_' lo sustituyo por ' '.
                paint.DrawString(records[i].Item2.Aggregate("", (current, t) => current + ((t == '_') ? ' ' : t)), new Font("Tahoma", 13), new SolidBrush(Color.Black), new Rectangle(0, i * width, 150, 26));
        }

        //Evento pintar times.
        private void lbtimes_Paint(object sender, PaintEventArgs e)
        {
            var paint = e.Graphics;
            var records = main.game.BestRecords.ToList();
            var width = lbnames.Width / 10 + 19;

            for (var i = 0; i < records.Count; i++)
                //Para no tener problemas con la coma.
                paint.DrawString(records[i].Item1.ToString().Aggregate("", (current, x) => current + ((x == ',') ? ',' : x)) + " min", new Font("Tahoma", 13), new SolidBrush(Color.Black), new Rectangle(0, i * width, 120, 26));
        }
        //Evento pintar sizes.
        private void lbsizes_Paint(object sender, PaintEventArgs e)
        {
            var paint = e.Graphics;
            var records = main.game.BestRecords.ToList();
            var width = lbnames.Width / 10 + 19;

            for (var i = 0; i < records.Count; i++)
                paint.DrawString((records[i].Item3 + " x " + records[i].Item3), new Font("Tahoma", 13), new SolidBrush(Color.Black), new Rectangle(0, i * width, 120, 26));
        }
        #endregion
    }
}
