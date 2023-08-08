using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Web.ViewModels.Topic
{
    public class AllTopicsViewModel
    {
        public string Id { get; set; } = null!;

        public string CourseId { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public int ResourceCount { get; set; }
    }
}
