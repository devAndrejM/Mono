using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coreapp.CRUD
{
    public class Sorting
    {
        public string SortOrder { get; set; }
        public Sorting() { }

        public Sorting(string sortOrder)
        {
            SortOrder = sortOrder;
        }
    }
}

