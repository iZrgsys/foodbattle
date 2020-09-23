using UnityEngine;

namespace FoodBattle.Modules.Game.Scripts.InputSystem
{
    public delegate void MovementInputHandler(object sender, InputEventArgs args);
    
    public interface IInputService
    {
        event MovementInputHandler OnMovementInput;
        event MovementInputHandler OnLookingInput;
        
        void MovementInput(Vector2 input);

        void LookingInput(Vector2 input);

        void BlockInput(bool block);
    }
}