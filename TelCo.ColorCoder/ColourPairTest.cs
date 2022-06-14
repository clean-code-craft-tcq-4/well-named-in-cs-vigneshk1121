using System;
using System.Diagnostics;
using System.Drawing;

namespace TelCo.ColorCoder
{
    public interface IColourPairTest
    {
        void TestColourPairCombination();
    }
    public class ColourPairTest: IColourPairTest
    {
        public Color[] MapMajor;

        public Color[] MapMinor;

        public ColourPairTest(Color[] mapMajor, Color[] mapMinor)
        {
            MapMajor = mapMajor;
            MapMinor = mapMinor;
        }

        public void TestColourPairCombination()
        {
            IProgramHelpers programHelpers = new ProgramHelpers(MapMajor, MapMinor);

            int pairNumber = 4;
            ColorPair testPair1 = programHelpers.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.White);
            Debug.Assert(testPair1.minorColor == Color.Brown);

            pairNumber = 5;
            testPair1 = programHelpers.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.White);
            Debug.Assert(testPair1.minorColor == Color.SlateGray);

            pairNumber = 23;
            testPair1 = programHelpers.GetColorFromPairNumber(pairNumber);
            Console.WriteLine("[In]Pair Number: {0},[Out] Colors: {1}\n", pairNumber, testPair1);
            Debug.Assert(testPair1.majorColor == Color.Violet);
            Debug.Assert(testPair1.minorColor == Color.Green);

            ColorPair testPair2 = new ColorPair() { majorColor = Color.Yellow, minorColor = Color.Green };
            pairNumber = programHelpers.GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair2, pairNumber);
            Debug.Assert(pairNumber == 18);

            testPair2 = new ColorPair() { majorColor = Color.Red, minorColor = Color.Blue };
            pairNumber = programHelpers.GetPairNumberFromColor(testPair2);
            Console.WriteLine("[In]Colors: {0}, [Out] PairNumber: {1}\n", testPair2, pairNumber);
            Debug.Assert(pairNumber == 6);
        }
    }
}
