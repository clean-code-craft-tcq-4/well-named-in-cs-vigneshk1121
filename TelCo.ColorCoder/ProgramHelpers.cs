using System;
using System.Drawing;

namespace TelCo.ColorCoder
{
    public class ProgramHelpers : IProgramHelpers
    {
        public Color[] MapMajor;

        public Color[] MapMinor;

        public ProgramHelpers(Color[] mapMajor, Color[] mapMinor)
        {
            MapMajor = mapMajor;
            MapMinor = mapMinor;
        }

        public ColorPair GetColorFromPairNumber(int pairNumber)
        {
            if (pairNumber < 1 || pairNumber > MapMinor.Length * MapMajor.Length)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }

            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / MapMinor.Length;
            int minorIndex = zeroBasedPairNumber % MapMinor.Length;

            return new ColorPair() { majorColor = MapMajor[majorIndex], minorColor = MapMinor[minorIndex] };
        }

        public int GetPairNumberFromColor(ColorPair pair)
        {
            IIndex index = new Index(MapMajor, MapMinor);
            int majorIndex = index.GetIndex(pair.majorColor, true);
            int minorIndex = index.GetIndex(pair.minorColor);

            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            return (majorIndex * MapMinor.Length) + (minorIndex + 1);
        }
    }
}