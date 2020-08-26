using System;
using System.Collections.Generic;

namespace Cignium.SearchFight.Core.Models
{
    public class ContainerSearch
    {
        public Dictionary<string, List<Search>> termDictionary { get; set; }

        public ContainerSearch()
        {
            termDictionary = new Dictionary<string, List<Search>>();
        }
    }
}
