using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace filework
{
    class ScanFile
    {
        public ScanFile(string fullname)
        {
            this.Fullname = fullname;
            this.Filename = Path.GetFileName(fullname);
            var rx = new Regex(@"^(.*?)\.(.*(\..+)?)");
            var g = rx.Match(this.Filename).Groups;
            this.Cleanname = g[1].Value;
            this.CmdType = g[2].Value;
        }


        public string CmdType { get; private set; }
        public string Filename { get; private set; }
        public string Fullname { get; private set; }
        public string Cleanname { get; private set; }
    }
}
