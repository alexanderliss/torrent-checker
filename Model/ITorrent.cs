using System;
using System.Linq;
using HtmlAgilityPack;

namespace Model
{
    public interface ITorrent
    {
        string Caption { get; }
        string Url { get; }
        DateTime Date { get; }
        string DateString { get; }
    }

    public class RutrackerTorrent : ITorrent
    {
        public RutrackerTorrent(HtmlNode x)
        {
            Caption = x.SelectSingleNode("td[4]/div[1]/a").InnerText;
            Url = "https://rutracker.org/forum/" + x.SelectSingleNode("td[4]/div[1]/a").Attributes["href"].Value;
            Date = DateTime.TryParse(x.SelectSingleNode("td[10]/p").InnerText, out var date) ? date : DateTime.Now;
        }

        public string Type => "RUTRACKER";
        public string Caption { get; }
        public string Url { get; }
        public DateTime Date { get; }
        public string DateString => Date.ToShortDateString();

        public override string ToString()
        {
            return Type + ": " + Caption;
        }
    }
    public class RutorTorrent : ITorrent
    {
        public RutorTorrent(HtmlNode x)
        {
            Caption = x.SelectSingleNode("td[2]/a[3]/text()").InnerText;
            Url = "http://rutor.info" + x.SelectSingleNode("td[2]/a[3]").Attributes["href"].Value;
            Date = DateTime.Parse(x.SelectSingleNode("td[1]").InnerText.Replace("&nbsp;", "-"));
        }

        public string Type => "RUTOR";
        public string Caption { get; }
        public string Url { get; }
        public DateTime Date { get; }
        public string DateString => Date.ToShortDateString();

        public override string ToString()
        {
            return Type + ": " + Caption;
        }
    }

    public class KinozalTorrent : ITorrent
    {
        public KinozalTorrent(HtmlNode x)
        {
            Caption = x.SelectSingleNode("td[2]/a/text()").InnerText;
            Url = "http://kinozal.tv" + x.SelectSingleNode("td[2]/a").Attributes["href"].Value;
            Date = DateTime.TryParse(new string(x.SelectSingleNode("td[7]").InnerText.Take(10).ToArray()), out var date) ? date : DateTime.Now;
        }

        public string Type => "KINOZAL";
        public string Caption { get; }
        public string Url { get; }
        public DateTime Date { get; }
        public string DateString => Date.ToShortDateString();

        public override string ToString()
        {
            return Type + ": " + Caption;
        }
    }

    public class NnmTorrent : ITorrent
    {
        public NnmTorrent(HtmlNode x)
        {
            Caption = x.SelectSingleNode("td[3]/a/b").InnerText;
            Url = "https://nnmclub.to/forum/" + x.SelectSingleNode("td[3]/a").Attributes["href"].Value;
            Date = DateTime.Parse(x.SelectSingleNode("td[10]/text()[1]").InnerText.Trim());
        }

        public string Type => "NNM";
        public string Caption { get; }
        public string Url { get; }
        public DateTime Date { get; }
        public string DateString => Date.ToShortDateString();

        public override string ToString()
        {
            return Type + ": " + Caption;
        }
    }
}
