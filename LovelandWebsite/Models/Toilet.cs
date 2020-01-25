using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LovelandWebsite.Models
{
    public class Toilet
    {
        public long Id { get; set; }
        public bool IsOccupied { get; set; }

        public ToiletSite ToiletSite { get; set; }
    }
}
