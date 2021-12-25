using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Upletter.Models;

namespace Upletter.Pages
{
    public class WordListModel : PageModel
    {
        private DataContext context;
        public WordListModel(DataContext dbContext)
        {
            context = dbContext;
        }
        public IEnumerable<Word> Words { get; set; }

        public void OnGet()
        {
            Words = context.Words;
        }
    }
}
