using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using startPoint3.Models.ImportBookmarks;
using HtmlAgilityPack;
using System.IO;
using System.Text.RegularExpressions;
using NuGet.Protocol.Core.v3;
using MongoDB.Driver;
using startPoint3.Models.Bookmarks;
using startPoint3.Repository;

namespace startPoint3.Controllers
{
    public class ImportBookmarksController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(ImportBookmarks importBookmarks)
        {


            if (ModelState.IsValid)
            {

                var buckeName = importBookmarks.Bucket;

                var streamToImprove = importBookmarks.NetscapeBookmarkFile.OpenReadStream();
                MemoryStream improvedStream = ImproveDocumentStructure(streamToImprove);

                Dictionary<string, List<Link>> bookmarksDictonary = ReadBookmarksIntoDictonary(improvedStream);
                                            
                var sections = new List<Section>();


                foreach (var sectionGroup in bookmarksDictonary.GroupBy(kp => kp.Key))
                {
                  sections.Add(new Section(sectionGroup.Key, sectionGroup.First().Value));
                }

                var bookmarks = new Bookmarks(buckeName,sections);
                              

                var repo = new BookmarkRepository("peter");

                repo.AddBookmarks(bookmarks);

                //string linkJson = sections.ToJson();

            }


            //TODO: add success message - ViewBag.
            return View();
        }


       


        private Dictionary<string, List<Link>> ReadBookmarksIntoDictonary(MemoryStream improvedStream)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(improvedStream);


            var sections = new Dictionary<string, List<Link>>();

            var nodes = doc.DocumentNode.SelectNodes("//a");
            foreach (HtmlNode item in nodes)
            {
                ProcessBookmark(sections, item);
            }

            return sections;
        }

        private void ProcessBookmark(Dictionary<string, List<Link>> bookmarks, HtmlNode item)
        {
            bool keepLocking = true;
            var currentNode = item;
            while (keepLocking)
            {
                currentNode = currentNode.ParentNode;
                if (currentNode.Name == "dl")
                {
                    keepLocking = false;
                }
            }

            string sectionName = "";

            if (currentNode.ParentNode.SelectSingleNode("h3") != null)
            {
                sectionName = currentNode.ParentNode.SelectSingleNode("h3").InnerText;

                sectionName = GetParentSectionNames(currentNode.ParentNode.ParentNode) + " - " + sectionName;

            }



            if (!bookmarks.ContainsKey(sectionName))
            {
                bookmarks.Add(sectionName, new List<Link>());
            }

            bookmarks[sectionName].Add(new Link(item.InnerText, item.GetAttributeValue("href", ""),""));
        }

        private static MemoryStream ImproveDocumentStructure(Stream streamToImprove)
        {
            var improvedStream = new MemoryStream();
            StreamWriter sw = new StreamWriter(improvedStream);


            //var improvedStream = new FileStream(@"C:\Users\Peter\Desktop\pretty.html",FileMode.CreateNew);
            //StreamWriter sw = new StreamWriter(improvedStream);


            using (StreamReader sr = new StreamReader(streamToImprove))
            {
                while (sr.Peek() >= 0)
                {

                    string line = sr.ReadLine();

                    if (!String.IsNullOrEmpty(line))
                    {
                        line = line.Replace("</A>", "</A></DT>");
                        line = line.Replace("</DL><p>", "</DL></DT>");
                        line = line.Replace("<p>", "");
                        line = Regex.Replace(line, @"(<\s*[a-z][a-z0-9]*.*\s)(ICON\s*=\s*"".*?"")([^<>]*>)", "$1 $3", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                        line = Regex.Replace(line, @"(<\s*[a-z][a-z0-9]*.*\s)(ADD_DATE\s*=\s*"".*?"")([^<>]*>)", "$1 $3", RegexOptions.Singleline | RegexOptions.IgnoreCase);
                    }

                    sw.WriteLine(line);


                }
            }



            //improvedStream.Flush();
            //return View();

            improvedStream.Seek(0, SeekOrigin.Begin);
            return improvedStream;
        }

        private string GetParentSectionNames(HtmlNode node)
        {


            string thisLevelsName = "";
            string otherLevelsName = "";

            if (node.SelectSingleNode("h3") != null)
            {
                thisLevelsName = node.SelectSingleNode("h3").InnerText;
            }

            if (node.ParentNode != null)
            {
                otherLevelsName = GetParentSectionNames(node.ParentNode);
            }

            if (String.IsNullOrEmpty(thisLevelsName))
            {
                return otherLevelsName;
            }
            else
            {
                return otherLevelsName + " - " + thisLevelsName;
            }
            
        }



    }
}