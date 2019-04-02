using Roldaice.IDal.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Dal.Entities
{

    public abstract class EntityBase : IEntityBase
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }
    }
}
