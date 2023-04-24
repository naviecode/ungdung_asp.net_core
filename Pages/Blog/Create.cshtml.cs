using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using asp14_Validation.Models;

namespace asp14_Validation.Pages_Blog
{
    public class CreateModel : PageModel
    {
        private readonly asp14_Validation.Models.MyBlogContext _context;

        public CreateModel(asp14_Validation.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Article Article { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Article.Add(Article);
            
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
