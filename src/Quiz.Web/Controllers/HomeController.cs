using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Quiz.Web.Models;

namespace Quiz.Web.Controllers;

public class HomeController : Controller
{
    private const string CorrectAnswer = "Ottawa";

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SubmitAnswer([FromForm] string? answer)
    {
        if (answer is not ("Toronto" or "Ottawa" or "Montreal" or "Vancouver"))
        {
            return BadRequest();
        }

        var isCorrect = answer == CorrectAnswer;
        var message = isCorrect ? "✅ richtig" : "❌ leider falsch";

        return Json(new AnswerSubmissionResult(isCorrect, CorrectAnswer, message));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
