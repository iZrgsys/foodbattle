using System;
using FoodBattle.Gameplay.Infrastructure.Attributes;
using FoodBattle.Gameplay.InputSystem.Abstract;
using UnityEngine;

namespace FoodBattle.Gameplay.InputSystem
{
    [Service]
    internal class UserInputService : IUserInputService
    {
        public event UserInputEventHandler MovementInput;
        public event UserInputEventHandler LookingInput;

        public UserInputService()
        {
            
        }
        
        public void UpdateMovementInput(Vector2 input)
        {
            MovementInput?.Invoke(this, new UserInputEventArgs(input));
        }

        public void UpdateLookingInput(Vector2 input)
        {
            LookingInput?.Invoke(this, new UserInputEventArgs(input));
        }
    }
}