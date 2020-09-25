using System;
using UnityEngine;

namespace FoodBattle.Modules.Core
{
    internal class Landing : MonoBehaviour
    {
        private void Awake()
        {
            ApplicationManager.InitGame();
        }

        // Start is called before the first frame update
        private void Start()
        {
            Debug.Log("Landing Started!");
            ApplicationManager.OpenMainMenu();
        }
    }
}
