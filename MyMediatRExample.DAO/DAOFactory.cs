
using System;
using Unity;

namespace MyMediatRExample.DAO
{
	/// <summary>
	/// Classe que exp�e os DAO's.
	/// Gerado por RSClass - Gerador de Classes
	/// </summary>
    public class DAOFactory : MarshalByRefObject, MyMediatRExample.DAO.IDAOFactory
    {
		/// <summary>
		/// Container para inje��o de depend�ncia.
		/// </summary>
        private UnityContainer unityContainer;
		/// <summary>
		/// Inicializa uma inst�ncia de <see cref="DAOFactory"/>.
		/// </summary>
        public DAOFactory() 
        {			
			Inicialize();
		}
		/// <summary>
		/// Inicializa esta inst�ncia.
		/// </summary>
		private void Inicialize() 
		{
			unityContainer = new UnityContainer();
			unityContainer.RegisterType<ICidadeDAO, CidadeDAO>();
			unityContainer.RegisterType<IUfDAO, UfDAO>();
		}
		#region IDAOFactory Members
		/// <summary>
		/// Acesso a classe CidadeDAO.
		/// </summary>
		/// <returns></returns>
        public ICidadeDAO CidadeDAO()
        {
			return unityContainer.Resolve<CidadeDAO>();
        }
		/// <summary>
		/// Acesso a classe UfDAO.
		/// </summary>
		/// <returns></returns>
        public IUfDAO UfDAO()
        {
			return unityContainer.Resolve<UfDAO>();
        }
		public void Dispose()
		{
			// Nada
		}

        #endregion
		
    }
}
