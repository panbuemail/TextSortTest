using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public class ConsoleLogger : ILogger
    {
        /// <summary>
        /// Log to console
        /// </summary>
        /// <param name="stuff"></param>
        public void Log(string stuff)
        {
            Console.WriteLine(stuff);
        }
    }
}
