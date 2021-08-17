using SudokuMaster.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuMaster.Sudoku_Infrastructure
{
    public static class SudHelper
    {
        public static Tuple<bool, SudokuMove, SudokuMove> CreateSudoku(int numberOfStarts)
        {
            var tries = 30000;
            while (true)
            {

                char[][] table = RandomSudoku(EmptyTable(), 30); //LoadTable();
                var doubleCheckTable = CloneCharArray(table);
                var secondSolutionTable = CloneCharArray(table);
                var original = CloneCharArray(table);

                int stepsCount = 0;
                int stepsCount2 = 0;
                if (Solve(table, ref stepsCount) && !SolveAnotherWay(doubleCheckTable, ref stepsCount2, table))
                {
                    var firstsSolution = CloneCharArray(table);
                    var theSolution = CloneCharArray(table);

                    var firstMove = ConvertPuzzle(doubleCheckTable, null);
                    var solution = ConvertPuzzle(theSolution, firstMove);

                    return new Tuple<bool, SudokuMove, SudokuMove>(true, 
                        numberOfStarts == 30 ? 
                            firstMove:
                            ConvertPuzzle(CreateMoveWithXNumberOfStarts(theSolution, numberOfStarts), null), solution);
                }
                else
                {
                    if (tries > 0)
                    {
                        tries--;
                        continue;
                    }
                    else
                    {
                        return new Tuple<bool, SudokuMove, SudokuMove>(false, new SudokuMove(), new SudokuMove());
                    }
                }
            }
        }

        static char[][] CreateMoveWithXNumberOfStarts(char[][] solution, int numberOfStarts)
        {
            var randomObj = new Random();
            var starts = 0;
            var alreadyUsedRowAndCol = new List<KeyValuePair<int, int>>();
            var result = EmptyTable();
            while(starts <= numberOfStarts)
            {
                var row = randomObj.Next(0, 9);
                var col = randomObj.Next(0, 9);

                if (alreadyUsedRowAndCol.Where(x => x.Key == row && x.Value == col).Count() > 0)
                    continue;
                else
                {
                    alreadyUsedRowAndCol.Add(new KeyValuePair<int, int>(row, col));
                    result[col][row] = solution[col][row];
                    starts = starts + 1;
                }
            }
            return result;
        }

        static SudokuMove ConvertPuzzle(char[][] move, SudokuMove start) =>
            new SudokuMove()
            {
                a1 = AddACell(move[0][0].ToString() == "." ? string.Empty : move[0][0].ToString(), start == null ? true: start.a1.IsAStart),
                a2 = AddACell(move[0][1].ToString() == "." ? string.Empty : move[0][1].ToString(), start == null ? true: start.a2.IsAStart),
                a3 = AddACell(move[0][2].ToString() == "." ? string.Empty : move[0][2].ToString(), start == null ? true: start.a3.IsAStart),
                a4 = AddACell(move[0][3].ToString() == "." ? string.Empty : move[0][3].ToString(), start == null ? true: start.a4.IsAStart),
                a5 = AddACell(move[0][4].ToString() == "." ? string.Empty : move[0][4].ToString(), start == null ? true: start.a5.IsAStart),
                a6 = AddACell(move[0][5].ToString() == "." ? string.Empty : move[0][5].ToString(), start == null ? true: start.a6.IsAStart),
                a7 = AddACell(move[0][6].ToString() == "." ? string.Empty : move[0][6].ToString(), start == null ? true: start.a7.IsAStart),
                a8 = AddACell(move[0][7].ToString() == "." ? string.Empty : move[0][7].ToString(), start == null ? true: start.a8.IsAStart),
                a9 = AddACell(move[0][8].ToString() == "." ? string.Empty : move[0][8].ToString(), start == null ? true: start.a9.IsAStart),
                b1 = AddACell(move[1][0].ToString() == "." ? string.Empty : move[1][0].ToString(), start == null ? true: start.b1.IsAStart),
                b2 = AddACell(move[1][1].ToString() == "." ? string.Empty : move[1][1].ToString(), start == null ? true: start.b2.IsAStart),
                b3 = AddACell(move[1][2].ToString() == "." ? string.Empty : move[1][2].ToString(), start == null ? true: start.b3.IsAStart),
                b4 = AddACell(move[1][3].ToString() == "." ? string.Empty : move[1][3].ToString(), start == null ? true: start.b4.IsAStart),
                b5 = AddACell(move[1][4].ToString() == "." ? string.Empty : move[1][4].ToString(), start == null ? true: start.b5.IsAStart),
                b6 = AddACell(move[1][5].ToString() == "." ? string.Empty : move[1][5].ToString(), start == null ? true: start.b6.IsAStart),
                b7 = AddACell(move[1][6].ToString() == "." ? string.Empty : move[1][6].ToString(), start == null ? true: start.b7.IsAStart),
                b8 = AddACell(move[1][7].ToString() == "." ? string.Empty : move[1][7].ToString(), start == null ? true: start.b8.IsAStart),
                b9 = AddACell(move[1][8].ToString() == "." ? string.Empty : move[1][8].ToString(), start == null ? true: start.b9.IsAStart),

                c1 = AddACell(move[2][0].ToString() == "." ? string.Empty : move[2][0].ToString(), start == null ? true: start.c1.IsAStart),
                c2 = AddACell(move[2][1].ToString() == "." ? string.Empty : move[2][1].ToString(), start == null ? true: start.c2.IsAStart),
                c3 = AddACell(move[2][2].ToString() == "." ? string.Empty : move[2][2].ToString(), start == null ? true: start.c3.IsAStart),
                c4 = AddACell(move[2][3].ToString() == "." ? string.Empty : move[2][3].ToString(), start == null ? true: start.c4.IsAStart),
                c5 = AddACell(move[2][4].ToString() == "." ? string.Empty : move[2][4].ToString(), start == null ? true: start.c5.IsAStart),
                c6 = AddACell(move[2][5].ToString() == "." ? string.Empty : move[2][5].ToString(), start == null ? true: start.c6.IsAStart),
                c7 = AddACell(move[2][6].ToString() == "." ? string.Empty : move[2][6].ToString(), start == null ? true: start.c7.IsAStart),
                c8 = AddACell(move[2][7].ToString() == "." ? string.Empty : move[2][7].ToString(), start == null ? true: start.c8.IsAStart),
                c9 = AddACell(move[2][8].ToString() == "." ? string.Empty : move[2][8].ToString(), start == null ? true: start.c9.IsAStart),

                d1 = AddACell(move[3][0].ToString() == "." ? string.Empty : move[3][0].ToString(), start == null ? true: start.d1.IsAStart),
                d2 = AddACell(move[3][1].ToString() == "." ? string.Empty : move[3][1].ToString(), start == null ? true: start.d2.IsAStart),
                d3 = AddACell(move[3][2].ToString() == "." ? string.Empty : move[3][2].ToString(), start == null ? true: start.d3.IsAStart),
                d4 = AddACell(move[3][3].ToString() == "." ? string.Empty : move[3][3].ToString(), start == null ? true: start.d4.IsAStart),
                d5 = AddACell(move[3][4].ToString() == "." ? string.Empty : move[3][4].ToString(), start == null ? true: start.d5.IsAStart),
                d6 = AddACell(move[3][5].ToString() == "." ? string.Empty : move[3][5].ToString(), start == null ? true: start.d6.IsAStart),
                d7 = AddACell(move[3][6].ToString() == "." ? string.Empty : move[3][6].ToString(), start == null ? true: start.d7.IsAStart),
                d8 = AddACell(move[3][7].ToString() == "." ? string.Empty : move[3][7].ToString(), start == null ? true: start.d8.IsAStart),
                d9 = AddACell(move[3][8].ToString() == "." ? string.Empty : move[3][8].ToString(), start == null ? true: start.d9.IsAStart),

                e1 = AddACell(move[4][0].ToString() == "." ? string.Empty : move[4][0].ToString(), start == null ? true: start.e1.IsAStart),
                e2 = AddACell(move[4][1].ToString() == "." ? string.Empty : move[4][1].ToString(), start == null ? true: start.e2.IsAStart),
                e3 = AddACell(move[4][2].ToString() == "." ? string.Empty : move[4][2].ToString(), start == null ? true: start.e3.IsAStart),
                e4 = AddACell(move[4][3].ToString() == "." ? string.Empty : move[4][3].ToString(), start == null ? true: start.e4.IsAStart),
                e5 = AddACell(move[4][4].ToString() == "." ? string.Empty : move[4][4].ToString(), start == null ? true: start.e5.IsAStart),
                e6 = AddACell(move[4][5].ToString() == "." ? string.Empty : move[4][5].ToString(), start == null ? true: start.e6.IsAStart),
                e7 = AddACell(move[4][6].ToString() == "." ? string.Empty : move[4][6].ToString(), start == null ? true: start.e7.IsAStart),
                e8 = AddACell(move[4][7].ToString() == "." ? string.Empty : move[4][7].ToString(), start == null ? true: start.e8.IsAStart),
                e9 = AddACell(move[4][8].ToString() == "." ? string.Empty : move[4][8].ToString(), start == null ? true: start.e9.IsAStart),

                f1 = AddACell(move[5][0].ToString() == "." ? string.Empty : move[5][0].ToString(), start == null ? true: start.f1.IsAStart),
                f2 = AddACell(move[5][1].ToString() == "." ? string.Empty : move[5][1].ToString(), start == null ? true: start.f2.IsAStart),
                f3 = AddACell(move[5][2].ToString() == "." ? string.Empty : move[5][2].ToString(), start == null ? true: start.f3.IsAStart),
                f4 = AddACell(move[5][3].ToString() == "." ? string.Empty : move[5][3].ToString(), start == null ? true: start.f4.IsAStart),
                f5 = AddACell(move[5][4].ToString() == "." ? string.Empty : move[5][4].ToString(), start == null ? true: start.f5.IsAStart),
                f6 = AddACell(move[5][5].ToString() == "." ? string.Empty : move[5][5].ToString(), start == null ? true: start.f6.IsAStart),
                f7 = AddACell(move[5][6].ToString() == "." ? string.Empty : move[5][6].ToString(), start == null ? true: start.f7.IsAStart),
                f8 = AddACell(move[5][7].ToString() == "." ? string.Empty : move[5][7].ToString(), start == null ? true: start.f8.IsAStart),
                f9 = AddACell(move[5][8].ToString() == "." ? string.Empty : move[5][8].ToString(), start == null ? true: start.f9.IsAStart),

                g1 = AddACell(move[6][0].ToString() == "." ? string.Empty : move[6][0].ToString(), start == null ? true: start.g1.IsAStart),
                g2 = AddACell(move[6][1].ToString() == "." ? string.Empty : move[6][1].ToString(), start == null ? true: start.g2.IsAStart),
                g3 = AddACell(move[6][2].ToString() == "." ? string.Empty : move[6][2].ToString(), start == null ? true: start.g3.IsAStart),
                g4 = AddACell(move[6][3].ToString() == "." ? string.Empty : move[6][3].ToString(), start == null ? true: start.g4.IsAStart),
                g5 = AddACell(move[6][4].ToString() == "." ? string.Empty : move[6][4].ToString(), start == null ? true: start.g5.IsAStart),
                g6 = AddACell(move[6][5].ToString() == "." ? string.Empty : move[6][5].ToString(), start == null ? true: start.g6.IsAStart),
                g7 = AddACell(move[6][6].ToString() == "." ? string.Empty : move[6][6].ToString(), start == null ? true: start.g7.IsAStart),
                g8 = AddACell(move[6][7].ToString() == "." ? string.Empty : move[6][7].ToString(), start == null ? true: start.g8.IsAStart),
                g9 = AddACell(move[6][8].ToString() == "." ? string.Empty : move[6][8].ToString(), start == null ? true: start.g9.IsAStart),

                h1 = AddACell(move[7][0].ToString() == "." ? string.Empty : move[7][0].ToString(), start == null ? true: start.h1.IsAStart),
                h2 = AddACell(move[7][1].ToString() == "." ? string.Empty : move[7][1].ToString(), start == null ? true: start.h2.IsAStart),
                h3 = AddACell(move[7][2].ToString() == "." ? string.Empty : move[7][2].ToString(), start == null ? true: start.h3.IsAStart),
                h4 = AddACell(move[7][3].ToString() == "." ? string.Empty : move[7][3].ToString(), start == null ? true: start.h4.IsAStart),
                h5 = AddACell(move[7][4].ToString() == "." ? string.Empty : move[7][4].ToString(), start == null ? true: start.h5.IsAStart),
                h6 = AddACell(move[7][5].ToString() == "." ? string.Empty : move[7][5].ToString(), start == null ? true: start.h6.IsAStart),
                h7 = AddACell(move[7][6].ToString() == "." ? string.Empty : move[7][6].ToString(), start == null ? true: start.h7.IsAStart),
                h8 = AddACell(move[7][7].ToString() == "." ? string.Empty : move[7][7].ToString(), start == null ? true: start.h8.IsAStart),
                h9 = AddACell(move[7][8].ToString() == "." ? string.Empty : move[7][8].ToString(), start == null ? true: start.h9.IsAStart),

                i1 = AddACell(move[8][0].ToString() == "." ? string.Empty : move[8][0].ToString(), start == null ? true: start.i1.IsAStart),
                i2 = AddACell(move[8][1].ToString() == "." ? string.Empty : move[8][1].ToString(), start == null ? true: start.i2.IsAStart),
                i3 = AddACell(move[8][2].ToString() == "." ? string.Empty : move[8][2].ToString(), start == null ? true: start.i3.IsAStart),
                i4 = AddACell(move[8][3].ToString() == "." ? string.Empty : move[8][3].ToString(), start == null ? true: start.i4.IsAStart),
                i5 = AddACell(move[8][4].ToString() == "." ? string.Empty : move[8][4].ToString(), start == null ? true: start.i5.IsAStart),
                i6 = AddACell(move[8][5].ToString() == "." ? string.Empty : move[8][5].ToString(), start == null ? true: start.i6.IsAStart),
                i7 = AddACell(move[8][6].ToString() == "." ? string.Empty : move[8][6].ToString(), start == null ? true: start.i7.IsAStart),
                i8 = AddACell(move[8][7].ToString() == "." ? string.Empty : move[8][7].ToString(), start == null ? true: start.i8.IsAStart),
                i9 = AddACell(move[8][8].ToString() == "." ? string.Empty : move[8][8].ToString(), start == null ? true: start.i9.IsAStart)
            };

        static SudokuCell AddACell(string val, bool isStart = false) => new SudokuCell()
        {
            Value = val,
            IsAStart = isStart && !string.IsNullOrEmpty(val)
        };

        static char[] GetSpecialCandidates(char[][] table, int row, int col, char val)
        {

            string s = "";

            for (char c = '1'; c <= '9'; c++)
            {

                bool collision = false;

                for (int i = 0; i < 9; i++)
                {
                    if (table[row][i] == c ||
                        table[i][col] == c ||
                        table[(row - row % 3) + i / 3][(col - col % 3) + i % 3] == c)
                    {
                        collision = true;
                        break;
                    }
                }

                if (!collision)
                    s += c;

            }

            return s.ToCharArray();

        }

        static char[] GetCandidates(char[][] table, int row, int col)
        {

            string s = "";

            for (char c = '1'; c <= '9'; c++)
            {

                bool collision = false;

                for (int i = 0; i < 9; i++)
                {
                    if (table[row][i] == c ||
                        table[i][col] == c ||
                        table[(row - row % 3) + i / 3][(col - col % 3) + i % 3] == c)
                    {
                        collision = true;
                        break;
                    }
                }

                if (!collision)
                    s += c;

            }

            return s.ToCharArray();

        }

        static bool SolveAnotherWay(char[][] table, ref int stepsCount, char[][] firstSolution)
        {
            bool solved = false;

            int row = -1;
            int col = -1;
            char[] candidates = null;

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (table[i][j] == '.')
                    {
                        char[] newCandidates = GetCandidates(table, i, j)
                            .Where(x => x != firstSolution[i][j]).ToArray();

                        if (row < 0 || newCandidates.Length < candidates.Length)
                        {
                            row = i;
                            col = j;
                            candidates = newCandidates;
                        }
                    }

            if (row < 0)
            {
                solved = true;
            }
            else
            {

                for (int i = 0; i < candidates.Length; i++)
                {
                    table[row][col] = candidates[i];
                    stepsCount++;
                    if (SolveAnotherWay(table, ref stepsCount, firstSolution))
                    {
                        solved = true;
                        break;
                    }
                    table[row][col] = '.';
                }
            }

            return solved;

        }

        static bool Solve(char[][] table, ref int stepsCount)
        {
            bool solved = false;

            int row = -1;
            int col = -1;
            char[] candidates = null;

            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                    if (table[i][j] == '.')
                    {
                        char[] newCandidates = GetCandidates(table, i, j);
                        if (row < 0 || newCandidates.Length < candidates.Length)
                        {
                            row = i;
                            col = j;
                            candidates = newCandidates;
                        }
                    }

            if (row < 0)
            {
                solved = true;
            }
            else
            {

                for (int i = 0; i < candidates.Length; i++)
                {
                    table[row][col] = candidates[i];

                    if (stepsCount >= 1000000)
                        return false;

                    stepsCount++;
                    if (Solve(table, ref stepsCount))
                    {
                        solved = true;
                        break;
                    }
                    table[row][col] = '.';
                }
            }

            return solved;

        }

        static char[][] TestSudoku()
        {
            return new char[9][]
            {
                new char[]{ '.','.','.','7','.','.','3','.','1' },
                new char[]{ '3','.','.','9','.','.','.','.','.' },
                new char[]{ '.','4','.','3','1','.','2','.','.' },
                new char[]{ '.','6','.','4','.','.','5','.','.' },
                new char[]{ '.','.','.','.','.','.','.','.','.' },
                new char[]{ '.','.','1','.','.','8','.','4','.' },
                new char[]{ '.','.','6','.','2','1','.','5','.' },
                new char[]{ '.','.','.','.','.','9','.','.','8' },
                new char[]{ '8','.','5','.','.','4','.','.','.' }
            };
        }

        static char[][] EmptyTable()
        {
            return new char[9][]
            {
                new char[]{ '.','.','.','.','.','.','.','.','.' },
                new char[]{ '.','.','.','.','.','.','.','.','.' },
                new char[]{ '.','.','.','.','.','.','.','.','.' },
                new char[]{ '.','.','.','.','.','.','.','.','.' },
                new char[]{ '.','.','.','.','.','.','.','.','.' },
                new char[]{ '.','.','.','.','.','.','.','.','.' },
                new char[]{ '.','.','.','.','.','.','.','.','.' },
                new char[]{ '.','.','.','.','.','.','.','.','.' },
                new char[]{ '.','.','.','.','.','.','.','.','.' }
            };
        }



        static char[][] GetRandomStart(char[][] completedTable, int numberOfStarts)
        {
            var randomObj = new Random();
            var clearedPosistions = new List<KeyValuePair<int, int>>();
            var emptyCells = 0;
            while (emptyCells < (81 - numberOfStarts))
            {
                var row = randomObj.Next(0, 9);
                var col = randomObj.Next(0, 9);

                if (clearedPosistions.Where(x => x.Key == row && x.Value == col).Count() > 0)
                    continue;

                completedTable[row][col] = '.';
                emptyCells++;
                clearedPosistions.Add(new KeyValuePair<int, int>(row, col));
            }
            return completedTable;
        }

        static char[][] RandomSudoku(char[][] theTable, int numberOfStarts)
        {
            var randomObj = new Random();
            var setPosistions = new List<KeyValuePair<int, int>>();
            while (numberOfStarts > 0)
            {
                var row = randomObj.Next(0, 9);
                var col = randomObj.Next(0, 9);

                if (setPosistions.Where(x => x.Key == row && x.Value == col).Count() > 0)
                    continue;

                var possibleCandidates = GetCandidates(theTable, row, col);
                if (possibleCandidates.Length > 0)
                {
                    theTable[row][col] = possibleCandidates[randomObj.Next(0, possibleCandidates.Length)];
                    numberOfStarts--;
                    setPosistions.Add(new KeyValuePair<int, int>(row, col));
                }
            }
            return theTable;
        }

        static char[][] CloneCharArray(char[][] @this) => @this.ToList().ConvertAll(x => (char[])x.Clone()).ToArray();

    }
}
