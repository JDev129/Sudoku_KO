using SudokuMaster.Models;
using System.Collections.Generic;

namespace SudokuMaster.Sudoku_Infrastructure
{
    public interface ISudokoh
    {

        List<SudokuMove> Moves { get; }
        SudokuMove Solution { get; }
        bool Solved { get; set; }
        bool InvalidSolution { get; set; }
        ISudokoh GuessAtPosition(int moveOrder, ISudCol column, ISudDigit row, ISudDigit guess);
        ISudokoh ClearGuessAtPostion(int moveOrder, ISudCol column, ISudDigit row);
        ISudokoh NewGuess(ISudCol column, ISudDigit row, ISudDigit guess);
        ISudokoh ClearGuess(ISudCol column, ISudDigit row);
    }
}
