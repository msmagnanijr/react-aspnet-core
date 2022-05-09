using Microsoft.AspNetCore.Mvc;
using ProAtividade.API.Models;
using ProAtividada.API.Data;

namespace ProAtividade.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AtividadeController : ControllerBase
{

    private readonly EFContext _context;

    public AtividadeController(EFContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<Atividade> Get()
    {
        return _context.Atividades;
    }

    [HttpGet("{id}")]
    public Atividade Get(int id)
    {
        return _context.Atividades.FirstOrDefault(x => x.Id == id);
    }

    [HttpPost]
    public Atividade Post(Atividade atividade)
    {
        _context.Atividades.Add(atividade);
        if (_context.SaveChanges() > 0)
            return _context.Atividades.FirstOrDefault(x => x.Id == atividade.Id);
        else
            throw new Exception("Você não conseguiu adicionar uma atividade");
    }

    [HttpPut("{id}")]
    public Atividade Put(int id, Atividade atividade)
    {
        if (atividade.Id != id)
            throw new Exception("Você está tentando atualizar uma atividade que não existe");

        _context.Atividades.Update(atividade);
        if (_context.SaveChanges() > 0)
            return _context.Atividades.FirstOrDefault(x => x.Id == id);
        else
            return new Atividade();
    }


    [HttpDelete("{id}")]
    public bool Delete(int id)
    {

        var atividade = _context.Atividades.FirstOrDefault(x => x.Id == id);
        if (atividade == null)
            throw new Exception("Você está tentando deletar uma atividade que não existe");

        _context.Atividades.Remove(atividade);

        return _context.SaveChanges() > 0;
    }
}