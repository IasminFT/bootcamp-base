using Microsoft.AspNetCore.Mvc;
using Tarefas.Web.Models;
using Tarefas.DTO;
using Tarefas.DAO;
using AutoMapper;

namespace Tarefas.Web.Controllers
{
    public class TarefaController : Controller
    {
        public List<TarefaViewModel> listaDeTarefa { get; set; }

        private readonly ITarefaDAO _tarefaDAO;

        private readonly IMapper _mapper;

        public TarefaController(ITarefaDAO tarefaDAO, IMapper mapper)
        {
            _tarefaDAO = tarefaDAO;
            _mapper = mapper;
        }
        
        public IActionResult Details(int id)
        {
            var tarefaDTO = _tarefaDAO.Consultar(id);

            var tarefa = _mapper.Map<TarefaViewModel>(tarefaDTO);

            /*var tarefa = new TarefaViewModel()
            {
                Id = tarefaDTO.Id,
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Concluida = tarefaDTO.Concluida
            };*/

            return View(tarefa);
        }

        public IActionResult Index()
        {   
            var listaDeTarefasDTO = _tarefaDAO.Consultar();

            listaDeTarefa = new List<TarefaViewModel>();

            foreach (var tarefaDTO in listaDeTarefasDTO)  
            {
                listaDeTarefa.Add(_mapper.Map<TarefaViewModel>(tarefaDTO));
                
                /*listaDeTarefa.Add(new TarefaViewModel()
                {
                    Id = tarefaDTO.Id,
                    Titulo = tarefaDTO.Titulo,
                    Descricao = tarefaDTO.Descricao,
                    Concluida = tarefaDTO.Concluida,

                });*/
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
            if(!ModelState.IsValid){
                return View();
            }  

            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);

            _tarefaDAO.Criar(tarefaDTO);

            return View();
        }

        [HttpPost]
        public IActionResult Update(TarefaViewModel tarefa){

            if(!ModelState.IsValid){
                return View();
            } 

            var tarefaDTO = _mapper.Map<TarefaDTO>(tarefa);

            /*var tarefaDTO = new TarefaDTO
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Concluida = tarefa.Concluida
            };*/

            _tarefaDAO.Atualizar(tarefaDTO);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id){

            var tarefaDTO = _tarefaDAO.Consultar(id);

            var tarefa = _mapper.Map<TarefaViewModel>(tarefaDTO);

            /*var tarefa = new TarefaViewModel()
            {
                Id = tarefaDTO.Id,
                Titulo = tarefaDTO.Titulo,
                Descricao = tarefaDTO.Descricao,
                Concluida = tarefaDTO.Concluida
            };*/

            return View(tarefa);
        }

        public IActionResult Delete(int id){
            _tarefaDAO.Excluir(id);

            return RedirectToAction("Index");
        }

    }
    
}