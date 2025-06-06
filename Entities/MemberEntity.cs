using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSectionWPF2.Entities
{
    public class MemberEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public UserEntity User { get; set; }
        [NotMapped]
        public string DisplayName => User?.Name;
        public List<SectionEntity> Sections { get; set; }
        public List<AchievementEntity> Achievements { get; set; }
        public List<AttendancesEntity> Attendances { get; set; }
    }
}
