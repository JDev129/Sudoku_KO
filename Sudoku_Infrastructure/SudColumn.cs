using System;

namespace SudokuMaster.Sudoku_Infrastructure
{
    public static class SudColumn
    {
        public static ISudCol ConvertCol(int col)
        {
            switch (col)
            {
                case 0:
                    return new A();
                case 1:
                    return new B();
                case 2:
                    return new C();
                case 3:
                    return new D();
                case 4:
                    return new E();
                case 5:
                    return new F();
                case 6:
                    return new G();
                case 7:
                    return new H();
                case 8:
                    return new I();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        //public static ISudCol A() => new A();
        //public static ISudCol B() => new B();
        //public static ISudCol C() => new C();
        //public static ISudCol D() => new D();
        //public static ISudCol E() => new E();
        //public static ISudCol F() => new F();
        //public static ISudCol G() => new G();
        //public static ISudCol H() => new H();
        //public static ISudCol I() => new I();


    }

    public class A : ISudCol { public string columnLetter { get { return "a"; } } }
    public class B : ISudCol { public string columnLetter { get { return "b"; } } }
    public class C : ISudCol { public string columnLetter { get { return "c"; } } }
    public class D : ISudCol { public string columnLetter { get { return "d"; } } }
    public class E : ISudCol { public string columnLetter { get { return "e"; } } }
    public class F : ISudCol { public string columnLetter { get { return "f"; } } }
    public class G : ISudCol { public string columnLetter { get { return "g"; } } }
    public class H : ISudCol { public string columnLetter { get { return "h"; } } }
    public class I : ISudCol { public string columnLetter { get { return "i"; } } }
}
