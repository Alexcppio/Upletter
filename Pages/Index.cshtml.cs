using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Upletter.Models;

namespace Upletter.Pages
{
    public class IndexModel : PageModel
    {
        public string MainText { get; set; } = "Hello";
        private DataContext context;
        public IndexModel(DataContext ctx)
        {
            context = ctx;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            MainText += "a";
            await context.SaveChangesAsync();
            return RedirectToPage();
        }

        public string GetText()
        {
            return MainText;
        }
    }
}
