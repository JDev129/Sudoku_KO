using System.Collections.Generic;

namespace SudokuMaster.Models
{
    public class SudokuViewModel
    {
        public string DifficultyLevel { get; set; }

        public int ID { get; set; }
        public bool CanFindValidSolution { get; set; }
        public bool ShowConfiguration { get; set; }
        public bool ShowOnlyValidEntries { get; set; }
        public double KP_POS_X { get; set; }
        public double KP_POS_Y { get; set; }
        public int GuessOrdinal { get; set; }
        public int GuessRow { get; set; }
        public int GuessColumn { get; set; }
        public int Guess { get; set; }
        public bool PuzzleSolved { get; set; }
        public bool InvalidSolution { get; set; }
        public SudokuMove Solution { get; set; }
        public SudokuMove CurrentMove { get; set; }
        public List<SudokuMove> Puzzle { get; set; }

        public SudokuViewModel()
        {
            this.Puzzle = new List<SudokuMove>();
        }
    }
}
