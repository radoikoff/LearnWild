﻿using LearnWild.Data;
using LearnWild.Data.Models;
using LearnWild.Services.Interfaces;
using LearnWild.Web.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Services
{
    public class EventService : IEventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(EventFormModel model, string courseId)
        {
            TrainingEvent trainingEvent = new TrainingEvent()
            {
                CourseId = Guid.Parse(courseId),
                Start = model.Start ?? DateTime.MinValue,
                End = model.End ?? DateTime.MinValue,
                TeacherId = Guid.Parse(model.TeacherId),
                Active = model.Active
            };

            _context.TrainingEvents.Add(trainingEvent);
            await _context.SaveChangesAsync();
        }

        public Task<bool> IsScheduled(DateTime? start, DateTime? end, string courseId, string teacherId)
        {
            return Task.FromResult(true);
        }
    }
}
