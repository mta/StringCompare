using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StringCompare.Models
{
    public class PositionResultModel
    {
        public bool MatchesFound { get; set; }
        public List<int> Positions { get; set; }

        public  PositionResultModel() {
            MatchesFound = false;
            Positions = new List<int>();
        }
    }
}
