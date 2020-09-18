using System;
using System.Collections.Generic;
using FoodBattle.Modules.Game.Scripts.Gameplay.Infrastructure.Abstract;
using FoodBattle.Modules.Game.Scripts.Gameplay.InputSystem;
using FoodBattle.Modules.Game.Scripts.Gameplay.InputSystem.Abstract;
using Ninject;

namespace FoodBattle.Modules.Game.Scripts.Gameplay.Infrastructure
{
    internal sealed class ServiceLocator : IServiceLocator
    {
        private static IServiceLocator _instance;
        private readonly IDictionary<Type, Type> _serviceTypes;
        private readonly IKernel _kernel;
        
        private static readonly object Lock = new object();

        private ServiceLocator()
        {
            _serviceTypes = new Dictionary<Type, Type>();
            _kernel = new StandardKernel();
            
            Init();
        }

        public static IServiceLocator Instance
        {
            get
            {
                lock (Lock)
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

        private void Init()
        {
            _kernel.Bind<IUserInputService>().To(typeof(UserInputService)).InSingletonScope();
        }
    }
}