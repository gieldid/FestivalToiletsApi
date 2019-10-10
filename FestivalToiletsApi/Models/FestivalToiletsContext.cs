using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FestivalToiletsApi.Models;

namespace FestivalToiletsApi.Models
{
    public class FestivalToiletsContext :DbContext
    {
        public FestivalToiletsContext(DbContextOptions<FestivalToiletsContext> options)
            : base(options)
        {
        }

        public DbSet<Festival> festivals { get; set; }

        public DbSet<FestivalToiletsApi.Models.ToiletSite> ToiletSite { get; set; }

        public DbSet<FestivalToiletsApi.Models.Toilet> Toilet { get; set; }
    }
}
