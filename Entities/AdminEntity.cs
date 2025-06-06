using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSectionWPF2.Entities
{
    public class AdminEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity User { get; set; }
    }
}
