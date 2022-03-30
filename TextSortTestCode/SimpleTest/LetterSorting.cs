using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

//simple test

//Test 


namespace SimpleTest
{
    public partial class LetterSorting
    {
        private readonly ILogger _logger;
        private List<IFilter> _filter = new List<IFilter>();
        public LetterSorting(ILogger logger)
        {
            _logger = logger;
        }
        public void AddFilter(IFilter filter)
        {
            _filter.Add(filter);
        }
        /// <summary>
        /// Sort letterrs by alphabet order with casesensitive
        /// </summary>
        /// <param name="someInput"></param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException"></exception>
        public string LetterSortingByAlphabetCase(string someInput)
        {
            if (string.IsNullOrEmpty(someInput))
            {
                throw new NullReferenceException("Data cannot be empty.");
            }

            _logger.Log("start LetterSortingByAlphabetCase");

            if(_filter.Any())
            {
                foreach (IFilter filter in _filter)
                {
                    someInput = filter.ApplyFilter(someInput);
                }
            }

            List<string> result = new List<string>();
            var orderedList = someInput.Split(' ').OrderBy(o => o,StringComparer.OrdinalIgnoreCase).ThenBy(s => s, StringComparer.Ordinal);


            _logger.Log("end LetterSortingByAlphabetCase");

            return string.Join(' ',orderedList) ;            
        }       

    }
 
}
