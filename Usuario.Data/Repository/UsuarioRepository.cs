using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Usuario.Business.Interfaces;
using Usuario.Business.Models;
using Usuario.Data.Context;

namespace Usuario.Data.Repository
{
    public class UsuarioRepository : Repository<Usuarios>, IUsuarioRepository
    {
        public UsuarioRepository(MeuDbContext context) : base(context) { }

    }
}