using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;


namespace ClasesInstanciables
{
    public class Jornada
    {
        #region Atributos

        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        #endregion
        #region Propiedades

        /// <summary>
        /// propiedad del campo _alumnos
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this._alumnos;
            }
            set
            {
                this._alumnos = value;
            }
        }

        /// <summary>
        /// propiedad del campo _clase
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this._clase;
            }

            set
            {
                this._clase = value;
            }
        }

        /// <summary>
        /// Propiedad del campo _instructor
        /// </summary>
        public Profesor Instructor
        {
            get
            {
               return this._instructor;
            }

            set
            {
                this._instructor = value;
            }
        }

        #endregion
        #region Constructores

        /// <summary>
        /// constructor por defecto de instancia que inicializa List<Alumno>
        /// </summary>
        private Jornada()
        {
            this._alumnos = new List<Alumno>();
        }

        /// <summary>
        /// Cosntructor con parametros
        /// </summary>
        /// <param name="clase"> valor para campo _clase </param>
        /// <param name="instructor">valor para campo _instructor</param>
        public Jornada(Universidad.EClases clase,Profesor instructor)
            :this()
        {
            this._clase = clase;
            this._instructor = instructor;
        }

        #endregion
        #region Metodos

        /// <summary>
        /// Metodo Jornada para guardar usando Proyecto Archivos
        /// </summary>
        /// <param name="jornada">valor a guardar</param>
        /// <returns>bool</returns>
        public static bool Guardar(Jornada jornada)
        {
            Texto t = new Texto();
            
            return t.Guardar("Jornada.txt", jornada.ToString());
        }

        /// <summary>
        /// Metodo de Jornada para leer usando Proyecto Archivos
        /// </summary>
        /// <returns>string del dato leido</returns>
        public static string Leer()
        {
            string retorno="";
            Texto t = new Texto();

            t.Leer("Jornada.txt", out retorno);

            return retorno;
        }

        #endregion
        #region SobreCargas

        /// <summary>
        /// Metodo que determina la igualdad de sus paramentros
        /// </summary>
        /// <param name="j">Valor Jornada</param>
        /// <param name="a">Valor Alumno</param>
        /// <returns></returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool retorno = false;

            foreach (Alumno temporal in j._alumnos)
            {
                if (temporal == a)
                {
                    retorno = true;
                    break;
                }
            }

            return retorno;            
        }

        /// <summary>
        /// Metodo que determina la desigualdad de sus paramentros
        /// </summary>
        /// <param name="j">Valor Jornada</param>
        /// <param name="a">Valor Alumno</param>
        /// <returns></returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        /// <summary>
        /// Metodo para agregar alumno a la lista de alumno de jornada, corroborando que no se encuentre
        /// </summary>
        /// <param name="j">Valor a validar</param>
        /// <param name="a">valor a validad</param>
        /// <returns>valor Jornada, con la lista de alumnos</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {           
            if (j != a)
            {
                j._alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException();
            }

            return j;
        }

        /// <summary>
        /// Metodo que muetra los datos de la jornada, sobreescribiendo el metodo ToString().
        /// </summary>
        /// <returns>string con los datos</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendFormat("\nClase: {0},\nInstructor: {1}", this._clase.ToString(), this._instructor.ToString());
            sb.AppendLine("Alumnos:");
            foreach (Alumno item in this._alumnos)
            {
                sb.AppendLine(item.ToString());
            }

            return sb.ToString();
        }
        #endregion
    }
}
