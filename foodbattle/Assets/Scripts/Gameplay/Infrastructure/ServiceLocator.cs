using System;
using System.Collections.Generic;
using System.Linq;
using FoodBattle.Gameplay.Infrastructure.Abstract;
using FoodBattle.Gameplay.Infrastructure.Attributes;

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
            return ResolveMultiple<T>().First();
        }

        public IEnumerable<T> ResolveMultiple<T>()
        {
            if (_instantiatedServices.ContainsKey(typeof(T)))
            {
                return _instantiatedServices[typeof(T)].Cast<T>();
            }

            try
            {
                _instantiatedServices.Add(typeof(T), InitTypes(typeof(T)));
                return _instantiatedServices[typeof(T)].Cast<T>();
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("The requested service is not registered");
            }
        }
        
        private IEnumerable<object> InitTypes(Type contract)
        {
            var typesToCreate = _serviceTypes[contract];
            return typesToCreate.Select(typeToCreate => InternalResolve(typeToCreate));
        }

        private object InternalResolve(Type typeToResolve)
        {
            var constructors = typeToResolve.GetConstructors();
            if (!constructors.Any())
            {
                throw new ApplicationException($"Cannot find a suitable constructor for {typeToResolve}");
            }

            if (constructors.Length > 1)
            {
                throw new ApplicationException($"[{nameof(ServiceLocator)}]: Should not have multiple constructors for {typeToResolve}");
            }

            var constructor = constructors[0];
            if (!constructor.IsPublic)
            {
                throw new ApplicationException($"[{nameof(ServiceLocator)}]: Should have public constructor for {typeToResolve}");
            }

            var parameters = constructor.GetParameters().OrderBy(param => param.Position);
            if (!parameters.Any())
            {
                return constructor.Invoke(null);
            }

            var initedParameters = new List<object>();
            foreach (var parameter in parameters)
            {
                if (_instantiatedServices.ContainsKey(parameter.ParameterType))
                {
                    initedParameters.Add(_instantiatedServices[parameter.ParameterType].First());
                    continue;
                }
                
                initedParameters.Add(InternalResolve(parameter.ParameterType));
            }

            return constructor.Invoke(initedParameters.ToArray());
        }

        private void Init()
        {
            var contracts = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes()
                    .Where(p=>Attribute.GetCustomAttribute(p, typeof(ContractAttribute)) != null));

            foreach (var contract in contracts)
            {
                var services = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(s => s.GetTypes()).Where(p => contract.IsAssignableFrom(p) && Attribute.GetCustomAttribute(p, typeof(ServiceAttribute)) != null);
                
                _serviceTypes.Add(contract, services);
            }
        }
    }
}