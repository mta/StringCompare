using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringCompare.Models
{
    public class CompareStringsModel
    {
        public CompareStringsModel()
        {
            this.MainText = "";
            this.SubText = "";
        }
        public string MainText { get; set; }
        public string SubText { get; set; }
    }
}
