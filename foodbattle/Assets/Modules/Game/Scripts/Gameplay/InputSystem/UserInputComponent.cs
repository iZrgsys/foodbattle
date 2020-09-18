using FoodBattle.Modules.Game.Scripts.Gameplay.Infrastructure;
using FoodBattle.Modules.Game.Scripts.Gameplay.InputSystem.Abstract;
using UnityEngine;

namespace FoodBattle.Modules.Game.Scripts.Gameplay.InputSystem
{
    internal class UserInputComponent : MonoBehaviour
    {
        private IUserInputService _inputService;

        private void Awake()
        {
            _inputService = ServiceLocator.Instance.Resolve<IUserInputService>();
            
            _inputService.OnMovementInput += InputService_OnMovementInput;
            _inputService.OnLookingInput += InputService_OnLookingInput;
        }

        private void InputService_OnMovementInput(object sender, UserInputEventArgs args)
        {
            Debug.Log($"[{nameof(InputService_OnMovementInput)}]: input: {args.UserInput}" );
        }

        private void InputService_OnLookingInput(object sender, UserInputEventArgs args)
        {
            Debug.Log($"[{nameof(InputService_OnLookingInput)}]: input: {args.UserInput}" );
        }

        private void OnEnable()
        {
            _inputService.OnMovementInput += InputService_OnMovementInput;
            _inputService.OnLookingInput += InputService_OnLookingInput;
        }

        private void OnDisable()
        {
            _inputService.OnMovementInput -= InputService_OnMovementInput;
            _inputService.OnLookingInput -= InputService_OnLookingInput;
        }

        private void OnDestroy()
        {
            _inputService.OnMovementInput -= InputService_OnMovementInput;
            _inputService.OnLookingInput -= InputService_OnLookingInput;
        }
    }
}