namespace SudokuMaster.Models
{
    public class SudokuCell
    {
        public int ID { get; set; }
        public int SudokuMoveID { get; set; }
        public string Value { get; set; }
        public bool IsAStart { get; set; }
    }
}
