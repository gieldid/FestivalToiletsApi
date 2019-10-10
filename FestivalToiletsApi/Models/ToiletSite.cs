using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FestivalToiletsApi.Models
{
    public class ToiletSite
    {
        public long Id { get; set; }
        public List<Toilet> Toilets { get; set; }

        public ToiletStatus Status { get; private set; }

        public Festival Festival { get; set; }

        public void CalculateStatus() {
            int occupiedToilets = 0;
            foreach (Toilet toilet in Toilets) {
                if (toilet.IsOccupied) {
                    occupiedToilets++;
                }
            }
            
            int occupiedPercentage = (occupiedToilets / Toilets.Count) * 100;

            if (occupiedPercentage < 70)
            {
                Status = ToiletStatus.Low;
            }
            else if (occupiedPercentage >= 70 && occupiedPercentage < 90)
            {
                Status = ToiletStatus.Medium;
            }
            else 
            {
                Status = ToiletStatus.High;
            }
        }
    }

    public enum ToiletStatus { 
        Low,
        Medium,
        High
    }
}
