namespace FoodBattle.Modules.Game.Scripts.Gameplay.Infrastructure.Abstract
{
    internal interface IServiceLocator
    {
        T Resolve<T>();
    }
}