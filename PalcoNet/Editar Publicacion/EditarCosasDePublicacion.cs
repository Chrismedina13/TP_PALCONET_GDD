using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using PalcoNet.Support;

namespace PalcoNet.Editar_Publicacion
{
    public partial class EditarCosasDePublicacion : Form
    {
        private int publicacionID;
        private DataTable dt;
        private EditarPublicacion ed;
        String categoriaOriginal;

   //     var ubicacionesYPrecio = new List<Tuple<int, int>>();
        List<Tuple<int, int>> ubicacionesYPrecio;
        List<Tuple<int, int>> ubicacionesOriginales;

        String puntajeOriginal, gradoOriginal, horaoriginalInicial, minutooriginalInicial;
        String horaOriginalFinal, minutoOriginalFinal, fechaOriginalFinal, fechaOriginalInicial;

        String anioFinal, mesFinal, diaFinal, horaFinal, minutoFinal;
        String anioInicial, mesInicial, diaInicial, horaInicial, minutoInicial;

        class ubicacionYPrecio 
        {
            public static List<int> ubicacion = new List<int>();
            public static List<int> precio = new List<int>();
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }
        
        public EditarCosasDePublicacion(int publicacion, EditarPublicacion eddy)
        {
            ed = eddy;
            publicacionID = publicacion;
            InitializeComponent();
            dt = new DataTable();
            String query = "SELECT publicacion_estado as 'ESTADO', publicacion_fecha_venc as 'FECHA FINAL', publicacion_fecha as 'FECHA INICIAL', g.grado_nombre as 'GRADO', r.rubro_descripcion as 'Rubro', publicacion_puntaje_venta as 'PUNTAJE' FROM SQLEADOS.Publicacion JOIN SQLEADOS.Rubro r ON r.rubro_id = publicacion_rubro JOIN SQLEADOS.GradoPrioridad G on G.grado_id = publicacion_grado where publicacion_codigo = " + publicacionID;
            dt = DBConsulta.AbrirCerrarObtenerConsulta(query);

            query = "SELECT u.ubiXpubli_Ubicacion, u.ubiXpubli_precio FROM SQLEADOS.Publicacion p JOIN SQLEADOS.ubicacionXpublicacion u ON p.publicacion_codigo = u.ubiXpubli_Publicacion";
            DataTable tt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            for(int i = 0; i<tt.Rows.Count;i++) 
            {
                int id = Convert.ToInt32(tt.Rows[i][0].ToString());
                int precio = Convert.ToInt32(tt.Rows[i][1].ToString());

                ubicacionYPrecio.precio.Add(precio);
                ubicacionYPrecio.ubicacion.Add(id);
            }
            ubicacionesOriginales = ubicacionesYPrecio;
            puntajeOriginal = dt.Rows[0]["PUNTAJE"].ToString();
            gradoOriginal = dt.Rows[0]["GRADO"].ToString();
            categoriaOriginal = dt.Rows[0]["Rubro"].ToString();

            fechaOriginalFinal = dt.Rows[0]["FECHA FINAL"].ToString();
            fechaOriginalInicial = dt.Rows[0]["FECHA INICIAL"].ToString();

        }

        private void EditarCosasDePublicacion_Load(object sender, EventArgs e)
        {
            radioButtonBorrador.Checked = true;
            textPuntaje.Text = dt.Rows[0]["PUNTAJE"].ToString();
            comboBoxGrados.Text = dt.Rows[0]["GRADO"].ToString();
            obtenerDatosDeFechasYHorarioInicial(dt.Rows[0]["FECHA INICIAL"].ToString());
            obtenerDatosDeFechasYHorarioFinal(dt.Rows[0]["FECHA FINAL"].ToString());
            labelCategoria.Text = dt.Rows[0]["Rubro"].ToString();

            dateTimePicker1.Value = new DateTime(Convert.ToInt32(anioInicial), Convert.ToInt32(mesInicial), Convert.ToInt32(diaInicial));
            dateTimePickerFechaFinal.Value = new DateTime(Convert.ToInt32(anioFinal), Convert.ToInt32(mesFinal), Convert.ToInt32(diaFinal));
     //       dateTimePicker1.Value = new DateTime(f1.Year, f1.Month, f1.Day);
        }

        public void cambiarCategoria(String cate) {
            labelCategoria.Text = cate;
        }


