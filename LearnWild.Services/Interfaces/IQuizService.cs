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
		Task<AttemptViewModel> CreateAttemptAsync(string quizId, string studentId);
		Task<bool> ExistsAsync(string id);
		Task<AttemptViewModel?> GetAttemptAsync(string quizId, string studentId);
		Task<QuizStepModel> GetQuizStepAsync(string quizId, int step = 1);
		Task SaveStepAsync(string quizId, string questionId, string responseId, string studentId);
	}
}
