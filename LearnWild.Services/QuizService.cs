using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Quiz;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Services
{
    public class QuizService : IQuizService
    {
        private readonly ApplicationDbContext _dbContext;

        public QuizService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AttemptViewModel> CreateAttemptAsync(string quizId, string studentId)
        {
            var attempt = new QuizAttempt()
            {
                QuizId = Guid.Parse(quizId),
                StudentId = Guid.Parse(studentId),
                StartedAt = DateTime.UtcNow,
            };

            _dbContext.QuizAttempts.Add(attempt);
            await _dbContext.SaveChangesAsync();

            return new AttemptViewModel
            {
                Id = attempt.Id.ToString(),
                Active = true
            };
        }

        public async Task<bool> ExistsAsync(string id)
        {
            return await _dbContext.Quizzes.AnyAsync(q => q.Id == Guid.Parse(id));
        }

        public async Task<AttemptViewModel?> GetAttemptAsync(string quizId, string studentId)
        {
            return await _dbContext.QuizAttempts
                                   .Where(a => a.QuizId == Guid.Parse(quizId) && a.StudentId == Guid.Parse(studentId))
                                   .Select(a => new AttemptViewModel()
                                   {
                                       Id = a.Id.ToString(),
                                       Active = a.FinishedAt.HasValue == false,
                                   })
                                   .FirstOrDefaultAsync();
        }

        public async Task<QuizStepModel> GetQuizStepAsync(string questionId, string studentId)
        {
            var model = await _dbContext.Questions
                                        .Where(q => q.Id == Guid.Parse(questionId))
                                        .Select(q => new QuizStepModel()
                                        {
                                            QuestionId = q.Id.ToString(),
                                            QuestionText = q.Text,
                                            Responses = q.Responses.Select(r => new ResponseViewModel()
                                            {
                                                Id = r.Id.ToString(),
                                                Text = r.Text,
                                                Selected = r.StudentResponses.Any(sr => sr.ResponseId == r.Id &&
                                                                                  sr.QuizAttempt.StudentId == Guid.Parse(studentId)),
                                            }),
                                            CurrentStep = q.SequentialNumber,
                                        })
                                        .FirstOrDefaultAsync();

            if (model == null)
            {
                throw new InvalidOperationException("Such question do not exists!");
            }

            var quiz = await _dbContext.Quizzes
                                       .Include(q => q.Questions)
                                       .FirstOrDefaultAsync(q => q.Questions.Any(q => q.Id == Guid.Parse(questionId)));

            if (quiz == null)
            {
                throw new InvalidOperationException("Quiz cannot be found!");
            }

            var steps = quiz.Questions.Select(q => new StepsViewModel()
            {
                QuestionId = q.Id.ToString(),
                StepNumber = q.SequentialNumber
            })
            .ToArray();

            model.Steps = steps;

            return model;
        }

        public Task<bool> HasStudentAccessToQuestionAsync(string questionId, string studentId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> QuestionExistsAsync(string questionId)
        {
            return await _dbContext.Questions.AnyAsync(q => q.Id == Guid.Parse(questionId));
        }

        public Task SaveStepAsync(string questionId, string responseId)
        {
            return Task.CompletedTask;
        }
    }
}
