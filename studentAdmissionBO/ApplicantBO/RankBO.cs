using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentAdmissionBO.ApplicantBO
{
    public class RankBO
    {
        public int Rank {  get; set; }
        public int RegistrationID { get; set; }
        public string Name { get; set; }
        public int TotalScore { get; set; }

        public string status { get; set; }
        public Users User { get; set; }
    }
}
