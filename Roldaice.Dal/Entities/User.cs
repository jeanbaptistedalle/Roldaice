using Roldaice.Dal.Attributes;
using Roldaice.Dal.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Dal.Entities
{
    public class User : AutoIncrementEntityBase
    {
        [Required]
        [Index(IsUnique = true)]
        [StringLength(100)]
        public string Login { get; set; }

        /// <summary>
        /// The password is a 64 character string because it's stored as a hash
        /// </summary>
        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        [Required]
        [StringLength(100)]
        public string Salt { get; set; }

        [SqlDefaultValue(DefaultValue = DalConstants.SqlFunction.GetDate)]
        public DateTime CreationDate { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
