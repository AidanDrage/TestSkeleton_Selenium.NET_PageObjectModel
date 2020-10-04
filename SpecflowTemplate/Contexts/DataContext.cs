using System;
using System.Collections.Generic;

namespace SpecflowTemplate.Contexts
{
    public class DataContext
    {
        public Dictionary<String, dynamic> ScenarioDataContext { get; set; }

        public DataContext()
        {
            ScenarioDataContext = new Dictionary<string, dynamic>();
        }
    }
}
