using FoodBattle.Modules.Infrastucture;
using UnityEngine;
using UnityEngine.InputSystem;

namespace FoodBattle.Modules.Game.Scripts.InputSystem
{
    public class InputHandler : MonoBehaviour
    {
        private IInputService m_inputService;
    
        private void Start()
        {
            m_inputService = ServiceLocator.Instance.Resolve<IInputService>();
        }

        public void Move(InputAction.CallbackContext context)
        {
            m_inputService.MovementInput(context.action.ReadValue<Vector2>());
        }
        
        public void Look(InputAction.CallbackContext context)
        {
            m_inputService.LookingInput(context.action.ReadValue<Vector2>());
        }

        public void Fire()
        {
            
        }
    }
}