using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FoodBattle.Modules.Game.Scripts.InputSystem
{
    public delegate void MovementInputHandler(object sender, InputEventArgs args);
    
    public interface IInputService
    {
        event MovementInputHandler OnMovementInput;
        event MovementInputHandler OnLookingInput;
        event EventHandler OnFireInput; 
        
        void MovementInput(Vector2 input);

        void LookingInput(Vector2 input);

        void FireInput();

        void BlockInput(bool block);
    }
}