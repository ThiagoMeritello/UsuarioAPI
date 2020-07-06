using System;
using System.Threading.Tasks;
using Usuario.Business.Models;

namespace Usuario.Business.Interfaces
{
    public interface IUsuarioService : IDisposable
    {
        Task Adicionar(Usuarios usuario);
        Task Atualizar(Usuarios usuario);
        Task Remover(Guid id);
    }
}
