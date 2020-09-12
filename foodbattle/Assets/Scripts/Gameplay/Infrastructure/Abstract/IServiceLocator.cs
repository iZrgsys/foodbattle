using System.Collections;
using System.Collections.Generic;

namespace FoodBattle.Gameplay.Infrastructure.Abstract
{
    internal interface IServiceLocator
    {
        T Resolve<T>();

        IEnumerable<T> ResolveMultiple<T>();
    }
}