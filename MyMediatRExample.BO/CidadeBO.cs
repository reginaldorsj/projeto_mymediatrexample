
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using Regisoft;
using MyMediatRExample.OR;
using MyMediatRExample.DAO;

namespace MyMediatRExample.BO
{
	/// <summary>
	/// Regras de negócio para gerenciamento da classe <see cref='CidadeBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public class CidadeBO : MarshalByRefObject, MyMediatRExample.BO.ICidadeBO
	{
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected ICidadeDAO cidadeDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="CidadeBO"/>.
		/// </summary>
		public CidadeBO()
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			cidadeDAO = daoAccess.CidadeDAO();
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="CidadeBO"/> is reclaimed by garbage collection.
		/// </summary>
		~CidadeBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			cidadeDAO.Dispose();
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		public IList<MyMediatRExample.OR.Cidade> ListarPorUf(Uf uf)
		{
			return cidadeDAO.ListarPorUf(uf);
		}
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		public DataTable ToDataTable(IList<MyMediatRExample.OR.Cidade> lst)
		{
			return cidadeDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public MyMediatRExample.OR.Cidade SelecionarPor(string propertyName, object value)
		{
			return cidadeDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public MyMediatRExample.OR.Cidade SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return cidadeDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public MyMediatRExample.OR.Cidade SelecionarPor(string[] propertyName, object[] value)
		{
			return cidadeDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public MyMediatRExample.OR.Cidade SelecionarPorId(object id)
		{
			return cidadeDAO.SelecionarPor("IdCidade",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<MyMediatRExample.OR.Cidade> Listar(string propertyOrder)
		{
			return cidadeDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public MyMediatRExample.OR.Cidade InserirAlterar(MyMediatRExample.OR.Cidade cidade, Regisoft.Operacao op)
		{
			cidadeDAO.ValidaNotNull(cidade);
			Cidade _ix_cidade_uf_descricao = cidadeDAO.SelecionarPor(new string[]{ "IdUf" , "Descricao" }, new object[]{ cidade.IdUf , cidade.Descricao });
			 if ((op == Operacao.Incluir && _ix_cidade_uf_descricao != null) ||(op == Operacao.Alterar && _ix_cidade_uf_descricao != null && _ix_cidade_uf_descricao.IdCidade != cidade.IdCidade))
				throw new ExceptionRS("Violação do índice: IX_CIDADE_UF_DESCRICAO");

			cidadeDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					cidade = cidadeDAO.CopiarParaPersistente(cidade.IdCidade.Value,cidade);
				cidade = cidadeDAO.InserirAlterar(cidade,op);
				cidadeDAO.CommitTransaction();				
			}			
			catch
			{
				cidadeDAO.RollbackTransaction();
				throw;
			}				
			return cidade;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		public void Excluir(MyMediatRExample.OR.Cidade cidade)
		{
			cidadeDAO.BeginTransaction();
			try
			{
				cidadeDAO.Excluir(cidade);
				cidadeDAO.CommitTransaction();
			}
			catch
			{
				cidadeDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		public void Excluir(IList<MyMediatRExample.OR.Cidade> lst)
		{
			cidadeDAO.BeginTransaction();
			try 
			{
				foreach (MyMediatRExample.OR.Cidade cidade in lst)
				{
					cidadeDAO.Excluir(cidade);
				}
				cidadeDAO.CommitTransaction();				
			}			
			catch
			{
				cidadeDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Cidade> ListarPor(string dado)
		{
			return cidadeDAO.ListarPor(dado);
		}
	}
}
