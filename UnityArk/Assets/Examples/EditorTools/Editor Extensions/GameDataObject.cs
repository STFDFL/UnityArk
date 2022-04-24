using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Ark.Examples.EditorExtensions
{

    [CreateAssetMenu(fileName = "gameData", menuName = "ScriptableObjects/GameDataObject", order = 1)]
    public class GameDataObject : ScriptableObject
    {
        public List<GameData> gameData = new List<GameData>();

    }

}
