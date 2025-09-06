using System.Data.Common;
using System.Linq;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Interfaces;
using MinimalApi.DTOs;
using MinimalApi.Infraestrutura.Db;

namespace MinimalApi.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;
    public AdministradorServico(DbContexto contexto)
    {
        _contexto = contexto;
    }

    // Método usado em alguns pontos do código que retorna bool
    public bool Login(LoginDTO loginDTO)
    {
        return _contexto.Administradores.Any(
            a => a.Email == loginDTO.Email &&
                 a.Senha == loginDTO.Senha
        );
    }

    // Método que retorna o Administrador (ou null)
    public Administrador? LoginAdministrador(LoginDTO loginDTO)
    {
        return _contexto.Administradores
            .FirstOrDefault(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha);
    }

    // Implementação explícita da interface (se IAdministradorServico.Login retorna Administrador?)
    Administrador? IAdministradorServico.Login(LoginDTO loginDTO)
    {
        return LoginAdministrador(loginDTO);
    }

    public Administrador Incluir(Administrador administrador)
    {
        _contexto.Administradores.Add(administrador);
        _contexto.SaveChanges();

        return administrador;
    }

    // Página padrão, com paginação simples
    public List<Administrador> Todos(int pagina = 1, string? nome = null, string? marca = null)
    {
        var query = _contexto.Administradores.AsQueryable();

        int tamanhoPagina = 10;
        int pularRegistros = (pagina - 1) * tamanhoPagina;

        return query
            .Skip(pularRegistros)
            .Take(tamanhoPagina)
            .ToList();
    }

    // Sobrecarga que aceita int? — delega ao método acima
    public List<Administrador> Todos(int? pagina)
    {
        return Todos(pagina ?? 1);
    }

    public Administrador? BuscaPorId(int id)
    {
        return _contexto.Administradores.Find(id);
    }
}