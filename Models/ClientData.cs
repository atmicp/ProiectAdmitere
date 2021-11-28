using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Admitere3.Models
{
    public enum Beneficiari { Mapn, Mai, Sri };
    public class Data
    {
        [Required(ErrorMessage = "Ziua is required")]
        public string zi { get; set; }
        [Required(ErrorMessage = "Luna is required")]
        public string luna { get; set; }
        [Required(ErrorMessage = "Anul is required")]
        public string an { get; set; }
    }
    public class Domiciliu
    {
        public string judet;
        public string localitate;
        public string sector;
        public string strada;
        public string nr;
        public string bl;
        public string sc;
        public string et;
        public string ap;
        public string codPostal;
        public string telefon;
    }
    public class CarteDeIdentitate
    {
        public string seria;
        public string nr;
        public string cnp;
        public string eliberatDe;
        public Data DataEliberarii;
    }
    public class ClientData
    {
        [Required(ErrorMessage = "Name is required")]
        public string nume { get; set; }
        [Required(ErrorMessage = "Prenume tata is required")]
        public string PrenumeTata { get; set; }
        [Required(ErrorMessage = "Prenume candidat is required")]
        public string PrenumeCandidat { get; set; }
        [Required(ErrorMessage = "Cod Candidat is required")]
        public string CodCandidat { get; set; }
        public Data DataNasterii { get; set; }
        public Domiciliu DomiciliuStabil { get; set; }
        public CarteDeIdentitate CarteDeIdentitate { get; set; }

        [Required(ErrorMessage = "Media bacalaureat is required")]
        public string MediaBacalaureat { get; set; }


        [Required(ErrorMessage = "DataCompletariiFormularului is required")]
        public string DataCompletariiFormularului { get; set; }


        public int[] benef = new int[] { 1, 2, 3 };
        public SelectList lista_beneficiari = new SelectList(new[] { "Mapn","MAI", "Sri" });
        public string selectedItem;

        public List<string> lista_optiuni = new List<string> { "Calc", "Com", "Bat" };
        public string[] optiuni=new string[3];

        public int[] int_numere_optiuni = { 1, 2, 3};
        public SelectList string_numere_optiuni;
        

        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; }
        [Required(ErrorMessage = "Confirma Email is required")]
        public string confirmEmail { get; set; }

        public string outputFileName { get; set; }
        public IFormFile diplomaBac { get; set; }

        public IFormFile dovadaTaxaInscriere { get; set; }

        public int MailSent { get; set; } = -1;
        public ClientData()
        {
            List<string> lista_numere = new List<string> { " " };
            lista_numere.AddRange(int_numere_optiuni.Select(x => x.ToString()).ToList());
            string_numere_optiuni = new SelectList(lista_numere);
        }

        public void GeneratePdf()
        {
            string _dataDir = @"Data\";
            // Initialize document object
            Aspose.Pdf.Document document = new Aspose.Pdf.Document();
            // Add page
            Aspose.Pdf.Page page = document.Pages.Add();
            // Add text to new page
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(nume));
            page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment(email));

            //add Dovada Taxa Inscriere to pdf
            System.IO.Stream streamDovadaTaxaInscriere = dovadaTaxaInscriere.OpenReadStream();
            page.AddImage(streamDovadaTaxaInscriere, new Aspose.Pdf.Rectangle(0, 0, 100, 100));

            //add Diploma Bac to pdf
            System.IO.Stream streamDiplomaBac = diplomaBac.OpenReadStream();
            page.AddImage(streamDiplomaBac, new Aspose.Pdf.Rectangle(100, 100, 200, 200));
            
            // Save updated PDF
            outputFileName = System.IO.Path.Combine(_dataDir, "client_" + nume + ".pdf");
            document.Save(outputFileName);
        }
        public async Task<bool> MySendMailAsync()
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient("smtp.gmail.com");

            mail.From = new System.Net.Mail.MailAddress("test.atm.icp@gmail.com");
            mail.To.Add(email);
            mail.Subject = "Test Mail";
            mail.Body = "This is for testing SMTP mail from GMAIL";



            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("test.atm.icp@gmail.com", "testatm2021");
            SmtpServer.Port = 587;
            SmtpServer.EnableSsl = true;

            mail.Attachments.Add(new System.Net.Mail.Attachment(outputFileName));

            try
            {
                MailSent = 1;
                await SmtpServer.SendMailAsync(mail);
            }
            catch
            {
                MailSent = 0;
            }
            return true;
        }
    }
}
