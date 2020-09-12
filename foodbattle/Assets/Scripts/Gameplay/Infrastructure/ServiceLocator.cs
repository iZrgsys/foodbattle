using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FoodBattle.Gameplay.Infrastructure.Abstract;
using FoodBattle.Gameplay.Infrastructure.Attributes;
using UnityEngine;

namespace FoodBattle.Gameplay.Infrastructure
{
    internal sealed class ServiceLocator : IServiceLocator
    {
        private static IServiceLocator _instance;
        private readonly IDictionary<Type, IEnumerable<Type>> _serviceTypes;
        private readonly IDictionary<Type, IEnumerable<object>> _instantiatedServices;
        
        private static readonly object Lock = new object();

        private ServiceLocator()
        {
            _serviceTypes = new Dictionary<Type, IEnumerable<Type>>();
            _instantiatedServices = new Dictionary<Type, IEnumerable<object>>();
            
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
            if (_instantiatedServices.ContainsKey(typeof(T)))
            {
                return (T) _instantiatedServices[typeof(T)].First();
            }

            try
            {
                var constructor = _serviceTypes[typeof(T)].First().GetConstructor(new Type[0]);
                Debug.Assert(constructor != null, "Cannot find a suitable constructor for " + typeof(T));

                var service = (T) constructor.Invoke(null);
                _instantiatedServices.Add(typeof(T), new List<object> {service});

                return service;
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("The requested service is not registered");
            }
        }

        public IEnumerable<T> ResolveMultiple<T>()
        {
            if (_instantiatedServices.ContainsKey(typeof(T)))
            {
                return (IEnumerable<T>) _instantiatedServices[typeof(T)].First();
            }

            try
            {
                var constructors = _serviceTypes[typeof(T)].Select(s=> s.GetConstructor(new Type[0]));
                Debug.Assert(constructors.Any(), "Cannot find a suitable constructor for " + typeof(T));

                var services = constructors.Select(constructor => constructor.Invoke(null)).ToList();

                _instantiatedServices.Add(typeof(T), services);

                return (IEnumerable<T>)services;
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("The requested service is not registered");
            }
        }

        private void Init()
        {
            var contracts = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes()
                    .Where(p=>Attribute.GetCustomAttribute(p, typeof(ContractAttribute)) != null));

            foreach (var contract in contracts)
            {
                var services = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes()).Where(p => p.IsAssignableFrom(contract) && Attribute.GetCustomAttribute(p, typeof(ServiceAttribute)) != null);
                
                _serviceTypes.Add(contract, services);
            }
        }
    }
}