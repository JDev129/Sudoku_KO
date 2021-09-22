using SudokuMaster.Helpers;
using SudokuMaster.Infrastructure;
using SudokuMaster.Models;
using SudokuMaster.Sudoku_Infrastructure;
using System;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace SudokuMaster.Controllers
{
    public class SudokuController : Controller
    {
        private ApplicationModel dbCtx;

        public SudokuController()
        {
        }

        public ActionResult Index()
        {
            var latestGame = dbCtx.Games.Where(x => x.Owner == Environment.UserName && 
                                                    x.Domain == Environment.UserDomainName &&
                                                    x.FinishedSuccesfully == false)
                                        .OrderByDescending(x => x.ID).FirstOrDefault();
            return View(new NewGameViewModel()
            {
                EastyCount = 65,
                MediumCount = 55,
                HardCount = 45,
                DiabolicalCount = 30,
                HasActiveGame = latestGame != null,
                ActiveGameID = latestGame != null ? latestGame.ID : -1
            });
        }

        public ActionResult TestFailure()
        {
            var myNewPuzzle = new NewPuzzle();
            if (myNewPuzzle.isValidPuzzle)
            {
                var latestGame = DateTime.Now;
                dbCtx.Games.Add(new ASudokuGame()
                {
                    DateTimeStarted = latestGame,
                    Owner = Environment.UserName,
                    Domain = Environment.UserDomainName,
                    Moves = myNewPuzzle.Moves,
                    Solution = myNewPuzzle.Solution,
                    Difficulty = "InvalidTest",
                    FinishedSuccesfully = false
                });
                dbCtx.SaveChanges();
                var newRecord = dbCtx.Games.Where(x => x.Owner == Environment.UserName &&
                                                  x.Domain == Environment.UserDomainName)
                                           .OrderByDescending(x => x.ID).FirstOrDefault();
                var newID = 0;
                if (newRecord != null)
                    newID = newRecord.ID;
                return View("Play", new SudokuViewModel()
                {
                    ID = newID,
                    CurrentMove = myNewPuzzle.Moves.FirstOrDefault(),
                    Puzzle = myNewPuzzle.Moves,
                    Solution = myNewPuzzle.Solution,
                    DifficultyLevel = "Invalid"
                });
            }
            else
            {
                return View("Play", new SudokuViewModel()
                {
                    //ID = newID,
                    //CurrentMove = myNewPuzzle.Moves.FirstOrDefault(),
                    //Puzzle = myNewPuzzle.Moves,
                    //Solution = myNewPuzzle.Solution,
                    //DifficultyLevel = difficulty
                    CurrentMove = new SudokuMove(),
                    Puzzle = new System.Collections.Generic.List<SudokuMove>(),
                    Solution = new SudokuMove()
                });
            }
        }

        public ActionResult Play(NewGameViewModel vm)
        {
            if (vm.PlayActiveGame)
            {
                var latestGame = dbCtx.Games.Where(x => x.ID == vm.ActiveGameID).FirstOrDefault();
                return View(new SudokuViewModel()
                {
                    ID = latestGame.ID,
                    CurrentMove = latestGame.Moves.Last(),
                    Puzzle = latestGame.Moves,
                    Solution = latestGame.Solution,
                    DifficultyLevel = latestGame.Difficulty
                });
            }
            var difficulty = vm.SelectedDifficulty == 0 ? "Easy" :
                vm.SelectedDifficulty == 1 ? "Medium" :
                    vm.SelectedDifficulty == 2 ? "Hard" :  "Diabolical";
            var puzzleCount = vm.SelectedDifficulty == 0 ? vm.EastyCount : 
                vm.SelectedDifficulty == 1 ? vm.MediumCount : 
                vm.SelectedDifficulty == 2 ? vm.HardCount : 
                vm.SelectedDifficulty == 3 ? vm.DiabolicalCount : throw new ArgumentOutOfRangeException("SelectedDifficulty");
            var myNewPuzzle = new NewPuzzle(puzzleCount);
            if (myNewPuzzle.isValidPuzzle)
            {
                var latestGame = DateTime.Now;
                dbCtx.Games.Add(new ASudokuGame()
                {
                    DateTimeStarted = latestGame,
                    Owner = Environment.UserName,
                    Domain = Environment.UserDomainName,
                    Moves = myNewPuzzle.Moves,
                    Solution = myNewPuzzle.Solution,
                    Difficulty = difficulty,
                    FinishedSuccesfully = false
                });
                dbCtx.SaveChanges();
                
                var newRecord = dbCtx.Games.Where(x => x.Owner == Environment.UserName && 
                                                  x.Domain == Environment.UserDomainName)
                                           .OrderByDescending(x => x.ID).FirstOrDefault();
                var newID = 0;
                if (newRecord != null)
                    newID = newRecord.ID;

                return View(new SudokuViewModel()
                {
                    ID = newID,
                    CurrentMove = myNewPuzzle.Moves.FirstOrDefault(),
                    Puzzle = myNewPuzzle.Moves,
                    Solution = myNewPuzzle.Solution,
                    DifficultyLevel = difficulty
                });
            }
            else
            {
                return View("SomethingWentWrong", new ErrorViewModel()
                {
                    Message = "Something went wrong with your request. Please try again."
                });
            }
        }

        public ActionResult MakeAMove(int gameID, int guess, int guessOrdinal, int guessColumn, int guessRow)
        {
            var thePuzzle = this.dbCtx.Games.Where(x => x.ID == gameID).FirstOrDefault();
            if(thePuzzle == null)
            {
                throw new Exception("The Puzzle ID of " + gameID + " was not found");
            }
            var theSol = thePuzzle.Solution;
            var puzzleMoves = thePuzzle.Moves;

            try
            {
                ISudokoh updatePuzzle = null;
                var myPuzzle = new ActivePuzzle(theSol, puzzleMoves);
                if (guess > 0 && guessOrdinal > 0)
                {
                    foreach (var move in puzzleMoves.Where(x => x.MoveOrder > guessOrdinal).ToList())
                        dbCtx.Moves.Remove(move);
                    updatePuzzle = myPuzzle.GuessAtPosition(
                            guessOrdinal,
                            SudColumn.ConvertCol(guessColumn),
                            SudDigit.ConvertSudRow(guessRow),
                            SudDigit.ConvertSudNumber(guess));
                }
                else if (guess > 0)
                    updatePuzzle = myPuzzle.NewGuess(
                            SudColumn.ConvertCol(guessColumn),
                            SudDigit.ConvertSudRow(guessRow),
                            SudDigit.ConvertSudNumber(guess));
                else if (guessOrdinal > 0)
                {
                    foreach (var move in puzzleMoves.Where(x => x.MoveOrder > guessOrdinal).ToList())
                        dbCtx.Moves.Remove(move);
                    updatePuzzle = myPuzzle.ClearGuessAtPostion(
                            guessOrdinal,
                            SudColumn.ConvertCol(guessColumn),
                            SudDigit.ConvertSudRow(guessRow));
                }
                else
                {
                    dbCtx.Moves.Remove(puzzleMoves.Last());
                    updatePuzzle = myPuzzle.ClearGuess(
                            SudColumn.ConvertCol(guessColumn),
                            SudDigit.ConvertSudRow(guessRow));
                }

                if (updatePuzzle.Solved && !updatePuzzle.InvalidSolution)
                    thePuzzle.FinishedSuccesfully = true;
                dbCtx.SaveChanges();

                return View("Play", new SudokuViewModel()
                {
                    ID = thePuzzle.ID,
                    CurrentMove = updatePuzzle.Moves.Last(),
                    Puzzle = updatePuzzle.Moves,
                    Solution = updatePuzzle.Solution,
                    PuzzleSolved = updatePuzzle.Solved,
                    InvalidSolution = updatePuzzle.InvalidSolution,
                    GuessOrdinal = 0,
                    DifficultyLevel = thePuzzle.Difficulty
                });
            }
            catch (Exception ex)
            {
                return View("SomethingWentWrong", new ErrorViewModel()
                {
                    Message = ex.Message
                });
            }
        }
    }
}
