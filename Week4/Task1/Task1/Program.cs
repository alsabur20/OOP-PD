using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.BL;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = new List<Ship>();
            char option;
            do
            {
                Console.Clear();
                option = Menu();
                if (option == '1')
                {
                    Console.Clear();
                    Ship s = AddShip();
                    ships.Add(s);
                }
                else if (option == '2')
                {
                    Console.Clear();
                    Console.Write("Enter Ship Number: ");
                    string number = Console.ReadLine();
                    SearchShipByNumber(number, ships).printLocation();
                    Console.ReadKey();
                }
                else if (option == '3')
                {
                    Console.Write("Enter Latitude: ");
                    string lat = Console.ReadLine();
                    Console.Write("Enter Longitude: ");
                    string lon = Console.ReadLine();
                    SearchByPosition(lat, lon, ships).printSerialNumber();
                    Console.ReadKey();
                }
                else if (option == '4')
                {
                    Console.Write("Enter Ship Number whose position you want to change: ");
                    string number = Console.ReadLine();
                    Ship s = SearchShipByNumber(number,ships);
                    Console.WriteLine("Enter Latitude Position: ");
                    Console.Write("Enter Latitude's Degree: ");
                    int latDegree = int.Parse(Console.ReadLine());
                    while (true)
                    {
                        if (latDegree < 0 || latDegree > 90)
                        {
                            Console.WriteLine("Invalid Input");
                            Console.Write("Enter Latitude's Degree: ");
                            latDegree = int.Parse(Console.ReadLine());
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.Write("Enter Latitude's Minutes: ");
                    float latMinutes = float.Parse(Console.ReadLine());
                    while (true)
                    {
                        if (latMinutes < 0 || latMinutes > 60)
                        {
                            Console.WriteLine("Invalid Input");
                            Console.Write("Enter Latitude's Minutes: ");
                            latMinutes = float.Parse(Console.ReadLine());
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.Write("Enter Latitude’s Direction: ");
                    char latDirection = char.Parse(Console.ReadLine());
                    while (true)
                    {
                        if (latDirection == 'N' || latDirection == 'S')
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            Console.Write("Enter Latitude’s Direction: ");
                            latDirection = char.Parse(Console.ReadLine());
                        }
                    }


                    Console.WriteLine("Enter Longitude Position: ");
                    Console.Write("Enter Longitude's Degree: ");
                    int lonDegree = int.Parse(Console.ReadLine());
                    while (true)
                    {
                        if (lonDegree < 0 || lonDegree > 180)
                        {
                            Console.WriteLine("Invalid Input");
                            Console.Write("Enter Longitude's Degree: ");
                            lonDegree = int.Parse(Console.ReadLine());
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.Write("Enter Longitude's Minutes: ");
                    float lonMinutes = float.Parse(Console.ReadLine());
                    while (true)
                    {
                        if (lonMinutes < 0 || lonMinutes > 60)
                        {
                            Console.WriteLine("Invalid Input");
                            Console.Write("Enter Longitude's Minutes: ");
                            lonMinutes = float.Parse(Console.ReadLine());
                        }
                        else
                        {
                            break;
                        }
                    }
                    Console.Write("Enter Longitude’s Direction: ");
                    char lonDirection = char.Parse(Console.ReadLine());
                    while (true)
                    {
                        if (lonDirection == 'E' || lonDirection == 'W')
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input");
                            Console.Write("Enter Longitude’s Direction: ");
                            lonDirection = char.Parse(Console.ReadLine());
                        }
                    }
                    Angle latitude = new Angle(latDegree, latMinutes, latDirection);
                    Angle longitude = new Angle(lonDegree, lonMinutes, lonDirection);
                    s.latitude = latitude;
                    s.longitude = longitude;
                    Console.WriteLine("Position Changed Successfully!!!");
                    Console.ReadKey();
                }
            }
            while (option != '5');
            Console.ReadKey();
        }
        static char Menu()
        {
            Console.WriteLine("1. Add Ship");
            Console.WriteLine("2. View Ship Position");
            Console.WriteLine("3. View Ship Serial Number");
            Console.WriteLine("4. Change Ship Position");
            Console.WriteLine("5. Exit");
            Console.Write("Enter Choice: ");
            char option = char.Parse(Console.ReadLine());
            return option;
        }
        static Ship AddShip()
        {
            Console.Write("Enter Ship Number: ");
            string number = Console.ReadLine();
            Console.WriteLine("Enter Latitude Position: ");
            Console.Write("Enter Latitude's Degree: ");
            int latDegree = int.Parse(Console.ReadLine());
            while (true)
            {
                if (latDegree < 0 || latDegree > 90)
                {
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Latitude's Degree: ");
                    latDegree = int.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            Console.Write("Enter Latitude's Minutes: ");
            float latMinutes = float.Parse(Console.ReadLine());
            while (true)
            {
                if (latMinutes < 0 || latMinutes > 60)
                {
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Latitude's Minutes: ");
                    latMinutes = float.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            Console.Write("Enter Latitude’s Direction: ");
            char latDirection = char.Parse(Console.ReadLine());
            while (true)
            {
                if (latDirection == 'N' || latDirection == 'S')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Latitude’s Direction: ");
                    latDirection = char.Parse(Console.ReadLine());
                }
            }


            Console.WriteLine("Enter Longitude Position: ");
            Console.Write("Enter Longitude's Degree: ");
            int lonDegree = int.Parse(Console.ReadLine());
            while (true)
            {
                if (lonDegree < 0 || lonDegree > 180)
                {
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Longitude's Degree: ");
                    lonDegree = int.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            Console.Write("Enter Longitude's Minutes: ");
            float lonMinutes = float.Parse(Console.ReadLine());
            while (true)
            {
                if (lonMinutes < 0 || lonMinutes > 60)
                {
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Longitude's Minutes: ");
                    lonMinutes = float.Parse(Console.ReadLine());
                }
                else
                {
                    break;
                }
            }
            Console.Write("Enter Longitude’s Direction: ");
            char lonDirection = char.Parse(Console.ReadLine());
            while (true)
            {
                if (lonDirection == 'E' || lonDirection == 'W')
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.Write("Enter Longitude’s Direction: ");
                    lonDirection = char.Parse(Console.ReadLine());
                }
            }
            Angle latitude = new Angle(latDegree, latMinutes, latDirection);
            Angle longitude = new Angle(lonDegree, lonMinutes, lonDirection);
            Ship s1 = new Ship(number, latitude, longitude);
            return s1;
        }
        static Ship SearchShipByNumber(string number, List<Ship> ships)
        {
            foreach (Ship x in ships)
            {
                if (x.number == number)
                {
                    return x;
                }
            }
            return null;
        }
        static Ship SearchByPosition(string latitude, string longitude, List<Ship> ships)
        {
            foreach (Ship x in ships)
            {
                if (latitude == x.latitude.returnAngle() && longitude == x.longitude.returnAngle())
                {
                    return x;
                }
            }
            return null;
        }
       
    }
}
