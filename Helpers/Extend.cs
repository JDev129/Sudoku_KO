using SudokuMaster.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SudokuMaster.Helpers
{
    public static class Extend
    {

        public static string SetUpperOn(
            this string @this,
            string delimitedPositionsBySemiColon)
        {
            var theResult = string.Empty;
            var theUpperPositions = new List<int>();
            foreach (var upperPosition in delimitedPositionsBySemiColon.Split(';'))
            {
                var theItem = 0;
                if (int.TryParse(upperPosition, out theItem) && !theUpperPositions.Contains(theItem))
                    theUpperPositions.Add(theItem);
            }
            for (int i = 0; i < @this.Length; i++)
            {
                var currentUpperPosition = -1;
                if (theUpperPositions.Count() > 0)
                    currentUpperPosition = theUpperPositions.First();
                if (currentUpperPosition == i)
                {
                    theResult += @this[i].ToString().ToUpper();
                    theUpperPositions.RemoveAt(0);
                }
                else
                    theResult += @this[i];
            }
            return theResult;
        }

        public static T Clone<T>(
            this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The type must be serializable.", nameof(source));
            }

            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null)) return default(T);

            using (Stream stream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }

        public static bool AllCellsFilledOut(
            this SudokuMove @this)
        {
            return
                !string.IsNullOrEmpty(@this.a1.Value) &&
                !string.IsNullOrEmpty(@this.b1.Value) &&
                !string.IsNullOrEmpty(@this.c1.Value) &&
                !string.IsNullOrEmpty(@this.d1.Value) &&
                !string.IsNullOrEmpty(@this.e1.Value) &&
                !string.IsNullOrEmpty(@this.f1.Value) &&
                !string.IsNullOrEmpty(@this.g1.Value) &&
                !string.IsNullOrEmpty(@this.h1.Value) &&
                !string.IsNullOrEmpty(@this.i1.Value) &&
                !string.IsNullOrEmpty(@this.a2.Value) &&
                !string.IsNullOrEmpty(@this.b2.Value) &&
                !string.IsNullOrEmpty(@this.c2.Value) &&
                !string.IsNullOrEmpty(@this.d2.Value) &&
                !string.IsNullOrEmpty(@this.e2.Value) &&
                !string.IsNullOrEmpty(@this.f2.Value) &&
                !string.IsNullOrEmpty(@this.g2.Value) &&
                !string.IsNullOrEmpty(@this.h2.Value) &&
                !string.IsNullOrEmpty(@this.i2.Value) &&
                !string.IsNullOrEmpty(@this.a3.Value) &&
                !string.IsNullOrEmpty(@this.b3.Value) &&
                !string.IsNullOrEmpty(@this.c3.Value) &&
                !string.IsNullOrEmpty(@this.d3.Value) &&
                !string.IsNullOrEmpty(@this.e3.Value) &&
                !string.IsNullOrEmpty(@this.f3.Value) &&
                !string.IsNullOrEmpty(@this.g3.Value) &&
                !string.IsNullOrEmpty(@this.h3.Value) &&
                !string.IsNullOrEmpty(@this.i3.Value) &&
                !string.IsNullOrEmpty(@this.a4.Value) &&
                !string.IsNullOrEmpty(@this.b4.Value) &&
                !string.IsNullOrEmpty(@this.c4.Value) &&
                !string.IsNullOrEmpty(@this.d4.Value) &&
                !string.IsNullOrEmpty(@this.e4.Value) &&
                !string.IsNullOrEmpty(@this.f4.Value) &&
                !string.IsNullOrEmpty(@this.g4.Value) &&
                !string.IsNullOrEmpty(@this.h4.Value) &&
                !string.IsNullOrEmpty(@this.i4.Value) &&
                !string.IsNullOrEmpty(@this.a5.Value) &&
                !string.IsNullOrEmpty(@this.b5.Value) &&
                !string.IsNullOrEmpty(@this.c5.Value) &&
                !string.IsNullOrEmpty(@this.d5.Value) &&
                !string.IsNullOrEmpty(@this.e5.Value) &&
                !string.IsNullOrEmpty(@this.f5.Value) &&
                !string.IsNullOrEmpty(@this.g5.Value) &&
                !string.IsNullOrEmpty(@this.h5.Value) &&
                !string.IsNullOrEmpty(@this.i5.Value) &&
                !string.IsNullOrEmpty(@this.a6.Value) &&
                !string.IsNullOrEmpty(@this.b6.Value) &&
                !string.IsNullOrEmpty(@this.c6.Value) &&
                !string.IsNullOrEmpty(@this.d6.Value) &&
                !string.IsNullOrEmpty(@this.e6.Value) &&
                !string.IsNullOrEmpty(@this.f6.Value) &&
                !string.IsNullOrEmpty(@this.g6.Value) &&
                !string.IsNullOrEmpty(@this.h6.Value) &&
                !string.IsNullOrEmpty(@this.i6.Value) &&
                !string.IsNullOrEmpty(@this.a7.Value) &&
                !string.IsNullOrEmpty(@this.b7.Value) &&
                !string.IsNullOrEmpty(@this.c7.Value) &&
                !string.IsNullOrEmpty(@this.d7.Value) &&
                !string.IsNullOrEmpty(@this.e7.Value) &&
                !string.IsNullOrEmpty(@this.f7.Value) &&
                !string.IsNullOrEmpty(@this.g7.Value) &&
                !string.IsNullOrEmpty(@this.h7.Value) &&
                !string.IsNullOrEmpty(@this.i7.Value) &&
                !string.IsNullOrEmpty(@this.a8.Value) &&
                !string.IsNullOrEmpty(@this.b8.Value) &&
                !string.IsNullOrEmpty(@this.c8.Value) &&
                !string.IsNullOrEmpty(@this.d8.Value) &&
                !string.IsNullOrEmpty(@this.e8.Value) &&
                !string.IsNullOrEmpty(@this.f8.Value) &&
                !string.IsNullOrEmpty(@this.g8.Value) &&
                !string.IsNullOrEmpty(@this.h8.Value) &&
                !string.IsNullOrEmpty(@this.i8.Value) &&
                !string.IsNullOrEmpty(@this.a9.Value) &&
                !string.IsNullOrEmpty(@this.b9.Value) &&
                !string.IsNullOrEmpty(@this.c9.Value) &&
                !string.IsNullOrEmpty(@this.d9.Value) &&
                !string.IsNullOrEmpty(@this.e9.Value) &&
                !string.IsNullOrEmpty(@this.f9.Value) &&
                !string.IsNullOrEmpty(@this.g9.Value) &&
                !string.IsNullOrEmpty(@this.h9.Value) &&
                !string.IsNullOrEmpty(@this.i9.Value);
        }
    }
}
