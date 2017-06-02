using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnlockApp
{
    public class MachineInfoMode
    {
        public int FileLen { get; set; }
        public String DateTime
        {
            get;
            set;
        }
        public int DataLen { get; set; }
        public String AddInfo
        {
            get;
            set;
        }
        public int AddInfoLen { get; set; }
        public String Version
        {
            get;
            set;
        }
        public int VersionLen { get; set; }
    }
}
