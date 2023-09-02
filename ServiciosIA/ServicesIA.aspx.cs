using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ServiciosIA
{
    public partial class ServicesIA : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string value = Request.QueryString["value"];
                string servicio = Request.QueryString["servicio"];

                if (!string.IsNullOrEmpty(value))
                {
                    string resultado = null;
                    string servicioNombre = string.Empty;
                    if (string.IsNullOrEmpty(servicio))
                    {
                        
                        resultado = ProcesarArchivoGeneral(value);
                        servicioNombre = "General";
                    }
                    else
                    {
                        
                        switch (servicio.ToLower())
                        {
                            case "liquidez":
                                resultado = ProcesarArchivoLiquidez(value);
                                lblServicio.Text = " - Liquidez";
                                break;
                            case "endeudamiento":
                                resultado = ProcesarArchivoEndeudamiento(value);
                                lblServicio.Text = " - Endeudamiento";
                                break;
                            case "rentabilidad":
                                resultado = ProcesarArchivoRentabilidad(value);
                                lblServicio.Text = " - Rentabilidad";
                                break;
                            case "eficiencia":
                                resultado = ProcesarArchivoEficiencia(value);
                                lblServicio.Text = " - Eficiencia";
                                break;
                            default:
                                resultado = "Servicio no válido.";
                                break;
                        }
                    }

                    lblMensaje.Text = $" - {servicioNombre}";

                    resultado = FormatearTexto(resultado);

                    lblMensaje.Text = resultado;
                    /*resultado*/
                }
                else
                {
                    
                    lblMensaje.Text = "Parámetro 'value' de URL incorrecto.";
                }
            }
        }

        private string FormatearTexto(string texto)
        {
            

            texto = texto.Replace("\n", "<br>");

            return texto;
        }

        public string ProcesarArchivoGeneral(string value)
        {
            var url = $"http://190.147.38.91:1002/ServiceIA/procesarArchivoUrl?url=https://cyber.contabilidadonline.com/rep/{value}.xls";
            return RealizarSolicitudHttp(url);
        }

        public string ProcesarArchivoLiquidez(string value)
        {
            var url = $"http://190.147.38.91:1002/ServiceIA/procesarArchivoUrlLiquidez?url=https://cyber.contabilidadonline.com/rep/{value}.xls";
            return RealizarSolicitudHttp(url);
        }

        public string ProcesarArchivoEndeudamiento(string value)
        {
            var url = $"http://190.147.38.91:1002/ServiceIA/procesarArchivoUrlEndeudamiento?url=https://cyber.contabilidadonline.com/rep/{value}.xls";
            return RealizarSolicitudHttp(url);
        }

        public string ProcesarArchivoRentabilidad(string value)
        {
            var url = $"http://190.147.38.91:1002/ServiceIA/procesarArchivoUrlRentabilidad?url=https://cyber.contabilidadonline.com/rep/{value}.xls";
            return RealizarSolicitudHttp(url);
        }
        public string ProcesarArchivoEficiencia(string value)
        {
            var url = $"http://190.147.38.91:1002/ServiceIA/procesarArchivoUrlEficiencia?url=https://cyber.contabilidadonline.com/rep/{value}.xls";
            return RealizarSolicitudHttp(url);
        }



        private string RealizarSolicitudHttp(string url)
        {
            string responseBody = "";

            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";

            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null)
                        {
                            return "";
                        }

                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            responseBody = objReader.ReadToEnd();
                            Console.WriteLine(responseBody);
                        }
                    }
                }
                return responseBody;
            }
            catch (WebException ex)
            {
                throw ex;
            }
        }
    }
}

