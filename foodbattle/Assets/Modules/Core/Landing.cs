using UnityEngine;

namespace FoodBattle.Modules.Core
{
    internal class Landing : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            Debug.Log("Landing Started!");
            ApplicationManager.StartGame(true);
        }
    }
}
