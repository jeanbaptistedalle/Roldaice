using Roldaice.ICommon.Dto;
using Roldaice.IDal.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.IDal.Interfaces.Dal
{
    public interface IBaseDal<TDto> 
        where TDto : class, IDtoBase
    {
        TDto Get(int id);
        bool Exists(int id);
        List<TDto> Get();
        TDto Insert(TDto dto);
        TDto Update(TDto dto);
        TDto InsertOrUpdate(TDto dto);
        bool Delete(int id);
    }
}
