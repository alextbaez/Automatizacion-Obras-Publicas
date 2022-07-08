using AutomatizacionObrasPublica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;

namespace AutomatizacionObrasPublica
{
    public partial class Form1 : Form
    {
       
        Random random = new Random();
        string connection = @"Data Source=.\SQLEXPRESS;Initial Catalog=ObrasPublicasDB;Integrated Security=True";
       
        public Form1()
        {
            InitializeComponent();
            refreshSensDataGrid();
            refreshReconDataGrid();
        }

        private async void buttonDuarte_Click(object sender, EventArgs e)
        {
            Sensor sens1 = new Sensor("SensorDuarte");
            string senName, loc;
            DateTime sens1EventRegisterTime = DateTime.Now;
            senName = sens1.SensorName;
            loc = sens1.Locations[0];  
            for (int i = 0; i < 20; i++)
            {
                
                double percent = sens1.Percentages[random.Next(sens1.Percentages.Count)];
                textBoxDuarte.Text = percent.ToString() + "%";
                sens1.InsertSensorInfoIntoBD(senName, loc, percent, sens1EventRegisterTime, connection);
                sens1EventRegisterTime = sens1EventRegisterTime.AddDays(10);
                await Task.Delay(1000);
                textBoxDuarte.Clear();
                await Task.Delay(500);
                refreshSensDataGrid();
                
            }
        }

        private async void buttonAvFebrero_Click(object sender, EventArgs e)
        {
            Sensor sens2 = new Sensor("Sensor27Febrero");
            string  sen2Name = sens2.SensorName;
            string loc2 = sens2.Locations[1];
            DateTime sens2EventRegisterTime = DateTime.Now;
           

            for (int i = 0; i < 20; i++)
            {
                double percent2 = sens2.Percentages[random.Next(sens2.Percentages.Count)];
                textBoxAvFebrero.Text = percent2.ToString() + "%";
                sens2.InsertSensorInfoIntoBD(sen2Name, loc2, percent2, sens2EventRegisterTime, connection);
                sens2EventRegisterTime = sens2EventRegisterTime.AddDays(10);
                await Task.Delay(1000);
                textBoxAvFebrero.Clear();
                await Task.Delay(500);
                refreshSensDataGrid();
            }
            
        }

        private void buttonRefreshSensData_Click(object sender, EventArgs e)
        {
            refreshSensDataGrid();
        }

        private void refreshSensDataGrid()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("SELECT DEVICE_NAME, PERCENTAGE, STATUS FROM SensorsTable ORDER BY DEVICE_NAME", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private async void buttonSatelite_Click(object sender, EventArgs e)
        {
            Recon sat = new Recon("SateliteAbreu");
        
            DateTime Recon1EventRegisterTime = DateTime.Now;



            for (int i = 0; i < 20; i++)
            {
                sat.RegisterDate = Recon1EventRegisterTime;
                sat.InsertReconInfoIntoBD(sat, connection);
                Recon1EventRegisterTime = Recon1EventRegisterTime.AddDays(10);
                await Task.Delay(1500);
                refreshReconDataGrid();
            }
        }

        public void refreshReconDataGrid()
        {
            SqlConnection con = new SqlConnection(connection);
            SqlCommand cmd = new SqlCommand("SELECT DEVICE_NAME, LOCATION, PHOTO, REGISTER_DATE FROM recontable ORDER BY DEVICE_NAME", con);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void buttonRefreshReconData_Click(object sender, EventArgs e)
        {
            refreshReconDataGrid();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            Recon dron1 = new Recon("DronBani");

            DateTime Recon2EventRegisterTime = DateTime.Now;

            for (int i = 0; i < 20; i++)
            {
                dron1.RegisterDate = Recon2EventRegisterTime;
                dron1.InsertReconInfoIntoBD(dron1, connection);
                Recon2EventRegisterTime = Recon2EventRegisterTime.AddDays(10);
                await Task.Delay(1500);
                refreshReconDataGrid();
            }
        }

        private async void buttonDron2_Click(object sender, EventArgs e)
        {
            Recon dron2 = new Recon("DronAzua");

            DateTime Recon3EventRegisterTime = DateTime.Now;

            for (int i = 0; i < 20; i++)
            {
                dron2.RegisterDate = Recon3EventRegisterTime;
                dron2.InsertReconInfoIntoBD(dron2, connection);
                Recon3EventRegisterTime = Recon3EventRegisterTime.AddDays(10);
                await Task.Delay(1500);
                refreshReconDataGrid();
            }
        }

    }
}
