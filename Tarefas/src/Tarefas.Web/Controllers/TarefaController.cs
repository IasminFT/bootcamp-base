using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;

namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        public List<Tarefa> listaDeTarefa { get; set; }

        public TarefaController()
        {
            listaDeTarefa = new List<TarefaViewModel>();
        }
        
        public IActionResult Details(int id)
        {
            var tarefaDTO = tarefaDAO.Consultar(id);

            var tarefa = new TarefaViewModel()
            {
                Id = tarefaDTO.Id,
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Concluida = tarefaDTO.Concluida
            };

            return View(tarefa);
        }

        public IActionResult Index()
        {   
            var listaDeTarefasDTO = tarefaDAO.Consultar();

            foreach (var tarefaDTO in listaDeTarefasDTO)  
            {
                listaDeTarefa.Add(new TarefaViewModel()
                {
                    Id = tarefaDTO.Id,
                    Titulo = tarefaDTO.Titulo,
                    Descricao = tarefaDTO.Descricao,
                    Concluida = tarefaDTO.Concluida,

                });
            }       
            return View(listaDeTarefa);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost] //receber objetos, parametros mais complexos -> mais abrangente que o get
        public IActionResult Create(TarefaViewModel tarefa)
        {
            var tarefaDTO = new TarefaDTO 
            {
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Concluida = tarefa.Concluida
            };

            var tarefaDAO = new TarefaDAO();
            tarefaDAO.Criar(tarefaDTO);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(TarefaViewModel tarefa){
            var tarefaDTO = new TarefaDTO
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Concluida = tarefa.Concluida
            };

            var tarefaDAO = new TarefaDAO();
            tarefaDAO.Atualizar(tarefaDTO);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id){
            var tarefaDTO = tarefaDAO.Consultar(id);

            var tarefa = new TarefaViewModel()
            {
                Id = tarefaDTO.Id,
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Concluida = tarefaDTO.Concluida
            };

            return View(tarefa);
        }

        public IActionResult Delete(int id){
            tarefaDAO.Excluir(id);

            return RedirectToAction("Index");
        }
    }
    
    private TarefaDAO tarefaDAO;

    public TarefaController()
    {
        tarefaDAO = new TarefaDAO();
    }
}