        private void obtenerDatosDeFechasYHorarioFinal(String fechaYHora) 
        { 
            //dd/MM/yyyy hh:mm:ss
            //OBTENER FECHA

            String anio = "", mes = "", dia = "", hora ="", minuto="", segundo="", subsstring ="";
            int pos = fechaYHora.IndexOf("/");
            dia += fechaYHora.Substring(0, pos);
            subsstring = fechaYHora.Substring(pos+1, fechaYHora.Length -pos-1);
            pos = subsstring.IndexOf("/");
            mes += subsstring.Substring(0, pos);
            subsstring = subsstring.Substring(pos + 1, subsstring.Length - pos-1);
            anio += subsstring.Substring(0, 4);
            subsstring = subsstring.Substring(5, subsstring.Length - 5);

            anioFinal = anio;
            mesFinal = mes;
            diaFinal = dia;

            dateTimePicker1.Value = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));

            pos = subsstring.IndexOf(":");
            hora += subsstring.Substring(0, pos);
            subsstring = subsstring.Substring(pos + 1, subsstring.Length - pos - 1);

            pos = subsstring.IndexOf(":");
            minuto += subsstring.Substring(0, pos);
            subsstring = subsstring.Substring(pos + 1, subsstring.Length - pos - 1);

            segundo += subsstring;
            horaFinal = hora;
            minutoFinal = minuto;

