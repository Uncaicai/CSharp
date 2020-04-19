using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
/* （1）只爬取起始网站上的网页。 
 * 例如起始网页是 https://www.cnblogs.com/dstang2000/  ，
 * 起始网站是www.cnblogs.com，也就是只爬域名相同的网页。
（2）只有当爬取的是html文本时，才解析并爬取下一级URL。
 （3）相对地址转成绝对地址进行爬取。
 相对地址转成绝对地址进行爬取。
链接的地址有的是以“http://…"这样的，有的是不带协议域名的相对地址。
例如：当前网页的地址  https://www.cnblogs.com/dstang2000/    
链接的地址href=“blog/paper1.html” 
实际地址是 https://www.cnblogs.com/dstang2000/blog/paper1.html
当前网页的地址  https://www.cnblogs.com/dstang2000/  
链接的地址href=“/blog/paper1.html” 
实际地址是 https://www.cnblogs.com/blog/paper1.html
当前网页的地址  https://www.cnblogs.com/dstang2000/ 
链接的地址href=“../blog/zhang/”
实际地址是 https://www.cnblogs.com/blog/zhang/
（4）尝试使用Winform来配置初始URL，启动爬虫，显示已经爬取的URL和错误的URL信息。*/
namespace SimpleCrawler {
 public class Crawler {

        private Hashtable urls = new Hashtable();
        private Queue<String> queue = new Queue<String>();
        private int count = 0;
        private string startUrl = "https://www.cnblogs.com/dstang2000/";
        public delegate void DownloadHandle(string args);
        public event DownloadHandle PageDownloaded;


       public Crawler(String startUrl)
        {
            urls.Add(startUrl, false);
            queue.Enqueue(startUrl);
            int startIndex = startUrl.IndexOf(":") + 3, endIndex = startUrl.IndexOf("/", startIndex);
            startUrl = startUrl.Substring(startIndex, endIndex - startIndex);
        }
    public void Crawl() {
      Console.WriteLine("开始爬行了.... ");

            while (true)
            {
                string current;
                do
                {
                    current = null;
                    if (queue.Count == 0)
                    {
                        break;
                    }
                    current = queue.Dequeue();
                } while ((bool)urls[current]);  //防止爬取相同网页
                if (current == null || count > 100)
                {
                    break;
                }
                Console.WriteLine("爬行" + current + "页面!");
                string html = DownLoad(current); // 下载
                urls[current] = true;
                count++;
                Parse(current, html);  //解析,并加入新的链接
                Console.WriteLine("爬行结束");
            }
        }

    public string DownLoad(string url) {
      try {
        WebClient webClient = new WebClient();
        webClient.Encoding = Encoding.UTF8;
        string html = webClient.DownloadString(url);
        string fileName = count.ToString();
        File.WriteAllText(fileName+".html", html, Encoding.UTF8);
        PageDownloaded(url);
        return html;
      }
      catch (Exception ex) {
        PageDownloaded(url + ":" + ex.Message);
        return "";
      }
    }

    private void Parse(string current, string html) {
       string strRef = @"(href|HREF)[ ]*=[ ]*[""'][^""'#>]+[""']";
            /*string strRef = @"(href|HREF)[ ]*=[ ]*[""'][^""'#>]+[""']";    
            (href|HREF) 表示href或者HREF
            [ ]*. 表示零到多个空格
            [""'] 双引号或者单引号 ， 使用@开头的字符串，不能用\ 转义，所以写两个双引号代表一个双引号\"
            [^""'#>]+表示不是"'#>这几个的字符出现一次到多次
                   MatchCollection matches = new Regex(strRef).Matches(html);
                  foreach (Match match in matches) {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)
                              .Trim('"', '\"', '#', '>');
                    if (strRef.Length == 0) continue;
                    if (urls[strRef] == null) urls[strRef] = false;
                  }*/
            //求当前网页的网页前缀，用于将相对地址转换为绝对地址
            int endIndex = current.IndexOf("/", current.IndexOf(":") + 3);
            string prefix = current.Substring(0, endIndex);
            string protocol = current.Substring(0, current.IndexOf(":"));

            string htmlPattern = @"(.html|.htm)";
            MatchCollection matches = new Regex(strRef).Matches(html);
            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\"', '#', '>');
                if (strRef.Length == 0) continue;
                //将相对地址转换为绝对地址
                if (!Regex.IsMatch(strRef, @"://"))
                {
                    if (Regex.IsMatch(strRef, @"^[a-zA-Z0-9]"))
                    {
                        strRef = new Regex(@"[^/]+$").Replace(current, strRef);
                    }
                    else if (strRef.StartsWith("//"))
                    {
                        strRef = protocol + ":" + strRef;
                    }
                    else if (strRef.StartsWith("/"))
                    {
                        strRef = prefix + strRef;
                    }
                    else if (strRef.StartsWith("./"))
                    {
                        strRef = new Regex(@"/[^/]/$").Replace(current, strRef.Substring(2, strRef.Length - 2));
                    }
                    else if (strRef.StartsWith("../"))
                    {
                        while (strRef.StartsWith("../"))
                        {
                            strRef = new Regex(@"[^/]+/[^/]+$").Replace(current, strRef);
                        }
                    }
                }
                if (!Regex.IsMatch(strRef, startUrl)) continue;  //只爬取原始网站上的信息
                if (!Regex.IsMatch(strRef, htmlPattern)) continue;  //只爬取html文本
                if (urls[strRef] == null)
                {
                    urls.Add(strRef, false);
                    queue.Enqueue(strRef);
                }
            }
    }
  }
}

