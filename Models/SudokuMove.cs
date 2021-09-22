using System;
using System.ComponentModel.DataAnnotations;
namespace SudokuMaster.Models
{
    public class SudokuMove 
    {
        [Key]
        public int ID { get; set; }
        public int SudokuPuzzleID { get; set; }
        public int MoveOrder { get; set; }
        public string CellChanged { get; set; }


        public SudokuCell a1 { get; set; }
        public SudokuCell b1 { get; set; }
        public SudokuCell c1 { get; set; }

        public SudokuCell a2 { get; set; }
        public SudokuCell b2 { get; set; }
        public SudokuCell c2 { get; set; }

        public SudokuCell a3 { get; set; }
        public SudokuCell b3 { get; set; }
        public SudokuCell c3 { get; set; }

        public SudokuCell a4 { get; set; }
        public SudokuCell b4 { get; set; }
        public SudokuCell c4 { get; set; }

        public SudokuCell a5 { get; set; }
        public SudokuCell b5 { get; set; }
        public SudokuCell c5 { get; set; }

        public SudokuCell a6 { get; set; }
        public SudokuCell b6 { get; set; }
        public SudokuCell c6 { get; set; }

        public SudokuCell a7 { get; set; }
        public SudokuCell b7 { get; set; }
        public SudokuCell c7 { get; set; }

        public SudokuCell a8 { get; set; }
        public SudokuCell b8 { get; set; }
        public SudokuCell c8 { get; set; }

        public SudokuCell a9 { get; set; }
        public SudokuCell b9 { get; set; }
        public SudokuCell c9 { get; set; }

        public SudokuCell d1 { get; set; }
        public SudokuCell e1 { get; set; }
        public SudokuCell f1 { get; set; }

        public SudokuCell d2 { get; set; }
        public SudokuCell e2 { get; set; }
        public SudokuCell f2 { get; set; }

        public SudokuCell d3 { get; set; }
        public SudokuCell e3 { get; set; }
        public SudokuCell f3 { get; set; }

        public SudokuCell d4 { get; set; }
        public SudokuCell e4 { get; set; }
        public SudokuCell f4 { get; set; }

        public SudokuCell d5 { get; set; }
        public SudokuCell e5 { get; set; }
        public SudokuCell f5 { get; set; }

        public SudokuCell d6 { get; set; }
        public SudokuCell e6 { get; set; }
        public SudokuCell f6 { get; set; }

        public SudokuCell d7 { get; set; }
        public SudokuCell e7 { get; set; }
        public SudokuCell f7 { get; set; }

        public SudokuCell d8 { get; set; }
        public SudokuCell e8 { get; set; }
        public SudokuCell f8 { get; set; }

        public SudokuCell d9 { get; set; }
        public SudokuCell e9 { get; set; }
        public SudokuCell f9 { get; set; }

        public SudokuCell g1 { get; set; }
        public SudokuCell h1 { get; set; }
        public SudokuCell i1 { get; set; }

        public SudokuCell g2 { get; set; }
        public SudokuCell h2 { get; set; }
        public SudokuCell i2 { get; set; }

        public SudokuCell g3 { get; set; }
        public SudokuCell h3 { get; set; }
        public SudokuCell i3 { get; set; }

        public SudokuCell g4 { get; set; }
        public SudokuCell h4 { get; set; }
        public SudokuCell i4 { get; set; }

        public SudokuCell g5 { get; set; }
        public SudokuCell h5 { get; set; }
        public SudokuCell i5 { get; set; }

        public SudokuCell g6 { get; set; }
        public SudokuCell h6 { get; set; }
        public SudokuCell i6 { get; set; }

        public SudokuCell g7 { get; set; }
        public SudokuCell h7 { get; set; }
        public SudokuCell i7 { get; set; }

        public SudokuCell g8 { get; set; }
        public SudokuCell h8 { get; set; }
        public SudokuCell i8 { get; set; }

        public SudokuCell g9 { get; set; }
        public SudokuCell h9 { get; set; }
        public SudokuCell i9 { get; set; }

    }
}
