using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Upletter.Models;

namespace Upletter.Pages
{
    public class CreateModel : EditorPageModel
    {
        public CreateModel(DataContext dbContext) : base(dbContext) { }
        public void OnGet()
        {
            ViewModel = ViewModelFactory.Create(new Word());
        }
        public async Task<IActionResult>
            OnPostAsync([FromForm] Word word)
        {
            if (ModelState.IsValid)
            {
                word.WordId = default;
                DataContext.Words.Add(word);
                await DataContext.SaveChangesAsync();
                return RedirectToPage("WordList");
            }
            ViewModel =
                ViewModelFactory.Create(word);
            return Page();
        }
    }
}
