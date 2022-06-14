using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    public static class Program
    {
        public static Color[] MapMajor;
        public static Color[] MapMinor;

        static Program()
        {
            MapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            MapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }

        private static void Main(string[] args)
        {
            IColourPairTest colourPairTest = new ColourPairTest(MapMajor, MapMinor);
            IProgramHelpers programHelpers = new ProgramHelpers(MapMajor, MapMinor);

            colourPairTest.TestColourPairCombination();
            programHelpers.PrintColorCoding();
        }
    }
}
