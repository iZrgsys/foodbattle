using System;
using UnityEngine;

namespace FoodBattle.Modules.Game.Scripts.Gameplay.InputSystem
{
    public class UserInputEventArgs : EventArgs
    {
        private Vector2 _userInput;

        public Vector2 UserInput => _userInput;
        
        public UserInputEventArgs(Vector2 userInput)
        {
            _userInput = userInput;
        }
    }
}