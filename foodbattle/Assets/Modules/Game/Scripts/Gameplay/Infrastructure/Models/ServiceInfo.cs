using System;
using System.Collections.Generic;

namespace FoodBattle.Gameplay.Infrastructure.Models
{
    internal class ServiceInfo
    {
        public Type ContractType { get; set; }
        public IEnumerable<Type> ServiceTypes { get; set; }
    }
}