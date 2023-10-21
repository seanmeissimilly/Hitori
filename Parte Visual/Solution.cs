using System.Drawing;
using System.Windows.Forms;

namespace Parte_Visual
{
    /// <summary>
    /// Formulario solucion.
    /// </summary>
    public partial class FrSolution : Form
    {
        private readonly FrmMain main; //Instancia del formulario principal.

        //Constructor.
        public FrSolution(FrmMain main)
        {
            InitializeComponent();
            this.main = main;
        }

        //Evento pintar.
        private void pbxLienzo_Paint(object sender, PaintEventArgs e)
        {
            var paint = e.Graphics;
            var width = pbxLienzo.Width / main.size; //Calculo el ancho de cada casilla.

            //Cuadriculo el tablero.
            for (var i = 0; i < main.size; i++)
            {
                paint.DrawLine(new Pen(Color.Gold, 1), i * width - 1, 0, i * width - 1, pbxLienzo.Height);
                paint.DrawLine(new Pen(Color.Gold, 1), 0, i * width - 1, pbxLienzo.Width, i * width - 1);
            }

            //pinto las casillas.
            var answer = main.game.Solution;
            foreach (var t in answer)
                paint.FillRectangle(new SolidBrush(Color.Goldenrod), new Rectangle(t.Y * width, t.X * width, width - 1, width - 1));

        }
    }
}
