using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Web.ViewModels.Course
{
    public class CourseScoresViewModel
    {
        public string CourseId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public int MaxCredits { get; set; }

        public IEnumerable<StudentScoreViewModel> Students { get; set; } = new HashSet<StudentScoreViewModel>();
    }
}
