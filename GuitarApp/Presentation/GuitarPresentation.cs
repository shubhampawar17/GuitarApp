using GuitarApp.Controller;
using GuitarApp.EnumType;
using GuitarApp.Exceptions;
using GuitarApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuitarApp.Presentation
{
    public class GuitarPresentation
    {
        private GuitarManager _manager;

        public GuitarPresentation(GuitarManager manager)
        {
            this._manager = manager;
        }
        public void ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n--- Guitar Inventory System ---");
                Console.WriteLine("1. Add a new guitar");
                Console.WriteLine("2. Search for a guitar");
                Console.WriteLine("3. Exit");
                Console.Write("Select an option: ");

                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        AddGuitar();
                        break;
                    case 2:
                        SearchGuitar();
                        break;
                    case 3:
                        Console.WriteLine("Exiting...");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        private void AddGuitar()
        {
            try
            {
                Guitar newGuitar = GetGuitarFromUser();
                _manager.AddGuitar(newGuitar);
                Console.WriteLine("Guitar added successfully!");
            }
            catch (InvalidGuitarSpecException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        private void SearchGuitar()
        {
            try
            {
                GuitarSpec searchSpec = GetSearchSpecFromUser();
                List<Guitar> matchingGuitars = _manager.SearchGuitars(searchSpec);
                DisplayMatchingGuitars(matchingGuitars);
            }
            catch (GuitarNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
            }
        }

        private Guitar GetGuitarFromUser()
        {
            Console.Write("Enter Serial Number: ");
            string serialNumber = Console.ReadLine();

            Console.Write("Enter Price: ");
            double price = double.Parse(Console.ReadLine());

            GuitarSpec spec = GetSearchSpecFromUser();

            return new Guitar(serialNumber, price, spec);
        }

        private GuitarSpec GetSearchSpecFromUser()
        {
            Console.Write("Enter Builder (e.g., FENDER, GIBSON): ");
            string builderInput = Console.ReadLine();
            BuilderType builder = (BuilderType)Enum.Parse(typeof(BuilderType), builderInput.ToUpper(), true);

            Console.Write("Enter Model: ");
            string model = Console.ReadLine();

            Console.Write("Enter Type (ACOUSTIC/ELECTRIC): ");
            string typeInput = Console.ReadLine();
            GuitarType type = (GuitarType)Enum.Parse(typeof(GuitarType), typeInput.ToUpper(), true);

            Console.Write("Enter Number of Strings: ");
            int numStrings = int.Parse(Console.ReadLine());

            Console.Write("Enter Back Wood (e.g., MAHOGANY, ALDER): ");
            string backWoodInput = Console.ReadLine();
            WoodType backWood = (WoodType)Enum.Parse(typeof(WoodType), backWoodInput.ToUpper(), true);

            Console.Write("Enter Top Wood (e.g., MAPLE, CEDAR): ");
            string topWoodInput = Console.ReadLine();
            WoodType topWood = (WoodType)Enum.Parse(typeof(WoodType), topWoodInput.ToUpper(), true);

            return new GuitarSpec(builder, model, type, backWood, topWood , numStrings);
        }

        private void DisplayMatchingGuitars(List<Guitar> guitars)
        {
            if (guitars.Count > 0)
            {
                Console.WriteLine("Matching Guitars:");
                foreach (var guitar in guitars)
                {
                    Console.WriteLine($"Serial: {guitar.SerialNumber}, Price: {guitar.Price}");
                }
            }
            else
            {
                Console.WriteLine("No guitars matched your search.");
            }
        }
    }
}