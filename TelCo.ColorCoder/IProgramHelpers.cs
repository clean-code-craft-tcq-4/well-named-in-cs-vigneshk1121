using System;
using System.Collections.Generic;
using System.Text;

namespace TelCo.ColorCoder
{
    public interface IProgramHelpers
    {
        ColorPair GetColorFromPairNumber(int pairNumber);

        int GetPairNumberFromColor(ColorPair pair);

        void PrintColorCoding();
    }
}
