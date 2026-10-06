using Microsoft.AspNetCore.Mvc;
using Quiz.Web.Controllers;
using Quiz.Web.Models;

namespace Quiz.Web.Tests;

public class AnswerSubmissionTests
{
    [Theory]
    [InlineData("Ottawa", true, "✅ richtig")]
    [InlineData("Toronto", false, "❌ leider falsch")]
    [InlineData("Montreal", false, "❌ leider falsch")]
    [InlineData("Vancouver", false, "❌ leider falsch")]
    public void SubmitAnswer_checks_valid_answers(string answer, bool expectedCorrectness, string expectedMessage)
    {
        var controller = new HomeController();

        var result = controller.SubmitAnswer(answer);

        var json = Assert.IsType<JsonResult>(result);
        var response = Assert.IsType<AnswerSubmissionResult>(json.Value);
        Assert.Equal(expectedCorrectness, response.IsCorrect);
        Assert.Equal("Ottawa", response.CorrectAnswer);
        Assert.Equal(expectedMessage, response.Message);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("ottawa")]
    [InlineData("Calgary")]
    public void SubmitAnswer_rejects_invalid_answers(string? answer)
    {
        var controller = new HomeController();

        var result = controller.SubmitAnswer(answer);

        Assert.IsType<BadRequestResult>(result);
    }
}
