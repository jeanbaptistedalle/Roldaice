using AutoMapper;
using Roldaice.Common.DTO.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roldaice.Web.App_Start.AutoMapperProfiles
{
    public class SelectListItemProfile : Profile
    {
        public SelectListItemProfile()
        {
            CreateMap<IdLabelBaseDto, SelectListItem>()
                .ForMember(target => target.Value, m => m.ResolveUsing(source => source.Id))
                .ForMember(target => target.Text, m => m.ResolveUsing(source => source.Label))
            ;
        }
    }
}