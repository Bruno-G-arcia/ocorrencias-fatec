using OcorrenciasWeb.Models;
using Microsoft.AspNetCore.Mvc;
using OcorrenciasWeb.Repositories;

namespace OcorrenciasWeb.Controllers
{
    public class OcorrenciaController : Controller
    {
        private IOcorrenciaRepository repository;

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
            repository.Create(ocorrencia);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            Console.WriteLine(id);
            var ocorrencia = repository.Read(id);
            return View(ocorrencia);
        }

        [HttpPost]
        public ActionResult Update(int id, Ocorrencia ocorrencia)
        {
            repository.Update(id, ocorrencia);
            return RedirectToAction("Index");
        } 
    }
}