using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Xml;
using Microsoft.Office.Interop.Excel;
using objExcel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Media;
using System.Collections;

namespace RecuperadorXML{
    
    public partial class formulario : Form
    {
        double ancho;
        double alto;
        String origen;
        String destino;
        int contadorGeneral;
        int contadorXml;
        FolderBrowserDialog fbd;
        const String TIPO = "xml";
        List<String> nombreArchivos;
        SortedList<string, Receptor> registros;
        List<String> telefonos;
        List<int> montos;
        int intentos;
        SoundPlayer sonido;
        DateTime fechaExpiracion;
        
        public formulario()
        {
            InitializeComponent();            
                        
            nombreArchivos = new List<String>();
            registros = new SortedList<string, Receptor>();
            telefonos = new List<String>();
            montos = new List<int>();
            this.ttmensaje.SetToolTip(this.btnOrigen, "SELECCIONE CARPETA QUE CONTIENE ARCHIVOS XML");
            this.ttmensaje.SetToolTip(this.btnDestino, "SELECCIONE ORIGEN DE DESTINO PARA GUARDAR ARCHIVO EXCEL");
            this.ttmensaje.SetToolTip(this.btnExportar, "GENERA UN ARCHIVO EXCEL");

            ancho = (double)Screen.PrimaryScreen.Bounds.Width / 2.76;
            alto = (double)Screen.PrimaryScreen.Bounds.Height / 2.3;
            origen = String.Empty;
            destino = String.Empty;
            fbd = new FolderBrowserDialog();
            this.Size = new System.Drawing.Size((int)ancho, (int)alto);
            intentos = 0;

            System.Drawing.Icon ic = new System.Drawing.Icon(System.Windows.Forms.Application.StartupPath + @"\Iconos\icono.ico");
            this.Icon = ic;

            fechaExpiracion = new DateTime(2022, 1, 17, 0, 51, 0).AddDays(10);
        }

        private void btnOrigen_Click(object sender, EventArgs e)
        {            
                versionExpirada();            

            if (intentos < 2)
            { 
                activarBoton("origen");

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    lblV1.Text = String.Empty;
                    lblV2.Text = String.Empty;
                    origen = fbd.SelectedPath;
                    destino = fbd.SelectedPath;
                    tbxOrigen.Text = origen;
                    tbxDestino.Text = origen;
                    contadorGeneral = 0;
                    contadorXml = 0;
                    registros.Clear();
                    lbxPrueba.Items.Clear();

                    cargaArchivos(origen);

                    if (destino.ToLower().Trim() != String.Empty)
                        btnExportar.Enabled = true;
                    else
                        btnExportar.Enabled = false;

                    intentos++;
                }                
            }
            else {
                    MessageBox.Show("ESTA ES UNA VERSION DE PRUEBA, SOLAMENTE SE PERMITEN 2 INTENTOS", "ACCESO DENEGADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    formulario.ActiveForm.Close();                
            }
        
        }

