namespace Proyecto_Practica_Gitub_T5
{
    using System;
    using System.Collections;
    using System.Windows.Forms;

    
    public partial class Form1 : Form
    {
        
        internal readonly Alumnos misAlumnos = new Alumnos();

        
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The button1_Click.
        /// </summary>
        /// <param name="sender">The sender<see cref="object"/>.</param>
        /// <param name="e">The e<see cref="EventArgs"/>.</param>
        private void button1_Click(object sender, EventArgs e)
        {
            Alumno miAlumno = new Alumno();
            String miAlumnoStr, miAlumnoNotaTexto;

            miAlumno.Nombre = aluNombre.Text;
            miAlumno.Nota = Convert.ToInt32(aluNota.Text);

            if (miAlumno.Nota < 5)
            {
                miAlumnoNotaTexto = "Suspenso";
            }
            else if (miAlumno.Nota < 7)
            {
                miAlumnoNotaTexto = "Aprobado";
            }
            else if (miAlumno.Nota < 9)
            {
                miAlumnoNotaTexto = "Notable";
            }
            else
                miAlumnoNotaTexto = "Sobresaliente";
            miAlumnoStr = aluNombre.Text + " " + aluNota.Text + " " + miAlumnoNotaTexto + "\n";
            listaAlumnos.AppendText(miAlumnoStr);
            misAlumnos.Agregar(miAlumno);
        }
    }

    /// <summary>
    /// Inicializa la instacia de la clase Alumno
    /// </summary>
    internal class Alumno
    {
        /// <summary>
        /// Define el nombre.
        /// </summary>
        private string nombre;

        /// <summary>
        /// Define la nota.
        /// </summary>
        private int nota;

        /// <summary>
        /// Establece y obtiene un valor de tipo string(nombre)
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

       /// <summary>
       /// Obtiene la nota del alumno
       /// </summary>
       /// <value>Especifica la nota del alumno</value>
        public int Nota
        {
            get { return nota; }
            set
            {
                if (value >= 0 && value <= 10)
                    nota = value;
            }
        }

        /// <summary>
        /// Obtiene el resultado 
        /// </summary>
        /// <returns>Devuelve un valor booleano del aprobado de un alumno</returns>
        public Boolean Aprobado
        {
            get
            {
                if (nota >= 5)
                    return true;
                else
                    return false;
            }
        }
    }

    /// <summary>
    /// Inicializa una nueva instancia de la clase Alumnos
    /// </summary>
    internal class Alumnos
    {
        /// <summary>
        /// Define la lista de Alumnos.
        /// </summary>
        private readonly ArrayList listaAlumnos = new ArrayList();

        
        
        /// <summary>
        /// Método que agraga  un nuevo alumno a la lista
        /// </summary>
        /// <param name="alu">Variable que se añade a la lista<see cref="Alumno"/>.</param>
        public void Agregar(Alumno alu)
        {
            listaAlumnos.Add(alu);
        }


        //
        /// <summary>
        ///Prporciona el método necesario para agregar alumnos a una lista.
        /// </summary>
        /// <param name="num">Variable de tipo int que devuelve una determinada posición</param>
        /// <returns> Devuelve el alumno que está en la posición num.</returns>
        public Alumno Obtener(int num)
        {
            if (num >= 0 && num <= listaAlumnos.Count)
            {
                return ((Alumno)listaAlumnos[num]);
            }
            return null;
        }

        // 
        //
        /// <summary>
        /// Proporciona la propiedad y el método necesario para obtener la nota media.
        /// </summary>
        /// <returns>Devuelve la nota media de los alumnos.</returns>
        public float Media
        {
            get
            {
                if (listaAlumnos.Count == 0)
                    return 0;
                else
                {
                    float media = 0;
                    for (int i = 0; i < listaAlumnos.Count; i++)
                    {
                        media += ((Alumno)listaAlumnos[i]).Nota;
                    }
                    return (media / listaAlumnos.Count);
                }
            }
        }
    }
}
