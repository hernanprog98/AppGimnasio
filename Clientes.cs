using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGimnasio
{
     public class Clientes
    {
        private int dni;
        private string nombres, apellido;
        private int membresia,contacto;
        private DateTime fechaIncio;

        //propiedades
        public  int Dni{ get { return dni; } set { dni = value; } }

        public string Nombres {  get { return nombres; } set {  nombres = value; } }

        public string Apellido { get {  return apellido; } set {  apellido = value; } }

        public int Membresia { get {  return membresia; } set {  membresia = value; } }

        public int Contacto { get {  return contacto; } set {  contacto = value; } }

        public DateTime FechaIncio { get {  return fechaIncio; } set {  fechaIncio = value; } }


        //Constructor sin parametros
        public Clientes()
        {
            this.dni = 0;
            this.nombres= string.Empty;
            this.apellido= string.Empty;
            this.membresia = 0;
            this.contacto = 0;
            this.fechaIncio = DateTime.Today;
        }

        //Constructor con parametros
        public Clientes(int dni, string nombres, string apellido, int membresia, int contacto, DateTime fechaInicio)
        {
            this.dni = dni;
            this.nombres = nombres;
            this.apellido = apellido;
            this.membresia= membresia;
            this.contacto= contacto;
            this.fechaIncio= fechaInicio;
            
        }

        public override string ToString()
        {
            return dni + " - " + nombres + "," + apellido;
        }



    }
}
