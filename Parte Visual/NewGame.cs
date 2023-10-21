using System;
using System.Windows.Forms;

namespace Parte_Visual
{
    /// <summary>
    /// Formulario de nuevo juego.
    /// </summary>
    public partial class FrmNewGame : Form
    {
        #region Variables utilzadas y constructor.
        private int size; //Para controlar el tamaño.

        //Necesito tener una instancia del form principal para poder reinicarlo con el nuevo tamaño.
        private readonly FrmMain main;

        //Constructor de la clase.
        public FrmNewGame(FrmMain main)
        {
            InitializeComponent();
            this.main = main;
            cbsize.SelectedItem = cbsize.Items[0];
        }
        #endregion
        #region Componentes.

        //Boton Ok.
        private void btOK_Click(object sender, EventArgs e)
        {
            //El tamaño es segun lo que se escoja en el combo box.
            if (cbsize.SelectedItem == cbsize.Items[0]) size = 8;
            else if (cbsize.SelectedItem == cbsize.Items[1]) size = 10;
            else if (cbsize.SelectedItem == cbsize.Items[2]) size = 13;
            else size = 16;

            //Reviso si es correcto el rango de valores.
            if (nudfinal.Value < nudinitial.Value || nudfinal.Value - nudinitial.Value < size + 1)
            {
                MessageBox.Show(@"Range of values invalidates.", @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Reinicio el form principal con el tamaño elegido y el rango de valores deseado.
            main.Restart(size, (int)nudinitial.Value, (int)nudfinal.Value, (int)nudholes.Value + 1);
            main.Show(); //Muestro el form principal.
            Close(); //Cierro este formulario.
        }

        //Boton cerrar.
        private void NewGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Muestro el form principal(Si no hago esto dejo un proceso abierto).
            main.Show();
        }
        #endregion
    }
}
