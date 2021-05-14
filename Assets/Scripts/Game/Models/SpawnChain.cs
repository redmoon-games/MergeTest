using System;
using System.Collections.Generic;

namespace Game.Models
{
    [Serializable]
    public class SpawnChain
    {
        public string id;
        public List<SpawnItem> items;
    }
    
    [Serializable]
    public class SpawnItem
    {
        public string id;
        public int weight;
    }
}
