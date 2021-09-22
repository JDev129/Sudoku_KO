using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SudokuMaster.Models
{
    public class ASudokuGame
    {
        [Key]
        public int ID { get; set; }
        public string Owner { get; set; }
        public string Domain { get; set; }
        public DateTime DateTimeStarted { get; set; }

        [ForeignKey("Solution")]
        public int Solution_ID { get; set; }
        public string Difficulty { get; set; }
        public bool FinishedSuccesfully { get; set; }


        [ForeignKey("SudokuPuzzleID")]
        public virtual List<SudokuMove> Moves { get; set; }

        public virtual SudokuMove Solution { get; set; }

        public ASudokuGame()
        {
            this.Moves = new List<SudokuMove>();
        }
    }
}
