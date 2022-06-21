using OcorrenciasWeb.Models;
using Microsoft.AspNetCore.Mvc;
using OcorrenciasWeb.Repositories;

namespace OcorrenciasWeb.Controllers
{
    public class OcorrenciaController : Controller
    {
    private const int V = 1;
    private readonly IOcorrenciaRepository repository;

        public OcorrenciaController(IOcorrenciaRepository repository)
        {
            this.repository = repository;
        }
        
        public ActionResult Index()
        {
            List<Ocorrencia> ocorrencias = repository.Read();
            return View(ocorrencias);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Ocorrencia ocorrencia)
        {
            int idCliente = 1;
            
            if(User.IsInRole("Cliente")){
                idCliente = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "idCliente").Value);
            }
            ocorrencia.IdCliente = idCliente;  
            
            repository.Create(ocorrencia);
            return RedirectToAction("Main", "Home");
        }

        

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Main", "Home");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var ocorrencia = repository.Read(id);
            return View(ocorrencia);
        }

        [HttpPost]
        public ActionResult Update(int id, Ocorrencia ocorrencia)
        {
            repository.Update(id, ocorrencia);
            return RedirectToAction("Main", "Home");
        }

        public ActionResult Detalhes(int id)
        {
            var ocorrencia = repository.Read(id);
            return View(ocorrencia);
        }

        public ActionResult Cargo(string cargo)
        {
            var ocorrencia = repository.Read();
            var fOcorrencia = ocorrencia.Where( o => o.Status == cargo).ToList();
            return View(fOcorrencia);
        }

        public ActionResult Finalizadas(int idCliente)
        {
            var ocorrencia = repository.Read();
            var fOcorrencia = ocorrencia.Where( o => o.IdCliente == idCliente && o.Status == "Finalizada").ToList();
            return View(fOcorrencia);
        }


    }
}