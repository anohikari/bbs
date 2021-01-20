using System;
using System.Collections.Generic;
using System.Text;

namespace bbs
{
    class A1
    {
        //static double zinssatz, kapital;//globale Variablen
        //static int tage;
        static double verzinsen(double _k, double _z, int _t)
        {
            double zinsen = _k * _z * _t / 100.0 / 360.0;
            return zinsen;
        }
        public static void A1Main(string[] args)
        {
            Console.Write("Bitte geben Sie das Kapital ein: ");
            double kapital = Convert.ToDouble(Console.ReadLine());
            Console.Write("Bitte geben Sie den Zinssatz ein: ");
            double zinssatz = double.Parse(Console.ReadLine());
            Console.Write("Bitte geben Sie die Tage ein: ");
            int tage = Convert.ToInt16(Console.ReadLine());
            ;
            Console.WriteLine("Wenn Sie {0,8:f2} Euro zu {1,5:f2}% für {2} Tage anlegen, \n" +
                "erhalten Sie {3,8:f2} Euro Zinsen.", kapital, zinssatz, tage, verzinsen(kapital, zinssatz, tage));
            Console.ReadKey();
        }

    }

    class A2
    {
        //globale Variablen
        static double zinssatz, kapital;
        static int tage;
        //Methoden
        static double berechneZinsen()
        {
            return kapital * zinssatz * tage / 100 / 360;
        }
        public static void A2Main(string[] args)
        {
            Console.WriteLine("Zinsberechnung A2\n");
            Console.Write("Bitte geben Sie das Kapital ein: ");
            kapital = double.Parse(Console.ReadLine());
            Console.Write("Bitte geben Sie den Zinssatz ein: ");
            zinssatz = double.Parse(Console.ReadLine());
            Console.Write("Bitte geben Sie die Dauer in Tagen ein: ");
            tage = int.Parse(Console.ReadLine());
            Console.WriteLine("Wenn Sie {0:f2} Euro bei {1:f2}% für {2} Tage anlegen,\n" +
                "erhalten Sie {3:f2} Euro Zinsen", kapital, zinssatz, tage, berechneZinsen());
            Console.WriteLine(3 / 4);
            Console.ReadKey();

        }
    }
    class A3
    {
        private static int calculateDays(int year)
        {
            var days = 0;
            if (year % 4 == 0)
            {
                if (year % 100 == 0)
                {
                    if (year % 400 == 0)
                    {
                        days = 29;
                    }
                    else
                    {
                        days = 28;
                    }
                }
                else
                {
                    days = 29;
                }
            }
            else
            {
                days = 28;
            }
            return days;
        }
        public static void A3Main(string[] args)
        {
            Console.Write("Enter year: ");
            var year = int.Parse(Console.ReadLine());
            var days = calculateDays(year);
            Console.WriteLine("February in year" + year + "has" + days  + "days");
            Console.ReadKey();

        }
    }

    class ABWPROZ
    {
        private double PreviousYearMittel = 0;
        private double Average;
        private List<(int menge, double price)> PreisMengen = new List<(int menge, double price)>();
        
        public void A4Main()
        {
            Input();
            Calc();
            Console.WriteLine(PreviousYearMittel / Average);
        }

        private void Input()
        {
            Console.WriteLine("Voriges mittel?");
            PreviousYearMittel = double.Parse(Console.ReadLine());
            while (true)
            {
                Console.WriteLine("Menge?:");
                var Menge = int.Parse(Console.ReadLine());
                if (Menge == 0)
                    break;
                Console.WriteLine("Preis");
                var Preis = double.Parse(Console.ReadLine());
                PreisMengen.Add((Menge, Preis));
            }
        }

        private void Calc()
        {
            var total = 0;
            double totalprice = 0;
            foreach (var item in PreisMengen)
            {
                total += item.menge;
                totalprice += item.price;
            }
            Average = Round(totalprice / total);
        }

        private double Round(double d)
        {
            return Math.Round(d, 2);
        }
    }

    unsafe class A5
    {
        //Methoden
        static double berechneZinsen(double* kapital, double* zinssatz, int* tage)
        {
            return *kapital * *zinssatz * *tage / 100 / 360;
        }
        public static void A2Main(string[] args)
        {
            Console.WriteLine("Zinsberechnung A2\n");
            Console.Write("Bitte geben Sie das Kapital ein: ");
            var kapital = double.Parse(Console.ReadLine());
            Console.Write("Bitte geben Sie den Zinssatz ein: ");
            double zinssatz = double.Parse(Console.ReadLine());
            Console.Write("Bitte geben Sie die Dauer in Tagen ein: ");
            int tage = int.Parse(Console.ReadLine());
            Console.WriteLine("Wenn Sie {0:f2} Euro bei {1:f2}% für {2} Tage anlegen,\n" +
                "erhalten Sie {3:f2} Euro Zinsen", kapital, zinssatz, tage, berechneZinsen(&kapital, &zinssatz,&tage));
            Console.WriteLine(3 / 4);
            Console.ReadKey();

        }
    }

    class A6
    {
        private int Anzahlkartons = 0;
        private int Kilometer = 0;
        private double gewicht;
        private double berechnetesgewicht;
        private double fracht = 0;
        private double Netto = 0;
        private double Brutto = 0;
        private double Rabatt = 0;
        private double Resultatspreis = 0;

        private bool cont = true;

        public void Main()
        {
            while (true)
            {
                Input();
                if (!cont)
                {
                    return;
                }
                Calculate();
                Output();
            }
        }

        private void Input()
        {
            Console.WriteLine("Anzahl kartons?");
            Anzahlkartons = int.Parse(Console.ReadLine());
            if(Anzahlkartons == 0)
            {
                cont = false;
                return;
            }
            Console.WriteLine("Kilometer?");
            Kilometer = int.Parse(Console.ReadLine());
        }

        private void Calculate()
        {
            gewicht = Anzahlkartons * productspecifications.weight;
            berechnetesgewicht = ((int)(gewicht / 100)) * 100 + 100;
            fracht = ((int)(berechnetesgewicht / 100)) * Kilometer * 0.06;
            Netto = Anzahlkartons * productspecifications.price;
            Brutto = Netto + fracht;
            if(Brutto < 10000)
            {
                Rabatt = Netto * 0.03;
            }
            else if(Brutto < 50000)
            {
                Rabatt = Netto * 0.05;
            }
            else
            {
                Rabatt = Netto * 0.07;
            }
            Resultatspreis = Brutto - Rabatt;
        }

        private void Output()
        {
            Console.WriteLine(Resultatspreis);
        }


        private static class productspecifications
        {
            public static double price = 7.85;
            public static int amount = 12;
            public static double weight = 24; // kg
        }

    }

    

}
