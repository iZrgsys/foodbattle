using System;
using UnityEngine;

namespace FoodBattle.Modules.Game.Scripts.Gameplay.Character
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