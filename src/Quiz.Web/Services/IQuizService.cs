using Quiz.Web.Models;

namespace Quiz.Web.Services;

public interface IQuizService
{
    QuestionViewModel GetQuestion(int index);

    AnswerSubmissionResult SubmitAnswer(int questionIndex, string? answer);
}
