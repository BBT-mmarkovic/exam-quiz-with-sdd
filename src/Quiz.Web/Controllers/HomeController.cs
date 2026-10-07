using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Quiz.Web.Models;
using Quiz.Web.Services;

namespace Quiz.Web.Controllers;

public class HomeController(IQuizService quizService) : Controller
{
    public IActionResult Index()
    {
        return View(quizService.GetQuestion(0));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult SubmitAnswer([FromForm] int questionIndex, [FromForm] string? answer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        try
        {
            return Json(quizService.SubmitAnswer(questionIndex, answer));
        }
        catch (ArgumentException)
        {
            return BadRequest();
        }
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
