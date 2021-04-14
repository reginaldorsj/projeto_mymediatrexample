
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
	/// Regras de negócio para gerenciamento da classe <see cref='UfBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public class UfBO : MarshalByRefObject, MyMediatRExample.BO.IUfBO
	{
		/// <summary>
		/// Define o objeto de acesso a dados.
		/// </summary>
		protected IUfDAO ufDAO;
	
		/// <summary>
		/// Inicializa uma instância da classe <see cref="UfBO"/>.
		/// </summary>
		public UfBO()
            : base()
        {
            IDAOFactory daoAccess = DAOAccess.GetDAOFactory();
			ufDAO = daoAccess.UfDAO();
        }
		/// <summary>
		/// Releases unmanaged resources and performs other cleanup operations before the
		/// <see cref="UfBO"/> is reclaimed by garbage collection.
		/// </summary>
		~UfBO()
		{
			Dispose();
		}
		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			ufDAO.Dispose();
		}
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		public DataTable ToDataTable(IList<MyMediatRExample.OR.Uf> lst)
		{
			return ufDAO.ToDataTable(lst);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na seleção.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public MyMediatRExample.OR.Uf SelecionarPor(string propertyName, object value)
		{
			return ufDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na seleção.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na seleção.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		public MyMediatRExample.OR.Uf SelecionarPor(string propertyName1, object value1, string propertyName2, object value2)
		{
			return ufDAO.SelecionarPor(propertyName1, value1, propertyName2, value2);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na seleção.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		public MyMediatRExample.OR.Uf SelecionarPor(string[] propertyName, object[] value)
		{
			return ufDAO.SelecionarPor(propertyName, value);
		}
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="id">O ID do objeto.</param>
		/// <returns>O objeto selecionado.</returns>
		public MyMediatRExample.OR.Uf SelecionarPorId(object id)
		{
			return ufDAO.SelecionarPor("IdUf",Convert.ChangeType(id,typeof(long)));
		}
		/// <summary>
		/// Listar objetos por uma propriedade específica.
		/// </summary>
		/// <param name="propertyOrder">A propriedade que ordena a seleção.</param>
		/// <returns>A lista ordenada.</returns>
		public IList<MyMediatRExample.OR.Uf> Listar(string propertyOrder)
		{
			return ufDAO.Listar(propertyOrder);
		}
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <param name="op">A operação.</param>
		/// <returns>O objeto após a persistência.</returns>
		public MyMediatRExample.OR.Uf InserirAlterar(MyMediatRExample.OR.Uf uf, Regisoft.Operacao op)
		{
			ufDAO.ValidaNotNull(uf);
			Uf _ix_uf_sigla = ufDAO.SelecionarPor(new string[]{ "Sigla" }, new object[]{ uf.Sigla });
			 if ((op == Operacao.Incluir && _ix_uf_sigla != null) ||(op == Operacao.Alterar && _ix_uf_sigla != null && _ix_uf_sigla.IdUf != uf.IdUf))
				throw new ExceptionRS("Violação do índice: IX_UF_SIGLA");

			ufDAO.BeginTransaction();
			try 
			{
				if (op==Regisoft.Operacao.Alterar)
					uf = ufDAO.CopiarParaPersistente(uf.IdUf.Value,uf);
				uf = ufDAO.InserirAlterar(uf,op);
				ufDAO.CommitTransaction();				
			}			
			catch
			{
				ufDAO.RollbackTransaction();
				throw;
			}				
			return uf;
		}
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		public void Excluir(MyMediatRExample.OR.Uf uf)
		{
			ufDAO.BeginTransaction();
			try 
			{
				ufDAO.Excluir(uf);
				ufDAO.CommitTransaction();				
			}			
			catch
			{
				ufDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Registro em uso.");
			}
		}
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		public void Excluir(IList<MyMediatRExample.OR.Uf> lst)
		{
			ufDAO.BeginTransaction();
			try 
			{
				foreach (MyMediatRExample.OR.Uf uf in lst)
				{
					ufDAO.Excluir(uf);
				}
				ufDAO.CommitTransaction();				
			}			
			catch
			{
				ufDAO.RollbackTransaction();
				throw new ExceptionRS("Impossivel excluir. Na lista informada possui registro em uso.");
			}
		}			
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Uf> ListarPor(string dado)
		{
			return ufDAO.ListarPor(dado);
		}
	}
}
