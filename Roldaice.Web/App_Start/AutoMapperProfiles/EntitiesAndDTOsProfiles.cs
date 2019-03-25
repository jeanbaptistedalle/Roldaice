using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roldaice.Web.App_Start.AutoMapperProfiles
{
    public class EntitiesAndDtosProfiles
    {
        /// <summary>
        /// Profile for all the mappings from Entities To Dto
        /// </summary>
        public class EntitiesToDtos : Profile
        {
            #region Convention
            public class Conventions : Profile
            {
                public Conventions()
                {
                    //Default mapping target ClassName -> ClassNameDto
                    AddConditionalObjectMapper().Where((s, d) => s.Name + "Dto" == d.Name);
                }
            }
            #endregion

            /// <summary>
            /// Custom mappings from Entities to Dto
            /// </summary>
            public EntitiesToDtos()
            {
            }
        }

        /// <summary>
        /// Profile for all the mappings from Dto To Entities
        /// </summary>
        public class DtosToEntities : Profile
        {
            #region Convention
            public class Conventions : Profile
            {
                public Conventions()
                {
                    //Default mapping target ClassNameDto -> ClassName 
                    AddConditionalObjectMapper().Where((s, d) => s.Name == d.Name + "Dto");
                }
            }
            #endregion

            /// <summary>
            /// Custom mappings from Dto to Entities
            /// </summary>
            public DtosToEntities()
            {
            }
        }
    }
}