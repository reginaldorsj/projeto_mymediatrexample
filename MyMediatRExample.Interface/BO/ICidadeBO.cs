

using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;
using MyMediatRExample.OR;

namespace MyMediatRExample.BO
{
	/// <summary>
	/// Regras de neg�cio para gerenciamento da classe <see cref='ICidadeBO'/>
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public interface ICidadeBO : IDisposable
	{
		/// <summary>
		/// Selecionar objeto.
		/// </summary>
		/// <param name="id">O id.</param>
		/// <returns></returns>
		MyMediatRExample.OR.Cidade SelecionarPorId(object id);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="propertyOrder">A propriedade ordem.</param>
		/// <returns>A lista ordenada.</returns>
		System.Collections.Generic.IList<MyMediatRExample.OR.Cidade> Listar(string propertyOrder);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O nome da propriedade para utilizar na sele��o.</param>
		/// <param name="value">O valor procurado na propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		MyMediatRExample.OR.Cidade SelecionarPor(string propertyName, object value);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName1">O nome da primeira propriedade a ser utilizada na sele��o.</param>
		/// <param name="value1">O valor procurado na primeira propriedade.</param>
		/// <param name="propertyName2">O nome da segunda propriedade a ser utlizada na sele��o.</param>
		/// <param name="value2">TO valor procurado na segunda propriedade.</param>
		/// <returns>O objeto selecionado.</returns>
		MyMediatRExample.OR.Cidade SelecionarPor(string propertyName1, object value1,string propertyName2, object value2);
		/// <summary>
		/// Selecionar um objeto.
		/// </summary>
		/// <param name="propertyName">O array de propriedades para utilizar na sele��o.</param>
		/// <param name="value">O array de valores procurados nas propriedades.</param>
		/// <returns>O objeto selecionado.</returns>
		MyMediatRExample.OR.Cidade SelecionarPor(string[] propertyName, object[] value);
		/// <summary>
		/// Transforma um lista em um DataTable.
		/// </summary>
		/// <param name="lst">A lista.</param>
		/// <returns>O DataTable.</returns>
		DataTable ToDataTable(IList<MyMediatRExample.OR.Cidade> lst);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		IList<MyMediatRExample.OR.Cidade> ListarPorUf(MyMediatRExample.OR.Uf uf);
		/// <summary>
		/// Insere ou altera um objeto no banco de dados.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		/// <param name="op">A opera��o.</param>
		/// <returns>O objeto ap�s a persist�ncia.</returns>
		MyMediatRExample.OR.Cidade InserirAlterar(MyMediatRExample.OR.Cidade cidade, Regisoft.Operacao op);
		/// <summary>
		/// Exclui o objeto do banco de dados.
		/// </summary>
		/// <param name="cidade">O(A) cidade.</param>
		void Excluir(MyMediatRExample.OR.Cidade cidade);
		/// <summary>
		/// Exclui uma lista de objeto do banco de dados.
		/// </summary>
		/// <param name="lst">A lista.</param>
		void Excluir(IList<MyMediatRExample.OR.Cidade> lst);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="dado"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Cidade> ListarPor(string dado);
					
	}
}
