using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyLatestCoverageReport
{
    class Program
    {
        const string ReportFolder = "UnitTestResults";

        static void Main(string[] args)
        {
            if (Directory.Exists(ReportFolder))
            {
                var reportDir = new DirectoryInfo(ReportFolder);
                var subDirs = reportDir.GetDirectories();
                if (subDirs != null && subDirs.Length > 0)
                {
                    var lastModified = subDirs.OrderBy(x => x.LastWriteTime).LastOrDefault();
                    if (lastModified != null)
                    {
                        var report = lastModified.GetFiles().FirstOrDefault();
                        if (report != null)
                        {
                            File.Copy(report.FullName, Path.Combine(ReportFolder, "out.coverage"), true);
                        }
                    }
                }
            }
        }
    }
}
