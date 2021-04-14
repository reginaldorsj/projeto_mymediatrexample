
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Regisoft.Camadas.Generic;
using System.Data;
using Unity;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Cfg;
using MyMediatRExample.OR;

namespace MyMediatRExample.DAO
{
	/// <summary>
	/// Classe para acesso ao banco de dados utilizando o NHiberante.
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public class CidadeDAO : BaseDAO<Cidade, long>, MyMediatRExample.DAO.ICidadeDAO
	{
		/// <summary>
		/// Inicializa uma instância de <see cref="CidadeDAO"/>.
		/// </summary>
		[InjectionConstructor]
        public CidadeDAO()
            : base()
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		public IList<Cidade> ListarPorUf(Uf uf)
		{
			return Listar("IdUf","IdUf",uf.IdUf,"IdUf");
		}
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="iduf"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Cidade> ListarPor(string iduf)
		{
			throw new NotImplementedException("Não implementado.");
		}
	}
}
