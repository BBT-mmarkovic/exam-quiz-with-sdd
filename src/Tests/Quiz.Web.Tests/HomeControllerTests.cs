using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Quiz.Web.Controllers;
using Quiz.Web.Models;
using Quiz.Web.Services;

namespace Quiz.Web.Tests;

public class HomeControllerTests
{
    [Fact]
    public void Index_shows_only_the_first_question_without_its_correct_answer()
    {
        var controller = CreateController();

        var result = Assert.IsType<ViewResult>(controller.Index());
        var model = Assert.IsType<QuestionViewModel>(result.Model);

        Assert.Equal("First question", model.Text);
        Assert.Equal(new[] { "A", "B", "C", "D" }, model.Options);
    }

    [Fact]
    public void SubmitAnswer_returns_the_next_question_without_the_answer_key()
    {
        var controller = CreateController();

        var result = Assert.IsType<JsonResult>(controller.SubmitAnswer(0, "A"));
        var response = Assert.IsType<AnswerSubmissionResult>(result.Value);

        Assert.True(response.IsCorrect);
        Assert.False(response.IsComplete);
        Assert.Equal(2, response.TotalQuestions);
        Assert.Equal("Second question", response.NextQuestion?.Text);
    }

    [Fact]
    public void SubmitAnswer_rejects_an_invalid_question_index()
    {
        var controller = CreateController();

        Assert.IsType<BadRequestResult>(controller.SubmitAnswer(10, "A"));
    }

    [Fact]
    public void SubmitAnswer_rejects_an_option_not_in_the_question()
    {
        var controller = CreateController();

        Assert.IsType<BadRequestResult>(controller.SubmitAnswer(0, "Unknown"));
    }

    [Fact]
    public void SubmitAnswer_rejects_invalid_model_binding()
    {
        var controller = CreateController();
        controller.ModelState.AddModelError("questionIndex", "Invalid question index.");

        Assert.IsType<BadRequestResult>(controller.SubmitAnswer(0, "A"));
    }

    [Fact]
    public void SubmitAnswer_requires_an_anti_forgery_token()
    {
        var action = typeof(HomeController).GetMethod(nameof(HomeController.SubmitAnswer));

        Assert.NotNull(action);
        Assert.NotNull(action.GetCustomAttribute<ValidateAntiForgeryTokenAttribute>());
    }

    private static HomeController CreateController()
    {
        var service = new QuizService(Options.Create(new QuestionnaireOptions
        {
            Questions =
            [
                new QuestionDefinition
                {
                    Text = "First question",
                    Options = ["A", "B", "C", "D"],
                    CorrectAnswer = "A"
                },
                new QuestionDefinition
                {
                    Text = "Second question",
                    Options = ["E", "F", "G", "H"],
                    CorrectAnswer = "E"
                }
            ]
        }));

        return new HomeController(service);
    }
}
