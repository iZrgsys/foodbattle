using UnityEngine;

namespace FoodBattle.Modules.Game.Scripts.Gameplay.Base
{
    /// <summary>
    /// Inherit from this base class to create a singleton.
    /// e.g. public class MyClassName : Singleton<MyClassName> {}
    /// </summary>
    public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // Check to see if we're about to be destroyed.
        private static bool _mShuttingDown = false;
        private static object _mLock = new object();
        private static T _mInstance;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        /// <summary>
        /// Access singleton instance through this propriety.
        /// </summary>
        public static T Instance
        {
            get
            {
                if (_mShuttingDown)
                {
                    Debug.LogWarning($"[Singleton] Instance '{typeof(T)}' already destroyed. Returning null.");
                    return null;
                }
 
                lock (_mLock)
                {
                    if (_mInstance != null) return _mInstance;
                    
                    // Search for existing instance.
                    _mInstance = (T)FindObjectOfType(typeof(T));
 
                    // Create new instance if one doesn't already exist.
                    if (_mInstance != null) return _mInstance;
                    
                    // Need to create a new GameObject to attach the singleton to.
                    var singletonObject = new GameObject();
                    _mInstance = singletonObject.AddComponent<T>();
                    singletonObject.name = $"{typeof(T)} (Singleton)";
 
                    // Make instance persistent.
                    DontDestroyOnLoad(singletonObject);

                    return _mInstance;
                }
            }
        }
 
 
        private void OnApplicationQuit()
        {
            _mShuttingDown = true;
        }
 
 
        private void OnDestroy()
        {
            _mShuttingDown = true;
        }
    }
}