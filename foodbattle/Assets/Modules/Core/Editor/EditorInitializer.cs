using UnityEditor;
using UnityEngine.SceneManagement;

namespace FoodBattle.Modules.Core.Editor
{
    [InitializeOnLoad]
    internal class EditorInitializer
    {
        static EditorInitializer()
        {
            EditorApplication.playModeStateChanged  += OnPlayModeStateChanged;
        }

        private static void OnPlayModeStateChanged(PlayModeStateChange playMode)
        {
            if (playMode != PlayModeStateChange.EnteredPlayMode)
            {
                return;
            }
            
            var currentScene = SceneManager.GetActiveScene();

            if (currentScene.name == ScenesConfig.LandingSceneName)
            {
                return;
            }

            SceneManager.LoadScene(ScenesConfig.LandingSceneName);

            ApplicationManager.OpenLevelAdditive(currentScene.name);
        }
    }
}