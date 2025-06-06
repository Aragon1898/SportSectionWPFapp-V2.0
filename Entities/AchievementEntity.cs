using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportSectionWPF2.Entities
{
    public class AchievementEntity
    {
        public int Id { get; set; }
        public string CompetitionName { get; set; } = string.Empty;
        public string Points { get; set; } = string.Empty;
        public string Awards {  get; set; } = string.Empty;

        public int MemberId { get; set; }
        public MemberEntity Member { get; set; }
    }
}
