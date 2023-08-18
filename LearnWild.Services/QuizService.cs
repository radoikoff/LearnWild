using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Quiz;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
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

        public async Task<QuizStepModel> GetQuizStepAsync(string quizId, int step)
        {

            var model = await _dbContext.Questions
                                        .Where(q => q.QuizId == Guid.Parse(quizId) && q.SequentialNumber == step)
                                        .Select(q => new QuizStepModel()
                                        {
                                            QuizId = q.QuizId.ToString(),
                                            QuestionId = q.Id.ToString(),
                                            QuestionText = q.Text,
                                            Responses = q.Responses.Select(r => new ResponseViewModel()
                                            {
                                                Id = r.Id.ToString(),
                                                Text = r.Text,
                                                Selected = r.StudentResponses.Any(sr => sr.ResponseId == r.Id &&
                                                                                  sr.QuizAttempt.Quiz.Id == Guid.Parse(quizId))
                                            }),
                                            CurrentStep = q.SequentialNumber,
                                        })
                                        .FirstOrDefaultAsync();

            if (model == null)
            {
                throw new InvalidOperationException("Such quiz or step doesn't exists!");
            }

            var steps = await _dbContext.Questions
                                       .Where(q => q.Quiz.Id == Guid.Parse(quizId))
                                       .Select(q => new StepsViewModel()
                                       {
                                           QuestionId = q.Id.ToString(),
                                           StepNumber = q.SequentialNumber
                                       })
                                       .ToArrayAsync();

            model.Steps = steps;

            return model;
        }

        public async Task SaveStepAsync(string quizId, string questionId, string responseId, string studentId)
        {
            var studentResponse = await _dbContext.StudentResponses.SingleOrDefaultAsync(sr =>
                sr.QuizAttempt.QuizId == Guid.Parse(quizId) &&
                sr.QuestionId == Guid.Parse(questionId));

            if (studentResponse == null)
            {
                var quizAttempt = await _dbContext.QuizAttempts.FirstAsync(qa => qa.QuizId == Guid.Parse(quizId) &&
                                        qa.StudentId == Guid.Parse(studentId));

                studentResponse = new StudentResponse()
                {
                    QuizAttempt = quizAttempt,
                    QuestionId = Guid.Parse(questionId),
                    ResponseId = Guid.Parse(responseId),
                    RespondedOn = DateTime.UtcNow,
                };

                _dbContext.StudentResponses.Add(studentResponse);
            }
            else
            {
                studentResponse.ResponseId = Guid.Parse(responseId);
                studentResponse.RespondedOn = DateTime.UtcNow;
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
