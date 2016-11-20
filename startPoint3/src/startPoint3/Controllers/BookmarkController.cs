using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using startPoint3.Repository;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace startPoint3.Controllers
{
    public class BookmarkController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

            var repo = new BookmarkRepository("peter");
            var Bookmarks = repo.GetBookmarks("AAA");

            return View(Bookmarks);
        }
    }

}
