using System;
using System.Windows.Forms;

namespace Parte_Visual
{
    /// <summary>
    /// Formulario de juego ganado.
    /// </summary>
    public partial class FrmWin : Form
    {
        #region Variables utilzadas y constructor.

        private readonly FrmMain main;  //Instancia del formulacio principal.
        private FrScore score; //Instancia del formulacio High Scores.
        private readonly bool valid; //Para saber si el usuario miro la solucion.
        private readonly double time;
        private bool yamostre; //Para no mostrar 2 veces el formulario de High Scores.

        //Constructor de la clase.
        public FrmWin(FrmMain main, double time, bool valid)
        {
            InitializeComponent();
            this.main = main;
            this.time = time;
            this.valid = valid;
        }
        #endregion
        #region Componentes.

        //Boton Ok.
        private void btOK_Click(object sender, EventArgs e)
        {
            main.Restart(main.size); //Reinicio el tablero.
            main.Show();
            if (valid && !yamostre)
            {
                score = new FrScore(main, time);
                score.Show();
                yamostre = true;
            }
            Close(); //Cierro este formulario.
        }

        //Boton cerrar.
        private void Win_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Restart(main.size); //Reinicio el tablero.
            main.Show(); //Muestro el form principal(Sino hago este dejo un proceso abierto).
            if (!valid || yamostre) return;
            score = new FrScore(main, time);
            score.Show();
        }
        #endregion
    }
}
