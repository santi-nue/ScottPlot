﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottPlot.Cookbook
{
    internal static class Template
    {
        public static void CreateHtmlPage(string filePath, string bodyHtml, string title, string description)
        {
            string html =
                "<html>" +
                "<head>" +
                $"  <title>{title}</title>" +
                "  <link href=https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css rel=stylesheet>" +
                "</head>" +
                "<body class=bg-light>" +
                "  <div class='container' style='max-width:1000px'>" +
                "    <div class='my-4'><code>THIS PAGE IS FOR TESTING ONLY</code></div>" +
                $"    <div class='display-4'>{title}</div>" +
                $"    <div class='fs-5'><i>{description}</i></div>" +
                "    <article class='bg-light shadow rounded my-5'>" +
                "    <div class='p-3 rounded bg-white'>" +
                $"      {bodyHtml}" +
                "    </div>" +
                "    </article>" +
                "  </div>" +
                "</body>" +
                "</html>";

            filePath = Path.GetFullPath(filePath);
            File.WriteAllText(filePath, html);
        }

        public static void CreateMarkdownPage(string mdFilePath, string body, string title, string description, string url = "", string[] frontmatter = null)
        {
            StringBuilder sb = new();
            sb.AppendLine("---");
            sb.AppendLine($"Title: \"{title}\"");
            sb.AppendLine($"Description: \"{description}\"");
            sb.AppendLine($"Date: {DateTime.Now}");
            sb.AppendLine($"Version: {ScottPlot.Version.LongString}");
            if (!string.IsNullOrEmpty(url))
                sb.AppendLine($"URL: {url}");
            if (frontmatter is not null)
            {
                foreach (string s in frontmatter)
                {
                    sb.AppendLine(s);
                }
            }
            sb.AppendLine("---");
            sb.AppendLine("");
            sb.AppendLine(body);

            mdFilePath = Path.GetFullPath(mdFilePath);
            File.WriteAllText(mdFilePath, sb.ToString());
        }
    }
}
