using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalToiletsApi.Models
{
    public class Toilet
    {
        public long Id { get; set; }
        public bool IsOccupied { get; set; }

        public ToiletSite ToiletSite { get; set; }
    }
}
