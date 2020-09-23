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
                default:
                    Debug.LogError($"Uknown scene loaded! - {scene.name}");
                    break;
            }
        }

        public static void StartGame(bool openMainMenu = false)
        {
            var serviceLocator = ServiceLocator.Instance;
            
            serviceLocator.Register<IInputService>(typeof(InputService));

            if (openMainMenu)
            {
                OpenMainMenu();
            }
        }
        
        private static void OpenMainMenu()
        {
            SceneManager.LoadSceneAsync(ScenesConfig.MainMenuSceneName, LoadSceneMode.Additive);
        }
    }
}