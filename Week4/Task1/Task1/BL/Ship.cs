using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.BL
{
    class Ship
    {
        public string number;
        public Angle latitude;
        public Angle longitude;
       
        public Ship(string number,Angle latitude,Angle longitude)
        {
            this.number = number;
            this.latitude = latitude;
            this.longitude = longitude;
        }
        public void printLocation()
        {
            Console.WriteLine("Latitude: "+latitude.returnAngle());
            Console.WriteLine("Longitude: "+longitude.returnAngle());
        }
        public void printSerialNumber()
        {
            Console.WriteLine("Ship Number: {0}",this.number);
        }
    }
}
