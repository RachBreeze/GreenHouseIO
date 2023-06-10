using Iot.Device.Tm1637;
using System.Diagnostics;
using System.Threading;

namespace RBD.GreenHouseIO
{
    public class Program
    {
       
        public static void Main()
        {
           
            var display=new Display();
            display.Init();
            var soilSensor = new SoilSensor();
            soilSensor.Init();

            display.DisplaySoilMouisture(soilSensor.ReadMoisture());
              // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }
       
    }
}
