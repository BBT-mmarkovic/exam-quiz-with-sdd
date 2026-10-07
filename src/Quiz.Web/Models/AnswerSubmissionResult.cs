namespace Quiz.Web.Models;

public sealed record AnswerSubmissionResult(
    bool IsCorrect,
    bool IsComplete,
    int TotalQuestions,
    QuestionViewModel? NextQuestion);
