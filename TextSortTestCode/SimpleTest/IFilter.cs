using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTest
{
    public interface IFilter
    {
        public string ApplyFilter(string data);
    }
}
