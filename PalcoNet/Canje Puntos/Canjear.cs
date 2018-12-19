using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PalcoNet.Support;

namespace PalcoNet.Canje_Puntos
{
    public partial class Canjear : Form
    {

        int puntosActuales;
        string ndocumento;
        string tdocumento;
        canjePuntos volver;
        public Canjear(int puntos,string numeroDocumento,string tipoDocumento, canjePuntos cj)
        {
            volver = cj;
            InitializeComponent();
            textBoxPuntos.Text = Convert.ToString(puntos);
            puntosActuales = puntos;
            ndocumento = numeroDocumento;
            tdocumento = tipoDocumento;
        }

        private void cargarPuntos() {
            String query = "SELECT SUM(punt_puntaje) FROM SQLEADOS.puntaje JOIN SQLEADOS.Cliente ON cliente_numero_documento = punt_cliente_numero_documento AND cliente_tipo_documento LIKE punt_cliente_tipo_documento WHERE punt_id NOT IN (SELECT pp.punt_id FROM SQLEADOS.puntaje pp WHERE pp.punt_fecha_vencimiento <= GETDATE()) AND cliente_usuario = 85";
            DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
            puntosActuales = Convert.ToInt32(dt.Rows[0][0].ToString());
            textBoxPuntos.Text = dt.Rows[0][0].ToString();
        }

        private void Canjear_Load(object sender, EventArgs e)
        {
            CanjePuntos.cargarGriddCanje(dataGridView1);
            dataGridView1.SelectionChanged += new EventHandler(dataGridView1_SelectionChanged);
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                textBoxPremio.Text = row.Cells["canj_producto"].Value.ToString();
                textBoxValor.Text = row.Cells["canj_costo_puntaje"].Value.ToString();
            //    textBoxPuntos.Text = Convert.ToString(puntosActuales - Convert.ToInt32(textBoxValor.Text));

                if (Convert.ToInt32(textBoxPuntos.Text) < Convert.ToInt32(textBoxValor.Text))
                {
                    textBoxPuntos.Text = puntosActuales.ToString();
                    MessageBox.Show("Puntos Insuficientes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                var row = dataGridView1.SelectedRows[0];
                textBoxPremio.Text = row.Cells["canj_producto"].Value.ToString();
                textBoxValor.Text = row.Cells["canj_costo_puntaje"].Value.ToString();
           //     textBoxPuntos.Text =Convert.ToString(puntosActuales - Convert.ToInt32(textBoxValor.Text));

                if (Convert.ToInt32(textBoxPuntos.Text) < Convert.ToInt32(textBoxValor.Text))
                {
                    textBoxPuntos.Text = puntosActuales.ToString();
                    MessageBox.Show("Puntos Insuficientes", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //BOTON CANJEAR
            if (Convert.ToInt32(textBoxPuntos.Text) < puntosActuales)
            {

                MessageBox.Show("Puntos Insuficiente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else if(datosVacios()){
                MessageBox.Show("Aún no se ha seleccionado un premio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                canjearPuntos(ndocumento, tdocumento, textBoxValor.Text, textBoxPremio.Text);
                cargarPuntos();
          //      CanjePuntos.canje(ndocumento, tdocumento, Convert.ToInt32(textBoxValor.Text) - Convert.ToInt32(textBoxValor.Text));
                /*
                volver.Show();
                this.Close();*/
            }
        }

        private void canjearPuntos(String nroDocumento, String tipoDoc, String valorProducto, String producto) {
            int aux = Convert.ToInt32(valorProducto);
            //SI ENTRA AQUÍ, ES PORQUE EL CLIENTE PUEDE GASTARSE LOS PUNTOS 

            while (aux > 0) 
            { 
                //EL SISTEMA RESTARÁ TODOS AQUELLOS PUNTOS QUE TIENE EL CLIENTE QUE NO HAYA VENCIDO
                String query = "SELECT TOP 1 punt_id, punt_puntaje FROM SQLEADOS.puntaje JOIN SQLEADOS.Cliente c ON c.cliente_numero_documento = punt_cliente_numero_documento AND c.cliente_tipo_documento LIKE punt_cliente_tipo_documento WHERE punt_id NOT IN (SELECT pp.punt_id FROM SQLEADOS.puntaje pp WHERE pp.punt_fecha_vencimiento <= GETDATE()) AND cliente_usuario = " + Usuario.ID + " ORDER BY punt_fecha_vencimiento ASC";
                DataTable dt = DBConsulta.AbrirCerrarObtenerConsulta(query);
                int puntos = Convert.ToInt32(dt.Rows[0][1].ToString());
                if (puntos <= aux) 
                {
                    aux -= puntos;
                    eliminarPuntaje(dt.Rows[0][0].ToString());
                }
                else 
                {
                    puntos -= aux;
                    aux = 0;
                    actualizarPuntaje(dt.Rows[0][0].ToString(), puntos);
                }
            }

            String querys = "INSERT INTO SQLEADOS.Canjes(canje_cliente_numero_documento,canje_cliente_tipo_documento, canje_fecha, canje_puntos_gastados, canje_producto) VALUES ("+nroDocumento+", '"+tipoDoc+"', GETDATE(), "+valorProducto+", '"+producto+"')";
            DBConsulta.AbrirCerrarModificarDB(querys);

            MessageBox.Show("Haz canjeado " + valorProducto + " puntos por el premio: " + producto);

        }

        private void actualizarPuntaje(String puntajeID, int nuevoPuntaje) 
        {
            String query = "UPDATE SQLEADOS.puntaje SET punt_puntaje = " + nuevoPuntaje + " WHERE punt_id =  " + puntajeID;
            DBConsulta.AbrirCerrarModificarDB(query);
        }

        private void eliminarPuntaje(String puntajeID)
        {
            String query = "DELETE FROM SQLEADOS.puntaje WHERE punt_id = " + puntajeID;
            DBConsulta.AbrirCerrarModificarDB(query);
        }

        private bool datosVacios() {
            if (textBoxPremio.Text == "") {
                return true;
            }
            if (textBoxPuntos.Text == "") {
                return true;
            }
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //VOLVER
            volver.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
       /*     String premio = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBoxPremio.Text = premio;
            textBoxPuntos.Text dataGridView1.SelectedRows[0].Cells[1].Value.ToString();*/
        }
    }
}
