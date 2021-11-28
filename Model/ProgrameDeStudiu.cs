using System;
using System.Collections.Generic;

#nullable disable

namespace Admitere3.Model
{
    public partial class ProgrameDeStudiu
    {
        public ProgrameDeStudiu()
        {
            BeneficiariProgrameDeStudiis = new HashSet<BeneficiariProgrameDeStudii>();
        }

        public int IdProgramDeStudiu { get; set; }
        public string Denumire { get; set; }

        public virtual ICollection<BeneficiariProgrameDeStudii> BeneficiariProgrameDeStudiis { get; set; }
    }
}
