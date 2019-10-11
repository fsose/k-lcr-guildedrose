using ApprovalTests;
using ApprovalTests.Reporters;
using GuildedRose;
using System;
using System.IO;
using System.Text;
using Xunit;

namespace GuildedRole.UnitTests
{
    public class ProgramTests
    {
        [Fact]
        [UseReporter(typeof(QuietReporter))]
        public void ProgramApprovalTest()
        {
            var fakeOutput = new StringBuilder();
            using (var sw = new StringWriter(fakeOutput))
            using (var sr = new StringReader("a\n"))
            {
                Console.SetOut(sw);
                Console.SetIn(sr);

                Program.Main(new string[] { });

                Approvals.Verify(fakeOutput);
            }
        }
    }
}
