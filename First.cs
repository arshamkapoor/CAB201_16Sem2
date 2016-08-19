using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First {
	/*
	Calculates fuel consumption in l/100km and the equivalent mpg,
	input units of measurement are litres (l) for the fuel used and
	kilometres (km) for the distance traveled
	
	Author Arsham Kapoor, 8561231
	Date: August 2016
	
	*/
    class Program {

        static void Main() {
			double fuel = 0.0;
			double dist = 0.0;
			double fCons = 0.0;
			string response;
            WelcomeMessage();
			fuel = InputFuel();
			dist = InputDist(fuel);
			fCons = ConsumptionCalc(fuel, dist);
			OutputResult(fCons);
			DisplayMenu();
			response = UserInput();
			RepeatProgram(response);
        }//end Main

        static void WelcomeMessage() {
            Console.WriteLine("\n\n\tFuel Consumption Calculator Conversion\n\n");
        }//end WelcomeMessage
		
		static double InputFuel() {
			double aFuel; string fValue; bool badValue = true;
			
			do {
				Console.Write("\nEnter amount of fuel used in litres: ");
				fValue = Console.ReadLine();
				if ((double.TryParse(fValue, out aFuel)) && (aFuel >= 20)) {
					badValue = false;
				} else {
					Console.WriteLine("\n {0} is below the minimum value of 20. \n\nPlease re-enter a number greater than or equal to 20.", fValue);
				}
			}while ((badValue) || (aFuel < 20));
			Console.WriteLine("\nYou input {0} litres", aFuel);
			return aFuel;
		}//end InputFuel
		
		static double InputDist(double aFuel) {
			double aDist; double rDist = 0.0; string fValue; bool badValue = true;
			rDist = aFuel * 8;
			do {
				Console.Write("\nEnter distance traveled in km greater than or equal to {0}: ", rDist);
				fValue = Console.ReadLine();
				if ((double.TryParse(fValue, out aDist)) && (aDist >= rDist)) {
					badValue = false;
				} else {
					Console.WriteLine("\n {0} is below the minimum value of {1}. \n\nPlease re-enter a number greater than or equal to {1}. ",fValue, rDist);
				}
			}while ((badValue) || (aDist < (aFuel*8)));
			Console.WriteLine("\nYou input {0} km\n", aDist);
			return aDist;
		}//end InputDist
		
		static double ConsumptionCalc(double aFuel, double aDist) {
			return Math.Round((aFuel/(aDist/100)),2);
		}

        static void OutputResult(double fCons) {
			double fMpg = 0.0;
			double kmlToMpg = 282.48;
			fMpg = Math.Round((kmlToMpg / fCons),2);
			Console.WriteLine("Your fuel consumption is {0} l/100km, \nwhich is equilivant to {1} mpg", fCons, fMpg);
        }//end OutputResult
		
		static void DisplayMenu() {
			string menu = "\n\nAnother calculation (Y/N)?: ";
			Console.Write(menu);
		}//end DisplayMenu
		
		static string UserInput() {
			string answer;
			answer = Console.ReadLine();
			return answer;
		}
		
		static void ExitProgram() {
		Console.Write("\n\nPress any key to exit.");
		Console.ReadLine();
		}
		
		static void RepeatProgram(string answer){
		if (answer == "Y" || answer == "y") {
		Main();
		} else {
		ExitProgram();
		}
		}
    }
}
