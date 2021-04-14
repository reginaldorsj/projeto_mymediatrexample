
using System;
using Unity;

namespace MyMediatRExample.BO
{
	/// <summary>
	/// Classe que expõe os BO's.
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
    public class BOFactory : MarshalByRefObject, MyMediatRExample.BO.IBOFactory
    {
		/// <summary>
		/// Container para injeção de dependência.
		/// </summary>
        private UnityContainer unityContainer;
		/// <summary>
		/// Instância da classe para acesso estático.
		/// </summary>
        private static BOFactory instance = null;

		/// <summary>
		/// Inicializa uma instância de <see cref="BOFactory"/>.
		/// </summary>
		public BOFactory()
		{
			Inicialize();
		}

		/// <summary>
		/// Lê/Cria uma instância da classe.
		/// </summary>
		/// <returns></returns>
        public static BOFactory getInstance()
        {
            if (instance == null)
            {
                instance = new BOFactory();
            }
            return instance;
        }
		/// <summary>
		/// Inicializa esta instância.
		/// </summary>
		private void Inicialize() 
		{
			unityContainer = new UnityContainer();
			unityContainer.RegisterType<ICidadeBO, CidadeBO>();
			unityContainer.RegisterType<IUfBO, UfBO>();
		}

		#region IDAOFactory Members
		/// <summary>
		/// Acesso a classe CidadeBO.
		/// </summary>
		/// <returns></returns>
        public ICidadeBO CidadeBO()
        {
			return unityContainer.Resolve<CidadeBO>();
        }
		/// <summary>
		/// Acesso a classe UfBO.
		/// </summary>
		/// <returns></returns>
        public IUfBO UfBO()
        {
			return unityContainer.Resolve<UfBO>();
        }

        #endregion
		
    }
}
