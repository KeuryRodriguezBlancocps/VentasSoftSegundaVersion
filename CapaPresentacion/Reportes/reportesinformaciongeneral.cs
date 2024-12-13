using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CapaPresentacion.Reportes
{
    public partial class reportesinformaciongeneral : Form
    {
        public reportesinformaciongeneral()
        {
            InitializeComponent();
            Load += Reportesinformaciongeneral_Load;
        }

        private void Reportesinformaciongeneral_Load(object sender, EventArgs e)
        {
            VentasTotales();
            ComprasTotales();
            ClientesTotales();
            ProductosEnAlertaDeStock();
            VentasDelDia();
            ComprasDelDia();
            ProductosMasVendidos();
        }






        private void ProductosMasVendidos()
        {

            try
            {

                cnproductos objproductos = new cnproductos();
                    DataTable dataTable = new DataTable();
                dataTable = objproductos.ProductosMasVendidos();

                    // Verificar si el DataTable contiene datos
                    if (dataTable.Rows.Count == 0)
                    {
                        MessageBox.Show("No se encontraron datos.");
                        return;
                    }

                    // Configuración del Chart
                   chart1.Series.Clear();
                    chart1.ChartAreas.Clear();

                    ChartArea chartArea = new ChartArea("ChartArea1")
                    {
                        BackColor = System.Drawing.Color.White,
                        AxisX =
            {

                TitleFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold),
                LabelStyle = { Font = new System.Drawing.Font("Arial", 10F) },
                MajorGrid = { LineWidth = 0 },
                IntervalAutoMode = IntervalAutoMode.VariableCount
            },
                        AxisY =
            {
                Title = "Cantidad",
                TitleFont = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold),
                LabelStyle = { Font = new System.Drawing.Font("Arial", 10F) },
                MajorGrid = { LineColor = System.Drawing.Color.LightGray },
                IntervalAutoMode = IntervalAutoMode.VariableCount
            },
                        BorderColor = System.Drawing.Color.Transparent,
                        BorderWidth = 0
                    };

                    chart1.ChartAreas.Add(chartArea);

                    Series series = new Series()
                    {
                        ChartType = SeriesChartType.Bar,
                        XValueMember = "Producto",
                        YValueMembers = "Cantidad",
                        IsValueShownAsLabel = true,
                        LabelForeColor = System.Drawing.Color.White,
                        Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold),
                        Color = System.Drawing.Color.FromArgb(93, 140, 165)
                    };

                   chart1.Series.Add(series);
                   chart1.DataSource = dataTable;
                   chart1.DataBind();
                  
                   chart1.BorderlineWidth = 0;
                    chart1.Legends.Clear();
                   chart1.Titles.Clear();
                    Title title = new Title
                    {
                        Text = "Productos más vendidos",
                        Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold),
                        ForeColor = System.Drawing.Color.Black,
                        Alignment = ContentAlignment.TopCenter
                    };
                    chart1.Titles.Add(title);

                    // Agregar un borde redondeado y sombra al gráfico
                    chart1.BackColor = System.Drawing.Color.White;
                    chart1.BackSecondaryColor = System.Drawing.Color.LightGray;
                    chart1.BackGradientStyle = GradientStyle.TopBottom;
                    chart1.BorderSkin.SkinStyle = BorderSkinStyle.Raised;
                }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos: " + ex.Message);
            }
        }






        private void VentasTotales()
        {
            try
            {
                cnventas obj = new cnventas();
                DataTable tabla = new DataTable();
                tabla = obj.VentasTotales();
                if (tabla!=null )
                {
                    txttotalventas.Text = tabla.Rows[0]["Total"].ToString();
                }
                else
                {
                    txttotalventas.Text = 0.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void VentasDelDia()
        {
            try
            {
                cnventas obj = new cnventas();
                DataTable tabla = new DataTable();
                tabla = obj.VentasDelDiaTarjetas();
                if (tabla != null)
                {
                    txttotaldeventasdeldia.Text = tabla.Rows[0]["Total"].ToString();
                }
                else
                {
                    txttotaldeventasdeldia.Text = 0.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void ComprasDelDia()
        {
            try
            {
                cncompra obj = new cncompra();
                DataTable tabla = new DataTable();
                tabla = obj.comprasdelDia();
                if (tabla != null)
                {
                    txtcomprasdeldia.Text = tabla.Rows[0]["Total"].ToString();
                }
                else
                {
                    txtcomprasdeldia.Text = 0.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }





        private void ComprasTotales()
        {
            try
            {
                cncompra obj = new cncompra();
                DataTable tabla = new DataTable();
                tabla = obj.TotalCompra();
                if (tabla != null)
                {
                    txttotalcompras.Text = tabla.Rows[0]["Total"].ToString();
                }
                else
                {
                    txttotalcompras.Text = 0.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void ClientesTotales()
        {
            try
            {
                cnclientes obj = new cnclientes();
                DataTable tabla = new DataTable();
                tabla = obj.Busqueda("");
                if (tabla != null)
                {
                    txttotalcliente.Text = tabla.Rows.Count.ToString();
                }
                else
                {
                    txttotalcliente.Text = 0.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void ProductosEnAlertaDeStock()
        {
            try
            {
                cnproductos obj = new cnproductos();
                DataTable tabla = new DataTable();
                tabla = obj.ProductosenAlertaDeStock();
                if (tabla != null)
                {
                    txtproductosenalerta.Text = tabla.Rows.Count.ToString();
                }
                else
                {
                    txtproductosenalerta.Text = 0.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
