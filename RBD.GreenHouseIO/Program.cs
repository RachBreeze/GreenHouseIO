using Iot.Device.Tm1637;
using System;
using System.Diagnostics;
using System.Threading;

namespace RBD.GreenHouseIO
{
    public class Program
    {
        public static void Main()
        {
            Tm1637 tm1637 = new Tm1637(2,4);
            tm1637.ScreenOn = true;
            tm1637.Brightness = 7;
            tm1637.ClearDisplay();

            Character[] toDisplay = new Character[4] {
    Character.Digit4,
    Character.Digit2 | Character.Dot,
    Character.Digit3,
    Character.Digit8
};
            tm1637.Display(toDisplay);

            Thread.Sleep(Timeout.Infinite);

            // Browse our samples repository: https://github.com/nanoframework/samples
            // Check our documentation online: https://docs.nanoframework.net/
            // Join our lively Discord community: https://discord.gg/gCyBu8T
        }
    }
}
