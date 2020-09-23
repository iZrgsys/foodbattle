using UnityEngine;

namespace FoodBattle.Modules.Game.Scripts.InputSystem
{
    public class InputService : IInputService
    {
        private bool _inputBlocked;
        
        public event MovementInputHandler OnMovementInput;
        public event MovementInputHandler OnLookingInput;
        
        public void MovementInput(Vector2 input)
        {
            if (!_inputBlocked)
            {
                OnMovementInput?.Invoke(this, new InputEventArgs(input));
            }
        }

        public void LookingInput(Vector2 input)
        {
            if (!_inputBlocked)
            {
                OnLookingInput?.Invoke(this, new InputEventArgs(input));
            }
        }

        public void BlockInput(bool block)
        {
            _inputBlocked = block;
        }
    }
}