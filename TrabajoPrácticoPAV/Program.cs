﻿using System;
using System.Windows.Forms;
using TrabajoPrácticoPAV.Formularios.Listados.EquipajeXPasajero;

namespace TrabajoPrácticoPAV
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Frm_Principal());
            //Application.Run(new Frm_EquipajeXPasajero());
        }
    }
}