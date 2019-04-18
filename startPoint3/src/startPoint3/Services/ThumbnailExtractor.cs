using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Net.Http;


namespace startPoint3.Services
{
    public class ThumbnailExtractor
    {

        public string GetSiteIconUrl(string url)
        {

            HttpResponseMessage html=null;


            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = new TimeSpan(0, 0, 1);
                    html = client.GetAsync(url).Result;
                }
            }
            catch { }

            if (html != null)
            {

                HtmlDocument htmlDoc = new HtmlDocument();
                htmlDoc.Load(html.Content.ReadAsStreamAsync().Result);

                // ParseErrors is an ArrayList containing any errors from the Load statement
                try
                {

                    if (htmlDoc.DocumentNode != null)
                    {
                        HtmlAgilityPack.HtmlNode bodyNode = htmlDoc.DocumentNode.SelectSingleNode("//body");

                        //if (bodyNode != null)
                        //{
                        // Do something with bodyNode
                        // <link rel="apple-touch-icon-precomposed" href="http://www.blogsmithmedia.com/www.engadget.com/media/apple-touch-icon-z.png" />
                        //<link rel="apple-touch-icon" href="http://gfx.aftonbladet-cdn.se/assets/gfx/social/abAppIcon.png" />
                        //<link rel="icon" href="//s.ytimg.com/yts/img/favicon_32-vflWoMFGx.png" sizes="32x32">
                        HtmlNodeCollection resultNodes = htmlDoc.DocumentNode.SelectNodes("//link[(@rel='apple-touch-icon-precomposed' or @rel='apple-touch-icon')]");



                        if (resultNodes != null && resultNodes.Count > 0)
                            return resultNodes.First().GetAttributeValue("href", "");
                        //}
                    }
                }
                catch (Exception) { };
            }

            return "";
        }

    }
}
