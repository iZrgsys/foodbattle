using System;
using FoodBattle.Gameplay.Infrastructure;
using FoodBattle.Gameplay.InputSystem.Abstract;
using UnityEngine;

namespace FoodBattle.Gameplay.InputSystem
{
    public class UserInputComponent : MonoBehaviour
    {
        private IUserInputService _inputService;

        private void Awake()
        {
            _inputService = ServiceLocator.Instance.Resolve<IUserInputService>();
            _inputService.MovementInput += InputService_OnMovementInput;
            _inputService.LookingInput += InputService_OnLookingInput;
        }

        private void InputService_OnMovementInput(object sender, UserInputEventArgs args)
        {
            Debug.Log($"[{nameof(InputService_OnMovementInput)}]: input: {args.UserInput}" );
        }

        private void InputService_OnLookingInput(object sender, UserInputEventArgs args)
        {
            Debug.Log($"[{nameof(InputService_OnLookingInput)}]: input: {args.UserInput}" );
        }
        
    }
}