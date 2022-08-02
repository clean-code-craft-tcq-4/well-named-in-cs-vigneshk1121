using System.Drawing;

namespace TelCo.ColorCoder
{
    public interface IIndex
    {
        int GetIndex(Color color, bool isMajorColor=false);
    }

    public class Index: IIndex
    {
        public static Color[] MapMajor;

        public static Color[] MapMinor;

        public Index(Color[] mapMajor, Color[] mapMinor)
        {
            MapMajor = mapMajor;
            MapMinor = mapMinor;
        }

        public int GetIndex(Color color, bool isMajorColor = false)
        {
            int index = -1;

            Color[] colors = isMajorColor ? MapMajor : MapMinor;

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
