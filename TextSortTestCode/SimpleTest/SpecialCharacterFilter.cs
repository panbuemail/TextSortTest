using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SimpleTest
{
    public class SpecialCharacterFilter : IFilter
    {
        /// <summary>
        /// Filter special caractes from the input string
        /// </summary>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public string ApplyFilter(string inputData)
        {
            return Regex.Replace(inputData, "[^a-zA-Z0-9_ ]+", "");
        }
    }
}
