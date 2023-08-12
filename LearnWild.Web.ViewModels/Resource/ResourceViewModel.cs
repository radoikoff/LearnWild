using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnWild.Web.ViewModels.Resource
{
    public class ResourceViewModel
    {
        public string Id { get; set; } = null!;

        public string DisplayName { get; set; } = null!;

        public string? FileName { get; set; }

        public string? Url { get; set; }

        public bool IsFile => FileName != null;
    }
}
