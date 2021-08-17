using System;
using System.Runtime.Serialization;

namespace SudokuMaster.Models
{
    public class SudokuMove //: ICloneable//: ISerializable//: ICloneable
    {
        public int ID { get; set; }
        public int SudokuPuzzleID { get; set; }
        public int MoveOrder { get; set; }
        public string CellChanged { get; set; }

        public bool AllCellsFilledOut
        {
            get
            {
                return
                    !string.IsNullOrEmpty(this.a1.Value) &&
                    !string.IsNullOrEmpty(this.b1.Value) &&
                    !string.IsNullOrEmpty(this.c1.Value) &&
                    !string.IsNullOrEmpty(this.d1.Value) &&
                    !string.IsNullOrEmpty(this.e1.Value) &&
                    !string.IsNullOrEmpty(this.f1.Value) &&
                    !string.IsNullOrEmpty(this.g1.Value) &&
                    !string.IsNullOrEmpty(this.h1.Value) &&
                    !string.IsNullOrEmpty(this.i1.Value) &&
                    !string.IsNullOrEmpty(this.a2.Value) &&
                    !string.IsNullOrEmpty(this.b2.Value) &&
                    !string.IsNullOrEmpty(this.c2.Value) &&
                    !string.IsNullOrEmpty(this.d2.Value) &&
                    !string.IsNullOrEmpty(this.e2.Value) &&
                    !string.IsNullOrEmpty(this.f2.Value) &&
                    !string.IsNullOrEmpty(this.g2.Value) &&
                    !string.IsNullOrEmpty(this.h2.Value) &&
                    !string.IsNullOrEmpty(this.i2.Value) &&
                    !string.IsNullOrEmpty(this.a3.Value) &&
                    !string.IsNullOrEmpty(this.b3.Value) &&
                    !string.IsNullOrEmpty(this.c3.Value) &&
                    !string.IsNullOrEmpty(this.d3.Value) &&
                    !string.IsNullOrEmpty(this.e3.Value) &&
                    !string.IsNullOrEmpty(this.f3.Value) &&
                    !string.IsNullOrEmpty(this.g3.Value) &&
                    !string.IsNullOrEmpty(this.h3.Value) &&
                    !string.IsNullOrEmpty(this.i3.Value) &&
                    !string.IsNullOrEmpty(this.a4.Value) &&
                    !string.IsNullOrEmpty(this.b4.Value) &&
                    !string.IsNullOrEmpty(this.c4.Value) &&
                    !string.IsNullOrEmpty(this.d4.Value) &&
                    !string.IsNullOrEmpty(this.e4.Value) &&
                    !string.IsNullOrEmpty(this.f4.Value) &&
                    !string.IsNullOrEmpty(this.g4.Value) &&
                    !string.IsNullOrEmpty(this.h4.Value) &&
                    !string.IsNullOrEmpty(this.i4.Value) &&
                    !string.IsNullOrEmpty(this.a5.Value) &&
                    !string.IsNullOrEmpty(this.b5.Value) &&
                    !string.IsNullOrEmpty(this.c5.Value) &&
                    !string.IsNullOrEmpty(this.d5.Value) &&
                    !string.IsNullOrEmpty(this.e5.Value) &&
                    !string.IsNullOrEmpty(this.f5.Value) &&
                    !string.IsNullOrEmpty(this.g5.Value) &&
                    !string.IsNullOrEmpty(this.h5.Value) &&
                    !string.IsNullOrEmpty(this.i5.Value) &&
                    !string.IsNullOrEmpty(this.a6.Value) &&
                    !string.IsNullOrEmpty(this.b6.Value) &&
                    !string.IsNullOrEmpty(this.c6.Value) &&
                    !string.IsNullOrEmpty(this.d6.Value) &&
                    !string.IsNullOrEmpty(this.e6.Value) &&
                    !string.IsNullOrEmpty(this.f6.Value) &&
                    !string.IsNullOrEmpty(this.g6.Value) &&
                    !string.IsNullOrEmpty(this.h6.Value) &&
                    !string.IsNullOrEmpty(this.i6.Value) &&
                    !string.IsNullOrEmpty(this.a7.Value) &&
                    !string.IsNullOrEmpty(this.b7.Value) &&
                    !string.IsNullOrEmpty(this.c7.Value) &&
                    !string.IsNullOrEmpty(this.d7.Value) &&
                    !string.IsNullOrEmpty(this.e7.Value) &&
                    !string.IsNullOrEmpty(this.f7.Value) &&
                    !string.IsNullOrEmpty(this.g7.Value) &&
                    !string.IsNullOrEmpty(this.h7.Value) &&
                    !string.IsNullOrEmpty(this.i7.Value) &&
                    !string.IsNullOrEmpty(this.a8.Value) &&
                    !string.IsNullOrEmpty(this.b8.Value) &&
                    !string.IsNullOrEmpty(this.c8.Value) &&
                    !string.IsNullOrEmpty(this.d8.Value) &&
                    !string.IsNullOrEmpty(this.e8.Value) &&
                    !string.IsNullOrEmpty(this.f8.Value) &&
                    !string.IsNullOrEmpty(this.g8.Value) &&
                    !string.IsNullOrEmpty(this.h8.Value) &&
                    !string.IsNullOrEmpty(this.i8.Value) &&
                    !string.IsNullOrEmpty(this.a9.Value) &&
                    !string.IsNullOrEmpty(this.b9.Value) &&
                    !string.IsNullOrEmpty(this.c9.Value) &&
                    !string.IsNullOrEmpty(this.d9.Value) &&
                    !string.IsNullOrEmpty(this.e9.Value) &&
                    !string.IsNullOrEmpty(this.f9.Value) &&
                    !string.IsNullOrEmpty(this.g9.Value) &&
                    !string.IsNullOrEmpty(this.h9.Value) &&
                    !string.IsNullOrEmpty(this.i9.Value);
            }
        }

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
