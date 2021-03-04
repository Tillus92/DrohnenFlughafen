using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneAirport
{
    class Program
    {
        static void Main(string[] args)
        {
            
            LandingPlattform landingPlattform = new LandingPlattform("plattform1", true);
            Drohne drone = new Drohne("Drone1", true);
            //Hier kannst du die werte umstellen und ausprobieren, gerne kannst du den Code verändern! Have fun!
            AirportManagment airport = new AirportManagment(drone, landingPlattform);
            Console.WriteLine(airport.Landung());
            Console.ReadLine();


        }
    }


    class AirportManagment
    {
        public string Name { get; set; }
        public AirportManagment(Drohne drone, LandingPlattform landeplatz)
        {
            this.drohne = drone;
            this.landeplatz = landeplatz;
        }


        public Drohne drohne;
        public LandingPlattform landeplatz;
        public string Landung()
        {
            if (drohne.Active && landeplatz.Used)
            {
                return $"Die landung ist nicht möglich, da {landeplatz.Landeplatz} gerade in benutzung ist";
            }
            else if (drohne.Active && !landeplatz.Used)
            {
                drohne.Active = false;
                landeplatz.Used = true;
                return drohne.ToString() + " " + landeplatz.ToString();
            }
            return "";
        }

    }
    class LandingPlattform
    {
        public string Landeplatz { get; set; }
        public bool Used { get; set; }

        public LandingPlattform(string landeplatz, bool used)
        {
            this.Landeplatz = landeplatz;
            this.Used = used;
        }

        public override string ToString()
        {
            return Used ? $"{Landeplatz} ist belegt" : $"Landeplatz Nr: {Landeplatz}  ist frei und bereit, für die Landung einer Drohen";
        }
    }
    class Drohne
    {
        //Konstruktor
        public Drohne(string name, bool active)
        {
            this.Name = name;
            this.Active = active;
        }

        //Attribute und Methoden
        public string Name { get; set; }
        public bool Active { get; set; }

        public override string ToString()
        {

            return Active ? $"Die Drohne {Name} ist am Fliegen" : $"Die Drohne {Name} ist am fliegen";

        }


    }
}
