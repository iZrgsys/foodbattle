using System;
using FoodBattle.Modules.Infrastucture.Abstract;
using Ninject;

namespace FoodBattle.Modules.Infrastucture
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IKernel m_kernel;
        private static IServiceLocator m_instance;
        private static readonly object LockObject = new object();

        private ServiceLocator()
        {
            m_kernel = new StandardKernel();
        }

        public static IServiceLocator Instance
        {
            get
            {
                lock (LockObject)
                {
                    if (m_instance == null)
                    {
                        m_instance = new ServiceLocator();
                    }
                }

                return m_instance;
            }
        }

        public T Resolve<T>()
        {
            return m_kernel.Get<T>();
        }

        public void Register<TInterface>(Type implementation)
        {
            m_kernel.Bind<TInterface>().To(implementation).InSingletonScope();
        }
    }
}