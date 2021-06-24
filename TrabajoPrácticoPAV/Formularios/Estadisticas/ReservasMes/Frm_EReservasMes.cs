﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoPrácticoPAV.Clase;
using TrabajoPrácticoPAV.NE_Usuarios;

namespace TrabajoPrácticoPAV.Formularios.Estadisticas.ReservasMes
{
    public partial class Frm_EReservasMes : Form
    {
        NE_Reserva reservaMes = new NE_Reserva();
        DataTable tabla = new DataTable();

        public Frm_EReservasMes()
        {
            InitializeComponent();
            
        }

        private void Frm_EReservasMes_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            this.BackColor = Estilo.ColorFondoForms;
            Estilo.FormatearEstilo(this.Controls);

            this.reportViewer1.RefreshReport();
        }
        private void ArmarEstadisticaReservaMes()
        {
            ReportDataSource PaqueteDatos = new ReportDataSource("Ds_ReservaMes", tabla);
            reportViewer1.LocalReport.ReportEmbeddedResource = "TrabajoPrácticoPAV.Formularios.Estadisticas.ReservasMes.Estadistica_ReservasMes.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(PaqueteDatos);
            reportViewer1.RefreshReport();
        }
        private void btn_Calcular_Click(object sender, EventArgs e)
        {
            if (rd_PorMes.Checked) {
                if (Txt_Desde.Text != "" && Txt_Hasta.Text != "") {
                    if (int.Parse(Txt_Desde.Text) > int.Parse(Txt_Hasta.Text))
                    {
                        MessageBox.Show("El rango no es válido. Por favor ingrese nuevamente un rango.");
                    }

                    string desde = "";
                    string hasta = "";

                    if (Txt_Desde.Text == "")
                        desde = "0";
                    else
                        desde = Txt_Desde.Text;
                    if (Txt_Hasta.Text == "")
                        hasta = "99999";
                    else
                        hasta = Txt_Hasta.Text;


                    tabla = reservaMes.E_ResuperarPorMes(msk_Mes.Text.ToString());
                    if (tabla.Rows.Count != 0)
                        ArmarEstadisticaReservaMes();
                    else
                    {
                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.RefreshReport();
                        MessageBox.Show("No se encontraron resultados");
                    }
                }
                else
                {
                    MessageBox.Show("LLena los campos de meses.");

                }
            //    if (msk_Mes.Text != "")
            //    {
            //        tabla = reservaMes.E_ResuperarPorMes(msk_Mes.Text.ToString());
            //        ArmarEstadisticaReservaMes(tabla);
            //    }
           
                        else
                        {
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.RefreshReport();
                    MessageBox.Show("No se encontraron resultados");
                }
            }
        


            else if (rd_PorMes.Checked && msk_Mes.Mask == "")
            {
                MessageBox.Show("Por favor, ingresar una fecha");
            }
            else if (rd_Todos.Checked)
            {
                tabla = reservaMes.ES_RecuperarTodosReservas();
                if (tabla.Rows.Count != 0)
                    ArmarEstadisticaReservaMes();
                else
                {
                    reportViewer1.LocalReport.DataSources.Clear();
                    reportViewer1.RefreshReport();
                    MessageBox.Show("No se encontraron resultados para la búsqueda");
                }
            }
        }
    }
}
