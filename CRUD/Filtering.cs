using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coreapp.CRUD 
{
    public class Filtering
    {
    public string SearchString { get; set; }
    public string CurrentFilter { get; set; }
    public Filtering() { }

    public Filtering(string searchString, string currentFilter)
    {
        SearchString = searchString;
        CurrentFilter = currentFilter;
    }
    }
}
