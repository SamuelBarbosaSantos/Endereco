using Endereco.Repositorio.Contrato;
using Microsoft.AspNetCore.Mvc;

namespace Endereco.Controllers
{
    public class EnderecoController : Controller
    {
        private IEnderecoRepositorio _enderecoRepositorio;
        public EnderecoController(IEnderecoRepositorio enderecoRepositorio)
        {
            _enderecoRepositorio = enderecoRepositorio;
        }
        public ActionResult Index()
        {
            return View(_enderecoRepositorio.ObterTodosEnderecos());
        }
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Models.Endereco endereco)
        {
            if (ModelState.IsValid)
            {
                _enderecoRepositorio.Cadastrar(endereco);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
