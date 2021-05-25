﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrabajoPrácticoPAV.Clase;
using System.Runtime.InteropServices;
using TrabajoPrácticoPAV.NE_Usuarios;

namespace TrabajoPrácticoPAV.Formularios.Reservas
{
    public partial class Frm_ConsultarPasajerosPorReserva : Form
    {
        // Permite el movimiento del formulario 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWind, int wMsg, int wParam, int lParam);

        // Logica
        private readonly NE_Reserva _NE_Reserva = new NE_Reserva();


        public Frm_ConsultarPasajerosPorReserva()
        {
            InitializeComponent();
            this.BackColor = Estilo.ColorFondoForms;
            Estilo.FormatearEstilo(this.Controls);
        }

        private void Frm_ConsultarPasajerosPorReserva_Load(object sender, EventArgs e)
        {
            comboBox_Aerolinea1.CargarCombo();
        }

        private void BarraSuperior_MouseMove(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void Btn_Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_Cerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox_Aerolinea1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string viajeSeleccionado = $"{comboBox_Aerolinea1.SelectedValue}";
            if (viajeSeleccionado == "" || viajeSeleccionado == "null") return;

            DataTable pasajerosDelViaje = _NE_Reserva.GetTodosLosPasajeros(viajeSeleccionado);

            if (pasajerosDelViaje.Rows.Count >= 1)
                CargarGrilla(pasajerosDelViaje);
            else
                MessageBox.Show("No hay pasajeros en el viaje seleccionado");
        }

        private void CargarGrilla(DataTable table)
        {
            if (table.Rows.Count <= 0) MessageBox.Show("No hay datos en la tabla");

            for (int i = 0; i < table.Rows.Count; i++)
            {
                grid_pasajeros.Rows.Add();

                grid_pasajeros.Rows[i].Cells[0].Value = $"{table.Rows[i]["tipoDoc"]}";
                grid_pasajeros.Rows[i].Cells[1].Value = $"{table.Rows[i]["numeroDoc"]}";
                grid_pasajeros.Rows[i].Cells[2].Value = $"{table.Rows[i]["nombre"]}";
                grid_pasajeros.Rows[i].Cells[3].Value = $"{table.Rows[i]["apellido"]}";
            }
        }
    }
}
