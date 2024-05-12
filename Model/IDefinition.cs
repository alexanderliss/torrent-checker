using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Model
{
    public abstract class BaseDefinition
    {
        protected string _cookie;

        public BaseDefinition(string cookie)
        {
            _cookie = cookie;
        }

        public abstract List<ITorrent> Search(string text, bool console = true);
    }

    public class RutrackerDefinition : BaseDefinition
    {
        public string GetSearchUrl(IEnumerable<string> words)
        {
            return $"https://rutracker.org/forum/tracker.php?nm={string.Join("%20", words)}";
        }

        public string NodesPath => "//*[@id=\"tor-tbl\"]/tbody/tr";

        public override List<ITorrent> Search(string text, bool console = true)
        {
            var counter = 0;
            while (true)
            {
                try
                {
                    var tokenSource = new CancellationTokenSource();
                    var token = tokenSource.Token;
                    Task.Run(() =>
                    {
                        token.ThrowIfCancellationRequested();
                        Thread.Sleep(new TimeSpan(0, 1, 0));
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                        throw new Exception();
                    }, token);
                    using (var client = new WebClient())
                    {
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                        client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.82 Safari/537.36");
                        client.Headers.Add(HttpRequestHeader.Cookie, _cookie);
                        
                        using (var stream = client.OpenRead(GetSearchUrl(text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries))))
                            using (var textReader = new StreamReader(stream, Encoding.GetEncoding(1251), true))
                            {
                                var doc = new HtmlDocument();
                                var t = textReader.ReadToEnd();
                                doc.LoadHtml(t);
                                var c = doc.DocumentNode.SelectNodes(NodesPath);
                                tokenSource.Cancel();
                                if ((c == null || c.Count == 1 && c.Single().InnerText.Contains("Не найдено")) && t.Contains("Не найдено"))
                                {
                                    
                                    return new List<ITorrent>();
                                }
                                
                                return c?.Select(x => new RutrackerTorrent(x)).Cast<ITorrent>().ToList() ?? new List<ITorrent>();

                            }
                    }
                }
                catch (Exception e)
                {
                    counter++;
                    if (counter <= 10) continue;
                    if (console)
                    {
                        Console.WriteLine("EXCEPTION IN RUTRACKER. SKIP?");
                        Console.ReadKey();
                    }
                    return new List<ITorrent>();
                }
            }
        }

        public RutrackerDefinition(string cookie) : base(cookie)
        {
        }
    }

    public class RutorDefinition : BaseDefinition
    {
        public string GetSearchUrl(IEnumerable<string> words)
        {
            return $"http://rutor.info/search/0/0/100/0/{string.Join("%20", words)}";
        }

        public string NodesPath => "//*[@id=\"index\"]/table[1]/tr";

        public override List<ITorrent> Search(string text, bool console = true)
        {
            var counter = 0;
            while (true)
            {
                try
                {
                    var tokenSource = new CancellationTokenSource();
                    var token = tokenSource.Token;
                    Task.Run(() =>
                    {
                        token.ThrowIfCancellationRequested();
                        Thread.Sleep(new TimeSpan(0, 1, 0));
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                        throw new Exception();
                    }, token);
                    using (var client = new WebClient())
                    {
                        client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/98.0.4758.102 Safari/537.36");
                        client.Headers.Add(HttpRequestHeader.Cookie, _cookie);
                        using (var stream = client.OpenRead(GetSearchUrl(text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))))
                            using (var textReader = new StreamReader(stream, Encoding.UTF8, true))
                            {
                                var doc = new HtmlDocument();
                                var t = textReader.ReadToEnd();
                                tokenSource.Cancel();
                                doc.LoadHtml(t);
                                var c = doc.DocumentNode.SelectNodes(NodesPath);
                                
                                return c.Skip(1).Select(x => new RutorTorrent(x)).Cast<ITorrent>().ToList();

                            }
                    }
                }
                catch (Exception e)
                {
                    counter++;
                    if (counter <= 10) continue;
                    if (console)
                    {
                        Console.WriteLine("EXCEPTION IN RUTOR. SKIP?");
                        Console.ReadKey();
                    }
                    return new List<ITorrent>();
                }
            }
            
        }

        public RutorDefinition(string cookie) : base(cookie)
        {
        }
    }

    public class KinozalDefinition : BaseDefinition
    {
        public string GetSearchUrl(IEnumerable<string> words)
        {
            return $"http://kinozal.tv/browse.php?s={string.Join("+", words)}";
        }

        public string NodesPath => "//*[@id=\"main\"]/div[2]/div[2]/table/tr";

        public Encoding GetEncoding()
        {
            return Encoding.GetEncoding("windows-1251");
        }

        public override List<ITorrent> Search(string text, bool console = true)
        {
            var counter = 0;

            while (true)
            {
                try
                {
                    var tokenSource = new CancellationTokenSource();
                    var token = tokenSource.Token;
                    Task.Run(() =>
                    {
                        token.ThrowIfCancellationRequested();
                        Thread.Sleep(new TimeSpan(0, 1, 0));
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                        throw new Exception();
                    }, token);
                    using (var client = new WebClient())
                    {
                        client.Headers.Add(HttpRequestHeader.Cookie, _cookie);
                        
                        using (var stream = client.OpenRead(GetSearchUrl(text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries))))
                            using (var textReader = new StreamReader(stream, GetEncoding(), true))
                            {
                                var doc = new HtmlDocument();
                                var t = textReader.ReadToEnd();
                                tokenSource.Cancel();
                                doc.LoadHtml(t);
                                var c = doc.DocumentNode.SelectNodes(NodesPath);
                                if (c == null && t.Contains("Нет активных раздач, приносим извинения. Пожалуйста, уточните параметры поиска"))
                                {
                                    return new List<ITorrent>();
                                }
                                
                                return c?.Skip(1).Select(x => new KinozalTorrent(x)).Cast<ITorrent>().ToList() ?? new List<ITorrent>();

                            }
                    }
                }
                catch (Exception e)
                {
                    counter++;
                    if (counter <= 10) continue;
                    if (console)
                    {
                        Console.WriteLine("EXCEPTION IN KINOZAL. SKIP?");
                        Console.ReadKey();
                    }
                    return new List<ITorrent>();
                }
            }
        }

        public KinozalDefinition(string cookie) : base(cookie)
        {
        }
    }

    public class NnmDefinition : BaseDefinition
    {
        public string GetSearchUrl(IEnumerable<string> words)
        {
            return $"https://nnmclub.to/forum/tracker.php?nm={string.Join("%20", words)}";
        }

        public string NodesPath => "//*[@id=\"search_form\"]/table[3]/tbody/tr";
 
        public override List<ITorrent> Search(string text, bool console = true)
        {
            int counter = 0;
            while (true)
            {
                try
                {
                    var tokenSource = new CancellationTokenSource();
                    var token = tokenSource.Token;
                    Task.Run(() =>
                    {
                        token.ThrowIfCancellationRequested();
                        Thread.Sleep(new TimeSpan(0, 1, 0));
                        if (token.IsCancellationRequested)
                        {
                            return;
                        }
                        throw new Exception();
                    }, token);
                    using (var client = new WebClient())
                    {
                        client.Headers.Add(HttpRequestHeader.Cookie, _cookie);
                        client.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/104.0.0.0 Safari/537.36");
                        using (var stream = client.OpenRead(GetSearchUrl(text.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries))))
                            using (var textReader = new StreamReader(stream, Encoding.GetEncoding("windows-1251"), true))
                            {
                                var doc = new HtmlDocument();
                                var t = textReader.ReadToEnd();
                                tokenSource.Cancel(); 
                                doc.LoadHtml(t);
                                var c = doc.DocumentNode.SelectNodes(NodesPath);
                                if (c == null && t.Contains("Не найдено"))
                                {
                                    
                                    return new List<ITorrent>();
                                }
                                
                                return c?.Select(x => new NnmTorrent(x)).Cast<ITorrent>().ToList() ?? new List<ITorrent>();
                            }
                    }
                }
                catch (Exception e)
                {
                    counter++;
                    if (counter <= 10) continue;
                    if (console)
                    {
                        Console.WriteLine("EXCEPTION IN NNM. SKIP?");
                        Console.ReadKey();
                    }
                    return new List<ITorrent>();
                }
            }
        }

        public NnmDefinition(string cookie) : base(cookie)
        {
        }
    }
}
