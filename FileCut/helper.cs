using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCut;

internal static class helper
{
    public static double KilobytesToBytes(double input) => (input * 1024f);
    public static double MegabytesToBytes(double input) => ((input * 1024f) * 1024f);
    public static double GigabytesToBytes(double input) => (((input * 1024f) * 1024f) * 1024F);
    public static double TerabytesToBytes(double input) => ((((input * 1024f) * 1024f) * 1024F) * 1024F);

    public static double BytesToTerabytes(double bytes) => ((((bytes / 1024f) / 1024f) / 1024f) / 1024f);
    public static double BytesToGigabytes(double bytes) => (((bytes / 1024f) / 1024f) / 1024f);
    public static double BytesToMegabytes(double bytes) => ((bytes / 1024f) / 1024f);
    public static double BytesToKilobytes(double bytes) => (bytes / 1024f);

    public static string BytesToPrettyString(object Size) => ConvertBytesToPrettyString((float)Convert.ToDouble(Size));
    public static string BytesToPrettyString(double Size) => ConvertBytesToPrettyString((float)Size);
    public static string BytesToPrettyString(float Size) => ConvertBytesToPrettyString(Size);
    public static string BytesToPrettyString(int Size) => ConvertBytesToPrettyString(Size);

    internal static string ConvertBytesToPrettyString(float Size, int count = 0)
    {
        float F = Size / 1024f;
        if (F < 1)
        {
            switch (count)
            {
                case 0:
                    return $"{Size:0.00} byte";
                case 1:
                    return $"{Size:0.00} kb";
                case 2:
                    return $"{Size:0.00} mb";
                case 3:
                    return $"{Size:0.00} gb";
                case 4:
                    return $"{Size:0.00} tb";
                case 5:
                    return $"{Size:0.00} pb";
                case 6:
                    return $"{Size:0.00} eb";
                case 7:
                    return $"{Size:0.00} zb";
                case 8:
                    return $"{Size:0.00} yb";
            }
        }
        return ConvertBytesToPrettyString(F, ++count);
    }
}
