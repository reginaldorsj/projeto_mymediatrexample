
using System;

namespace MyMediatRExample.BO
{
	/// <summary>
	/// Classe que expõe os BO's.
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
    public interface IBOFactory
    {
		/// <summary>
		/// Acesso a classe CidadeBO.
		/// </summary>
		/// <returns></returns>
		ICidadeBO CidadeBO();
		/// <summary>
		/// Acesso a classe UfBO.
		/// </summary>
		/// <returns></returns>
		IUfBO UfBO();

    }
}
