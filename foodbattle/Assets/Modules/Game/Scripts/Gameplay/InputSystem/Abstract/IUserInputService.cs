using FoodBattle.Modules.Game.Scripts.Gameplay.Infrastructure.Attributes;
using UnityEngine;

namespace FoodBattle.Modules.Game.Scripts.Gameplay.InputSystem.Abstract
{
    public delegate void UserInputEventHandler(object sender, UserInputEventArgs args);
    
    [Contract]
    public interface IUserInputService
    {
        event UserInputEventHandler OnMovementInput;
        event UserInputEventHandler OnLookingInput;

        void UpdateMovementInput(Vector2 input);
        void UpdateLookingInput(Vector2 input);
    }
}