using System;

namespace SudokuMaster.Sudoku_Infrastructure
{
    public static class SudDigit
    {
        public static ISudDigit ConvertSudNumber(string row)
        {
            switch (row)
            {
                case "1":
                    return One();
                case "2":
                    return Two();
                case "3":
                    return Three();
                case "4":
                    return Four();
                case "5":
                    return Five();
                case "6":
                    return Six();
                case "7":
                    return Seven();
                case "8":
                    return Eight();
                case "9":
                    return Nine();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static ISudDigit ConvertSudNumber(int numb)
        {
            switch (numb)
            {
                case 1:
                    return One();
                case 2:
                    return Two();
                case 3:
                    return Three();
                case 4:
                    return Four();
                case 5:
                    return Five();
                case 6:
                    return Six();
                case 7:
                    return Seven();
                case 8:
                    return Eight();
                case 9:
                    return Nine();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static ISudDigit ConvertSudRow(int row)
        {
            switch (row)
            {
                case 0:
                    return One();
                case 1:
                    return Two();
                case 2:
                    return Three();
                case 3:
                    return Four();
                case 4:
                    return Five();
                case 5:
                    return Six();
                case 6:
                    return Seven();
                case 7:
                    return Eight();
                case 8:
                    return Nine();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public static ISudDigit One() => new One();
        public static ISudDigit Two() => new Two();
        public static ISudDigit Three() => new Three();
        public static ISudDigit Four() => new Four();
        public static ISudDigit Five() => new Five();
        public static ISudDigit Six() => new Six();
        public static ISudDigit Seven() => new Seven();
        public static ISudDigit Eight() => new Eight();
        public static ISudDigit Nine() => new Nine();



    }

    public class One : ISudDigit { public string digitNumber { get { return "1"; } } }
    public class Two : ISudDigit { public string digitNumber { get { return "2"; } } }
    public class Three : ISudDigit { public string digitNumber { get { return "3"; } } }
    public class Four : ISudDigit { public string digitNumber { get { return "4"; } } }
    public class Five : ISudDigit { public string digitNumber { get { return "5"; } } }
    public class Six : ISudDigit { public string digitNumber { get { return "6"; } } }
    public class Seven : ISudDigit { public string digitNumber { get { return "7"; } } }
    public class Eight : ISudDigit { public string digitNumber { get { return "8"; } } }
    public class Nine : ISudDigit { public string digitNumber { get { return "9"; } } }
}
