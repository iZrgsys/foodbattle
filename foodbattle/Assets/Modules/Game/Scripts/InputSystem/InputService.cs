using System;
using UnityEngine;

namespace FoodBattle.Modules.Game.Scripts.InputSystem
{
    public class InputService : IInputService
    {
        private bool m_inputBlocked;
        
        public event MovementInputHandler OnMovementInput;
        public event MovementInputHandler OnLookingInput;
        public event EventHandler OnFireInput;

        public void MovementInput(Vector2 input)
        {
            if (!m_inputBlocked)
            {
                OnMovementInput?.Invoke(this, new InputEventArgs(input));
            }
        }

        public void LookingInput(Vector2 input)
        {
            if (!m_inputBlocked)
            {
                OnLookingInput?.Invoke(this, new InputEventArgs(input));
            }
        }

        public void FireInput()
        {
            if (!m_inputBlocked)
            {
                OnFireInput?.Invoke(this, new EventArgs());
            }
        }

        public void BlockInput(bool block)
        {
            m_inputBlocked = block;
        }
    }
}