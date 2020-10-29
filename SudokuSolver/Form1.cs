using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuSolver
{
    public partial class Form1 : Form
    {
        /*Atributos*/
        public List<PictureBox> listaImagenes = new List<PictureBox>();
        int numImag = 0;
        int selec = 0;
        int aux = 0;
        int[,] solucion = new int[9, 9];
        int[,] final = new int[9, 9];
        static int[,] mx = new int[9, 9];
        static string s;
        string cadena = "";

        /*Constructor*/
     public Form1()
    {
        crearCuadros();
        InitializeComponent();
        backgroundWorker1.WorkerReportsProgress = true;
        backgroundWorker1.WorkerSupportsCancellation = true;
    }

        /*Meotodos*/
                                     /*generacion del sudoku aleatorio*/
    static void inicio(ref int[,] mx)//Iniciar mx
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    mx[i, j] = (i * 3 + i / 3 + j) % 9 + 1;
                }
            }
        }
    static void muestraCons(ref int[,] mx, out string _s)//muestra matriz por consola
        {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    s += mx[x, y].ToString() + " ";
                }
                s += "\n";
            }
            // mostramos la matriz en consola....
            Console.WriteLine(s);
            _s = s;
            s = "";
        }
    static void genSoduku(ref int[,] mx, int valor1, int valor2)//Generador de tablero
     {
            int x1, y1, x2, y2;
            x1 = y1 = x2 = y2 = 0;
            for (int i = 0; i < 9; i += 3)
            {
                for (int k = 0; k < 9; k += 3)
                {
                    for (int j = 0; j < 3; j++)
                    {

                        for (int z = 0; z < 3; z++)
                        {
                            if (mx[i + j, k + z] == valor1)
                            {
                                x1 = i + j;
                                y1 = k + z;
                            }
                            if (mx[i + j, k + z] == valor2)
                            {
                                x2 = i + j;
                                y2 = k + z;
                            }
                        }
                    }
                    mx[x1, y1] = valor2;
                    mx[x2, y2] = valor1;
                }

            }

        }
    static void generarNumRand(ref int[,] mx)//genera numero random del 1 al 9
        {
            for (int repeat = 0; repeat < 10; repeat++)
            {
                Random rand1 = new Random(Guid.NewGuid().GetHashCode());
                Random rand2 = new Random(Guid.NewGuid().GetHashCode());
                genSoduku(ref mx, rand1.Next(1, 9), rand2.Next(1, 9));
            }
        }
        /*------------------------------------------------------------------------------*/
                                         /*generacion parte Grafica*/
    private void crearCuadros()//Creacion de cuadros en el tablero mediante ubicacion de pixeles
        {
            int x = 12, y = 12;
            for (int j = 0; j < 9; j++)
            {
                for (int i = 0; i < 9; i++)
                {
                    PictureBox img = new PictureBox();
                    img.Location = new System.Drawing.Point(x, y);
                    img.Size = new System.Drawing.Size(48, 48);
                    img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
                    img.BackColor = Color.White;
                    img.Tag = j * 10 + i;
                    img.TabStop = false;
                    if ((i < 3 || i > 5))
                    {
                        if (j < 3)
                        {
                            img.BackColor = Color.OrangeRed;
                        }
                    }
                    if ((i > 2) && (i < 6))
                    {
                        if ((j > 2) && (j < 6))
                        {
                            img.BackColor = Color.OrangeRed;
                        }
                    }
                    if ((i < 3 || i > 5))
                    {
                        if (j > 5)
                        {
                            img.BackColor = Color.OrangeRed;
                        }
                    }
                    this.Controls.Add(img);
                    listaImagenes.Add(img);
                    x += 54;
                }
                x = 12;
                y += 54;
            }
        }
    public void selecImagenes(PictureBox im, int num)//selecciona las imagenes segun el caso
        {
            try
            {
                switch (num)
                {
                    case 0:
                        im.Image = null;
                        break;
                    case 1:
                        im.Image = SudokuSolver.Properties.Resources._1;
                        break;
                    case 2:
                        im.Image = SudokuSolver.Properties.Resources._2;
                        break;
                    case 3:
                        im.Image = SudokuSolver.Properties.Resources._3;
                        break;
                    case 4:
                        im.Image = SudokuSolver.Properties.Resources._4;
                        break;
                    case 5:
                        im.Image = SudokuSolver.Properties.Resources._5;
                        break;
                    case 6:
                        im.Image = SudokuSolver.Properties.Resources._6;
                        break;
                    case 7:
                        im.Image = SudokuSolver.Properties.Resources._7;
                        break;
                    case 8:
                        im.Image = SudokuSolver.Properties.Resources._8;
                        break;
                    case 9:
                        im.Image = SudokuSolver.Properties.Resources._9;
                        break;
                }
            }
            catch (Exception e){}
        }
    private void selecImag_mouseClick(object sender, MouseEventArgs e) //seleccion de numero en espacio vacio y comprueba si corresponde o no
        {
            if (numImag > 9)
            {
                numImag = 0;
            }
            PictureBox r = (PictureBox)sender;
            selec = int.Parse(r.Tag.ToString());
            if (selec == aux)
            {
                numImag++;
            }
            else
            {
                numImag = 1;
            }
            selecImagenes(r, numImag);
            int x, y;

            x = (selec % 100) % 10;
            y = (selec % 100) / 10;
            if (chkMovimiento(x, y, numImag, solucion))
            {
                label1.Text = "Bueno";
            }
            else { label1.Text = "Malo"; }
            aux = selec;
        }
    private void iniciarMx(ref int[,] mx1) //inicia la matriz vacia 
        {
            int k = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    mx1[i, j] = 0;
                    final[i, j] = 0;
                    solucion[i, j] = 0;
                    listaImagenes[k].Image = null;
                    listaImagenes[k].BackColor = Color.WhiteSmoke;
                    k++;
                }

            }

        }
    public int dificultad()//selecciona dificultad del juego
        {
            int level=0;
            int indice = comDific.SelectedIndex;
            switch (indice)
            {
                case 0:
                    level = 15;
                    break;
                case 1:
                    level = 30;
                    break;
                case 2:
                    level = 40;
                    break;
                default:
                    break;
            }
            return level;
        }
    private void generarSudoku() //genera el sudoku con interfaz 
        {
            s = "";

            string ss;
            iniciarMx(ref mx);
            Actualizar(mx);
            inicio(ref mx);

            muestraCons(ref mx, out ss);
            generarNumRand(ref mx);
            muestraCons(ref mx, out ss);
            cadena = ss;
            solucion = mx;
            int r1, r2;
            for (int i = 0; i < dificultad(); i++)
            {
                do
                {
                    Random fil = new Random(Guid.NewGuid().GetHashCode());
                    Random col = new Random(Guid.NewGuid().GetHashCode());
                    r1 = (int)fil.Next(0, 9);
                    r2 = (int)col.Next(0, 9);
                } while (solucion[r1, r2] == 0);

                solucion[r1, r2] = 0;
            }
            int c = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    selecImagenes(listaImagenes[c], solucion[i, j]);
                    if (solucion[i, j] != 0)
                    {
                        listaImagenes[c].BackColor = Color.Thistle;
                        listaImagenes[c].MouseClick -= new System.Windows.Forms.MouseEventHandler(this.selecImag_mouseClick);
                    }
                    else
                    {
                        listaImagenes[c].MouseClick += new System.Windows.Forms.MouseEventHandler(this.selecImag_mouseClick);
                    }
                    c++;
                }
            }
        }
    private void Actualizar(int[,] m) //al generarlo se actualiza nuevamente los colores
        {
            int c = 0;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if ((j < 3 || j > 5))
                    {
                        if (i < 3)
                        {
                            listaImagenes[c].BackColor = Color.OrangeRed;
                        }
                    }
                    if ((j > 2) && (j < 6))
                    {
                        if ((i > 2) && (i < 6))
                        {
                            listaImagenes[c].BackColor = Color.OrangeRed;
                        }
                    }
                    if ((j < 3 || j > 5))
                    {
                        if (i > 5)
                        {
                            listaImagenes[c].BackColor = Color.OrangeRed;
                        }
                    }
                    selecImagenes(listaImagenes[c], m[i, j]);
                    c++;
                }
            }
        }
    private int[,] resolutSudoku(int valor, int px, int py, int[,] matriz)//resuelve el sudoku
        {
            int[,] matriz1 = new int[9, 9];
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    matriz1[j, i] = matriz[j, i];
                }
            }
            matriz1[px, py] = valor;
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    if (matriz1[x, y] == 0)
                    {
                        for (int val = 1; val <= 9; val++)
                        {
                            backgroundWorker1.ReportProgress(y);
                            if (chkMovimiento(y, x, val, matriz1)) //checkea que el num ingresado corresponda 
                            {
                                for (int z = 0; z < listaImagenes.Count; z++)
                                {
                                    if (int.Parse(listaImagenes[z].Tag.ToString()) == x * 10 + y) 
                                    {
                                        selecImagenes(listaImagenes[z], val);
                                    }
                                }
                                resolutSudoku(val, x, y, matriz1);
                            }
                        }
                        return null;
                    }

                }
            }
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    Console.Write(matriz1[i, j].ToString());
                }
                Console.WriteLine();
            }
            Console.WriteLine("----");
            final = matriz1;
            return matriz1;
        }
        /*---------------------------------------------------------------------------------------*/
                                    /*checkeo de ingresos*/
        private bool chkFila(int fila, int valor, int[,] arr)
        {
            for (int i = 0; i < 9; i++)
            {
                if (arr[i, fila] == valor) return false;
            }
            return true;
        }
    private bool chkColumna(int columna, int valor, int[,] arr)
        {
            for (int i = 0; i < 9; i++)
            {
                if (arr[columna, i] == valor) return false;
            }
            return true;
        }
    private bool chkBloques(int fila, int columna, int valor, int[,] arr)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[columna - (columna % 3) + i, fila - (fila % 3) + j] == valor) return false;
                }
            }
            return true;
        }
    private bool chkMovimiento(int fila, int columna, int valor, int[,] arr)
        {
            if (!chkFila(fila, valor, arr)) return false;
            if (!chkColumna(columna, valor, arr)) return false;
            if (!chkBloques(fila, columna, valor, arr)) return false;
            return true;
        }
        /*---------------------------------------------------------------------------------------*/
                                                /*Botones*/
    private void button1_Click(object sender, EventArgs e)//boton generar
        {
            btGenerar.Enabled = false;
            generarSudoku();
            btResolver.Enabled = true;
            btDetener.Enabled = false;
        }
    private void button2_Click(object sender, EventArgs e)//boton resolver
        {
            btDetener.Enabled = true;
            if (backgroundWorker1.IsBusy != true)
            {
                // Inicia la operacion asincrona para resolver
                backgroundWorker1.RunWorkerAsync();
            }
        }
    private void button3_Click(object sender, EventArgs e)//boton detener
        {
            if (backgroundWorker1.WorkerSupportsCancellation == true)
            {
                // cancelar la operacion asincrona
                backgroundWorker1.CancelAsync();
                MessageBox.Show("Cancelado");
            }
        }
    private void comDific_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        /*---------------------------------------------------------------------------------------*/
                                                  /*fondo*/
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)//muestra la matriz completa
        {
            Actualizar(final);
            btGenerar.Enabled = true;
            btResolver.Enabled = false;
            btDetener.Enabled = false;
        }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)//inicia todo en cero
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            resolutSudoku(0, 0, 0, solucion);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}