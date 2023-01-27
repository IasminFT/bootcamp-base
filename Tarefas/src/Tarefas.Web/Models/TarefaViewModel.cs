using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Tarefas.Web.Models;

public class TarefaViewModel
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "A descrição da tarefa deve ser preenchida.")]
    [DisplayName("Título")]    
    [MinLength(5, ErrorMessage = "O título deve ter no minimo 5 caracteres")]
    public string? Titulo { get; set; }        
    
    [Required(ErrorMessage = "A descrição da tarefa deve ser preenchida.")]
    [DisplayName("Descrição")]    
    [MinLength(5, ErrorMessage = "A descrição deve ter no minimo 5 caracteres")]
    public string? Descricao { get; set; }  

    [Required(ErrorMessage = "A descrição da tarefa deve ser preenchida.")]
    [DisplayName("Concluída")]
    
    public bool Concluida { get; set; }
}