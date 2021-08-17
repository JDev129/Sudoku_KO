using SudokuMaster.Sudoku_Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuMaster.Models
{
    public abstract class SudokuPuzzle : ISudokoh
    {
        public List<SudokuMove> Moves { get { return this.MyMoves.OrderBy(x => x.MoveOrder).ToList(); } }
        public bool isValidPuzzle { get; }
        public SudokuMove Solution { get; }

        private IList<SudokuMove> MyMoves { get; }

        public bool Solved { get; set; }
        public bool InvalidSolution { get; set; }

        public SudokuPuzzle(int numberOfStarts)
        {
            if (numberOfStarts < 17 || numberOfStarts > 79)
                throw new ArgumentOutOfRangeException("numberOfStarts");

            var createdSolution = SudHelper.CreateSudoku(numberOfStarts);
            if (createdSolution.Item1)
            {
                isValidPuzzle = true;
                Solution = createdSolution.Item3;
                Solution.CellChanged = "Solution";
                createdSolution.Item2.CellChanged = "Start";
                createdSolution.Item2.ID = 1;
                createdSolution.Item2.MoveOrder = 1;
                MyMoves = new List<SudokuMove>()
                {
                    createdSolution.Item2
                };
            }
            else
            {
                isValidPuzzle = false;
                this.MyMoves = new List<SudokuMove>() { new SudokuMove() };
                this.Solution = new SudokuMove();
            }
        }

        public SudokuPuzzle(SudokuMove solution, IList<SudokuMove> moves)
        {
            this.Solution = solution;
            this.MyMoves = moves;
        }


        public ISudokoh NewGuess(ISudCol column, ISudDigit row, ISudDigit guess)
        {
            var newMove = CopyMove(Moves.Last());
            AddGuess(column.columnLetter, row.digitNumber, newMove, guess.digitNumber);
            this.MyMoves.Add(newMove);
            CheckPuzzleSolved();
            return this;
        }

        public ISudokoh ClearGuess(ISudCol column, ISudDigit row)
        {
            var newMove = CopyMove(Moves.Last());
            AddGuess(column.columnLetter, row.digitNumber, newMove, string.Empty);
            this.MyMoves.Add(newMove);
            return this;
        }

        public ISudokoh GuessAtPosition(int moveOrder, ISudCol column, ISudDigit row, ISudDigit guess)
        {
            var newMove = CopyMove(Moves.Where(x => x.MoveOrder == moveOrder).First());
            AddGuess(column.columnLetter, row.digitNumber, newMove, guess.digitNumber);
            for (int i = Moves.Count; i > moveOrder; i--)
                this.MyMoves.Remove(this.MyMoves.Last());
            this.MyMoves.Add(newMove);
            CheckPuzzleSolved();
            return this;
        }

        public ISudokoh ClearGuessAtPostion(int moveOrder, ISudCol column, ISudDigit row)
        {
            var newMove = CopyMove(Moves.Where(x => x.MoveOrder == moveOrder).First());
            AddGuess(column.columnLetter, row.digitNumber, newMove, string.Empty);
            for (int i = Moves.Count; i > moveOrder; i--)
                this.MyMoves.Remove(this.MyMoves.Last());
            this.MyMoves.Add(newMove);
            return this;
        }

        private void CheckPuzzleSolved()
        {
            var lastMove = this.Moves.Last();
            var allMovesPlayed = lastMove.AllCellsFilledOut;
            this.Solved = (allMovesPlayed) ? MovesAreTheSame(lastMove, this.Solution): false;
            this.InvalidSolution = !this.Solved && allMovesPlayed;
        }

        private bool MovesAreTheSame(SudokuMove move, SudokuMove solution) =>
                move.a1.Value == solution.a1.Value &&
                move.a2.Value == solution.a2.Value &&
                move.a3.Value == solution.a3.Value &&
                move.a4.Value == solution.a4.Value &&
                move.a5.Value == solution.a5.Value &&
                move.a6.Value == solution.a6.Value &&
                move.a7.Value == solution.a7.Value &&
                move.a8.Value == solution.a8.Value &&
                move.a9.Value == solution.a9.Value &&
                move.b1.Value == solution.b1.Value &&
                move.b2.Value == solution.b2.Value &&
                move.b3.Value == solution.b3.Value &&
                move.b4.Value == solution.b4.Value &&
                move.b5.Value == solution.b5.Value &&
                move.b6.Value == solution.b6.Value &&
                move.b7.Value == solution.b7.Value &&
                move.b8.Value == solution.b8.Value &&
                move.b9.Value == solution.b9.Value &&
                move.c1.Value == solution.c1.Value &&
                move.c2.Value == solution.c2.Value &&
                move.c3.Value == solution.c3.Value &&
                move.c4.Value == solution.c4.Value &&
                move.c5.Value == solution.c5.Value &&
                move.c6.Value == solution.c6.Value &&
                move.c7.Value == solution.c7.Value &&
                move.c8.Value == solution.c8.Value &&
                move.c9.Value == solution.c9.Value &&
                move.d1.Value == solution.d1.Value &&
                move.d2.Value == solution.d2.Value &&
                move.d3.Value == solution.d3.Value &&
                move.d4.Value == solution.d4.Value &&
                move.d5.Value == solution.d5.Value &&
                move.d6.Value == solution.d6.Value &&
                move.d7.Value == solution.d7.Value &&
                move.d8.Value == solution.d8.Value &&
                move.d9.Value == solution.d9.Value &&
                move.e1.Value == solution.e1.Value &&
                move.e2.Value == solution.e2.Value &&
                move.e3.Value == solution.e3.Value &&
                move.e4.Value == solution.e4.Value &&
                move.e5.Value == solution.e5.Value &&
                move.e6.Value == solution.e6.Value &&
                move.e7.Value == solution.e7.Value &&
                move.e8.Value == solution.e8.Value &&
                move.e9.Value == solution.e9.Value &&
                move.f1.Value == solution.f1.Value &&
                move.f2.Value == solution.f2.Value &&
                move.f3.Value == solution.f3.Value &&
                move.f4.Value == solution.f4.Value &&
                move.f5.Value == solution.f5.Value &&
                move.f6.Value == solution.f6.Value &&
                move.f7.Value == solution.f7.Value &&
                move.f8.Value == solution.f8.Value &&
                move.f9.Value == solution.f9.Value &&
                move.g1.Value == solution.g1.Value &&
                move.g2.Value == solution.g2.Value &&
                move.g3.Value == solution.g3.Value &&
                move.g4.Value == solution.g4.Value &&
                move.g5.Value == solution.g5.Value &&
                move.g6.Value == solution.g6.Value &&
                move.g7.Value == solution.g7.Value &&
                move.g8.Value == solution.g8.Value &&
                move.g9.Value == solution.g9.Value &&
                move.h1.Value == solution.h1.Value &&
                move.h2.Value == solution.h2.Value &&
                move.h3.Value == solution.h3.Value &&
                move.h4.Value == solution.h4.Value &&
                move.h5.Value == solution.h5.Value &&
                move.h6.Value == solution.h6.Value &&
                move.h7.Value == solution.h7.Value &&
                move.h8.Value == solution.h8.Value &&
                move.h9.Value == solution.h9.Value &&
                move.i1.Value == solution.i1.Value &&
                move.i2.Value == solution.i2.Value &&
                move.i3.Value == solution.i3.Value &&
                move.i4.Value == solution.i4.Value &&
                move.i5.Value == solution.i5.Value &&
                move.i6.Value == solution.i6.Value &&
                move.i7.Value == solution.i7.Value &&
                move.i8.Value == solution.i8.Value &&
                move.i9.Value == solution.i9.Value;

        private SudokuMove CopyMove(SudokuMove copyFrom) =>
            new SudokuMove()
            {
                ID = copyFrom.ID + 1,
                SudokuPuzzleID = copyFrom.SudokuPuzzleID,
                MoveOrder = (copyFrom.MoveOrder + 1),
                a1 = new SudokuCell() { IsAStart = copyFrom.a1.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.a1.Value },
                a2 = new SudokuCell() { IsAStart = copyFrom.a2.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.a2.Value },
                a3 = new SudokuCell() { IsAStart = copyFrom.a3.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.a3.Value },
                a4 = new SudokuCell() { IsAStart = copyFrom.a4.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.a4.Value },
                a5 = new SudokuCell() { IsAStart = copyFrom.a5.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.a5.Value },
                a6 = new SudokuCell() { IsAStart = copyFrom.a6.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.a6.Value },
                a7 = new SudokuCell() { IsAStart = copyFrom.a7.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.a7.Value },
                a8 = new SudokuCell() { IsAStart = copyFrom.a8.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.a8.Value },
                a9 = new SudokuCell() { IsAStart = copyFrom.a9.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.a9.Value },
                b1 = new SudokuCell() { IsAStart = copyFrom.b1.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.b1.Value },
                b2 = new SudokuCell() { IsAStart = copyFrom.b2.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.b2.Value },
                b3 = new SudokuCell() { IsAStart = copyFrom.b3.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.b3.Value },
                b4 = new SudokuCell() { IsAStart = copyFrom.b4.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.b4.Value },
                b5 = new SudokuCell() { IsAStart = copyFrom.b5.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.b5.Value },
                b6 = new SudokuCell() { IsAStart = copyFrom.b6.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.b6.Value },
                b7 = new SudokuCell() { IsAStart = copyFrom.b7.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.b7.Value },
                b8 = new SudokuCell() { IsAStart = copyFrom.b8.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.b8.Value },
                b9 = new SudokuCell() { IsAStart = copyFrom.b9.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.b9.Value },
                c1 = new SudokuCell() { IsAStart = copyFrom.c1.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.c1.Value },
                c2 = new SudokuCell() { IsAStart = copyFrom.c2.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.c2.Value },
                c3 = new SudokuCell() { IsAStart = copyFrom.c3.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.c3.Value },
                c4 = new SudokuCell() { IsAStart = copyFrom.c4.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.c4.Value },
                c5 = new SudokuCell() { IsAStart = copyFrom.c5.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.c5.Value },
                c6 = new SudokuCell() { IsAStart = copyFrom.c6.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.c6.Value },
                c7 = new SudokuCell() { IsAStart = copyFrom.c7.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.c7.Value },
                c8 = new SudokuCell() { IsAStart = copyFrom.c8.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.c8.Value },
                c9 = new SudokuCell() { IsAStart = copyFrom.c9.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.c9.Value },
                d1 = new SudokuCell() { IsAStart = copyFrom.d1.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.d1.Value },
                d2 = new SudokuCell() { IsAStart = copyFrom.d2.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.d2.Value },
                d3 = new SudokuCell() { IsAStart = copyFrom.d3.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.d3.Value },
                d4 = new SudokuCell() { IsAStart = copyFrom.d4.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.d4.Value },
                d5 = new SudokuCell() { IsAStart = copyFrom.d5.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.d5.Value },
                d6 = new SudokuCell() { IsAStart = copyFrom.d6.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.d6.Value },
                d7 = new SudokuCell() { IsAStart = copyFrom.d7.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.d7.Value },
                d8 = new SudokuCell() { IsAStart = copyFrom.d8.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.d8.Value },
                d9 = new SudokuCell() { IsAStart = copyFrom.d9.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.d9.Value },
                e1 = new SudokuCell() { IsAStart = copyFrom.e1.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.e1.Value },
                e2 = new SudokuCell() { IsAStart = copyFrom.e2.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.e2.Value },
                e3 = new SudokuCell() { IsAStart = copyFrom.e3.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.e3.Value },
                e4 = new SudokuCell() { IsAStart = copyFrom.e4.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.e4.Value },
                e5 = new SudokuCell() { IsAStart = copyFrom.e5.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.e5.Value },
                e6 = new SudokuCell() { IsAStart = copyFrom.e6.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.e6.Value },
                e7 = new SudokuCell() { IsAStart = copyFrom.e7.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.e7.Value },
                e8 = new SudokuCell() { IsAStart = copyFrom.e8.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.e8.Value },
                e9 = new SudokuCell() { IsAStart = copyFrom.e9.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.e9.Value },
                f1 = new SudokuCell() { IsAStart = copyFrom.f1.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.f1.Value },
                f2 = new SudokuCell() { IsAStart = copyFrom.f2.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.f2.Value },
                f3 = new SudokuCell() { IsAStart = copyFrom.f3.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.f3.Value },
                f4 = new SudokuCell() { IsAStart = copyFrom.f4.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.f4.Value },
                f5 = new SudokuCell() { IsAStart = copyFrom.f5.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.f5.Value },
                f6 = new SudokuCell() { IsAStart = copyFrom.f6.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.f6.Value },
                f7 = new SudokuCell() { IsAStart = copyFrom.f7.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.f7.Value },
                f8 = new SudokuCell() { IsAStart = copyFrom.f8.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.f8.Value },
                f9 = new SudokuCell() { IsAStart = copyFrom.f9.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.f9.Value },
                g1 = new SudokuCell() { IsAStart = copyFrom.g1.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.g1.Value },
                g2 = new SudokuCell() { IsAStart = copyFrom.g2.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.g2.Value },
                g3 = new SudokuCell() { IsAStart = copyFrom.g3.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.g3.Value },
                g4 = new SudokuCell() { IsAStart = copyFrom.g4.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.g4.Value },
                g5 = new SudokuCell() { IsAStart = copyFrom.g5.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.g5.Value },
                g6 = new SudokuCell() { IsAStart = copyFrom.g6.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.g6.Value },
                g7 = new SudokuCell() { IsAStart = copyFrom.g7.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.g7.Value },
                g8 = new SudokuCell() { IsAStart = copyFrom.g8.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.g8.Value },
                g9 = new SudokuCell() { IsAStart = copyFrom.g9.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.g9.Value },
                h1 = new SudokuCell() { IsAStart = copyFrom.h1.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.h1.Value },
                h2 = new SudokuCell() { IsAStart = copyFrom.h2.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.h2.Value },
                h3 = new SudokuCell() { IsAStart = copyFrom.h3.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.h3.Value },
                h4 = new SudokuCell() { IsAStart = copyFrom.h4.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.h4.Value },
                h5 = new SudokuCell() { IsAStart = copyFrom.h5.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.h5.Value },
                h6 = new SudokuCell() { IsAStart = copyFrom.h6.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.h6.Value },
                h7 = new SudokuCell() { IsAStart = copyFrom.h7.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.h7.Value },
                h8 = new SudokuCell() { IsAStart = copyFrom.h8.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.h8.Value },
                h9 = new SudokuCell() { IsAStart = copyFrom.h9.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.h9.Value },
                i1 = new SudokuCell() { IsAStart = copyFrom.i1.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.i1.Value },
                i2 = new SudokuCell() { IsAStart = copyFrom.i2.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.i2.Value },
                i3 = new SudokuCell() { IsAStart = copyFrom.i3.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.i3.Value },
                i4 = new SudokuCell() { IsAStart = copyFrom.i4.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.i4.Value },
                i5 = new SudokuCell() { IsAStart = copyFrom.i5.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.i5.Value },
                i6 = new SudokuCell() { IsAStart = copyFrom.i6.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.i6.Value },
                i7 = new SudokuCell() { IsAStart = copyFrom.i7.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.i7.Value },
                i8 = new SudokuCell() { IsAStart = copyFrom.i8.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.i8.Value },
                i9 = new SudokuCell() { IsAStart = copyFrom.i9.IsAStart, SudokuMoveID = (copyFrom.ID + 1), Value = copyFrom.i9.Value }
            };

        private void AddGuess(string col, string row, SudokuMove move, string guess)
        {
            if (col == "a" && row == "1")
                move.a1.Value = guess;
            else if (col == "a" && row == "2")
                move.a2.Value = guess;
            else if (col == "a" && row == "3")
                move.a3.Value = guess;
            else if (col == "a" && row == "4")
                move.a4.Value = guess;
            else if (col == "a" && row == "5")
                move.a5.Value = guess;
            else if (col == "a" && row == "6")
                move.a6.Value = guess;
            else if (col == "a" && row == "7")
                move.a7.Value = guess;
            else if (col == "a" && row == "8")
                move.a8.Value = guess;
            else if (col == "a" && row == "9")
                move.a9.Value = guess;

            else if (col == "b" && row == "1")
                move.b1.Value = guess;
            else if (col == "b" && row == "2")
                move.b2.Value = guess;
            else if (col == "b" && row == "3")
                move.b3.Value = guess;
            else if (col == "b" && row == "4")
                move.b4.Value = guess;
            else if (col == "b" && row == "5")
                move.b5.Value = guess;
            else if (col == "b" && row == "6")
                move.b6.Value = guess;
            else if (col == "b" && row == "7")
                move.b7.Value = guess;
            else if (col == "b" && row == "8")
                move.b8.Value = guess;
            else if (col == "b" && row == "9")
                move.b9.Value = guess;

            else if (col == "c" && row == "1")
                move.c1.Value = guess;
            else if (col == "c" && row == "2")
                move.c2.Value = guess;
            else if (col == "c" && row == "3")
                move.c3.Value = guess;
            else if (col == "c" && row == "4")
                move.c4.Value = guess;
            else if (col == "c" && row == "5")
                move.c5.Value = guess;
            else if (col == "c" && row == "6")
                move.c6.Value = guess;
            else if (col == "c" && row == "7")
                move.c7.Value = guess;
            else if (col == "c" && row == "8")
                move.c8.Value = guess;
            else if (col == "c" && row == "9")
                move.c9.Value = guess;

            else if (col == "d" && row == "1")
                move.d1.Value = guess;
            else if (col == "d" && row == "2")
                move.d2.Value = guess;
            else if (col == "d" && row == "3")
                move.d3.Value = guess;
            else if (col == "d" && row == "4")
                move.d4.Value = guess;
            else if (col == "d" && row == "5")
                move.d5.Value = guess;
            else if (col == "d" && row == "6")
                move.d6.Value = guess;
            else if (col == "d" && row == "7")
                move.d7.Value = guess;
            else if (col == "d" && row == "8")
                move.d8.Value = guess;
            else if (col == "d" && row == "9")
                move.d9.Value = guess;

            else if (col == "e" && row == "1")
                move.e1.Value = guess;
            else if (col == "e" && row == "2")
                move.e2.Value = guess;
            else if (col == "e" && row == "3")
                move.e3.Value = guess;
            else if (col == "e" && row == "4")
                move.e4.Value = guess;
            else if (col == "e" && row == "5")
                move.e5.Value = guess;
            else if (col == "e" && row == "6")
                move.e6.Value = guess;
            else if (col == "e" && row == "7")
                move.e7.Value = guess;
            else if (col == "e" && row == "8")
                move.e8.Value = guess;
            else if (col == "e" && row == "9")
                move.e9.Value = guess;

            else if (col == "f" && row == "1")
                move.f1.Value = guess;
            else if (col == "f" && row == "2")
                move.f2.Value = guess;
            else if (col == "f" && row == "3")
                move.f3.Value = guess;
            else if (col == "f" && row == "4")
                move.f4.Value = guess;
            else if (col == "f" && row == "5")
                move.f5.Value = guess;
            else if (col == "f" && row == "6")
                move.f6.Value = guess;
            else if (col == "f" && row == "7")
                move.f7.Value = guess;
            else if (col == "f" && row == "8")
                move.f8.Value = guess;
            else if (col == "f" && row == "9")
                move.f9.Value = guess;

            else if (col == "g" && row == "1")
                move.g1.Value = guess;
            else if (col == "g" && row == "2")
                move.g2.Value = guess;
            else if (col == "g" && row == "3")
                move.g3.Value = guess;
            else if (col == "g" && row == "4")
                move.g4.Value = guess;
            else if (col == "g" && row == "5")
                move.g5.Value = guess;
            else if (col == "g" && row == "6")
                move.g6.Value = guess;
            else if (col == "g" && row == "7")
                move.g7.Value = guess;
            else if (col == "g" && row == "8")
                move.g8.Value = guess;
            else if (col == "g" && row == "9")
                move.g9.Value = guess;

            else if (col == "h" && row == "1")
                move.h1.Value = guess;
            else if (col == "h" && row == "2")
                move.h2.Value = guess;
            else if (col == "h" && row == "3")
                move.h3.Value = guess;
            else if (col == "h" && row == "4")
                move.h4.Value = guess;
            else if (col == "h" && row == "5")
                move.h5.Value = guess;
            else if (col == "h" && row == "6")
                move.h6.Value = guess;
            else if (col == "h" && row == "7")
                move.h7.Value = guess;
            else if (col == "h" && row == "8")
                move.h8.Value = guess;
            else if (col == "h" && row == "9")
                move.h9.Value = guess;

            else if (col == "i" && row == "1")
                move.i1.Value = guess;
            else if (col == "i" && row == "2")
                move.i2.Value = guess;
            else if (col == "i" && row == "3")
                move.i3.Value = guess;
            else if (col == "i" && row == "4")
                move.i4.Value = guess;
            else if (col == "i" && row == "5")
                move.i5.Value = guess;
            else if (col == "i" && row == "6")
                move.i6.Value = guess;
            else if (col == "i" && row == "7")
                move.i7.Value = guess;
            else if (col == "i" && row == "8")
                move.i8.Value = guess;
            else if (col == "i" && row == "9")
                move.i9.Value = guess;

            move.CellChanged = col + row;
        }
    }
}
