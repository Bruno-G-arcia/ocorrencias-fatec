using OcorrenciasWeb.Models;
using Microsoft.AspNetCore.Mvc;
using OcorrenciasWeb.Repositories;

namespace OcorrenciasWeb.Controllers
{
    public class OrdemServicoController : Controller
    {
        private readonly IOrdemServicoRepository repository;
        public IOcorrenciaRepository OcRep;

        public OrdemServicoController(IOrdemServicoRepository repository)
        {
            this.repository = repository;
            this.OcRep = new OcorrenciaSQLRepository();
        }
        
        public ActionResult Index()
        {
            List<OrdemServico> ordemServicos = repository.Read();
            return View(ordemServicos);
        }

        public ActionResult Detalhes(int idOcorrencia)
        {
            var ocorrencia = OcRep.Read(idOcorrencia);

            ViewBag.IdOcorrencia  = ocorrencia.IdOcorrencia;
            ViewBag.OcTitulo      = ocorrencia.Titulo;
            ViewBag.OcDescricao   = ocorrencia.Descricao;
            ViewBag.OcAbertura    = ocorrencia.Abertura;
            ViewBag.OcPrazo       = ocorrencia.Prazo;
            ViewBag.OcStatus      = ocorrencia.Status;
            
            List<OrdemServico> ordemServicos = repository.ReadOc(idOcorrencia);

            return View(ordemServicos);
        }

        [HttpGet]
        public ActionResult Create(string idOcorrencia)
        {
            ViewBag.idOcorrencia = idOcorrencia;
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrdemServico ordemServico)
        {
            var idFuncionario = User.Claims.FirstOrDefault( u => u.Type == "idFuncionario").Value;
            ordemServico.IdFuncionario = Int32.Parse(idFuncionario);
            var ocorrencia = OcRep.Read(ordemServico.IdOcorrencia);
            ocorrencia.Status = ordemServico.Status;
            OcRep.Update(ocorrencia.IdOcorrencia, ocorrencia);
            repository.Create(ordemServico);
            return RedirectToAction("Funcionario", "Home");
        }

        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Main", "Home");
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var ordemServico = repository.Read(id);
            return View(ordemServico);
        }

        [HttpPost]
        public ActionResult Update(int id, OrdemServico ordemServico)
        {
            var idFuncionario = User.Claims.FirstOrDefault( u => u.Type == "idFuncionario").Value;
            ordemServico.IdFuncionario = Int32.Parse(idFuncionario);
            var ocorrencia = OcRep.Read(ordemServico.IdOcorrencia);
            ocorrencia.Status = ordemServico.Status;
            
            OcRep.Update(ocorrencia.IdOcorrencia, ocorrencia);
            repository.Update(id, ordemServico);
            return RedirectToAction("Main", "Home");
        }


    }
}