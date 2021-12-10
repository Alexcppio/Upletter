using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Upletter.Models;

namespace Upletter.Pages
{
    public class EditorPageModel : PageModel
    {
        public EditorPageModel(DataContext dbContext)
        {
            DataContext = dbContext;
        }
        public DataContext DataContext { get; set; }
        public IEnumerable<Word> Words => DataContext.Words;
        public WordViewModel ViewModel { get; set; }
    }
}
