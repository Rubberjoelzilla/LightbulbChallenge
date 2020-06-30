using System;
using System.Dynamic;

namespace Lightbulbs
{ 
    public class Lightbulb
    {
        public int lightBulbID { get; set; }
        public bool lightbulbOn { get; set; }
        public static int currentBulbID = 0;

        public Lightbulb(int myID, bool lightBulb)
        {
            lightBulbID = myID;
        }

        public static int IncrementBulbID()
        {
            currentBulbID++;
            return currentBulbID;
        }
    }

    class Program
    {
        private static bool lightSwitchOnState = false;

        static void Main(string[] args)
        {
            Lightbulb lightBulb1 = new Lightbulb(Lightbulb.IncrementBulbID(), false);
            Lightbulb lightBulb2 = new Lightbulb(Lightbulb.IncrementBulbID(), false);
            Lightbulb lightBulb3 = new Lightbulb(Lightbulb.IncrementBulbID(), false);

            Lightbulb[] roomBulbs = new Lightbulb[3] { lightBulb1, lightBulb2, lightBulb3 };

            Console.WriteLine("Press any key to start the application");
            CheckUserInput(roomBulbs);  
    }


        public static void TurnOnLightSwitch(Lightbulb[] bulbs)
        {
            Console.Clear();

            lightSwitchOnState = true;

            Random randomNumber = new Random();
          
            int bulbToTurnOn = randomNumber.Next(1, bulbs.Length +1);

            foreach (Lightbulb bulb in bulbs)
            {
                if(bulb.lightBulbID == bulbToTurnOn)
                {
                    bulb.lightbulbOn = true;
                    Console.WriteLine("Lightbulb {0} has turned on" , bulb.lightBulbID);
                }
            }

            Console.WriteLine("Press any key to turn the light on or press E to exit");
            CheckUserInput(bulbs);
        }

        public static void TurnOffLightSwitch(Lightbulb[] bulbs)
        {
            Console.Clear();
            lightSwitchOnState = false;

            foreach (Lightbulb bulb in bulbs)
            {
                if(bulb.lightbulbOn == true)
                {
                    bulb.lightbulbOn = false;
                    Console.WriteLine("Lightbulb {0} has turned off", bulb.lightBulbID);
                }
            }

            Console.WriteLine("Press any key to turn the light off or press E to exit");
            CheckUserInput(bulbs);
        }

        private static void CheckUserInput(Lightbulb[] bulbs)
        {
            string userInput = Console.ReadLine();
            if(userInput == "e" || userInput == "E")
            {
                return;
            }
            else if(lightSwitchOnState == false)
            {
                TurnOnLightSwitch(bulbs);
            }
            else
            {
                TurnOffLightSwitch(bulbs);
            }
        }
    }

}
