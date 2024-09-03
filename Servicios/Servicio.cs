using AppGimnasio.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AppGimnasio.Servicios
{
    public class Servicio
    {

        private ContratoDao oBD;

        public Servicio()
        { 
            oBD = new ContratoDao();
        }

        public DataTable ConsultarTabla(string nombreTabla)
        {
            return oBD.ConsultarTabla(nombreTabla);
        }

        public bool GuardarCliente(Clientes oCliente)
        {
            string query = "INSERT INTO Clientes (dni, nombre, apellido, membresia, contacto, fechaInicio) VALUES (@dni,@nombre,@apellido,@membresia,@contacto,@fechaInicio)";
            List<Parametro> list = new List<Parametro>();
            list.Add(new Parametro("@dni", oCliente.Dni));
            list.Add(new Parametro("@nombre", oCliente.Nombres));
            list.Add(new Parametro("@apellido", oCliente.Apellido));
            list.Add(new Parametro("@membresia", oCliente.Membresia));
            list.Add(new Parametro("@contacto", oCliente.Contacto));
            list.Add(new Parametro("@fechaInicio", oCliente.FechaIncio));

            return oBD.ActualizarBD(query, list) == 1;



        }
    }
}
