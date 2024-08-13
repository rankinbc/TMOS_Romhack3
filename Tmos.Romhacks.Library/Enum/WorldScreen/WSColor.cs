using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tmos.Romhacks.Library.Enum.WorldScreen
{
	public class WSColor
	{
		public static Color GetColor(byte wsColorValue)
		{

				Color gr;
				switch (wsColorValue.ToString("X2"))
				{
					case "21":
					case "2A":
					case "32":
					case "45":
						gr = Color.FromArgb(255, 0, 60, 20);        //past
						break;
					case "30":
					//  case "38":
					case "3B":
						// gr = Color.FromArgb(255, 36, 24, 140);
						gr = Color.FromArgb(255, 0, 112, 236);      //water
						break;
					case "25":
					case "41":
					case "47":
						gr = Color.FromArgb(255, 252, 228, 160);    //desert
						break;
					case "1A":
						gr = Color.FromArgb(255, 0, 80, 0);         //Dark palace
						break;
					case "3C":
					case "31":
						//case "34":
						gr = Color.FromArgb(255, 164, 0, 0);        //red
						break;
					case "23":
					case "2B":
					case "39":
						gr = Color.FromArgb(255, 188, 188, 188);    //winter
						break;
					/*  case "1B":
						  gr = Color.FromArgb(255, 60, 188, 252);     //ice
						  break;*/
					case "11":
					case "27":
					case "43":
					case "44":
					case "4A":
					case "34":
					case "1F":
					case "20":
						gr = Color.FromArgb(255, 0, 0, 0);          //black
						break;
					case "1C":
					//case "27":
					//case "31":
					//case "34":
					//case "44":
					case "46":
					case "48":
						gr = Color.FromArgb(255, 216, 40, 0);       //lava
						break;
					/* case "1D":
						 gr = Color.FromArgb(255, 68, 0, 156);       //Sabaron's palace
						 break;*/
					default:
						gr = Color.FromArgb(255, 0, 148, 0);
						// Console.WriteLine(ws.WorldScreenColor);
						break;
				}
				return gr;
			}
		
	}
}
