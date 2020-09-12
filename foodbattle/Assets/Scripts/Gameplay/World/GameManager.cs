using System;
using FoodBattle.Gameplay.Base;
using FoodBattle.Gameplay.Infrastructure;

namespace FoodBattle.Gameplay.World
{
    public class GameManager : MonoSingleton<GameManager>
    {
        private void Start()
        {
            var locator = ServiceLocator.Instance;
        }
    }
}