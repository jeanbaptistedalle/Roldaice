using AutoMapper;
using Roldaice.Common.Dto.Base;
using Roldaice.Cryptograph.Enigma;
using Roldaice.RollDice.Logic;
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
            CreateMap<IdLabelDtoBase, SelectListItem>()
                .ForMember(target => target.Value, m => m.ResolveUsing(source => source.Id))
                .ForMember(target => target.Text, m => m.ResolveUsing(source => source.Label))
                .ForMember(target => target.Disabled, m => m.Ignore())
                .ForMember(target => target.Group, m => m.Ignore())
                .ForMember(target => target.Selected, m => m.Ignore())
            ;

            CreateMap<Rotor, SelectListItem>()
                .ForMember(target => target.Value, m => m.ResolveUsing(source => source.Code))
                .ForMember(target => target.Text, m => m.ResolveUsing(source => source.Code))
                .ForMember(target => target.Disabled, m => m.Ignore())
                .ForMember(target => target.Group, m => m.Ignore())
                .ForMember(target => target.Selected, m => m.Ignore())
            ;

            CreateMap<Dice, SelectListItem>()
                .ForMember(target => target.Value, m => m.ResolveUsing(source => source.Code))
                .ForMember(target => target.Text, m => m.ResolveUsing(source => source.Code))
                .ForMember(target => target.Disabled, m => m.Ignore())
                .ForMember(target => target.Group, m => m.Ignore())
                .ForMember(target => target.Selected, m => m.Ignore())
            ;
        }
    }
}