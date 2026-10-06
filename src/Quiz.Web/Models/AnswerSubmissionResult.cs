namespace Quiz.Web.Models;

public sealed record AnswerSubmissionResult(bool IsCorrect, string CorrectAnswer, string Message);
