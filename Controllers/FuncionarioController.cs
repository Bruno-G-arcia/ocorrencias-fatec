using OcorrenciasWeb.Models;
using Microsoft.AspNetCore.Mvc;
using OcorrenciasWeb.Repositories;

namespace OcorrenciasWeb.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioRepository repository;

        public FuncionarioController(IFuncionarioRepository repository)
        {
            this.repository = repository;
        }
        
        public ActionResult Index()
        {
            List<Funcionario> funcionarios = repository.Read();
            return View(funcionarios);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Funcionario funcionario)
        {
            repository.Create(funcionario);
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
            var funcionario = repository.Read(id);
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Update(int id, Funcionario funcionario)
        {
            repository.UpdateFuncionarioPessoa(id, funcionario);
            return RedirectToAction("Funcionario", "Home");
        } 
    }
}