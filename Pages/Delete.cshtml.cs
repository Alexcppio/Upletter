using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Upletter.Models;

namespace Upletter.Pages
{
    public class DeleteModel : EditorPageModel
    {
        public DeleteModel(DataContext dbContext) : base(dbContext) { }
        public async Task OnGetAsync(long id)
        {
            ViewModel = ViewModelFactory.Delete(
                await DataContext.Words.FindAsync(id));
        }
        public async Task<IActionResult>
            OnPostAsync([FromForm] Word word)
        {
            DataContext.Words.Remove(word);
            await DataContext.SaveChangesAsync();
            return RedirectToPage("WordList");
        }
    }
}
