using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuMaster.Models
{
    public class NewGameViewModel
    {
        public int SelectedDifficulty { get; set; }

        public int EastyCount { get; set; }
        public int MediumCount { get; set; }
        public int HardCount { get; set; }
        public int DiabolicalCount { get; set; }

        public bool AllowInvalidMoves { get; set; }
    }
}
