using SudokuMaster.Models;
using System.Collections.Generic;

namespace SudokuMaster.Sudoku_Infrastructure
{
    public class ActivePuzzle : SudokuPuzzle
    {
        public ActivePuzzle(SudokuMove solution, IList<SudokuMove> moves) : base(solution, moves)
        {
        }
    }
}
