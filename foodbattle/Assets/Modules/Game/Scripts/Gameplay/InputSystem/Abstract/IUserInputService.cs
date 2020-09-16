using FoodBattle.Gameplay.Infrastructure.Attributes;
using FoodBattle.Gameplay.InputSystem;
using UnityEngine;

namespace FoodBattle.Gameplay.InputSystem.Abstract
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