
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
	public class UfDAO : BaseDAO<Uf, long>, MyMediatRExample.DAO.IUfDAO
	{
		/// <summary>
		/// Inicializa uma instância de <see cref="UfDAO"/>.
		/// </summary>
		[InjectionConstructor]
        public UfDAO()
            : base()
        {
        }
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="sigla"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		public IList<Uf> ListarPor(string sigla)
		{
			throw new NotImplementedException("Não implementado.");
		}
	}
}
