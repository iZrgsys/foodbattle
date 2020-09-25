using FoodBattle.Modules.Game.Scripts.InputSystem;
using FoodBattle.Modules.Infrastucture;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoodBattle.Modules.Core
{
    internal static class ApplicationManager
    {
        static ApplicationManager()
        {
            SceneManager.sceneLoaded += OnSceneLoaded;
        }

        private static void OnSceneLoaded(Scene scene, LoadSceneMode arg1)
        {
            switch (scene.name)
            {
                case ScenesConfig.LandingSceneName:
                    break;
                case ScenesConfig.MainMenuSceneName:
                    break;
                case ScenesConfig.TestSceneName:
                    break;
                default:
                    Debug.LogError($"Uknown scene loaded! - {scene.name}");
                    break;
            }
        }

        public static void InitGame()
        {
            var serviceLocator = ServiceLocator.Instance;
            
            serviceLocator.Register<IInputService>(typeof(InputService));
        }
        
        public static void OpenMainMenu()
        {
            SceneManager.LoadSceneAsync(ScenesConfig.MainMenuSceneName, LoadSceneMode.Additive);
        }
    }
}