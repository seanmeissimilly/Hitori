using System;
using System.Drawing;
using System.IO;
using System.Media;
using System.Threading;
using System.Windows.Forms;
using Parte_Logica;
using Parte_Visual.Properties;

namespace Parte_Visual
{
    /// <summary>
    /// Formulario principal.
    /// </summary>
    public partial class FrmMain : Form
    {
        #region Constructores.

        // Constructores de la clase.
        public FrmMain(int size = 8)
        {
            InitializeComponent();
            
            //Parte de los sonidos.
            sound = new SoundPlayer(Resources.musica_de_fondo);
            soundinvalidates = new SoundPlayer();
            sound.PlayLooping(); //Empiezo a reproducir la musica.
            isplaying = true; //La musica esta reproduciendose. 

            //Parte logica de juego.
            game = new ParteLogica(size); //Inicalizo el juego.
            this.size = size;
            valid = true;
            position = new int[4];
            invalid = false;
            solution = new FrSolution(this);

            //Parte del tiempo.
            minutes = seconds = 0;
            lbtime.Text = minutes.ToString("00") + @":" + seconds.ToString("00");

            //Combox de cambiar los colores.
            cboxchangecolor.Text = @"Selects an element";

            score = new FrScore(this);

            //Para cargar automaticamemte el ultimo tablero jugado.
            if (!File.Exists("last.hitori")) return; //Reviso si existe.

            //Reviso si el archivo es valido.
            try { game = game.LoadGame("last.hitori", out minutes, out seconds); }
            catch (Exception a) { MessageBox.Show(a.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            this.size = game.Size; //Actualizo el tamaño.

            //Inicio el reloj donde se quedo el juego anterior.
            reloj.Start();
            lbtime.Text = minutes.ToString("00") + @":" + seconds.ToString("00");
        }

        #endregion
        #region Variables utilizadas.

        /*Pintar
        Array de colores(Colores por defecto utilizados para pintar)
        { color de sombra, color de linea, color de fondo, color de numeros, color invalido, color hint }*/
        private readonly Color[] colors = { Color.Goldenrod, Color.Gold, Color.Wheat, Color.Blue, Color.Red, Color.Aquamarine };

        /*Time*/
        private int minutes, seconds; //Para llevar el tiempo.

        /*Parte Logica*/
        public ParteLogica game; //Creo una instancia de la clase juego.

        /*Casilla invalida y hint*/
        private bool invalid, hint; //Para pintar la casilla invalida y para pintar la casilla hint.
        private readonly int[] position; //Para almacenar posicion de la casilla invalida y la casilla hint.

        public int size; //Para saber el tamaño.

        /*Musica*/
        private readonly SoundPlayer sound, soundinvalidates; //Para reproducir musica: de fondo y cuando marque una casilla invalida.
        private bool isplaying; //Para verificar cuándo se está reproduciendo sonido(su valor es true) y cuando no(false).

        /*Solucion*/
        private FrSolution solution; // Para mostrar la solucion.
        private bool valid; //Para saber si el usuario mira la respuesta(si la mira no vale aunque gane).

        /*High Scores*/
        private FrScore score; //Instancia del formulario de High Scores.

        #endregion
        #region Componentes.

        //Boton de la musica de fondo.
        private void onToolStripMenuItem_Click(object sender, EventArgs e)
        {
            isplaying = !isplaying; //Cambio el estado del bool.
            if (isplaying) sound.PlayLooping(); //si esta en true, reproduzco la musica.
            else sound.Stop(); //Paro la musica.
        }

        //Boton Exit.
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //Boton Cargar.
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            solution.Close(); //Por si esta abierto.
            if (Abrir.ShowDialog() == DialogResult.OK)
            {
                //Reviso si el archivo es valido.
                try { game = game.LoadGame(Abrir.FileName, out minutes, out seconds); }
                catch (Exception a) { MessageBox.Show(a.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            else MessageBox.Show(@"You don't select any previous play.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            size = game.Size; //Actualizo el tamaño.

            //Cargo el tiempo.
            lbtime.Text = minutes.ToString("00") + @":" + seconds.ToString("00");
            reloj.Start();

            Refresh(); //Refresco la aplicacion.
        }

        //Boton Salvar.
        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            solution.Close(); //Por si esta abierto.

            if (Salvar.ShowDialog() == DialogResult.OK) game.SaveGame(Salvar.FileName, minutes, seconds);
            else MessageBox.Show(@"You didn't save.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Evento pintar.
        private void pbxLienzo_Paint(object sender, PaintEventArgs e)
        {
            var paint = e.Graphics;
            var width = pbxLienzo.Width / size; //Calculo el ancho de cada casilla.

            //Brochas para pintar.
            var delete = new SolidBrush(colors[0]);
            var nodelete = new SolidBrush(colors[2]);
            var pencil = new SolidBrush(colors[3]);
            var pen = new Pen(colors[1], 1);

            var center = new StringFormat //Para poder centrar los numeros.
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            //Cuadriculo el tablero.
            for (var i = 0; i < size; i++)
            {
                paint.DrawLine(pen, i * width - 1, 0, i * width - 1, pbxLienzo.Height);
                paint.DrawLine(pen, 0, i * width - 1, pbxLienzo.Width, i * width - 1);
            }

            //Creo una fuente para escribir el string.
            var font = new Font(FontFamily.GenericSansSerif, pbxLienzo.Width / (size * (float)(3.9)));

            for (var i = 0; i < size; i++)
                for (var j = 0; j < size; j++)
                {
                    var square = new Rectangle(j * width, i * width, width - 1, width - 1);

                    //Voy a pintar de un color las casillas tachadas.
                    if (game.ThisDarkened(i, j)) paint.FillRectangle(delete, square);
                    else
                    {
                        paint.FillRectangle(nodelete, square); //Pinto de otro color las casillas no marcadas.
                        paint.DrawString(game[i, j].ToString(), font, pencil, square, center); //Pinto el numero de cada casilla.
                    }
                }

            //Para pintar la casilla invalida.
            if (invalid) paint.FillRectangle(new SolidBrush(colors[4]), new Rectangle(position[1] * width, position[0] * width, width - 1, width - 1));
            //Para pintar la casilla hint.
            if (hint) paint.FillRectangle(new SolidBrush(colors[5]), new Rectangle(position[3] * width, position[2] * width, width - 1, width - 1));

            cboxchangecolor.Text = @"Selects an element"; //Combox de cambiar los colores.
        }

        //Evento MouseClick.
        private void pbxLienzo_MouseClick(object sender, MouseEventArgs e)
        {
            reloj.Start(); //Inicio el reloj;

            //Calculo las coordenadas de la casilla del tablero donde se hizo click.
            int i = e.Y / (pbxLienzo.Width / size), j = e.X / (pbxLienzo.Width / size);

            try
            {
                if (!(invalid && i == position[0] && j == position[1]))
                {
                    //Reviso el estado de la casilla(tachada o no tachada).
                    if (game.ThisDarkened(i, j)) game.Clarify(i, j); 
                    else game.Darken(i, j);
                }

                lbinvalid.Text = "";
                invalid = false;

                Refresh(); //Refresco la aplicacion.

                //Reviso si el usuario gano.
                if (!game.Win) return;
                solution.Close(); //Por si esta abierto.
                score.Close(); //Por si esta abierto.

                //Muestro el formulario de juego completado.
                var win = new FrmWin(this, (float)(minutes + seconds / 100.0), valid);
                win.Show();
                Hide(); //Oculto este formulario.
            }
            catch (Exception a)
            {
                soundinvalidates.Play(); //Reproduzco un sonido para avisar que la casilla es invalida.
                position[0] = i; position[1] = j; //Almaceno la posicion de la casilla invalida.
                invalid = true; //Pongo la variable invalida en true(para pintar la casilla).
                lbinvalid.Text = a.Message; //Imprimo la exepcion.
                Refresh(); //Refresco la aplicacion.
            }
        }

        //Boton New Game.
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            solution.Close(); //Por si esta abierto.
            //Pregunto antes de iniciar un nuevo juego.
            var sms = MessageBox.Show(@"You want to begin a new game?", @"Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            //Escondo el form principal y muestro el de NewGame.
            if (sms != DialogResult.OK) return;
            var nuevo = new FrmNewGame(this); //Le paso este formulario.
            nuevo.Show();
            Hide();
        }

        //Boton Reiniciar.
        private void restartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            solution.Close(); //Por si esta abierto.

            //Pregunto antes de reiniciar.
            var sms = MessageBox.Show(@"You really want to restart the game?", @"Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (sms != DialogResult.OK) return;
            game.Restart();
            Refresh(); //Refresco la aplicacion.
        }

        //Boton mostrar score.
        private void viewScoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            score.Close(); //Por si esta abierto.
            score = new FrScore(this);
            score.Show();
        }

        //Boton Cerrar.
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Salvo el ultimo tablero (para cuando el usuario vuelva a iniciar carge automatico).
            game.SaveGame("last.hitori", minutes, seconds);

            //Para guardar antes de salir.
            var mensaje = MessageBox.Show(@"Does want to discard the new carried out plays?", @"Warning",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (mensaje != DialogResult.No) return;
            if (Salvar.ShowDialog() == DialogResult.OK) game.SaveGame(Salvar.FileName, minutes, seconds);
            else MessageBox.Show(@"You didn't save.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //Combo box de cambiar los colores.
        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxchangecolor.SelectedItem == cboxchangecolor.Items[0]) ChangeColor(2); //Color de fondo.
            else if (cboxchangecolor.SelectedItem == cboxchangecolor.Items[1]) ChangeColor(5); //Color de casilla pista.
            else if (cboxchangecolor.SelectedItem == cboxchangecolor.Items[2]) ChangeColor(4); //Color de casilla invalida.
            else if (cboxchangecolor.SelectedItem == cboxchangecolor.Items[3]) ChangeColor(1); //Color de linea.
            else if (cboxchangecolor.SelectedItem == cboxchangecolor.Items[4]) ChangeColor(3);  //Color de numeros.
            else if (cboxchangecolor.SelectedItem == cboxchangecolor.Items[5]) ChangeColor(0); //Color de sombra.
        }

        //Timer.
        private void reloj_Tick(object sender, EventArgs e)
        {
            /*Con cada tick (ocurren cada segundo) del timer, se suma 1 a la cantidad de segundos transcurridos.
             una vez que los segundos transcurridos llegan a 60, se suma 1 a la cantidad de minutos y se pone la cantidad
             de segundos en 0, de forma que se simula un reloj. */
            seconds++;
            if (seconds >= 60)
            {
                minutes++;
                seconds -= 60;
            }
            lbtime.Text = minutes.ToString("00") + @":" + seconds.ToString("00");
            Refresh();
        }

        //Boton ¿Cómo jugar?.
        private void howToPlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
             var rule = new FrHowToPlay();
             rule.Show();
        }

        //Mostrar la solucion.
        private void viewSolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Pregunto si desea ver la solucion, si se la muestro y gana no sera valido.
            var sms = MessageBox.Show(@"Watching solution invalid the validity of the game. Do you want continue?", @"Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (sms != DialogResult.OK) return;
            valid = false; //el usuario ya miro la solucion.
            solution = new FrSolution(this);
            solution.Show();
        }

        //Boton Hint.
        private void bthint_Click(object sender, EventArgs e)
        {
                //Aumento el reloj si me pide pista 15s.
                seconds += 15;
                if (seconds >= 60)
                {
                    seconds -= 60;
                    minutes++;
                }
                var pista = game.Hint;
                if (pista == null) return; //Por si no hay pista.
                position[2] = pista.X;
                position[3] = pista.Y;
                hint = true;
                pbxLienzo.Refresh();
                hint = false;
                Thread.Sleep(400); //Demoro el refresh para que se pueda ver el hint.
                pbxLienzo.Refresh();
        }

        //Boton Help.
        private void aboToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Hitori v2.1 David Sean Meissimilly Frometa C-123.", @"Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
        #region Metodos internos.

        //Metodo para cambiar los colores.
        private void ChangeColor(int color)
        {
            if (clgColor.ShowDialog() == DialogResult.OK) colors[color] = clgColor.Color;
            Refresh(); //Refresco la aplicacion.
        }

        //Hago lo mismo que el constructor(reconstruyo el objeto ParteLogica).
        public void Restart(int newsize, int initial = 1, int final = 10, int holes = 5)
        {
            size = newsize;
            valid = true;
            game = new ParteLogica(newsize, initial, final, holes); //Inicalizo el juego.
            //Reinicio el reloj.
            reloj.Stop();
            minutes = seconds = 0;
            lbtime.Text = minutes.ToString("00") + @":" + seconds.ToString("00");
    }

        #endregion
    }
}

