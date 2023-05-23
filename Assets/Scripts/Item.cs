using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    [Serializable]
    public class Item
    {
        public string Name;
        public int Amount;
        public int Weight;
        public GameObject prefab;
    }
}
