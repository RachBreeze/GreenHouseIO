using System.Device.Adc;
using System.Diagnostics;


namespace RBD.GreenHouseIO
{
    public class SoilSensor
    {
        const int Soil_Channel = 0;
        private AdcChannel _soilADC;
        public void Init()
        {
            var adc = new AdcController();
            _soilADC = adc.OpenChannel(Soil_Channel);
        }
        public int ReadMoisture()
        {
            // in the air the value was 2927
            // in dry soil the value was 2653
            const double Dry_Soil = 2927;

            var moisture= (double)_soilADC.ReadValue();

            if (moisture> Dry_Soil)
            {
                return 0;
            }

            if (moisture <= 1)
            {
                return 100;
            }

            return (int)((moisture / Dry_Soil) * 100);
        }
        
    }
}
