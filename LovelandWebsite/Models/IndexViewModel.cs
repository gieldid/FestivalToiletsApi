using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivalToiletsApi.Models;

namespace LovelandWebsite.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Toilet> Toilets { get; set; }

    }
}
