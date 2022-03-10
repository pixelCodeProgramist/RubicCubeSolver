using RubicCube.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RubicCube.Business.LoggerPackage
{
    class Logger
    {
        public static int counter= 0;
        public Dictionary<Color, Side> rubicCubeSides { get; set; }

        public Logger(Dictionary<Color, Side> rubicCubeSides)
        {
            this.rubicCubeSides = rubicCubeSides;
        }

        public void display()
        {
            System.Diagnostics.Debug.WriteLine("ITERACJA: " + counter);
            System.Diagnostics.Debug.WriteLine("                         |       " + String.Join("  ", rubicCubeSides[Color.WHITE].fields[0]));
            System.Diagnostics.Debug.WriteLine("                         |       " + String.Join("  ", rubicCubeSides[Color.WHITE].fields[1]));
            System.Diagnostics.Debug.WriteLine("                         |       " + String.Join("  ", rubicCubeSides[Color.WHITE].fields[2]));
            System.Diagnostics.Debug.WriteLine("--------------------------------------------------------------------------------------------------------");
            System.Diagnostics.Debug.WriteLine(String.Join("  ", rubicCubeSides[Color.ORANGE].fields[0]) + "|        " + String.Join("  ", rubicCubeSides[Color.GREEN].fields[0]) + "|       " + String.Join("  ", rubicCubeSides[Color.RED].fields[0]) + "|       " + String.Join("  ", rubicCubeSides[Color.BLUE].fields[0]) + "|       ");
            System.Diagnostics.Debug.WriteLine(String.Join("  ", rubicCubeSides[Color.ORANGE].fields[1]) + "|        " + String.Join("  ", rubicCubeSides[Color.GREEN].fields[1]) + "|       " + String.Join("  ", rubicCubeSides[Color.RED].fields[1]) + "|       " + String.Join("  ", rubicCubeSides[Color.BLUE].fields[1]) + "|       ");
            System.Diagnostics.Debug.WriteLine(String.Join("  ", rubicCubeSides[Color.ORANGE].fields[2]) + "|        " + String.Join("  ", rubicCubeSides[Color.GREEN].fields[2]) + "|       " + String.Join("  ", rubicCubeSides[Color.RED].fields[2]) + "|       " + String.Join("  ", rubicCubeSides[Color.BLUE].fields[2]) + "|       ");
            System.Diagnostics.Debug.WriteLine("--------------------------------------------------------------------------------------------------------");
            System.Diagnostics.Debug.WriteLine("                         |       " + String.Join("  ", rubicCubeSides[Color.YELLOW].fields[0]));
            System.Diagnostics.Debug.WriteLine("                         |       " + String.Join("  ", rubicCubeSides[Color.YELLOW].fields[1]));
            System.Diagnostics.Debug.WriteLine("                         |       " + String.Join("  ", rubicCubeSides[Color.YELLOW].fields[2]));
            System.Diagnostics.Debug.WriteLine("--------------------------------------------------------------------------------------------------------");
            System.Diagnostics.Debug.WriteLine("--------------------------------------------------------------------------------------------------------");
            counter++;
        }
    }
}
