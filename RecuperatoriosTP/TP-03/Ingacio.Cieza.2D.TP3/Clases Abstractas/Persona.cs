using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace EntidadesAbstractas
{
    public abstract class Persona
    {
        #region Enumerados

        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #endregion
        #region Atributos

        private string _apellido;
        private int _dni;
        private ENacionalidad _nacionalidad;
        private string _nombre;

        #endregion
        #region Propiedades

        /// <summary>
        /// propiedad del campo _apellido, que valida el apellido
        /// </summary>
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                this._apellido = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// propiedad del campo _nombre, que valida el nombre
        /// </summary>
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                this._nombre = this.ValidarNombreApellido(value);
            }
        }

        /// <summary>
        /// propiedad del campo _dni, que valida el dni.
        /// </summary>
        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni =this.ValidarDni(this._nacionalidad,value);
            }
        }
        /// <summary>
        /// propiedad del campo _nacionalidad
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
               return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }

        /// <summary>
        /// propiedad que transforma un string a int y lo valida
        /// </summary>
        public string StringToDni
        {
            set
            {
                this._dni=this.ValidarDni(this._nacionalidad,value);
            }
        }

        #endregion
        #region Constructores
        /// <summary>
        /// constructor por defecto
        /// </summary>
        public Persona() : this("", "", default(ENacionalidad))
        {
            this._dni = 0;
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre"> valor campo _nombre</param>
        /// <param name="apellido">valor campo _apellido </param>
        /// <param name="nacionalidad">valor campo _nacionalidad</param>
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this._nombre = nombre;
            this._apellido = apellido;
            this._nacionalidad = nacionalidad;
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre">valor campo _nombre</param>
        /// <param name="apellido">valor campo _apellido</param>
        /// <param name="dni">valor en INT campo _dni</param>
        /// <param name="nacionalidad">valor campo _nacionalidad</param>
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            :this(nombre,apellido,nacionalidad)
        {
            this.DNI=dni;
        }
        /// <summary>
        /// Constructor con parametros
        /// </summary>
        /// <param name="nombre">valor campo _nombre</param>
        /// <param name="apellido">valor campo _apellido</param>
        /// <param name="dni">valor en STRING campo _dni</param>
        /// <param name="nacionalidad">valor campo _nacionalidad</param>
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :this(nombre, apellido, nacionalidad)
        {
            this.StringToDni = dni;
        }

        #endregion
        #region Metodos
        /// <summary>
        /// SobreEscribe ToString(), mostrando los campos de la persona.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
           
            sb.AppendFormat("\nNombre: {0}\nApellido: {1}\nDNI: {2}\nNacionalidad: {3}", this._nombre, this._apellido, this._dni, this._nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// Validad el DNi, con dato tipo INT 
        /// </summary>
        /// <param name="nacionalidad"> valor campo _nacionalidad</param>
        /// <param name="dato">valor int para _dni</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad,int dato)
        {
            return this.ValidarDni(nacionalidad, dato.ToString());
        }

        /// <summary>
        /// Validad el DNi, con dato tipo STRING 
        /// </summary>
        /// <param name="nacionalidad"> valor campo _nacionalidad</param>
        /// <param name="dato">valor STRING para _dni</param>
        /// <returns></returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int retorno = -1;
            int dni;

            if (dato.Length <=8 && Int32.TryParse(dato, out dni))
            {
                dni = Int32.Parse(dato);

                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:
                        if (dni> 0 && dni <= 89999999)
                        {
                            retorno = dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("\nLa Nacionalidad y DNI, no coinciden.");
                        }
                        break;

                    case ENacionalidad.Extranjero:

                        if (dni >= 90000000 && dni<= 99999999)
                        {
                            retorno = dni;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("\nLa Nacionalidad y DNI, no coinciden.");
                        }

                        break;

                    default:
                        break;
                }
            }
            else
            {
                throw new DniInvalidoException("Dni formato incorrecto");
            }

            return retorno;            
        }

        /// <summary>
        /// Validad nombre y apellido
        /// </summary>
        /// <param name="dato"> dato string a validar </param>
        /// <returns>valor string</returns>
        private string ValidarNombreApellido(string dato)
        {
           foreach(char temporal in dato)
           {
                if (!(char.IsLetter(temporal)))
                {
                    return "No se pudo cargar.";
                }
           }

           return dato;
        }
        #endregion

    }
}
