using Iot.Device.Tm1637;
using System.Diagnostics;
using System.Threading;

namespace RBD.GreenHouseIO
{
    public class Display
    {
        const int CLOCK_PIN = 2;
        const int DIO_PIN = 4;
        private Tm1637 _display;

        private Character _character1;
        private Character _character2;
        private Character _character3;
        private Character _character4;
        public void Init()
        {
            _display = new Tm1637(CLOCK_PIN, DIO_PIN);
            _display.ScreenOn = true;
            _display.Brightness = 7;
            _display.ClearDisplay();
            _character1 = Character.A;
            _character2 = Character.A;
            _character3 = Character.A;
            _character4 = Character.A;
            DisplayCharacters();
        }
        public void DisplaySoilMouisture(int mouisture)
        {

            if (mouisture>100)
            {
                _character1 = Character.Digit9;
                _character2 = Character.Digit9;
            }
            else if (mouisture<10)
            {
                _character1= Character.Digit0;
                _character2 = CharacterConvetor(mouisture);
            }
            else if (mouisture < 20)
            {
                _character1 = Character.Digit1;
                _character2 = CharacterConvetor(mouisture-10);
            }
            else if (mouisture < 30)
            {
                _character1 = Character.Digit2;
                _character2 = CharacterConvetor(mouisture - 20);
            }
            else if (mouisture < 40)
            {
                _character1 = Character.Digit3;
                _character2 = CharacterConvetor(mouisture - 30);
            }
            else if (mouisture < 50)
            {
                _character1 = Character.Digit4;
                _character2 = CharacterConvetor(mouisture - 40);
            }
            else if (mouisture < 60)
            {
                _character1 = Character.Digit5;
                _character2 = CharacterConvetor(mouisture - 50);
            }
            else if (mouisture < 70)
            {
                _character1 = Character.Digit6;
                _character2 = CharacterConvetor(mouisture - 60);
            }
            else if (mouisture < 80)
            {
                _character1 = Character.Digit7;
                _character2 = CharacterConvetor(mouisture - 70);
            }
            else if (mouisture < 90)
            {
                _character1 = Character.Digit8;
                _character2 = CharacterConvetor(mouisture - 80);
            }
            else
            {
                _character1 = Character.Digit9;
                _character2 = CharacterConvetor(mouisture - 90);
            }

            DisplayCharacters();
        }
        private void DisplayCharacters()
        {
            Character[] toDisplay = new Character[4] {
                _character1,
                _character2 | Character.Dot,
                _character3,
                _character4
            };
            _display.Display(toDisplay);
        }
        private Character CharacterConvetor(int value)
        {
            switch (value)
            {
                case 0:
                    return Character.Digit0;
                case 1:
                    return Character.Digit1;
                case 2:
                    return Character.Digit2;
                case 3:
                    return Character.Digit3;
                case 4:
                    return Character.Digit4;
                case 5:
                    return Character.Digit5;
                case 6:
                    return Character.Digit6;
                case 7:
                    return Character.Digit7;
                case 8:
                    return Character.Digit8;
                case 9:
                    return Character.Digit9;
                default:
                    return Character.Nothing;
            }
        }
    }
}
