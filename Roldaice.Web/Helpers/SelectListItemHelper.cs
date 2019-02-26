using AutoMapper;
using Roldaice.Cryptograph.Enigma;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;

namespace Roldaice.Web.Helpers
{
    public class SelectListItemHelper
    {
        [Dependency]
        public IMapper Mapper { get; set; }

        public List<SelectListItem> GetRotors()
        {
            return ToSelectListItem(Rotor.GetAll());
        }

        private List<SelectListItem> ToSelectListItem<T>(List<T> items)
        {
            return Mapper.Map<List<SelectListItem>>(items);
        }
    }
}