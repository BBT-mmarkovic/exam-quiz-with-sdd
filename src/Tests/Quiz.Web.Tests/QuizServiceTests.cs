using Microsoft.Extensions.Options;
using Quiz.Web.Models;
using Quiz.Web.Services;

namespace Quiz.Web.Tests;

public class QuizServiceTests
{
    [Fact]
    public void GetQuestion_returns_the_requested_question_in_configuration_order()
    {
        var service = CreateService();

        var question = service.GetQuestion(1);

        Assert.Equal(1, question.Index);
        Assert.Equal("Second question", question.Text);
        Assert.Equal(new[] { "E", "F", "G", "H" }, question.Options);
    }

    [Fact]
    public void GetQuestion_does_not_expose_the_correct_answer()
    {
        var question = CreateService().GetQuestion(0);

        Assert.DoesNotContain(
            typeof(QuestionViewModel).GetProperties(),
            property => property.Name.Contains("CorrectAnswer", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void SubmitAnswer_marks_a_correct_answer_and_returns_the_next_question()
    {
        var service = CreateService();

        var result = service.SubmitAnswer(0, "A");

        Assert.True(result.IsCorrect);
        Assert.False(result.IsComplete);
        Assert.Equal(2, result.TotalQuestions);
        Assert.NotNull(result.NextQuestion);
        Assert.Equal(1, result.NextQuestion.Index);
        Assert.DoesNotContain(
            typeof(AnswerSubmissionResult).GetProperties(),
            property => property.Name.Contains("CorrectAnswer", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void SubmitAnswer_marks_a_wrong_answer_and_returns_the_next_question()
    {
        var service = CreateService();

        var result = service.SubmitAnswer(0, "B");

        Assert.False(result.IsCorrect);
        Assert.False(result.IsComplete);
        Assert.NotNull(result.NextQuestion);
        Assert.Equal(1, result.NextQuestion.Index);
    }

    [Fact]
    public void SubmitAnswer_completes_after_the_last_configured_question()
    {
        var service = CreateService();

        var result = service.SubmitAnswer(1, "E");

        Assert.True(result.IsCorrect);
        Assert.True(result.IsComplete);
        Assert.Null(result.NextQuestion);
        Assert.Equal(2, result.TotalQuestions);
    }

    [Fact]
    public void Quiz_length_is_based_on_all_configured_questions()
    {
        var questions = Enumerable.Range(0, 12)
            .Select(index => new QuestionDefinition
            {
                Text = $"Question {index}",
                Options = [$"Correct {index}", "B", "C", "D"],
                CorrectAnswer = $"Correct {index}"
            })
            .ToList();
        var service = new QuizService(Options.Create(new QuestionnaireOptions { Questions = questions }));

        var result = service.SubmitAnswer(10, "Correct 10");

        Assert.Equal(12, result.TotalQuestions);
        Assert.Equal(11, result.NextQuestion?.Index);
        Assert.False(result.IsComplete);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(2)]
    public void GetQuestion_rejects_an_invalid_question_index(int index)
    {
        var service = CreateService();

        Assert.Throws<ArgumentOutOfRangeException>(() => service.GetQuestion(index));
    }

    [Fact]
    public void SubmitAnswer_rejects_an_option_not_in_the_question()
    {
        var service = CreateService();

        Assert.Throws<ArgumentException>(() => service.SubmitAnswer(0, "Unknown"));
    }

    private static QuizService CreateService() => new(Options.Create(new QuestionnaireOptions
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
}
