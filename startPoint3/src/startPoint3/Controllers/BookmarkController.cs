using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using startPoint3.Repository;
using startPoint3.Services;

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


        public void ReScanBookmarkThumbnails()
        {

            var repo = new BookmarkRepository("peter");
            var bookmarks = repo.GetBookmarks("AAA");

            var thumbNailService = new ThumbnailExtractor();

            int count = 0;

            foreach (var section in bookmarks.Sections)
            {

                foreach (var link in section.links)
                {
                    try
                    {

                        if (String.IsNullOrEmpty(link.imgUrl) && count<200)
                        {
                            count++;

                            var thumbnailLink = thumbNailService.GetSiteIconUrl(link.linkUrl);
                            if (!String.IsNullOrEmpty(thumbnailLink))
                            {
                                if (!thumbnailLink.StartsWith("http"))
                                {
                                    var linkUrl = new Uri(link.linkUrl);
                                    thumbnailLink = linkUrl.OriginalString.Replace(linkUrl.AbsolutePath, "") + thumbnailLink;

                                }

                                link.imgUrl = thumbnailLink;
                            }
                        }
                    }
                    catch { }
                }
            }


            repo.UpdateBookmarks(bookmarks);
            
            
        }

    }

}
