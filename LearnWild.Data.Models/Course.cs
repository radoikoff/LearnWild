﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static LearnWild.Common.EntityValidationConstants.Course;

namespace LearnWild.Data.Models
{
    public class Course
    {
        public Course()
        {
            this.Id = Guid.NewGuid();
            this.Topics = new HashSet<Topic>();
            this.TrainingEvents = new HashSet<TrainingEvent>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        public int Duration { get; set; }

        public int MaxCredits { get; set; }

        public decimal? Price { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int TypeId { get; set; }
        public CourseType Type { get; set; } = null!;

        public Guid? DefaultTeacherId { get; set; }
        public ApplicationUser? DefaultTeacher { get; set; } = null!;

        public bool Deleted { get; set; }

        public DateTime CreatedOn { get; set; }

        public Guid CreatedBy { get; set; }

        public ICollection<Topic> Topics { get; set; }

        public ICollection<TrainingEvent> TrainingEvents { get; set; }

    }
}
