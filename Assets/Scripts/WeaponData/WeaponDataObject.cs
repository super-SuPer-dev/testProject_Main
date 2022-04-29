using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperP.WeaponData
{
    [CreateAssetMenu(fileName = "Weapon",menuName = "Weapon/Gun")]
    public class WeaponDataObject : ScriptableObject
    {
        [Header("Info")]
        public new string name;
        public GameObject prefab;
        public GameObject bullet_prefab;

        [Header("Weapon Info")]
        public float danmage;
        public int ammo;
        public int magSize;

        public float reloadtime;
    }
}
