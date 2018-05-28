using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace CopyLatestCoverageReport
{
    class Program
    {
        const string ReportFolder = "TestResults";
        const string ReportFileName = "coverage_report.xml";
        const string FileSeperator = "\\";

        static void Main(string[] args)
        {
            UpdateCoverageReport();
        }

        private static void UpdateCoverageReport()
        {
            var reportFullFilename = Path.Combine(ReportFolder, ReportFileName);
            var currentFolder = new DirectoryInfo(Directory.GetCurrentDirectory());
            if (File.Exists(reportFullFilename))
            {
                var doc = XDocument.Load(reportFullFilename);
                var sourceFileNodes = doc.XPathSelectElements("//source_file");

                foreach (var sourceFileNode in sourceFileNodes)
                {
                    var pathAttr = sourceFileNode.Attribute("path");
                    if (pathAttr != null && !string.IsNullOrEmpty(pathAttr.Value))
                    {
                        var pathValue = pathAttr.Value;
                        if (pathValue.ToLower().Contains(currentFolder.Name.ToLower()))
                        {
                            var newPathValue = GenerateNewPathValue(currentFolder, pathValue);
                            pathAttr.Value = newPathValue;
                        }
                    }
                }
                doc.Save(reportFullFilename);
            }
        }

        private static string GenerateNewPathValue(DirectoryInfo currentFolder, string pathValue)
        {
            var index = pathValue.ToLower().IndexOf(currentFolder.Name.ToLower());
            var relativePath = pathValue.Substring(index, pathValue.Length - index);
            var parts = relativePath.Split(new[] { FileSeperator }, StringSplitOptions.RemoveEmptyEntries);

            var pathBuilder = new StringBuilder();
            pathBuilder.Append(currentFolder.Name).Append(FileSeperator);
            for (int i = 1; i < parts.Length; i++)
            {
                var path = parts[i];

                if (i == parts.Length - 1)
                {
                    var file = currentFolder.GetFiles(path, SearchOption.AllDirectories).FirstOrDefault();
                    if (file != null)
                    {
                        pathBuilder.Append(file.Name);
                    }
                }
                else
                {
                    var dir = currentFolder.GetDirectories().Where(x => x.Name.ToLower() == path.ToLower()).FirstOrDefault();
                    if (dir != null)
                    {
                        pathBuilder.Append(dir.Name).Append(FileSeperator);
                    }
                }
            }
            var newPathValue = pathBuilder.ToString();
            return newPathValue;
        }
    }
}
