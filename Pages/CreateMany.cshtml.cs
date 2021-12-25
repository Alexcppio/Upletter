using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Upletter.Models;

namespace Upletter.Pages
{
    public class CreateManyModel : PageModel
    {
        private DataContext context;
        public List<Word> Words { get; set; }
        public Word w1 { get; set; } = new Word { WordId = default, Meaning = "One" };
        public Word w2 { get; set; } = new Word { WordId = default, Meaning = "Two" };
        public Word w3 { get; set; } = new Word { WordId = default, Meaning = "Three" };
        public CreateManyModel(DataContext dbContext)
        {
            Words = new List<Word>();
            Words.Add(w1);
            Words.Add(w2);
            Words.Add(w3);
            context = dbContext;
        }
        public void OnGet()
        {
            
        }
    }
}
