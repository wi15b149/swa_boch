using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingDojo1
{

    class Program
    {
        static void Main(string[] args)
        {

            do
            {
                Console.WriteLine("Select:\n1 Celsius\n2 Fahrenheit\n3 Reamur\n4 Kelvin");
                int input = 0;

                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    break;
                }

                if (input < 1 || input > 4)
                {
                    break;
                }

                Console.Write("Enter value: ");
                float temperature = 0;

                try
                {
                    temperature = float.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    break;
                }

                float celsius = 0;
                float fahrenheit = 0;
                float kelvin = 0;
                float reamur = 0;

                switch (input)
                {
                    case 1:
                        celsius = temperature;
                        break;
                    case 2:
                        celsius = ConvertFahrenheitToCelsius(temperature);
                        break;
                    case 3:
                        celsius = ConvertKelvinToCelsisus(temperature);
                        break;
                    case 4:
                        celsius = ConvertReamurToCelsius(temperature);
                        break;
                        //default:
                        //break;
                }

                fahrenheit = ConvertCelsiusToFahrenheit(celsius);
                kelvin = ConvertCelsiusToKelvin(celsius);
                reamur = ConvertCelsiusToReamur(celsius);

                PrintResult(celsius, fahrenheit, kelvin, reamur);

                Console.Write("Again? y/n: ");

            } while (Console.ReadLine() == "y");



        }

        private static float ConvertCelsiusToFahrenheit(float c)
        {
            return c * 1.8f + 32;
        }

        private static float ConvertCelsiusToKelvin(float c)
        {
            return c + 273.15f;
        }

        private static float ConvertCelsiusToReamur(float c)
        {
            return c * 0.8f;
        }

        private static float ConvertFahrenheitToCelsius(float f)
        {
            return (f - 32) * (5f / 9f);
        }

        private static float ConvertKelvinToCelsisus(float k)
        {
            return k - 273.15f;
        }

        private static float ConvertReamurToCelsius(float r)
        {
            return r * 1.25f;
        }

        private static void PrintResult(float celsius, float fahrenheit, float kelvin, float reamur)
        {
            Console.WriteLine("Results");
            Console.WriteLine("{0} Celsius", celsius);
            Console.WriteLine("{0} Fahrenheit", fahrenheit);
            Console.WriteLine("{0} Kelvin", kelvin);
            Console.WriteLine("{0} Reamur\n", reamur);
        }
    }
}
