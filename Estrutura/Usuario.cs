using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Estrutura
{
    public class Usuario : Modelo.Usuario.ModeloUsuario
    {
        public Usuario()
            : base()
        {
        }

        public Usuario(int? id, string nome, string login, string senha, Modelo.Usuario.PermissaoUsuario permissao, Modelo.Usuario.StatusUsuario status)
            : base()
        {
            this.Id = id;
            this.Nome = nome;
            this.Login = login;
            this.Senha = senha;
            this.Permissao = permissao;
            this.Status = status;            
        }

        public bool Logar()
        {
            return Sessao.AceitarUsuario(this);            
        }

        public void Inserir()
        {
            this.ConferirOrigemParaInserir();
            Dados.AcessoUsuario.InserirUsuario(this);
        }

        public void Remover()
        {
            this.ConferirOrigemParaManipularDados();
            Dados.AcessoUsuario.RemoverUsuario(this);
        }

        public void Alterar()
        {
            this.ConferirOrigemParaManipularDados();
            Dados.AcessoUsuario.AlterarUsuario(this);
        }
    }
}
