using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Ark.Examples.EditorExtensions
{


    [Serializable]
    public class GameData
    {
        public enum ERace
        {
            Human,
            Elf,
            Goblin
        }

        [SerializeField] public ERace race;

        public string name;
        public bool isHero;
        public float health;

        public int strenght;
        public int intellect;
        public int charisma;
        public int dexterity;
    }


}

