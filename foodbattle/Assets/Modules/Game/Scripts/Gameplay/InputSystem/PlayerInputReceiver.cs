using FoodBattle.Modules.Game.Scripts.Gameplay.Infrastructure;
using FoodBattle.Modules.Game.Scripts.Gameplay.InputSystem.Abstract;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FoodBattle.Modules.Game.Scripts.Gameplay.InputSystem
{
    internal class PlayerInputReceiver : MonoBehaviour
    {
        private IUserInputService _inputService;
        
        private void Awake()
        {
            _inputService = ServiceLocator.Instance.Resolve<IUserInputService>();
        }

        public void Movement(InputAction.CallbackContext context)
        {
            _inputService.UpdateMovementInput(context.action.ReadValue<Vector2>());
        }
        
        public void Look(InputAction.CallbackContext context)
        {
            _inputService.UpdateLookingInput(context.action.ReadValue<Vector2>());
        }
    }
}