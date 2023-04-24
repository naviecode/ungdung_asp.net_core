using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using asp14_Validation.Models;

namespace asp14_Validation.Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly asp14_Validation.Models.MyBlogContext _context;

        public IndexModel(asp14_Validation.Models.MyBlogContext context)
        {
            _context = context;
        }

        public IList<Article> Article { get;set; }

        public async Task OnGetAsync(string SearchString)
        {
            Article = await _context.Article.ToListAsync();

            var qr = from a in _context.Article
                    orderby a.Created descending
                    select a;
            if(!string.IsNullOrEmpty(SearchString))
            {
              Article =  qr.Where(a=>a.Title.Contains(SearchString)).ToList();
            }
            else{
              Article = await qr.ToListAsync();
            }
            
        }
    }
}
