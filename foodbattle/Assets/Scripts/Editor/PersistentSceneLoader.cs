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
                SceneManager.LoadScene("PersistentScene");
                SceneManager.LoadScene(currentScene.name);
            }
        }
    }    
}


