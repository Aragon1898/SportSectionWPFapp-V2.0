using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSectionWPF2.Entities
{
    public class CoachEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }

        [NotMapped]
        public string DisplayName => User?.Name;
    }
}
