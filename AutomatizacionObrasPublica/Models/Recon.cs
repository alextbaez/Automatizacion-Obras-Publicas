using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatizacionObrasPublica.Models
{
    class Recon
    {
        private string _reconDeviceName;
        private List<string> _placePhoto;
        private List<string> _locations;
        private DateTime _registerDate = new DateTime();

        public Recon(string name)
        {
            _reconDeviceName = name;
            _locations = new List<string>() {"location1", "location2", "location3", "location4", "location5"};
            _placePhoto = new List<string>() {"PuenteRoto.jpg", "AutopistaAgrietada.png", "calleInundada.jpg"};
        }
        public string ReconDeviceName 
        { 
            get { return _reconDeviceName; }
        }

        public List<string> Locations
        {
            get { return _locations; } 
            set { _locations = value; }
        }

        public DateTime RegisterDate
        {
            get { return _registerDate; }
            set { _registerDate = value; }
        }
        public List<string> PlacePhoto
        {
            get { return _placePhoto; }
            set { _placePhoto = value; }
        }

        public void InsertReconInfoIntoBD(Recon reconDev, string connect)
        {
            try
            {
                Random random = new Random();
                SqlConnection con = new SqlConnection(connect);
                con.Open();

                SqlCommand cmd = new SqlCommand("Insert Into recontable Values (@ReconName,@ReconLoc,@ReconPhoto,@RegisterDate)", con);

                cmd.Parameters.AddWithValue("@ReconName", reconDev.ReconDeviceName);
                cmd.Parameters.AddWithValue("@ReconLoc", reconDev.Locations[random.Next(Locations.Count)]);
                cmd.Parameters.AddWithValue("@ReconPhoto", reconDev.PlacePhoto[random.Next(PlacePhoto.Count)]);
                cmd.Parameters.AddWithValue("@RegisterDate", reconDev.RegisterDate);

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
