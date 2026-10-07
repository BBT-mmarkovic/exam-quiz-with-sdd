namespace Quiz.Web.Models;

public sealed record QuestionViewModel(
    int Index,
    int TotalQuestions,
    string Text,
    IReadOnlyList<string> Options);
