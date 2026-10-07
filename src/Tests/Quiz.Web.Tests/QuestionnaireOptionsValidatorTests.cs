using System.Text.Json;
using Microsoft.Extensions.Options;
using Quiz.Web.Models;

namespace Quiz.Web.Tests;

public class QuestionnaireOptionsValidatorTests
{
    private readonly QuestionnaireOptionsValidator _validator = new();

    [Fact]
    public void Validate_accepts_multiple_valid_questions_without_a_fixed_limit()
    {
        var options = new QuestionnaireOptions
        {
            Questions = Enumerable.Range(1, 12).Select(CreateQuestion).ToList()
        };

        var result = _validator.Validate(Options.DefaultName, options);

        Assert.True(result.Succeeded);
    }

    [Fact]
    public void Shipped_questionnaire_file_contains_a_valid_initial_quiz()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "questionnaire.json");
        using var stream = File.OpenRead(path);
        var options = JsonSerializer.Deserialize<QuestionnaireOptions>(stream);

        Assert.NotNull(options);
        Assert.Equal(4, options.Questions?.Count);
        Assert.True(_validator.Validate(Options.DefaultName, options).Succeeded);
    }

    [Fact]
    public void Validate_rejects_an_empty_questionnaire()
    {
        var options = new QuestionnaireOptions { Questions = [] };

        var result = _validator.Validate(Options.DefaultName, options);

        Assert.False(result.Succeeded);
    }

    [Fact]
    public void Validate_rejects_a_questionnaire_without_questions()
    {
        var options = new QuestionnaireOptions { Questions = null };

        var result = _validator.Validate(Options.DefaultName, options);

        Assert.False(result.Succeeded);
    }

    [Fact]
    public void Validate_rejects_a_question_without_exactly_four_options()
    {
        var question = CreateQuestion(1);
        question.Options = ["A", "B", "C"];
        var options = new QuestionnaireOptions { Questions = [question] };

        var result = _validator.Validate(Options.DefaultName, options);

        Assert.False(result.Succeeded);
    }

    [Fact]
    public void Validate_rejects_duplicate_options()
    {
        var question = CreateQuestion(1);
        question.Options = ["A", "B", "B", "D"];
        var options = new QuestionnaireOptions { Questions = [question] };

        var result = _validator.Validate(Options.DefaultName, options);

        Assert.False(result.Succeeded);
    }

    [Fact]
    public void Validate_rejects_empty_options()
    {
        var question = CreateQuestion(1);
        question.Options = ["A", " ", "C", "D"];
        var options = new QuestionnaireOptions { Questions = [question] };

        var result = _validator.Validate(Options.DefaultName, options);

        Assert.False(result.Succeeded);
    }

    [Fact]
    public void Validate_rejects_a_correct_answer_not_in_the_options()
    {
        var question = CreateQuestion(1);
        question.CorrectAnswer = "Not an option";
        var options = new QuestionnaireOptions { Questions = [question] };

        var result = _validator.Validate(Options.DefaultName, options);

        Assert.False(result.Succeeded);
    }

    [Fact]
    public void Validate_rejects_missing_question_text()
    {
        var question = CreateQuestion(1);
        question.Text = " ";
        var options = new QuestionnaireOptions { Questions = [question] };

        var result = _validator.Validate(Options.DefaultName, options);

        Assert.False(result.Succeeded);
    }

    private static QuestionDefinition CreateQuestion(int number) => new()
    {
        Text = $"Question {number}",
        Options = ["A", "B", "C", "D"],
        CorrectAnswer = "A"
    };
}
