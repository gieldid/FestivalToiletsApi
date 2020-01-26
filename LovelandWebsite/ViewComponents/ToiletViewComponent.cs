using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LovelandWebsite.Models;
using Microsoft.AspNetCore.Mvc;


namespace LovelandWebsite.ViewComponents
{
    [ViewComponent]
    public class ToiletViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() {
            FestivalToilets festivalToilets = new FestivalToilets();
            IndexViewModel indexViewModel = new IndexViewModel();

            indexViewModel.Toilets = festivalToilets.JsonToObject(festivalToilets.Get());

            return View(indexViewModel);
        }

    }
}
