using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Interfaz_P4
{
    public partial class Form1 : Form
    {

        SerialPort mySerialPort = new SerialPort()
        {
            BaudRate = 9600,
            Parity = Parity.None,
            StopBits = StopBits.One,
            DataBits = 8,
            Handshake = Handshake.None,
            RtsEnable = true,
            DtrEnable = true
        };
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] puertos = SerialPort.GetPortNames();
            cbPuertos.Items.AddRange(puertos);
            cbPuertos.SelectedIndex = 0;
            btnCerrar.Enabled = false;

        }

        private void txtDatos_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            btnAbrir.Enabled = false;
            btnCerrar.Enabled = true;
            try
            {
                mySerialPort.PortName = cbPuertos.Text;
                mySerialPort.Open();
                while (true)
                {
                    txtDatos.Text += $"{mySerialPort.ReadLine()}\n";
                }
                mySerialPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            btnAbrir.Enabled = true;
            btnCerrar.Enabled = false;
            try
            {
                mySerialPort.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtDatos_TextChanged_1(object sender, EventArgs e)
        {
            txtDatos.SelectionStart = txtDatos.Text.Length;
            txtDatos.ScrollToCaret();
        }
    }
}
