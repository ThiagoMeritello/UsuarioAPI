using System;
using System.Collections.Generic;
using System.Text;
using Usuario.Business.Notificacoes;

namespace Usuario.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
