using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperP.inventory
{
    public class inventory_system : MonoBehaviour
    {
        public Dictionary<string,string> items = new Dictionary<string, string>();
        public List<GameObject> i = new List<GameObject>();

        void Start()
        {
            items.Add("Flashlight","t");
            items.Add("Phone","s");

            foreach(var item in items){
                print(item.Key + " is " + item.Value);
            }
        }
    }
}
