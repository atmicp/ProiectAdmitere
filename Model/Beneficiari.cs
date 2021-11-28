using System;
using System.Collections.Generic;

#nullable disable

namespace Admitere3.Model
{
    public partial class Beneficiari
    {
        public Beneficiari()
        {
            BeneficiariProgrameDeStudiis = new HashSet<BeneficiariProgrameDeStudii>();
            DateCandidatis = new HashSet<DateCandidati>();
        }

        public int IdBeneficiar { get; set; }
        public string Denumire { get; set; }

        public virtual ICollection<BeneficiariProgrameDeStudii> BeneficiariProgrameDeStudiis { get; set; }
        public virtual ICollection<DateCandidati> DateCandidatis { get; set; }
    }
}
