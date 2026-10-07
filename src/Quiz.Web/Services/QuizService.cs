using Microsoft.Extensions.Options;
using Quiz.Web.Models;

namespace Quiz.Web.Services;

public sealed class QuizService(IOptions<QuestionnaireOptions> questionnaire) : IQuizService
{
    private readonly IReadOnlyList<QuestionDefinition> _questions =
        questionnaire.Value.Questions
        ?? throw new InvalidOperationException("Die Fragenkonfiguration enthält keine Fragen.");

    public QuestionViewModel GetQuestion(int index)
    {
        if (index < 0 || index >= _questions.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), "Die Fragenummer ist ungültig.");
        }

        return ToViewModel(index);
    }

    public AnswerSubmissionResult SubmitAnswer(int questionIndex, string? answer)
    {
        if (questionIndex < 0 || questionIndex >= _questions.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(questionIndex), "Die Fragenummer ist ungültig.");
        }

        var question = _questions[questionIndex];
        if (answer is null || question.Options is null || !question.Options.Contains(answer, StringComparer.Ordinal))
        {
            throw new ArgumentException("Die Antwortoption ist ungültig.", nameof(answer));
        }

        var isCorrect = string.Equals(answer, question.CorrectAnswer, StringComparison.Ordinal);
        var nextIndex = questionIndex + 1;
        var isComplete = nextIndex >= _questions.Count;

        return new AnswerSubmissionResult(
            isCorrect,
            isComplete,
            _questions.Count,
            isComplete ? null : ToViewModel(nextIndex));
    }

    private QuestionViewModel ToViewModel(int index)
    {
        var question = _questions[index];
        var text = question.Text
            ?? throw new InvalidOperationException($"Frage {index + 1} hat keinen Fragetext.");
        var options = question.Options
            ?? throw new InvalidOperationException($"Frage {index + 1} hat keine Antwortoptionen.");

        return new QuestionViewModel(index, _questions.Count, text, options);
    }
}
