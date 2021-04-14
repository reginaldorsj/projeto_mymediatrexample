
using System;

namespace MyMediatRExample.DAO
{
	/// <summary>
	/// Classe que exp�e os DAO's.
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
    public interface IDAOFactory : IDisposable
    {
		/// <summary>
		/// Acesso a classe CidadeDAO.
		/// </summary>
		/// <returns></returns>
		ICidadeDAO CidadeDAO();
		/// <summary>
		/// Acesso a classe UfDAO.
		/// </summary>
		/// <returns></returns>
		IUfDAO UfDAO();

    }
}
