using Microsoft.Extensions.Options;

namespace Quiz.Web.Models;

public sealed class QuestionnaireOptionsValidator : IValidateOptions<QuestionnaireOptions>
{
    public ValidateOptionsResult Validate(string? name, QuestionnaireOptions options)
    {
        if (options.Questions is not { Count: > 0 } questions)
        {
            return ValidateOptionsResult.Fail("Die Fragenkonfiguration muss mindestens eine Frage enthalten.");
        }

        var errors = new List<string>();
        for (var questionIndex = 0; questionIndex < questions.Count; questionIndex++)
        {
            var question = questions[questionIndex];
            var label = $"Frage {questionIndex + 1}";

            if (question is null)
            {
                errors.Add($"{label} darf nicht leer sein.");
                continue;
            }

            if (string.IsNullOrWhiteSpace(question.Text))
            {
                errors.Add($"{label} benötigt einen Fragetext.");
            }

            if (question.Options is not { Count: 4 } answerOptions)
            {
                errors.Add($"{label} muss genau vier Antwortoptionen enthalten.");
                continue;
            }

            if (answerOptions.Any(string.IsNullOrWhiteSpace))
            {
                errors.Add($"{label} darf keine leeren Antwortoptionen enthalten.");
            }

            if (answerOptions.Distinct(StringComparer.OrdinalIgnoreCase).Count() != answerOptions.Count)
            {
                errors.Add($"{label} darf keine doppelten Antwortoptionen enthalten.");
            }

            if (string.IsNullOrWhiteSpace(question.CorrectAnswer)
                || !answerOptions.Contains(question.CorrectAnswer, StringComparer.Ordinal))
            {
                errors.Add($"{label} benötigt eine richtige Antwort aus den Antwortoptionen.");
            }
        }

        return errors.Count == 0
            ? ValidateOptionsResult.Success
            : ValidateOptionsResult.Fail(errors);
    }
}
