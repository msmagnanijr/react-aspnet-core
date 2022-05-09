using ProAtividade.API.Models.Enums;

namespace ProAtividade.API.Models;
public class Atividade
{

    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public Prioridade Prioridade { get; set; }
}