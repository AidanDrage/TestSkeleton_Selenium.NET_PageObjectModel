using System;
using System.Collections.Generic;

namespace SpecflowTemplate.Contexts
{
    internal class DataContext
    {
        public Dictionary<String, dynamic> ScenarioDataContext { get; set; }

        public DataContext()
        {
            ScenarioDataContext = new Dictionary<string, dynamic>();
        }

        public string ArticleSearchedFor { get; set; }
    }
}
