using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class PersistentSceneLoader
{
    static PersistentSceneLoader()
    {
        EditorApplication.playModeStateChanged += EditorApplicationOnplayModeStateChanged;
    }

    private static void EditorApplicationOnplayModeStateChanged(PlayModeStateChange state)
    {
        Debug.Log(state);
    }
}
