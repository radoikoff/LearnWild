using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Web.ViewModels.Course
{
    public class StudentScoreViewModel
    {
        public string Id { get; set; } = null!;

        public string FullName { get; set; } = null!;

        public int? Credits { get; set; }

        public decimal? Score { get; set; }
    }
}
