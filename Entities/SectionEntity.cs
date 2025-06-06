using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSectionWPF2.Entities
{
    public class SectionEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? CoachId { get; set; } 
        public CoachEntity Coach { get; set; }
        public List<MemberEntity> Members { get; set; }
        public ScheduleEntity Schedule { get; set; }
    }
}
