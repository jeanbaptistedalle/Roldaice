using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roldaice.Dal.Entities
{
    public class UserCustomization : EntityBase
    {
        [Key, ForeignKey(nameof(User)), DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override int Id { get; set; }

        [StringLength(100)]
        public string IdenticonSeed { get; set; }

        [StringLength(50)]
        public string NavbarBackgroundColor { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}
