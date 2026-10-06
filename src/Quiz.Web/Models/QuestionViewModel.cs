namespace Quiz.Web.Models;

public sealed record QuestionViewModel(int Index, string Text, IReadOnlyList<string> Options);
