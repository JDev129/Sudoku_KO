using SudokuMaster.Sudoku_Infrastructure;
using SudokuMaster.Models;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace SudokuMaster.Controllers
{
    public class SudokuController : Controller
    {

        public SudokuController()
        {
        }

        public ActionResult Index() =>
            View(new NewGameViewModel() {
                EastyCount = 65,
                MediumCount = 55,
                HardCount = 45,
                DiabolicalCount = 30
            });

        public ActionResult Play(NewGameViewModel vm)
        {
            var puzzleCount = vm.SelectedDifficulty == 0 ? 
                vm.EastyCount : vm.SelectedDifficulty == 1 ? 
                vm.MediumCount : vm.SelectedDifficulty == 2 ? 
                vm.HardCount : vm.SelectedDifficulty == 3 ? 
                vm.DiabolicalCount : 
                throw new ArgumentOutOfRangeException("SelectedDifficulty");
            var myNewPuzzle = new NewPuzzle(puzzleCount);
            if (myNewPuzzle.isValidPuzzle)
            {
                TempData["MySolution"] = JsonConvert.SerializeObject(myNewPuzzle.Solution);
                TempData["MyPuzzle"] = JsonConvert.SerializeObject(myNewPuzzle.Moves);

                return View(new SudokuViewModel()
                {
                    Start = myNewPuzzle.Moves.FirstOrDefault(),
                    CurrentMove = myNewPuzzle.Moves.FirstOrDefault(),
                    Puzzle = myNewPuzzle.Moves,
                    Solution = myNewPuzzle.Solution,
                });
            }
            else
            {
                return View(new SudokuViewModel()
                {
                });
            }
        }

        public ActionResult MakeAMove(SudokuViewModel viewModel)
        {
            object attempSol = string.Empty;
            object attempPuz = string.Empty;
            TempData.TryGetValue("MySolution", out attempSol);
            TempData.TryGetValue("MyPuzzle", out attempPuz);

            var theSol = JsonConvert.DeserializeObject<SudokuMove>(attempSol.ToString());
            var thePuzz = JsonConvert.DeserializeObject<List<SudokuMove>>(attempPuz.ToString());

            var myPuzzle = new ActivePuzzle(theSol, thePuzz);
            var updatePuzzle = 
                viewModel.Guess > 0 && viewModel.GuessOrdinal > 0 ?
                    myPuzzle.GuessAtPosition(
                        viewModel.GuessOrdinal, 
                        SudColumn.ConvertCol(viewModel.GuessColumn),
                        SudDigit.ConvertSudRow(viewModel.GuessRow),
                        SudDigit.ConvertSudNumber(viewModel.Guess)) :
                viewModel.Guess > 0 ?
                    myPuzzle.NewGuess(
                        SudColumn.ConvertCol(viewModel.GuessColumn),
                        SudDigit.ConvertSudRow(viewModel.GuessRow),
                        SudDigit.ConvertSudNumber(viewModel.Guess)):
                viewModel.GuessOrdinal > 0 ?
                    myPuzzle.ClearGuessAtPostion(
                        viewModel.GuessOrdinal,
                        SudColumn.ConvertCol(viewModel.GuessColumn),
                        SudDigit.ConvertSudRow(viewModel.GuessRow)) :
                    myPuzzle.ClearGuess(
                        SudColumn.ConvertCol(viewModel.GuessColumn),
                        SudDigit.ConvertSudRow(viewModel.GuessRow));

            viewModel.Solution = updatePuzzle.Solution;
            viewModel.Puzzle = updatePuzzle.Moves;
            viewModel.CurrentMove = updatePuzzle.Moves.Last();

            viewModel.PuzzleSolved = updatePuzzle.Solved;
            viewModel.InvalidSolution = updatePuzzle.InvalidSolution;

            viewModel.GuessOrdinal = 0;

            TempData["MyPuzzle"] = JsonConvert.SerializeObject(updatePuzzle.Moves);
            TempData["MySolution"] = JsonConvert.SerializeObject(updatePuzzle.Solution);

            return View("Play", viewModel);
        }
    }
}
