using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usuario.Api.ViewModels;
using Usuario.Business.Interfaces;
using Usuario.Business.Models;

namespace Usuario.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : MainController
    {

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuariosController(INotificador notificador,
                                  IUsuarioRepository usuarioRepository,
                                  IUsuarioService usuarioService,
                                  IMapper mapper) : base(notificador)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        //Listas
        [HttpGet]
        public async Task<IEnumerable<UsuarioViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<UsuarioViewModel>>(await _usuarioRepository.ObterTodos());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> ObterPorId(Guid id)
        {
            var usuarioViewModel = await ObterUsuario(id);

            if (usuarioViewModel == null) return NotFound();

            return usuarioViewModel;
        }

        //Adicionar
        [HttpPost]
        public async Task<ActionResult<UsuarioViewModel>> Adicionar(UsuarioViewModel usuarioViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _usuarioService.Adicionar(_mapper.Map<Usuarios>(usuarioViewModel));

            return CustomResponse(usuarioViewModel);
        }

        //Atualizar
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Atualizar(Guid id, UsuarioViewModel usuarioViewModel)
        {
            if (id != usuarioViewModel.Id)
            {
                NotificarErro("Os ids informados não são iguais!");
                return CustomResponse();
            }

            var usuarioAtualizacao = await ObterUsuario(id);
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            usuarioAtualizacao.Nome = usuarioViewModel.Nome;
            usuarioAtualizacao.Sobrenome = usuarioViewModel.Sobrenome;
            usuarioAtualizacao.Email = usuarioViewModel.Email;
            usuarioAtualizacao.DataNascimento = usuarioViewModel.DataNascimento;
            usuarioAtualizacao.Escolaridade = usuarioViewModel.Escolaridade;

            await _usuarioService.Atualizar(_mapper.Map<Usuarios>(usuarioAtualizacao));

            return CustomResponse(usuarioViewModel);
        }

        //Deletar
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<UsuarioViewModel>> Excluir(Guid id)
        {
            var usuario = await ObterUsuario(id);

            if (usuario == null) return NotFound();

            await _usuarioService.Remover(id);

            return CustomResponse(usuario);
        }

        private async Task<UsuarioViewModel> ObterUsuario(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.ObterPorId(id));
        }
    }
}