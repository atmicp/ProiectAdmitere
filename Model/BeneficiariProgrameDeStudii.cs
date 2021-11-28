using System;
using System.Collections.Generic;

#nullable disable

namespace Admitere3.Model
{
    public partial class BeneficiariProgrameDeStudii
    {
        public int IdBeneficiar { get; set; }
        public int IdProgrameDeStudiu { get; set; }
        public int LocuriScoaseLaConcurs { get; set; }

        public virtual Beneficiari IdBeneficiarNavigation { get; set; }
        public virtual ProgrameDeStudiu IdProgrameDeStudiuNavigation { get; set; }
    }
}
