using Admitere3.Model;
using Admitere3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;


namespace Admitere3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AdmitereContext _context;
        public HomeController(ILogger<HomeController> logger,AdmitereContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Formular()
        {
            ClientData client = new ClientData();
            List<Model.Beneficiari> lista_beneficiari = (from beneficiar in _context.Beneficiaris
                                                         select beneficiar).ToList();


            List<Item> optiuni = new List<Item>();


            ViewBag.ListaDeBeneficiari = lista_beneficiari;
            return View(client);
        }

        [HttpPost]
        public async Task<IActionResult> Submit(ClientData client)
        {
            if (client.diplomaBac == null || client.dovadaTaxaInscriere == null || 
                client.nume ==null || client.email == null)
            {
                return View("MailResultView",client);
            }

            //pdf
            client.GeneratePdf();

            //mail
            //Task.Factory.StartNew(() => {
            //    client.MySendMailAsync();
            //    //Do an advanced looging here which takes a while
            //});


            await client.MySendMailAsync();

            return View("MailResultView", client);
        }
       
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public class Item
        {
            public string Text;
            public int Value;
        }
    }
}
