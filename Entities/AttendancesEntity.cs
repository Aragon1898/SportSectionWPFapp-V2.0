using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSectionWPF2.Entities
{
    public class AttendancesEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public bool IsPresent { get; set; }

        public ScheduleEntity Schedule { get; set; }

    }
}
