using System;
using System.Device.Location;
using System.Text.Json;
using System.TCP;

namespace GetLocationProperty
{
    class Program
    {
        static void Main(string[] args)
        {
            GetLocationProperty();
        }

        static void GetLocationProperty()
        {
            GeoCoordinateWatcher watcher = new GeoCoordinateWatcher();

            // Do not suppress prompt, and wait 1000 milliseconds to start.
            watcher.TryStart(false, TimeSpan.FromMilliseconds(5000));

            GeoCoordinate coord = watcher.Position.Location;

            if (coord.IsUnknown != true)
            {
                Coo = new object("Lat: {0}, Long: {1}",
                    coord.Latitude,
                    coord.Longitude);
                    string json = JsonSerializer.Serialize<Coo>(coord.Latitude, coord.Latitude);
            }
            else
            {
                Console.WriteLine("Unknown latitude and longitude.");
            }
        }
    }
    
    class ClientTRNSKD
    {
        private const int port = 8888;
        private const string server = "314.159.265.1"; // здесь надо вписать адрес вашего сервера
 
        static void Main(string[] args)
        {
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(server, port);
                
                NetworkStream stream = tcpClient.GetStream();
                stream.Write(json, 0);
            }

            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: {0}", e.Message);
            }
        }
    }
}
