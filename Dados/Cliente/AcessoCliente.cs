using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dados
{
    public static class AcessoCliente
    {
        public static void InserirCliente(Modelo.Cliente.ModeloCliente cliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Cliente.InserirCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Nome, cliente.Nome),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.NomePai, cliente.NomePai),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.NomeMae, cliente.NomeMae),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.DataNascimento, cliente.DataNascimento),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Profissao, cliente.Profissao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.TipoPessoa, cliente.TipoPessoa),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CPF, cliente.Cpf),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CNPJ, cliente.Cnpj),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.RG, cliente.Rg),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.OrgaoExpedidorRG, cliente.OrgaoExpedidorRG),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.DataEmissaoRG, cliente.DataEmissaoRG),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.EstadoCivil, cliente.EstadoCivil),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Nacionalidade, cliente.Nacionalidade),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.Logradouro, cliente.Endereco.Logradouro),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.Numero, cliente.Endereco.Numero),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.Complemento, cliente.Endereco.Complemento),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.Bairro, cliente.Endereco.Bairro),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.Cidade, cliente.Endereco.Cidade),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.UF, cliente.Endereco.Uf),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.CEP, cliente.Endereco.Cep),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.TituloEleitor, cliente.TituloEleitor),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.ZonaEleitoral, cliente.ZonaEleitoral),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.SecaoEleitoral, cliente.SecaoEleitoral),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IndicadorGrupo, cliente.IndGrupo),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IndicadorCliente, cliente.IndCliente),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IndicadorContato, cliente.IndContato),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IndicadorDependente, cliente.IndDependente),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IndicadorPendencia, cliente.IndPendencia),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IndicadorFalecido, cliente.IndFalecido),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.DataFalecimento, cliente.DataFalecimento),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Naturalidade, cliente.Naturalidade),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPS1, cliente.Ctps1),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPS2, cliente.Ctps2),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPS3, cliente.Ctps3),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPS4, cliente.Ctps4),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPS5, cliente.Ctps5),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPSSerie1, cliente.CtpsSerie1),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPSSerie2, cliente.CtpsSerie2),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPSSerie3, cliente.CtpsSerie3),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPSSerie4, cliente.CtpsSerie4),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPSSerie5, cliente.CtpsSerie5),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.PISPASEP1, cliente.PisPasep1),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.PISPASEP2, cliente.PisPasep2),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.PISPASEP3, cliente.PisPasep3),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.PISPASEP4, cliente.PisPasep4),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.NIT1, cliente.Nit1),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.NIT2, cliente.Nit2),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.NIT3, cliente.Nit3),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.NIT4, cliente.Nit4),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Indicacao, cliente.NomeClienteIndicacao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento, cliente.Atendimento)
                );
                dynamic dados = objeto as dynamic;
                objeto.Reader.Read();
                cliente.Id = (int?)@dados.idCliente;
                cliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objeto != null)
                {
                    objeto.Reader.Close();
                }
            }
        }

        public static void AlterarCliente(Modelo.Cliente.ModeloCliente cliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(
                    Constantes.Procedures.Cliente.AlterarCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IdCliente, cliente.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Nome, cliente.Nome),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.NomePai, cliente.NomePai),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.NomeMae, cliente.NomeMae),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.DataNascimento, cliente.DataNascimento),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Profissao, cliente.Profissao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.TipoPessoa, cliente.TipoPessoa),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CPF, cliente.Cpf),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CNPJ, cliente.Cnpj),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.RG, cliente.Rg),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.OrgaoExpedidorRG, cliente.OrgaoExpedidorRG),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.DataEmissaoRG, cliente.DataEmissaoRG),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.EstadoCivil, cliente.EstadoCivil),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Nacionalidade, cliente.Nacionalidade),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.Logradouro, cliente.Endereco.Logradouro),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.Numero, cliente.Endereco.Numero),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.Complemento, cliente.Endereco.Complemento),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.Bairro, cliente.Endereco.Bairro),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.Cidade, cliente.Endereco.Cidade),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.UF, cliente.Endereco.Uf),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Endereco.CEP, cliente.Endereco.Cep),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.TituloEleitor, cliente.TituloEleitor),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.ZonaEleitoral, cliente.ZonaEleitoral),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.SecaoEleitoral, cliente.SecaoEleitoral),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IndicadorGrupo, cliente.IndGrupo),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IndicadorCliente, cliente.IndCliente),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IndicadorContato, cliente.IndContato),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IndicadorDependente, cliente.IndDependente),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IndicadorPendencia, cliente.IndPendencia),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IndicadorFalecido, cliente.IndFalecido),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.DataFalecimento, cliente.DataFalecimento),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Naturalidade, cliente.Naturalidade),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPS1, cliente.Ctps1),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPS2, cliente.Ctps2),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPS3, cliente.Ctps3),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPS4, cliente.Ctps4),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPS5, cliente.Ctps5),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPSSerie1, cliente.CtpsSerie1),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPSSerie2, cliente.CtpsSerie2),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPSSerie3, cliente.CtpsSerie3),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPSSerie4, cliente.CtpsSerie4),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CTPSSerie5, cliente.CtpsSerie5),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.PISPASEP1, cliente.PisPasep1),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.PISPASEP2, cliente.PisPasep2),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.PISPASEP3, cliente.PisPasep3),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.PISPASEP4, cliente.PisPasep4),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.NIT1, cliente.Nit1),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.NIT2, cliente.Nit2),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.NIT3, cliente.Nit3),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.NIT4, cliente.Nit4),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Indicacao, cliente.NomeClienteIndicacao),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Atendimento, cliente.Atendimento)
                );
                cliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                cliente.Sujo = false;
            }
            finally
            {
                if (objeto != null)
                {
                    objeto.Reader.Close();
                }
            }
        }

        public static bool ObterCliente(Modelo.Cliente.ModeloCliente cliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.ObterCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IdCliente, cliente.Id));

                dynamic dados = objeto as dynamic;
                if (objeto.Reader.Read())
                {
                    cliente.Id = @dados.idCliente;
                    cliente.Nome = @dados.nome;
                    cliente.NomePai = @dados.nomePai;
                    cliente.NomeMae = @dados.nomeMae;
                    cliente.DataNascimento = @dados.dataNascimento;
                    cliente.Profissao = @dados.profissao;
                    cliente.TipoPessoa = @dados.tipoPessoa == null ? 'F' : Convert.ToChar(@dados.tipoPessoa);
                    cliente.Cpf = @dados.cpf;
                    cliente.Cnpj = @dados.cnpj;
                    cliente.Rg = @dados.rg;
                    cliente.OrgaoExpedidorRG = @dados.orgaoExpedidorRG;
                    cliente.DataEmissaoRG = @dados.dataEmissaoRg;
                    Modelo.Comum.EstadoCivil estadoCivil;
                    if (Enum.TryParse(@dados.estadoCivil, out estadoCivil))
                    {
                        cliente.EstadoCivil = estadoCivil;
                    }
                    cliente.Nacionalidade = @dados.nacionalidade;
                    cliente.Endereco.Logradouro = @dados.enderecoLogradouro;
                    cliente.Endereco.Numero = @dados.enderecoNumero;
                    cliente.Endereco.Complemento = @dados.enderecoComplemento;
                    cliente.Endereco.Bairro = @dados.enderecoBairro;
                    cliente.Endereco.Cidade = @dados.enderecoCidade;
                    cliente.Endereco.Uf = @dados.enderecoUF;
                    cliente.Endereco.Cep = @dados.enderecoCEP;
                    cliente.TituloEleitor = @dados.tituloEleitor;
                    cliente.ZonaEleitoral = @dados.zonaEleitoral;
                    cliente.SecaoEleitoral = @dados.secaoEleitoral;
                    cliente.IndGrupo = Convert.ToBoolean(@dados.indGrupo);
                    cliente.IndCliente = Convert.ToBoolean(@dados.indCliente);
                    cliente.IndContato = Convert.ToBoolean(@dados.indContato);
                    cliente.IndDependente = Convert.ToBoolean(@dados.indDependente);
                    cliente.IndPendencia = Convert.ToBoolean(@dados.indPendencia);
                    cliente.IndFalecido = Convert.ToBoolean(@dados.indFalecido);
                    cliente.DataFalecimento = @dados.dataFalecimento;
                    cliente.Naturalidade = @dados.naturalidade;
                    cliente.Ctps1 = @dados.ctps1;
                    cliente.Ctps2 = @dados.ctps2;
                    cliente.Ctps3 = @dados.ctps3;
                    cliente.Ctps4 = @dados.ctps4;
                    cliente.Ctps5 = @dados.ctps5;
                    cliente.CtpsSerie1 = @dados.ctpsserie1;
                    cliente.CtpsSerie2 = @dados.ctpsserie2;
                    cliente.CtpsSerie3 = @dados.ctpsserie3;
                    cliente.CtpsSerie4 = @dados.ctpsserie4;
                    cliente.CtpsSerie5 = @dados.ctpsserie5;
                    cliente.Nit1 = @dados.nit1;
                    cliente.Nit2 = @dados.nit2;
                    cliente.Nit3 = @dados.nit3;
                    cliente.Nit4 = @dados.nit4;
                    cliente.PisPasep1 = @dados.pispasep1;
                    cliente.PisPasep2 = @dados.pispasep2;
                    cliente.PisPasep3 = @dados.pispasep3;
                    cliente.PisPasep4 = @dados.pispasep4;
                    cliente.NomeClienteIndicacao = @dados.indicacao;
                    cliente.Atendimento = @dados.atendimento;
                    cliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;                    
                    return true;
                }
                else return false;
            }
            finally
            {
                if (objeto != null)
                {
                    objeto.Reader.Close();
                }
            }
        }

        public static void RemoverCliente(Modelo.Cliente.ModeloCliente cliente)
        {
            try
            {
                ExecucaoProcedure.ExecutarNonQuery(
                    Constantes.Procedures.Cliente.RemoverCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IdCliente, cliente.Id)
                );
                cliente.Id = null;
                cliente.OrigemDados = Modelo.Comum.OrigemDados.Local;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static IEnumerable<Modelo.Cliente.ModeloCliente> PesquisarCliente(Modelo.Cliente.ModeloCliente clienteBase,Func<Modelo.Cliente.ModeloCliente> criacaoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.ListarCliente,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.IdCliente, clienteBase.Id),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.Nome, clienteBase.Nome),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.CPF, clienteBase.Cpf),
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.RG, clienteBase.Rg)
                    );

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Cliente.ModeloCliente cliente = criacaoCliente();
                    cliente.Id = @dados.idCliente;
                    cliente.Nome = @dados.nome;
                    cliente.Nome = @dados.nome;
                    cliente.NomePai = @dados.nomePai;
                    cliente.NomeMae = @dados.nomeMae;
                    cliente.DataNascimento = @dados.dataNascimento;
                    cliente.Profissao = @dados.profissao;
                    cliente.TipoPessoa = @dados.tipoPessoa == null ? 'F' : Convert.ToChar(@dados.tipoPessoa);
                    cliente.Cpf = @dados.cpf;
                    cliente.Cnpj = @dados.cnpj;
                    cliente.Rg = @dados.rg;
                    cliente.OrgaoExpedidorRG = @dados.orgaoExpedidorRG;
                    cliente.DataEmissaoRG = @dados.dataEmissaoRg;
                    Modelo.Comum.EstadoCivil estadoCivil;
                    if (Enum.TryParse(@dados.estadoCivil, out estadoCivil))
                    {
                        cliente.EstadoCivil = estadoCivil;
                    }
                    cliente.Nacionalidade = @dados.nacionalidade;
                    cliente.Endereco.Logradouro = @dados.enderecoLogradouro;
                    cliente.Endereco.Numero = @dados.enderecoNumero;
                    cliente.Endereco.Complemento = @dados.enderecoComplemento;
                    cliente.Endereco.Bairro = @dados.enderecoBairro;
                    cliente.Endereco.Cidade = @dados.enderecoCidade;
                    cliente.Endereco.Uf = @dados.enderecoUF;
                    cliente.Endereco.Cep = @dados.enderecoCEP;
                    cliente.TituloEleitor = @dados.tituloEleitor;
                    cliente.ZonaEleitoral = @dados.zonaEleitoral;
                    cliente.SecaoEleitoral = @dados.secaoEleitoral;
                    cliente.IndGrupo = Convert.ToBoolean(@dados.indGrupo);
                    cliente.IndCliente = Convert.ToBoolean(@dados.indCliente);
                    cliente.IndContato = Convert.ToBoolean(@dados.indContato);
                    cliente.IndDependente = Convert.ToBoolean(@dados.indDependente);
                    cliente.IndPendencia = Convert.ToBoolean(@dados.indPendencia);
                    cliente.IndFalecido = Convert.ToBoolean(@dados.indFalecido);
                    cliente.DataFalecimento = @dados.dataFalecimento;
                    cliente.Naturalidade = @dados.naturalidade;
                    cliente.Ctps1 = @dados.ctps1;
                    cliente.Ctps2 = @dados.ctps2;
                    cliente.Ctps3 = @dados.ctps3;
                    cliente.Ctps4 = @dados.ctps4;
                    cliente.Ctps5 = @dados.ctps5;
                    cliente.CtpsSerie1 = @dados.ctpsserie1;
                    cliente.CtpsSerie2 = @dados.ctpsserie2;
                    cliente.CtpsSerie3 = @dados.ctpsserie3;
                    cliente.CtpsSerie4 = @dados.ctpsserie4;
                    cliente.CtpsSerie5 = @dados.ctpsserie5;
                    cliente.Nit1 = @dados.nit1;
                    cliente.Nit2 = @dados.nit2;
                    cliente.Nit3 = @dados.nit3;
                    cliente.Nit4 = @dados.nit4;
                    cliente.PisPasep1 = @dados.pispasep1;
                    cliente.PisPasep2 = @dados.pispasep2;
                    cliente.PisPasep3 = @dados.pispasep3;
                    cliente.PisPasep4 = @dados.pispasep4;
                    cliente.NomeClienteIndicacao = @dados.indicacao;
                    cliente.Atendimento = @dados.atendimento;
                    cliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return cliente;
                }
            }
            finally
            {
                if (objeto != null)
                {
                    objeto.Reader.Close();
                }
            }
        }

        public static IEnumerable<Modelo.Cliente.ModeloCliente> PesquisarClienteFullText(String textoBusca, Func<Modelo.Cliente.ModeloCliente> criacaoCliente)
        {
            ObjetoBanco objeto = null;
            try
            {
                objeto = ExecucaoProcedure.ExecutarQuery(Constantes.Procedures.Cliente.ListarClienteFullText,
                    new KeyValuePair<string, object>(Constantes.Parametros.Cliente.TextoBusca, textoBusca)
                    );

                dynamic dados = objeto as dynamic;
                while (objeto.Reader.Read())
                {
                    Modelo.Cliente.ModeloCliente cliente = criacaoCliente();
                    cliente.Id = @dados.idCliente;
                    cliente.Nome = @dados.nome;
                    cliente.Nome = @dados.nome;
                    cliente.NomePai = @dados.nomePai;
                    cliente.NomeMae = @dados.nomeMae;
                    cliente.DataNascimento = @dados.dataNascimento;
                    cliente.Profissao = @dados.profissao;
                    cliente.TipoPessoa = @dados.tipoPessoa == null ? 'F' : Convert.ToChar(@dados.tipoPessoa);
                    cliente.Cpf = @dados.cpf;
                    cliente.Cnpj = @dados.cnpj;
                    cliente.Rg = @dados.rg;
                    cliente.OrgaoExpedidorRG = @dados.orgaoExpedidorRG;
                    cliente.DataEmissaoRG = @dados.dataEmissaoRg;
                    Modelo.Comum.EstadoCivil estadoCivil;
                    if (Enum.TryParse(@dados.estadoCivil, out estadoCivil))
                    {
                        cliente.EstadoCivil = estadoCivil;
                    }
                    cliente.Nacionalidade = @dados.nacionalidade;
                    cliente.Endereco.Logradouro = @dados.enderecoLogradouro;
                    cliente.Endereco.Numero = @dados.enderecoNumero;
                    cliente.Endereco.Complemento = @dados.enderecoComplemento;
                    cliente.Endereco.Bairro = @dados.enderecoBairro;
                    cliente.Endereco.Cidade = @dados.enderecoCidade;
                    cliente.Endereco.Uf = @dados.enderecoUF;
                    cliente.Endereco.Cep = @dados.enderecoCEP;
                    cliente.TituloEleitor = @dados.tituloEleitor;
                    cliente.ZonaEleitoral = @dados.zonaEleitoral;
                    cliente.SecaoEleitoral = @dados.secaoEleitoral;
                    cliente.IndGrupo = Convert.ToBoolean(@dados.indGrupo);
                    cliente.IndCliente = Convert.ToBoolean(@dados.indCliente);
                    cliente.IndContato = Convert.ToBoolean(@dados.indContato);
                    cliente.IndDependente = Convert.ToBoolean(@dados.indDependente);
                    cliente.IndPendencia = Convert.ToBoolean(@dados.indPendencia);
                    cliente.IndFalecido = Convert.ToBoolean(@dados.indFalecido);
                    cliente.DataFalecimento = @dados.dataFalecimento;
                    cliente.Naturalidade = @dados.naturalidade;
                    cliente.Ctps1 = @dados.ctps1;
                    cliente.Ctps2 = @dados.ctps2;
                    cliente.Ctps3 = @dados.ctps3;
                    cliente.Ctps4 = @dados.ctps4;
                    cliente.Ctps5 = @dados.ctps5;
                    cliente.CtpsSerie1 = @dados.ctpsserie1;
                    cliente.CtpsSerie2 = @dados.ctpsserie2;
                    cliente.CtpsSerie3 = @dados.ctpsserie3;
                    cliente.CtpsSerie4 = @dados.ctpsserie4;
                    cliente.CtpsSerie5 = @dados.ctpsserie5;
                    cliente.Nit1 = @dados.nit1;
                    cliente.Nit2 = @dados.nit2;
                    cliente.Nit3 = @dados.nit3;
                    cliente.Nit4 = @dados.nit4;
                    cliente.PisPasep1 = @dados.pispasep1;
                    cliente.PisPasep2 = @dados.pispasep2;
                    cliente.PisPasep3 = @dados.pispasep3;
                    cliente.PisPasep4 = @dados.pispasep4;
                    cliente.NomeClienteIndicacao = @dados.indicacao;
                    cliente.Atendimento = @dados.atendimento;
                    cliente.OrigemDados = Modelo.Comum.OrigemDados.Banco;
                    yield return cliente;
                }
            }
            finally
            {
                if (objeto != null)
                {
                    objeto.Reader.Close();
                }
            }
        }

    }
}
