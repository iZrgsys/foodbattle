using FoodBattle.Modules.Game.Scripts.Gameplay.Infrastructure.Attributes;
using FoodBattle.Modules.Game.Scripts.Gameplay.InputSystem.Abstract;
using UnityEditor;
using UnityEngine;

namespace FoodBattle.Modules.Game.Scripts.Gameplay.InputSystem
{
    [Service]
    internal sealed class UserInputService : IUserInputService
    {
        private readonly object _lock = new object();
        private GUID _guid;
        
        private event UserInputEventHandler MovementEvent;
        private event UserInputEventHandler LookingEvent;
        
        event UserInputEventHandler IUserInputService.OnMovementInput
        {
            add { lock(_lock) { MovementEvent += value; } }
            remove { lock(_lock) { MovementEvent -= value; } }
        }
        
        event UserInputEventHandler IUserInputService.OnLookingInput
        {
            add { lock(_lock) { LookingEvent += value; } }
            remove { lock(_lock) { LookingEvent -= value; } }
        }

        public UserInputService()
        {
            _guid = GUID.Generate();
        }

        public void UpdateMovementInput(Vector2 input)
        {
            MovementInput(new UserInputEventArgs(input));
        }

        public void UpdateLookingInput(Vector2 input)
        {
            LookingInput(new UserInputEventArgs(input));
        }

        private void LookingInput(UserInputEventArgs args)
        {
            LookingEvent?.Invoke(this, args);
        }

        private void MovementInput(UserInputEventArgs args)
        {
            MovementEvent?.Invoke(this, args);
        }
    }
}