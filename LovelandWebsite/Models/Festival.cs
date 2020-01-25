using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LovelandWebsite.Models
{
    public class Festival
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<ToiletSite> ToiletSites { get; set; }
    }
}
