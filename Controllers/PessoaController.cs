using OcorrenciasWeb.Models;
using Microsoft.AspNetCore.Mvc;
using OcorrenciasWeb.Repositories;

namespace OcorrenciasWeb.Controllers
{
    public class PessoaController : Controller
    {
        private readonly IPessoaRepository repository;

        public PessoaController(IPessoaRepository repository)
        {
            this.repository = repository;
        }
        
        public ActionResult Index()
        {
            List<Pessoa> pessoas = repository.Read();
            return View(pessoas);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pessoa pessoa)
        {
            repository.Create(pessoa);
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
            var pessoa = repository.Read(id);
            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Update(int id, Pessoa pessoa)
        {
            repository.Update(id, pessoa);
            return RedirectToAction("Index");
        } 
    }
}