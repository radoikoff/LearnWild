using LearnWild.Web.ViewModels.Quiz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Services.Interfaces
{
	public interface IQuizService
	{
		Task<QuizStepModel> GetQuizStepAsync(string questionId, string studentId);
		Task<bool> HasStudentAccessToQuestionAsync(string questionId, string studentId);
		Task<bool> QuestionExistsAsync(string questionId);
		Task SaveStepAsync(string questionId, string responseId);
	}
}
