using AhorcadoMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AhorcadoMVC.Controllers
{
    public class AhorcadoController : Controller
    {
        private static Hangman _game;

        public IActionResult Ahorcado()
        {
            if (_game == null)
            {
                return RedirectToAction("Start");
            }

            return View(_game);
        }

        [HttpGet]
        public IActionResult Start()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Start(string wordToGuess)
        {
            _game = new Hangman(wordToGuess);
            return RedirectToAction("Ahorcado");
        }

        [HttpPost]
        public IActionResult Guess(char letter)
        {
            _game.Guess(letter);

            if (_game.IsGameWon())
            {
                ViewBag.Message = "You won!";
            }
            else if (_game.IsGameLost())
            {
                ViewBag.Message = "You lost! The word was " + _game.WordToGuess;
            }

            return View("Ahorcado", _game);
        }
    }
}
