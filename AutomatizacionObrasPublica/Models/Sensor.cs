using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AutomatizacionObrasPublica.Models
{
    class Sensor
    {
        private string _sensorName;
        private List<string> _locations;
        private List<double> _percentages;
    

        public Sensor(string name)
        {
            this._percentages = new List<double>() {0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100};
            this._locations = new List<string>() {"https://goo.gl/maps/aQ5qBtHfxz4M7n3Q9",
                "https://goo.gl/maps/fokm48BBvVp9tLKh6"};
            this._sensorName = name;
        }

        public string SensorName
        {
            get { return _sensorName;}
        }

        public List<string> Locations
        {
            get { return _locations; }
        }

        public List<double> Percentages
        {
            get { return _percentages;}
        }

 
        public void InsertSensorInfoIntoBD(string name, string location, double percentage, DateTime registerDate)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=ADMINISTRATOR2\SQLEXPRESS;Initial Catalog=ObrasPublicasDB;Integrated Security=True");
                con.Open();

                SqlCommand cmd = new SqlCommand("Insert Into sensorstable Values (@SenName,@SenLoc,@SenPercent,(" +
                    "CASE " +
                    "WHEN @SenPercent = 100 then 'Excelent' " +
                    "WHEN @SenPercent < 100 AND @SenPercent >= 70 then 'Normal' " +
                    "WHEN @SenPercent <= 60 AND @SenPercent >= 40 then 'Check' " +
                    "ELSE 'Repair' " +
                    "end), @RegisterDate)", con);

                cmd.Parameters.AddWithValue("@SenName", name);
                cmd.Parameters.AddWithValue("@SenLoc", location);
                cmd.Parameters.AddWithValue("@SenPercent", percentage);
                cmd.Parameters.AddWithValue("@RegisterDate", registerDate);

                cmd.ExecuteNonQuery();

                con.Close();

            }
            catch (Exception)
            {

                throw;
            }
            
        }

       
    }
}
