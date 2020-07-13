using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StringCompare.Models;

namespace StringCompare.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringComparisonController : ControllerBase
    {
        

        // POST: api/CompareStrings
        [HttpPost(Name ="CompareStrings")]
        [Route("CompareStrings")]
        public PositionResultModel CompareStrings(CompareStringsModel model)
        {
            MatchCollection mCollection = Regex.Matches(model.MainText, model.SubText, options:RegexOptions.IgnoreCase);
            PositionResultModel result = new PositionResultModel();
            if (mCollection != null && mCollection.Count > 0)
            {
                result.Positions = mCollection.Where(mat => mat.Value != "").Select(m => m.Index).ToList();
                if (result.Positions.Count > 0)
                {
                    result.MatchesFound = true;
                }
            }

            return result;

        }
    }
}
