using System;

namespace FoodBattle.Modules.Infrastucture.Abstract
{
    public interface IServiceLocator
    {
        T Resolve<T>();

        void Register<T>(Type implementation);
    }
}