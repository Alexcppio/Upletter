using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Upletter.Models;

namespace Upletter.Pages
{
    public class EditModel : EditorPageModel
    {
        public EditModel(DataContext dbContext) : base(dbContext) { }
        public async Task OnGetAsync(long id)
        {
            Word w = await this.DataContext.Words.FindAsync(id);
            ViewModel = ViewModelFactory.Edit(w);
        }
        public async Task<IActionResult>
            OnPostAsync([FromForm] Word w)
        {
            if (ModelState.IsValid)
            {
                DataContext.Words.Update(w);
                await DataContext.SaveChangesAsync();
                return RedirectToPage("WordList");
            }
            ViewModel = ViewModelFactory.Edit(w);
            return Page();
        }
    }
}
