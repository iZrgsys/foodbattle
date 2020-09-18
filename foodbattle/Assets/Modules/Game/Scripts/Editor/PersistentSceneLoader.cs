using FoodBattle.Modules.Landing.Scenes;
using UnityEditor;
using UnityEngine.SceneManagement;

namespace FoodBattle.Modules.Game.Scripts.Editor
{
    //[InitializeOnLoad]
    public class PersistentSceneLoader
    {
        static PersistentSceneLoader()
        {
            EditorApplication.playModeStateChanged += EditorApplicationOnplayModeStateChanged;
        }

        private static void EditorApplicationOnplayModeStateChanged(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredPlayMode)
            {
                var currentScene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(SceneConfig.PersistentSceneName);
                SceneManager.LoadScene(currentScene.name, LoadSceneMode.Additive);
            }
        }
    }    
}


