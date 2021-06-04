namespace Proyecto_Practica_Gitub_T5
{
    using System;
    using System.Collections;
    using System.Windows.Forms;

    /// <summary>
    /// Defines the <see cref="Form1" />.
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// Defines the misAlumnos.
        /// </summary>
        internal readonly Alumnos misAlumnos = new Alumnos();

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
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
    /// Defines the <see cref="Alumno" />.
    /// </summary>
    internal class Alumno
    {
        /// <summary>
        /// Defines the nombre.
        /// </summary>
        private string nombre;

        /// <summary>
        /// Defines the nota.
        /// </summary>
        private int nota;

        /// <summary>
        /// Gets or sets the Nombre.
        /// </summary>
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        /// <summary>
        /// Gets or sets the Nota.
        /// </summary>
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
        /// Gets the Aprobado.
        /// </summary>
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
    /// Defines the <see cref="Alumnos" />.
    /// </summary>
    internal class Alumnos
    {
        /// <summary>
        /// Defines the listaAlumnos.
        /// </summary>
        private readonly ArrayList listaAlumnos = new ArrayList();

        // Agrega un nuevo alumno a la lista
        //
        /// <summary>
        /// The Agregar.
        /// </summary>
        /// <param name="alu">The alu<see cref="Alumno"/>.</param>
        public void Agregar(Alumno alu)
        {
            listaAlumnos.Add(alu);
        }

        // Devuelve el alumno que está en la posición num
        //
        /// <summary>
        /// The Obtener.
        /// </summary>
        /// <param name="num">The num<see cref="int"/>.</param>
        /// <returns>The <see cref="Alumno"/>.</returns>
        public Alumno Obtener(int num)
        {
            if (num >= 0 && num <= listaAlumnos.Count)
            {
                return ((Alumno)listaAlumnos[num]);
            }
            return null;
        }

        // Devuelve la nota media de los alumnos
        //
        /// <summary>
        /// Gets the Media.
        /// </summary>
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
