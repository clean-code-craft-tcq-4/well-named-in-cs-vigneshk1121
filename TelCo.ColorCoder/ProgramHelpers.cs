using System;
using System.Drawing;

namespace TelCo.ColorCoder
{
    public class ProgramHelpers : IProgramHelpers
    {
        public Color[] MapMajor;

        public Color[] MapMinor;

        public ProgramHelpers()
        {
            MapMajor = new Color[] { Color.White, Color.Red, Color.Black, Color.Yellow, Color.Violet };
            MapMinor = new Color[] { Color.Blue, Color.Orange, Color.Green, Color.Brown, Color.SlateGray };
        }

        public ColorPair GetColorFromPairNumber(int pairNumber)
        {
            int minorSize = MapMinor.Length;
            int majorSize = MapMajor.Length;
            if (pairNumber < 1 || pairNumber > minorSize * majorSize)
            {
                throw new ArgumentOutOfRangeException(
                    string.Format("Argument PairNumber:{0} is outside the allowed range", pairNumber));
            }

            int zeroBasedPairNumber = pairNumber - 1;
            int majorIndex = zeroBasedPairNumber / minorSize;
            int minorIndex = zeroBasedPairNumber % minorSize;

            return new ColorPair() { majorColor = MapMajor[majorIndex], minorColor = MapMinor[minorIndex] };
        }

        public int GetPairNumberFromColor(ColorPair pair)
        {
            int majorIndex = GetIndex(pair.majorColor, true);

            int minorIndex = GetIndex(pair.majorColor);

            if (majorIndex == -1 || minorIndex == -1)
            {
                throw new ArgumentException(
                    string.Format("Unknown Colors: {0}", pair.ToString()));
            }

            return (majorIndex * MapMinor.Length) + (minorIndex + 1);
        }

        public int GetIndex(Color color, bool isMajorColor = true)
        {
            int index = -1;

            Color[] colors = isMajorColor ? MapMajor : MapMajor;

            for (int i = 0; i < colors.Length; i++)
            {
                if (colors[i] == color)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}