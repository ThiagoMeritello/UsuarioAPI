using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Usuario.Business.Interfaces;
using Usuario.Business.Models;
using Usuario.Business.Models.Validations;

namespace Usuario.Business.Services
{
    public class UsuarioService : BaseService, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              INotificador notificador) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task Adicionar(Usuarios usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return;

            await _usuarioRepository.Adicionar(usuario);
        }

        public async Task Atualizar(Usuarios usuario)
        {
            if (!ExecutarValidacao(new UsuarioValidation(), usuario)) return;

            await _usuarioRepository.Atualizar(usuario);
        }

        public async Task Remover(Guid id)
        {
            await _usuarioRepository.Remover(id);
        }

        public void Dispose()
        {
            _usuarioRepository?.Dispose();
        }
    }
}