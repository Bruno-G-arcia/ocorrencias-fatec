using OcorrenciasWeb.Models;
using Microsoft.AspNetCore.Mvc;
using OcorrenciasWeb.Repositories;

namespace OcorrenciasWeb.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository repository;

        public ClienteController(IClienteRepository repository)
        {
            this.repository = repository;
        }
        
        public ActionResult Index()
        {
            List<Cliente> clientes = repository.Read();
            return View(clientes);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            repository.Create(cliente);
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
            var cliente = repository.Read(id);
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Update(int id, Cliente cliente)
        {
            repository.UpdateClientePessoa(id, cliente);
            return RedirectToAction("Cliente", "Home");
        } 
    }
}