        private void btnDestino_Click(object sender, EventArgs e)
        {            
                versionExpirada();
            
                activarBoton("destino");
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                destino = String.Empty;

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    destino = fbd.SelectedPath;
                    tbxDestino.Text = destino;
                }           
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {            
                versionExpirada();
                       
                DateTime inicio = DateTime.Now;
                TimeSpan? transcurrido = null;
                DateTime? fin = null;

                activarBoton("exportar");
                btnExportar.Enabled = false;

                generarExcel();

                String rutaArchivo = destino + "\\backup.xlsx";

                if (File.Exists(rutaArchivo))
                {
                    transcurrido = DateTime.Now - inicio;
                    fin = DateTime.Now;
                    agregarSonido(true);
                    MessageBox.Show("SU ARCHIVO HA SIDO CREADO SATISFACTORIAMENTE\n\ninicio: " + inicio.ToString() + "\ntermino: " + fin + "\ntiempo transcurrido: " + transcurrido.Value.Hours + ":" + transcurrido.Value.Minutes + ":" + transcurrido.Value.Seconds + ":" + transcurrido.Value.Milliseconds, "FELICITACIONES", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!lblV2.Text.Equals("0"))
                {
                    agregarSonido(false);
                    MessageBox.Show("EL O LOS ARCHIVOS XML NO CUMPLEM CON EL FORMATO SOLICITADO", "FORMATO INCORRECTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                registros.Clear();
                btnExportar.Enabled = true;        
        }

        private String getRutaXML(String archivo)
        {
            String ruta = null;

            if (archivo.Trim() != String.Empty & archivo.Trim() != null)
            {
                if (nombreArchivos.Count > 0)
                {
                    ruta = origen + "\\" + archivo;
                }
            }
            else
            {
                agregarSonido(false);
                ruta = "NO SE HA ENCONTRADO UNA RUTA PARA EL ARCHIVO!";
            }

            return ruta;
        }

        private void cargaArchivos(String origen)
        {
            String actual = String.Empty;

            if (origen.ToLower().Trim() != String.Empty)
            {
                btnDestino.Enabled = true;
                lbxPrueba.Items.Clear();
                lblV1.Text = String.Empty;
                lblV2.Text = String.Empty;
                DirectoryInfo di = new DirectoryInfo(@origen);
                contadorXml = 0;
                contadorGeneral = 0;
                nombreArchivos.Clear();

                if (di.GetFiles().Length > 0)
                {
                    String extension = String.Empty;

                    foreach (var item in di.GetFiles())
                    {
                        actual = item.ToString().ToLower().Trim();
                        extension = actual.Substring(actual.Length - 3);

                        if (extension.ToString().Trim().Equals(TIPO))
                        {
                            contadorXml++;
                            nombreArchivos.Add(item.ToString());
                        }

                        lbxPrueba.Items.Add(actual);

                        contadorGeneral++;
                    }
                }

                if (lblV1.Text == String.Empty)
                    lblV1.Text = contadorGeneral.ToString();

                if (lblV2.Text == String.Empty)
                    lblV2.Text = contadorXml.ToString();
            }
            else
                btnDestino.Enabled = false;
        }

        private void cargarRegistrosPorArchivos(String archivoXML)
        {
            XmlReader xmlReader = null;
            List<Receptor> registrosInternos = new List<Receptor>();
            List<String> planes = new List<String>();
            
            Receptor receptor = new Receptor();
            int contadorTelefonos;
            int contadorPlanes;
            int mntotal;
            String ejemplo = String.Empty;

            try
            {
                if (archivoXML.ToLower().Trim() != null && archivoXML.ToLower().Trim() != String.Empty && !archivoXML.Equals("backup.xml"))
                {
                    xmlReader = XmlReader.Create(getRutaXML(archivoXML));

                    if (xmlReader == null)
                    {
                        agregarSonido(false);
                        MessageBox.Show(archivoXML.ToUpper() + ", NO ES UN ARCHIVO XML VALIDO", "ERROR DE LECTURA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        receptor.Archivo = archivoXML;
                        contadorTelefonos = 0;
                        contadorPlanes = 0;
                        mntotal = 0;
                        telefonos.Clear();
                        montos.Clear();	 
	
                        while (xmlReader.Read())
                        {
                            if (xmlReader.IsStartElement())
                            {
                                    switch (xmlReader.Name.ToString())
                                    {
                                        case "RUTRecep":
                                            receptor.Rut = xmlReader.ReadString();
                                            break;
                                        case "RznSocRecep":
                                            receptor.Nombre = xmlReader.ReadString();
                                            break;
                                        case "MntTotal":

                                            if (Int32.TryParse(xmlReader.ReadString(), out mntotal))
                                            {
                                                receptor.MontoTotal = mntotal;
                                            }
                                            break;
                                        case "DirRecep":
                                            receptor.Direccion = xmlReader.ReadString();
                                            break;
                                        case "CmnaRecep":
                                            receptor.Comuna = xmlReader.ReadString();
                                            break;
                                        case "CiudadRecep":
                                            receptor.Ciudad = xmlReader.ReadString();
                                            break;
                                        case "DetPersonAFN_03": // telefonos

                                            String temporal = xmlReader.ReadString();

                                            String patron = @"(569)\d{8}";                                            

                                            if (new Regex(patron).IsMatch(temporal))
                                            {
                                                if (!telefonos.Contains(temporal))
                                                {
                                                    telefonos.Add(temporal);
                                                    contadorTelefonos++;
                                                }
                                            }

                                            break;

                                        case "DetPersonAFN_04": // planes                                            

                                            String temporal2 = xmlReader.ReadString();

                                            contadorPlanes++;
                                            
                                            if (contadorPlanes >= 18 && isPlanValido(temporal2))
                                            {                                                
                                                planes.Add(temporal2);
                                            }

                                            break;
                                        case "DetPersonAFN_05": // valores

                                            string temporal3 = xmlReader.ReadString();

                                            int valoresTemporales = 0;

                                            if (Int32.TryParse(temporal3, out valoresTemporales))
                                            {
                                                if (valoresTemporales >= 9990 && receptor.MontoTotal != 0 && valoresTemporales < receptor.MontoTotal)
                                                {
                                                    montos.Add(valoresTemporales);   
                                                }
                                            }

                                            break;

                                        case "campoString":
                                            if (xmlReader.HasAttributes && xmlReader.GetAttribute("name").Equals("EmailRecep"))
                                                receptor.Email = xmlReader.ReadString();
                                            break;
                                }                  

                            } 

                        }
                    
                        bool formatoCorrecto = (telefonos.Count > 0 || montos.Count > 0);

                        if (isUsuarioValido(receptor) && formatoCorrecto)
                        {
                            Receptor nuevo;
                            int mt = 0;
                            int contadorMonto = 0;
                            int contPlanes = 0;

                            if (montos.Count == 0 && telefonos.Count == 1 && receptor.MontoTotal != 0 && planes.Count != 0)
                            {
                                mt = receptor.MontoTotal;
                                nuevo = new Receptor(receptor.Archivo, receptor.Rut, receptor.Nombre, receptor.Direccion, receptor.Comuna, receptor.Ciudad, receptor.MontoTotal, receptor.Email, telefonos[0], mt, planes[0]);

                                if(nuevo.Telefono != telefonos[0])
                                registros.Add(telefonos[0], nuevo);
                            }
                            else
                            {
                                for (int i = 0; i < telefonos.Count; i++)
                                {

                                    if (montos.Count > 0 && planes.Count > 0)
                                    {
                                        mt = montos.ElementAt(contadorMonto);

                                        nuevo = new Receptor(receptor.Archivo, receptor.Rut, receptor.Nombre, receptor.Direccion, receptor.Comuna, receptor.Ciudad, receptor.MontoTotal, receptor.Email, telefonos[i], mt, planes[contPlanes]);

                                        if (!registros.ContainsKey(telefonos[i]))
                                            registros.Add(telefonos[i], nuevo);                                        
                                    }

                                    if (contadorMonto < montos.Count - 1 && contPlanes < planes.Count - 1)
                                    {
                                        contadorMonto++;
                                        contPlanes++;
                                    }
                                }
                            }

                        }

                        xmlReader.Close(); 
                    }
                }
            }
            catch (FileNotFoundException)
            {
                agregarSonido(false);
                MessageBox.Show("DEBE INGRESAR UNA RUTA VALIDA PARA LEER ARCHIVOS XML", "ERROR DE TIPO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }        

        private void generarExcel()
        {
            String rutaArchivo = destino + "\\backup.xlsx";
            List<Receptor> usuarios = new List<Receptor>();
            bool falla = false;

            try
            {
                if (nombreArchivos.Count > 0)
                {
                    objExcel.Application objAplicacion = new objExcel.Application();
                    Workbook objLibro = objAplicacion.Workbooks.Add(XlSheetType.xlWorksheet);
                    Worksheet objHoja = (Worksheet)objAplicacion.ActiveSheet;

                    objAplicacion.Visible = false;

                    int fila = 2;
                    int columna = 2;
                    int cuentaRegistro = 1;

                    objHoja.Cells[fila, columna++] = "N° registro";
                    objHoja.Cells[fila, columna++] = "telefono";
                    objHoja.Cells[fila, columna++] = "servicio";
                    objHoja.Cells[fila, columna++] = "valor";
                    objHoja.Cells[fila, columna++] = "nombre";
                    objHoja.Cells[fila, columna++] = "rut";
                    objHoja.Cells[fila, columna++] = "montototal";
                    objHoja.Cells[fila, columna++] = "direccion";
                    objHoja.Cells[fila, columna++] = "comuna";
                    objHoja.Cells[fila, columna++] = "ciudad";
                    objHoja.Cells[fila, columna++] = "email";
                    objHoja.Cells[fila, columna++] = "archivo";

                    SortedList<string, Receptor> temporal = new SortedList<string, Receptor>();

                    foreach (var item in nombreArchivos)
                    {                        
                            cargarRegistrosPorArchivos(item);                        
                    }

                    foreach (KeyValuePair<string, Receptor> rcs in registros)
                    {                        
                        Receptor r = rcs.Value;

                        if (!existeRegistro(r))
                        {
                            columna = 2;
                            fila++;

                            objHoja.Cells[fila, columna++] = cuentaRegistro.ToString();// id
                            objHoja.Cells[fila, columna++] = rcs.Key;
                            objHoja.Cells[fila, columna++] = rcs.Value.Servicio; // Servicio;
                            objHoja.Cells[fila, columna++] = rcs.Value.Valor; // Valor
                            objHoja.Cells[fila, columna++] = rcs.Value.Nombre; // Nombre
                            objHoja.Cells[fila, columna++] = rcs.Value.Rut; // Rut
                            objHoja.Cells[fila, columna++] = rcs.Value.MontoTotal; // MontoTotal
                            objHoja.Cells[fila, columna++] = rcs.Value.Direccion; // Direccion
                            objHoja.Cells[fila, columna++] = rcs.Value.Comuna; // Comuna
                            objHoja.Cells[fila, columna++] = rcs.Value.Ciudad; // Ciudad
                            objHoja.Cells[fila, columna++] = rcs.Value.Email; // Ciudad
                            objHoja.Cells[fila, columna++] = rcs.Value.Archivo; // Archivo

                            cuentaRegistro++;
                        }                        
                    }

                    if (File.Exists(rutaArchivo))
                    {
                        foreach (var process in Process.GetProcesses())
                        {
                            if (process.MainWindowTitle.Contains("backup.xlsx"))
                            {
                                process.Kill();
                                break;
                            }
                        }

                        try
                        {
                            File.Delete(rutaArchivo);
                        }
                        catch (IOException)
                        {
                            falla = true;
                            agregarSonido(false);
                            MessageBox.Show("CIERRE TODAS LAS VENTANAS DE EXCEL ABIERTAS, PARA PODER CONTINUAR", "DEBE CERRAR ARCHIVO BACKUP.XLSX", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (!falla)
                    {
                        objLibro.SaveAs(destino + "\\backup.xlsx");
                        objLibro.Close();
                        objAplicacion.Quit();
                    }
                }
                else
                {
                    agregarSonido(false);
                    MessageBox.Show("NO EXISTEN DATOS A CONVERTIR", "XML NULL", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (NullReferenceException nre)
            {
                agregarSonido(false);
                MessageBox.Show("NO SE PUEDE LLENAR UN OBJETO QUE NO SE HA CREADO\n" + nre.HResult, "OBJETO NULL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void formulario_Click(object sender, EventArgs e)
        {
            cargaArchivos(origen);
            lblV1.Text = contadorGeneral.ToString();
            lblV2.Text = contadorXml.ToString();
        }

        private void lbxPrueba_Click(object sender, EventArgs e)
        {
            cargaArchivos(origen);
            lblV1.Text = contadorGeneral.ToString();
            lblV2.Text = contadorXml.ToString();
        }

        private bool isUsuarioValido(Receptor receptor)
        {
            if (receptor.Archivo != String.Empty && receptor.Ciudad != String.Empty && receptor.Comuna != String.Empty &&
                receptor.Direccion != String.Empty && receptor.Nombre != String.Empty && receptor.Rut != String.Empty && 
                receptor.Email != String.Empty)
            {
                return true;
            }
            return false;
        }        

        private bool isPlanValido(String nombre)
        {
            #region

            bool isCorrecto = false;

            if (!String.IsNullOrEmpty(nombre))
            {
                switch (nombre)
                {
                    case "Plan 25 Gigas WOM":
                        isCorrecto = true;
                        break;
                    case "Plan Acumula 125 Gigas":
                        isCorrecto = true;
                        break;
                    case "Plan Acumula 50 GB":
                        isCorrecto = true;
                        break;
                    case "Plan Acumula 75 Gigas":
                        isCorrecto = true;
                        break;
                    case "Plan de Retención":
                        isCorrecto = true;
                        break;
                    case "Plan Emprende Acumula 50 GB":
                        isCorrecto = true;
                        break;
                    case "Plan Emprendedores 25 GB":
                        isCorrecto = true;
                        break;
                    case "Plan Grupal 50 Gigas WOM":
                        isCorrecto = true;
                        break;
                    case "Plan Grupal Acumula 50 GB":
                        isCorrecto = true;
                        break;
                    case "Plan Grupal Acumula 75 GB":
                        isCorrecto = true;
                        break;
                    case "Plan Grupal WOM 85 Gigas":
                        isCorrecto = true;
                        break;
                    case "Plan Mandato 85 Gigas 18M":
                        isCorrecto = true;
                        break;
                    case "Plan Retail 50 GB 18M":
                        isCorrecto = true;
                        break;
                    case "Plan RO WOM Emprende 85Gigas":
                        isCorrecto = true;
                        break;
                    case "Plan WOM 125 Gigas":
                        isCorrecto = true;
                        break;
                    case "Plan WOM 15 GB":
                        isCorrecto = true;
                        break;
                    case "Plan WOM 25 GB":
                        isCorrecto = true;
                        break;
                    case "Plan WOM 85 GB":
                        isCorrecto = true;
                        break;
                    case "Plan WOM 85 Gigas":
                        isCorrecto = true;
                        break;
                    case "Plan Womers 25 GB":
                        isCorrecto = true;
                        break;
                    case "Prepago WOM 00":
                        isCorrecto = true;
                        break;
                    default:
                        isCorrecto = false;
                        break;
                }
            }
            #endregion
            return isCorrecto;
        }

        private void activarBoton(string nombre) {

            switch (nombre.ToLower())
            {
                case "origen":
                    btnOrigen.BackColor = Color.FromArgb(2, 183, 4);
                    btnExportar.BackColor = System.Drawing.Color.Teal;
                    btnDestino.BackColor = System.Drawing.Color.DimGray;
                break;
                case "destino":
                    btnDestino.BackColor = System.Drawing.Color.Gray;
                    btnOrigen.BackColor = System.Drawing.Color.Green;
                    btnExportar.BackColor = System.Drawing.Color.Teal;
                break;
                case "exportar":
                    btnDestino.BackColor = System.Drawing.Color.DimGray;
                    btnOrigen.BackColor = System.Drawing.Color.Green;
                break;
            }
        }

        private bool fechaValida(DateTime fechaFutura){

            bool fechaCorrecta = true;

            if (fechaFutura != null)
            {
                DateTime actual = DateTime.UtcNow.AddHours(-1);                

                if (fechaFutura < actual)
                {
                    fechaCorrecta = false;
                }                
            }

            return fechaCorrecta;
        }

        public void agregarSonido(bool estado) {

            sonido = new SoundPlayer();

            if (estado)
                sonido.Stream = Properties.Resources.aplausos;
            else
                sonido.Stream = Properties.Resources.plop;

            sonido.Play();
        }

        private bool existeRegistro(Receptor receptor)
        {

            bool existe = false;

            if (receptor != null && registros.Count > 0)
            {

                foreach (KeyValuePair<String, Receptor> item in this.registros)
                {
                    Receptor r = item.Value;

                    if (r.Archivo != receptor.Archivo && r.Ciudad == receptor.Ciudad && r.Comuna == receptor.Comuna && r.Direccion == receptor.Direccion
                            && r.Email == receptor.Email && r.MontoTotal == receptor.MontoTotal && r.Nombre == receptor.Nombre && r.Rut == receptor.Rut
                            && r.Servicio == receptor.Servicio && r.Telefono == receptor.Telefono && r.Valor == receptor.Valor)
                    {
                        existe = true;
                    }
                }
            }

            return existe;
        }

        public void versionExpirada() {

            if (!fechaValida(fechaExpiracion))
            {
                agregarSonido(false);
                MessageBox.Show("SU VERSION DE PRUEBA A EXPIRADO, CONTACTESE CON EL DESARROLLADOR", "LA FECHA DE PRUEBA HA EXPIRADO", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                formulario.ActiveForm.Close();
            }
        }
    }
}
