using System.Collections.Generic;
using Game.Models;
using UnityEditor;
using UnityEngine;
using Utils;

namespace Game.Databases
{
    [CreateAssetMenu(menuName = "Scriptable Database/SpawnChainDatabase", fileName = "SpawnChainDatabase")]
    public class SpawnChainDatabase : ScriptableObject
    {
        [SerializeField] private List<SpawnChain> chains;
        
        public List<SpawnItem> GetChainById(string id) => chains.GetBy(value => value.id == id).items;
    }
}
