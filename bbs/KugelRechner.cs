using System;
using System.Collections.Generic;
using System.Text;

namespace bbs
{
    class KugelRechner
    {
        private double Durchmesser;
        private Materialien Material;
        private enum Materialien
        {
            Holz = 0,
            Alu = 1,
            Glas = 2,
            Eisen = 3,
            Blei = 4
        }
        Dictionary<Materialien, double> Gewichte =
            new Dictionary<Materialien, double>()
            {
                {Materialien.Holz, 1.4 },
                {Materialien.Alu, 2.7 },
                {Materialien.Glas, 3.0 },
                {Materialien.Eisen, 7.8 },
                {Materialien.Blei, 11.3 },
            };

        public void Main()
        {
            Input();
            Console.WriteLine("Mit Rückgabewert: " + Calculate());
            double result = 0;
            Calculate(ref result);
            Console.WriteLine("Mit Referenz: " + result);
            Output();
        }

        private void Input()
        {
            Console.WriteLine("Durchmesser ?:");
            var DurchmesserInput = Console.ReadLine();
            Console.WriteLine("Type ?:");
            var MaterialInput = Console.ReadLine();
            try
            {
                Durchmesser = Double.Parse(DurchmesserInput);
                Material = int.Parse(MaterialInput) switch
                {
                    0 => Materialien.Holz,
                    1 => Materialien.Alu,
                    2 => Materialien.Glas,
                    3 => Materialien.Eisen,
                    4 => Materialien.Blei,
                };
            }
            catch
            {
                Console.WriteLine("ya dun goofed");
            }
        }

        private double Calculate()
        {
            return Gewichte[Material] * (2d / 3d) * Math.PI * Durchmesser;
        }

        private void Calculate(ref double result)
        {
            result = Calculate();
        }

        private void Output()
        {
            Console.WriteLine("Ohne Rückgabewert" + Calculate());
        }

    }
}
