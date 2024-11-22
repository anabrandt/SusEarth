using SusEarth.Models;

namespace SusEarth.Services
{
    public class MetroService
    {
        private readonly List<MetroStation> _stations;

        public MetroService()
        {
            _stations = new List<MetroStation>
            {
                new MetroStation { Name = "Estação Sé", Lat = -23.550520, Lon = -46.633308 },
                new MetroStation { Name = "Estação Paulista", Lat = -23.561584, Lon = -46.656745 },
                new MetroStation { Name = "Estação Liberdade", Lat = -23.681278, Lon = -46.598855 }
                // Adicione mais estações aqui
            };
        }

        public MetroStation FindNearestMetro(double userLat, double userLon)
        {
            MetroStation nearestStation = null;
            double minDistance = double.MaxValue;

            foreach (var station in _stations)
            {
                var distance = Haversine(userLat, userLon, station.Lat, station.Lon);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestStation = station;
                }
            }

            return nearestStation;
        }

        public static double Haversine(double lat1, double lon1, double lat2, double lon2)
        {
            var R = 6371; // Raio da Terra em km
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c; // Distância em km
        }

        private static double ToRadians(double angle)
        {
            return angle * Math.PI / 180;
        }
    }
}
