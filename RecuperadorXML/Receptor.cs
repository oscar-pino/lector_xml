using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecuperadorXML
{
    class Receptor
    {        
        private String servicio;
        private String telefono;
        private int valor;
        private int montoTotal;
        private String nombre;
        private String rut;
        private String direccion;
        private String comuna;
        private String ciudad;
        private String email;
        private String archivo;

        public Receptor() { }

        public Receptor(String archivo, String rut, String nombre, String direccion, String comuna, String ciudad, int montoTotal, String email) {

            this.archivo = archivo;
            this.rut = rut;
            this.nombre = nombre;
            this.direccion = direccion;
            this.comuna = comuna;
            this.ciudad = ciudad;
            this.email = email;
            this.montoTotal = montoTotal;
        }

        public Receptor(String archivo, String rut, String nombre, String direccion, String comuna, String ciudad, int montoTotal, String email, String telefono)
        {

            this.archivo = archivo;
            this.rut = rut;
            this.nombre = nombre;
            this.direccion = direccion;
            this.comuna = comuna;
            this.ciudad = ciudad;
            this.montoTotal = montoTotal;
            this.email = email;
            this.telefono = telefono;
        }

        public Receptor(String archivo, String rut, String nombre, String direccion, String comuna, String ciudad, int montoTotal, String email, String telefono, int valor, String servicio)
        {

            this.archivo = archivo;
            this.rut = rut;
            this.nombre = nombre;
            this.direccion = direccion;
            this.comuna = comuna;
            this.ciudad = ciudad;
            this.montoTotal = montoTotal;
            this.email = email;
            this.telefono = telefono;
            this.valor = valor;
            this.servicio = servicio;
        }

        public int Valor { get {return valor;} set { if (value >= 5000) valor = value; } }
        public int MontoTotal { get {return montoTotal;} set {if (value >= 5000) montoTotal = value; } }
        public String Servicio { get {return servicio;} set { if (value.Trim() != String.Empty || value.Trim() != null) servicio = value; } }
        public String Telefono { get {return telefono;} set{if (value.Trim() != String.Empty || value.Trim() != null) telefono = value;} }
        public String Nombre { get {return nombre;} set{if (value.Trim() != String.Empty || value.Trim() != null) nombre = value;} }
        public String Rut { get {return rut;} set { if (value.Trim() != String.Empty || value.Trim() != null) rut = value; } }
        public String Direccion { get {return direccion;} set { if (value.Trim() != String.Empty || value.Trim() != null) direccion = value; } }
        public String Comuna { get {return comuna;} set { if (value.Trim() != String.Empty || value.Trim() != null) comuna = value; } }
        public String Ciudad { get {return ciudad;} set { if (value.Trim() != String.Empty || value.Trim() != null) ciudad = value; } }
        public String Email { get { return email; } set { if (value.Trim() != String.Empty || value.Trim() != null) email = value; } }
        public String Archivo { get { return archivo; } set { if (value.Trim() != String.Empty || value.Trim() != null) archivo = value; } }
              

        public override String ToString()
        {
            return String.Format("Rut: {0}\nValor: {1}\nMonto Total: {2}\nTelefono: {3}\nServicio: {4}\nNombre: {5}\nDireccion: {6}\nComuna: {7}\nCiudad: {8}\nEmail: {9}\nArchivo: {10}", this.rut, this.valor, this.montoTotal, this.telefono, this.servicio, this.nombre, this.direccion, this.comuna, this.ciudad,this.email, this.archivo);
        }
    }
}
