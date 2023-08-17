using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Web.ViewModels.Quiz
{
    public class QuizStepModel
    {
        public string QuestionId { get; set; } = null!;

        public string QuestionText { get; set; } = null!;

        public IEnumerable<ResponseViewModel> Responses { get; set; } = new HashSet<ResponseViewModel>();

        public string? ResponseId { get; set; }

        public IEnumerable<StepsViewModel> Steps { get; set; } = new HashSet<StepsViewModel>();

        public int CurrentStep { get; set; }

        public int MaxStep => Steps.Max(s => s.StepNumber);
    }
}
