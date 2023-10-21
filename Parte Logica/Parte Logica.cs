using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Parte_Logica
{
    /// <summary>
    /// Representa todas las operaciones logicas del juego.
    /// </summary>
    [Serializable] //Para poder serializar la clase.
    public class ParteLogica
    {
        #region Constructores.

        //Constructores de la clase.
        public ParteLogica(int size, int initial = 1, int final = 13, int holes = 5)
        {
            //Inicializo los tableros y las variables.
            board = new int[size, size];
            marked = new bool[size, size];
            random = new Random();
            psolution = new List<Pair>();

            rellenar: Fill(initial, final, holes); //Mando a rellenar el tablero.
            if (Win) goto rellenar; //Para no mostrar un tablero resuelto.

            OptimizesSolution(); //Optimizo la solucion.
        }

        #endregion
        #region Variables utilizadas.

        private readonly Random random; //Ramdon para poder rellenar los tableros.

        private readonly int[,] direction = { { -1, 0 }, { 1, 0 }, { 0, 1 }, { 0, -1 } }; //Array de direcciones(up, down, right, left).

        private bool[,] marked; //Matriz para controlar las casillas que voy marcando.

        private readonly int[,] board; //Matriz que me representa el tablero.

        private readonly List<Pair> psolution; //Lista donde voy a almacenar una posible solucion del juego.

        private int minutes, seconds; //Para controlar el tiempo.

        #endregion
        #region Salvar y cargar en juego.

        //Metodo para salvar un juego.
        public void SaveGame(string name, int minutes, int seconds)
        {
            //Actualizo el tiempo.
            this.minutes = minutes;
            this.seconds = seconds;

            SaveScore(); //Guardo el score.

            //Serializo la clase.
            var formatter = new BinaryFormatter();
            var fs = new FileStream(name, FileMode.Create);
            formatter.Serialize(fs, this);
            fs.Close();
        }

        //Metodo para cargar un juego.
        public ParteLogica LoadGame(string name, out int minutes, out int seconds)
        {
            //Deserializo la clase.
            var formatter = new BinaryFormatter();
            var fs = new FileStream(name, FileMode.Open);
            if (fs == null) { throw new Exception("Invalid File."); }
            var coderead = (ParteLogica)formatter.Deserialize(fs);
            fs.Close();

            //Actualizo el tiempo.
            minutes = coderead.minutes;
            seconds = coderead.seconds;

            LoadScore(); //Leo el score.

            return coderead;
        }

        //Metodo para salvar los mejores scores.
        private void SaveScore()
        {
            var write = new StreamWriter("Scores.txt"); //Creo el archivo.
            using (write)
            {
                var score = new List<Tuple<double, string, int>>(BestRecords);
                write.WriteLine(score.Count); //escribo la cantidad.
                foreach (var t in score) write.WriteLine(t.Item1 + " " + t.Item2 + " " + t.Item3); //Escribo los scores.
            }
        }

        //Metodo para cargar los mejores scores.
        private static void LoadScore()
        {
            if (!File.Exists("Scores.txt")) return; //Por si el archivo no existe.

            var read = new StreamReader("Scores.txt");
            using (read)
            {
                var cont = Convert.ToInt32(read.ReadLine()); //leo la cantidad.
                while (cont-- > 0)
                {
                    var leido = read.ReadLine().Split();
                    HighScores.Add((Convert.ToDouble(leido[0])), leido[1], Convert.ToInt32(leido[2])); //Adiciono los scores.
                }
            }
        }

        #endregion
        #region Propiedades de la clase.

        //Indexer.
        public int this[int row, int column]
        {
            get { return board[row, column]; }
        }

        //Propiedad para saber si el usuario gano el juego.
        public bool Win
        {
            get
            {
                //Reviso si no existen numeros repetidos en la filas ni columnas.

                for (var i = 0; i < Size; i++)
                {
                    //Reinicio las colas.
                    var rows = new Queue<int>();
                    var columns = new Queue<int>();

                    for (var j = 0; j < Size; j++)
                    {
                        if (!marked[i, j] && rows.Contains(board[i, j])) return false;
                        if (!marked[i, j]) rows.Enqueue(board[i, j]);

                        if (!marked[j, i] && columns.Contains(board[j, i])) return false;
                        if (!marked[j, i]) columns.Enqueue(board[j, i]);
                    }
                }

                return true;
            }
        }

        //Propiedad para saber el tamaño del tablero.
        public int Size
        {
            get { return board.GetLength(0); }
        }

        //Propiedad para saber la solucion del tablero.
        public IEnumerable<Pair> Solution
        {
            get { return psolution; }
        }

        //Propiedad para dar una pista sobre la solucion del tablero.
        public Pair Hint
        {
            get
            {
                var temp = new List<Pair>(); //Lista para almacenar todas las casillas repetidas.

                for (var i = 0; i < Size; i++)
                    for (var j = 0; j < Size; j++)
                    {
                        var broke = false; //Para romper el ciclo de las dirreciones.
                        if (marked[i, j]) continue; //Por si esta marcada.

                        for (var k = 0; k < 4; k++)
                        {
                            var x = i + direction[k, 0];
                            var y = j + direction[k, 1];
                            while (InRange(x, y, board))
                            {
                                if (!marked[x, y] && board[i, j] == board[x, y])
                                {
                                    temp.Add(new Pair(i, j)); //Adiciono el par<i,j>.
                                    broke = true;
                                    break;
                                }
                                x += direction[k, 0];
                                y += direction[k, 1];
                            }
                            if (broke) break;
                        }
                    }

                return temp[random.Next(0, temp.Count)]; //Uso ramdom para dar pistas diferentes.
            }
        }

        //Propiedad para devolver los mayores scores.
        public IEnumerable<Tuple<double, string, int>> BestRecords
        {
            get { return HighScores.BestRecords(); }
        }

        #endregion
        #region Metodos visibles para el usuario.

        /*Metodo para borrar una casilla, si la casilla que se quiere borrar se encuentra en una posicion
       que no cumple con las reglas del juego doy una exepcion.*/
        public void Darken(int row, int column)
        {
            if (!IsValid(marked, row, column)) throw new InvalidOperationException("Position invalidates.");
        }

        //Metodo para aclarar una casilla.
        public void Clarify(int row, int column)
        {
            marked[row, column] = false;
        }

        //Metodo para reiniciar un tablero.
        public void Restart()
        {
            marked = new bool[Size, Size]; //Reinicio la matriz de bool.
        }

        //Metodo para saber si una casilla esta oscurecida.
        public bool ThisDarkened(int row, int column)
        {
            return marked[row, column];
        }

        //Metodo para adicionar un nuevo record.
        public void AddNewScore(double time, string name, int size)
        {
            HighScores.Add(time, name, size);
        }

        #endregion
        #region Metodos internos de la clase.

        /*Metodo para saber si estoy en una posicion valida.
        (lo hice generico para que sirva con cualquier matriz)*/
        private static bool InRange<T>(int i, int j, T[,] array)
        {
            return i >= 0 && i < array.GetLength(0) && j >= 0 && j < array.GetLength(1);
        }

        //Metodo para rellenar el tablero.
        private void Fill(int initial, int final, int holes)
        {
            var posbboard = new bool[Size, Size]; //Posible configuracion del tablero.

            #region Pongo las casillas marcadas.

            //Relleno un posible tablero con las casillas tachadas colocadas correctamnete.

            var posvalid = new List<int>(); //Lista para ir llevando las posiciones que quedan vacias en la fila.

            for (var i = 0; i < Size; i++)
            {
                var cantholes = random.Next(1, holes + 1);  //Cantidad de huecos que voy a poner por fila.
                var cont = 0;
                posvalid.Clear();
                for (var j = 0; j < Size; j++) posvalid.Add(j); //Lleno la lista con todas las posiciones.

                while (cont < cantholes && posvalid.Count > 0)
                {
                    var j = random.Next(0, posvalid.Count); //elijo una casilla.

                    if (IsValid(posbboard, i, posvalid[j])) //Reviso si la posicion es valida.
                    {
                        posbboard[i, posvalid[j]] = true; //Marco la casilla.
                        psolution.Add(new Pair(i, posvalid[j]));//Copio la casilla a lista de la solucion.
                        posvalid.RemoveAt(j); //quito la posicion porque ya la puse.
                        cont++;
                    }
                    else posvalid.RemoveAt(j);  //quito la posicion porque no la pude poner.
                }
            }

            #endregion
            #region Pongo los numeros.

            //Relleno el tablero con los numeros.

            posvalid.Clear();
            for (var j = initial; j <= final; j++) posvalid.Add(j); //Lleno las lista con todos los valores posibles.

            var almacen = new Queue<int>(); //Relleno la cola con los numeros puestos de forma aleatoriamente.
            while (posvalid.Count > 0)
            {
                var valor = random.Next(posvalid.Count);
                almacen.Enqueue(posvalid[valor]);
                posvalid.RemoveAt(valor);
            }

            for (var i = 0; i < Size; i++)
            {
                var numbers = new Queue<int>(almacen); //Lleno la cola con los numeros.

                for (var j = 0; j < Size; j++)
                {
                    //Reviso si la casilla esta tachada.
                    if (posbboard[i, j]) board[i, j] = random.Next(initial, final + 1); //Pongo cualquier valor(dentro del rango)
                    else
                    {
                        //Voy a copiar la columna donde estoy parado desde la posicion i, j hasta arriba.
                        var repetidos = new Queue<int>();
                        var x = i - 1;
                        while (InRange(x--, j, posbboard)) if (!posbboard[x + 1, j]) repetidos.Enqueue(board[x + 1, j]);

                        //Reviso si no he puesto ya ese numero en la columna.
                        if (!repetidos.Contains(numbers.Peek())) board[i, j] = numbers.Dequeue(); //pongo el numero.
                        else  //Intento con otro numero en la proxima iteracion.
                        {
                            numbers.Enqueue(numbers.Dequeue());
                            j--;
                        }

                    }
                }
            }

            #endregion
        }

        //Metodo para saber si es valida una casilla marcada en una posicion del tablero.
        private bool IsValid(bool[,] posboard, int row, int column)
        {
            //Reviso si alguna de las casillas adyacentes ya esta marcada.
            for (var l = 0; l < 4; l++)
            {
                int x = row + direction[l, 0], y = column + direction[l, 1];
                if (InRange(x, y, posboard) && posboard[x, y]) return false;
            }

            //Reviso si no se pierde la conectividad entre las casillas no marcadas.
            posboard[row, column] = true; //Tacho la casilla, si esta mal la desmarco despues.
            if (!LoseConnection(posboard)) return true;
            return posboard[row, column] = false;
        }

        //Metodo para saber si pierdo conectividad entre las casillas no marcadas.
        private bool LoseConnection(bool[,] shadows)
        {
            var road = LeeAlgorithm(shadows); //Genero la matriz de los posibles caminos desde una casilla no marcada.

            //Reviso si me encuentro una casilla que no esta marcada a la que no pude llegar.
            for (var i = 0; i < Size; i++)
                for (var j = 0; j < Size; j++) if (road[i, j] == 0 && !shadows[i, j]) return true; //Perdi conectividad.

            return false; //No se pierde conectividad.
        }

        //Metodo para moverme por las casillas marcadas del tablero(Algoritmo de Lee).
        private int[,] LeeAlgorithm(bool[,] shadows)
        {
            var road = new int[Size, Size]; //Matriz para representar el camino.
            var points = new Queue<Pair>(); //para saber cuando termine.

            //Empiezo en una posicion no marcada(las dos no pueden estar marcadas a la vez).
            var p = !shadows[0, 0] ? new Pair(0, 0) : new Pair(0, 1);

            road[p.X, p.Y] += 1;
            points.Enqueue(p);

            while (points.Count > 0) //Condicion de parada.
            {
                var pair = points.Peek();
                points.Dequeue();
                for (var i = 0; i < 4; i++) //Me muevo por las diagonales.
                {
                    int x = pair.X + direction[i, 0], y = pair.Y + direction[i, 1];

                    //Reviso si las casillas vecinas no estan ya escritas y estan tachadas.
                    if (!InRange(x, y, road) || road[x, y] != 0 || shadows[x, y]) continue;
                    road[x, y] = road[pair.X, pair.Y] + 1;
                    points.Enqueue(new Pair(x, y));
                }
            }
            return road;
        }

        /*Metodo para optimizar la solucion.
        Reviso si borrando menos casillas que las que ya tengo el tablero continua teniendo solucion.*/
        private void OptimizesSolution()
        {
            var temp = new List<Pair>(); //Lista temporal.
            foreach (var t in psolution)
            {
                var broke = false;
                for (var i = 0; i < 4; i++)
                {
                    var x = t.X + direction[i, 0];
                    var y = t.Y + direction[i, 1];
                    while (InRange(x, y, board))
                    {
                        if (board[t.X, t.Y] == board[x, y])
                        {
                            temp.Add(t);
                            broke = true;
                            break;
                        }
                        x += direction[i, 0];
                        y += direction[i, 1];
                    }

                    if (broke) break;
                }
            }

            psolution.Clear(); //Vacio la lista.
            psolution.AddRange(temp); //Adiciono solo los pares minimos para que el juego tenga una solucion.
        }

        #endregion
    }

    /// <summary>
    ///Representa un par ordenado (x,y).
    /// </summary>
    [Serializable]
    public class Pair
    {
        public Pair(int x, int y)
        {
            X = x;
            Y = y;
        }
        public int X { get; }
        public int Y { get; }
    }

    /// <summary>
    ///Representa los mayores scores.
    /// </summary>
    internal static class HighScores
    {
        private static readonly List<Score> Bestrecords;

        //Constructor.
        static HighScores()
        {
            Bestrecords = new List<Score>();
        }

        //Metodo donde adiciono un nuevo record(si es mejor que uno ya existente).
        public static void Add(double time, string name, int size)
        {
            if (Bestrecords.Count < 10) Bestrecords.Add(new Score(time, name, size));
            else if (Bestrecords[9].Time > time) Bestrecords[9] = new Score(time, name, size);
            else return;
            Sort(); //Ordeno los records por el tiempo.
        }

        //Metodo para ordenar los scores(Ordenamiento por Seleccion n^2).
        private static void Sort()
        {
            for (var i = 0; i < Bestrecords.Count - 1; i++)
            {
                var pos = i;
                for (var j = i + 1; j < Bestrecords.Count; j++)
                    if (Bestrecords[pos].Time > Bestrecords[j].Time) pos = j; //Busco el menor.

                //Hago swap.
                var temp = new Score(Bestrecords[i].Time, Bestrecords[i].Name, Bestrecords[i].Size);
                Bestrecords[i] = new Score(Bestrecords[pos].Time, Bestrecords[pos].Name, Bestrecords[pos].Size);
                Bestrecords[pos] = new Score(temp.Time, temp.Name, temp.Size);
            }
        }

        //Metodo para devolver los mayores scores.
        public static IEnumerable<Tuple<double, string, int>> BestRecords()
        {
            return Bestrecords.Select(t => new Tuple<double, string, int>(t.Time, t.Name, t.Size));
        }
    }

    /// <summary>
    ///Representa un record.
    /// </summary>
    [Serializable]
    internal class Score
    {
        public Score(double time, string name, int size)
        {
            Time = time;
            Name = name;
            Size = size;
        }
        public double Time { get; }
        public string Name { get; }
        public int Size { get; }
    }
}


