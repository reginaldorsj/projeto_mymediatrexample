

using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Regisoft.Camadas.Generic;
using MyMediatRExample.OR;

namespace MyMediatRExample.DAO
{
	/// <summary>
	/// Classe <see cref='ICidadeDAO'/> para acesso a dados
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
	public interface ICidadeDAO : Regisoft.Camadas.Generic.IBaseDAO<Cidade, long>
	{
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="uf">O(A) uf.</param>
		/// <returns>A lista.</returns>
		IList<Cidade> ListarPorUf(Uf uf);
		/// <summary>
		/// Listar objetos.
		/// </summary>
		/// <param name="iduf"> O dado para pesquisa.</param>
		/// <returns>A lista.</returns>
		IList<Cidade> ListarPor(string iduf);
			
	}
}
