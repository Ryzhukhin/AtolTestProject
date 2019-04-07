using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Bll.Core
{
    public class Filter
    {
        public static Filter WhereIdContains(string partOfId) 
            => new Filter { IdContains = partOfId };

        public static Filter WhereDescriptionContains(string partOfDescription) 
            => new Filter { DescriptionContains = partOfDescription };

        public static Filter WhereAnythingContains(string searchString) 
            => new Filter { AnythingContains = searchString };
        public static Filter NoFilter => new Filter();

        public string IdContains { get; private set; }
        public string DescriptionContains { get; private set; }
        public string AnythingContains { get; private set; }
    }
}
