using System;
using UnityEngine;

namespace FoodBattle.Gameplay.Character
{
    [Serializable]
    public class CharacterData
    {
        [SerializeField]
        private string _name;

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}