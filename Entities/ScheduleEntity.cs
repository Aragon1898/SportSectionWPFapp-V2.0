using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSectionWPF2.Entities
{
    public class ScheduleEntity
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string BeginTime { get; set; }
        public string EndingTime {  get; set; }

        public int SectionEntityId { get; set; }
        public SectionEntity Section { get; set; }

        public List<AttendancesEntity> Attendances { get; set; }
    }
}
