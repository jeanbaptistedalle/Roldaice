using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Dal.Entities
{
    public class Role : EntityBase
    {
        [Required, StringLength(200)]
        public string Label { get; set; }
        public virtual List<User> Users { get; set; }
    }
}
