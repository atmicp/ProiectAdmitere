using System;
using System.Collections.Generic;

#nullable disable

namespace Admitere3.Model
{
    public partial class DateCandidati
    {
        public int IdCandidat { get; set; }
        public string Nume { get; set; }
        public string PrenumeTata { get; set; }
        public string PrenumeCandidat { get; set; }
        public int CodCandidat { get; set; }
        public DateTime DataNasterii { get; set; }
        public string LoculNasterii { get; set; }
        public string Judet { get; set; }
        public string Localitatea { get; set; }
        public string Sector { get; set; }
        public string Strada { get; set; }
        public int NumarStarda { get; set; }
        public string Bloc { get; set; }
        public string Scara { get; set; }
        public string Etaj { get; set; }
        public string Apartament { get; set; }
        public int Cod { get; set; }
        public string Telefon { get; set; }
        public string SerieCi { get; set; }
        public string NumarCi { get; set; }
        public string Cnp { get; set; }
        public double MedieBacalaureat { get; set; }
        public byte[] Pdf { get; set; }
        public int IdBeneficiar { get; set; }
        public string Email { get; set; }

        public virtual Beneficiari IdBeneficiarNavigation { get; set; }
    }
}