            textBoxHoraInicial.Text = hora;
            textBoxMinutoInicial.Text = minuto;
        }

        private void obtenerDatosDeFechasYHorarioInicial(String fechaYHora) 
        { 
            //dd/MM/yyyy hh:mm:ss
            //OBTENER FECHA

            String anio = "", mes = "", dia = "", hora ="", minuto="", segundo="", subsstring ="";
            int pos = fechaYHora.IndexOf("/");
            dia += fechaYHora.Substring(0, pos);
            subsstring = fechaYHora.Substring(pos+1, fechaYHora.Length -pos-1);
            pos = subsstring.IndexOf("/");
            mes += subsstring.Substring(0, pos);
            subsstring = subsstring.Substring(pos + 1, subsstring.Length - pos-1);
            anio += subsstring.Substring(0, 4);
            subsstring = subsstring.Substring(5, subsstring.Length - 5);

            anioInicial = anio;
            mesInicial = mes;
            diaInicial = dia;

            dateTimePicker1.Value = new DateTime(Convert.ToInt32(anio), Convert.ToInt32(mes), Convert.ToInt32(dia));

            pos = subsstring.IndexOf(":");
            hora += subsstring.Substring(0, pos);
            subsstring = subsstring.Substring(pos + 1, subsstring.Length - pos - 1);

            pos = subsstring.IndexOf(":");
            minuto += subsstring.Substring(0, pos);
            subsstring = subsstring.Substring(pos + 1, subsstring.Length - pos - 1);

            segundo += subsstring;
            horaInicial = hora;
            minutoInicial = minuto;
            textBoxHoraInicial.Text = hora;
            textBoxMinutoInicial.Text = minuto;
        }

        private bool todosLosHorariosSonValidos()
        {
            if (AyudaExtra.esStringVacio(textBoxHoraInicial.Text) == true)
            {
                MessageBox.Show("En la sección HORARIOS, algunas campos están vacíos");
                return false;
            }
            if (AyudaExtra.esStringVacio(textBoxMinutoInicial.Text) == true)
            {
                MessageBox.Show("En la sección HORARIOS, algunas campos están vacíos");
                return false;
            }
           
            if (!AyudaExtra.esStringNumerico(textBoxHoraInicial.Text))
            { 
                MessageBox.Show("El campo hora no es numérico");
                return false;
            }
                if (!AyudaExtra.esStringNumerico(textBoxMinutoInicial.Text))
            { 
                MessageBox.Show("El campo minuto no es numérico");
                return false;
            }

                if (Convert.ToInt32(textBoxMinutoInicial.Text) < 60 && Convert.ToInt32(textBoxHoraInicial.Text) < 24)
                {
                    return true;
                }
                MessageBox.Show("Alguno de los campos de Horario tiene un número inválido");
                return false; 
        }

        //MODIFICAR DATOS
        private void button1_Click(object sender, EventArgs e)
        {
            // O = BORRRADOR = NO HACER NADA , 1 = PUBLICADA o 2 = FINALIZADA = CAMBIAR
//            String update = "UPDATE SQLEADOS.Publicacion SET ";
            String estado = "";
            if (radioButtonBorrador.Checked == true)
            {
                estado = "Borrador";
            } else
            if (radioButtonFinalizada.Checked == true)
            {
                estado = "Finalizada";
            }
            else if (radioButtonPublicada.Checked == true) {
                estado = "Publicada";
            }
            

            if (todosLosHorariosSonValidos())
            {
                //ARMAR FECHA CON HORA
            }
            else {
                return;
            }
            //AGREGAR AHORA CATEGORÍA

       //     update += buscarCategoriaYAgregar();

            if (!AyudaExtra.esStringVacio(textPuntaje.Text)) {
                if (!AyudaExtra.esStringNumerico(textPuntaje.Text))
                {
                    MessageBox.Show("El puntaje no fue ingresado no es un número");
                    return;
                }
            } else {
                MessageBox.Show("El puntaje no fue ingresado");
                return;
            }


            if (AyudaExtra.fechaMenorQueActual(dateTimePicker1.Value))
            {
                MessageBox.Show("La fecha del espectáculo debe ser mayor que la fecha de hoy");
                return;
            }
            if (AyudaExtra.fechaIgualQueActual(dateTimePicker1.Value))
            {
                MessageBox.Show("La fecha del espectáculo debe ser mayor que la fecha de hoy");
                return;
            }
            
         //   DBConsulta.ConectarConsulta(update);
            if (noHayProblemaConLaFechaYHora()) {
                DBConsulta.conexionAbrir();
                DBConsulta.actualizarPublicidad(publicacionID, estado, buscarCategoriaYAgregar(), comboBoxGrados.SelectedIndex + 1, armarFechaYHoraYAgregarAUpdate(), Convert.ToInt32(textPuntaje.Text));
                DBConsulta.conexionCerrar();
                MessageBox.Show("Se ha actualizado la publicación");
                ed.recargar();
                this.Close();
            } else {
                MessageBox.Show("A la fecha que se quiere indicar ya existe otra función,\nSeleccione otra fecha");
            }
        }

        private bool noHayProblemaConLaFechaYHora() {
            String query = "SELECT publicacion_fecha_venc FROM SQLEADOS.Publicacion where publicacion_fecha_venc = '" + armarFechaYHoraYAgregarAUpdate()+"'";
            DBConsulta.conexionAbrir();
            DataTable dt = DBConsulta.obtenerConsultaEspecifica(query);
            DBConsulta.conexionCerrar();
            return dt.Rows.Count == 0;
        }

        private String armarFechaYHoraYAgregarAUpdate() {
            String fechaArmada = dateTimePicker1.Value.ToString();
            fechaArmada = fechaArmada.Substring(0, fechaArmada.Length - fechaArmada.LastIndexOf("/") - 3);
            fechaArmada += " " + textBoxHoraInicial.Text + ":" + textBoxMinutoInicial.Text;
            return fechaArmada;
        }

        private int buscarCategoriaYAgregar() {

            DataTable dt1 = new DataTable();
            DBConsulta.conexionAbrir();
            dt1 = DBConsulta.obtenerConsultaEspecifica("SELECT rubro_id FROM SQLEADOS.Rubro where rubro_descripcion LIKE '" + labelCategoria.Text + "'");
            DBConsulta.conexionCerrar();
            return Convert.ToInt32(dt1.Rows[0][0].ToString());
        }

        //IR A ELEGIR CATEGORÍA
        private void button2_Click(object sender, EventArgs e)
        {
            Seleccionar1Categoria sel = new Seleccionar1Categoria(this);
            sel.Show();
        }

        // EDITAR UBICACIONES
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void labelCategoria_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //LIMPIAR CRITERIOS
            radioButtonBorrador.Checked = true;
            radioButtonFinalizada.Checked = false;
            radioButtonPublicada.Checked = false;

            textPuntaje.Text = puntajeOriginal;
            comboBoxGrados.Text = gradoOriginal;
            labelCategoria.Text = categoriaOriginal;
            ubicacionesYPrecio = ubicacionesOriginales;

            textBoxHoraFinal.Text = horaFinal;
            textBoxMinutoFinal.Text = minutoFinal;

            textBoxHoraInicial.Text = horaInicial;
            textBoxMinutoInicial.Text = minutoInicial;

            dateTimePicker1.Value = new DateTime(Convert.ToInt32(anioInicial), Convert.ToInt32(mesInicial), Convert.ToInt32(diaInicial));
            dateTimePickerFechaFinal.Value = new DateTime(Convert.ToInt32(anioFinal), Convert.ToInt32(mesFinal), Convert.ToInt32(diaFinal));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ed.Show();
            this.Close();
        }

        
    }
}
