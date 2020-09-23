using System;
using FoodBattle.Modules.Infrastucture.Abstract;
using Ninject;

namespace FoodBattle.Modules.Infrastucture
{
    public class ServiceLocator : IServiceLocator
    {
        private readonly IKernel _kernel;
        private static IServiceLocator _instance;
        private static readonly object LockObject = new object();

        private ServiceLocator()
        {
            _kernel = new StandardKernel();
        }

        public static IServiceLocator Instance
        {
            get
            {
                lock (LockObject)
                {
                    if (_instance == null)
                    {
                        _instance = new ServiceLocator();
                    }
                }

                return _instance;
            }
        }

        public T Resolve<T>()
        {
            return _kernel.Get<T>();
        }

        public void Register<TInterface>(Type implementation)
        {
            _kernel.Bind<TInterface>().To(implementation).InSingletonScope();
        }
    }
}