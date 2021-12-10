using System.Collections.Generic;
using System.Linq;

namespace Upletter.Models
{
    public class WordViewModel
    {
        public Word Word { get; set; }
        public string Action { get; set; } = "Create";
        public bool ReadOnly { get; set; } = false;
        public string Theme { get; set; } = "primary";
        public bool ShowAction { get; set; } = true;
    }
}
