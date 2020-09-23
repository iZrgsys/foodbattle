using System;
using UnityEngine;

namespace FoodBattle.Modules.Game.Scripts.InputSystem
{
    public class InputEventArgs : EventArgs
    {
        public Vector2 Value { get; private set; }
        
        public InputEventArgs(Vector2 value)
        {
            Value = value;
        }
    }
}