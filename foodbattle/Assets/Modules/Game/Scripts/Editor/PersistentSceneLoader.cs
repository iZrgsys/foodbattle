using FoodBattle.Modules.Landing.Scenes;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FoodBattle.Editor
{
    [InitializeOnLoad]
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
                SceneManager.LoadSceneAsync(SceneConfig.PersistentSceneName);
                SceneManager.LoadSceneAsync(currentScene.name, LoadSceneMode.Additive);
            }
        }
    }    
}


