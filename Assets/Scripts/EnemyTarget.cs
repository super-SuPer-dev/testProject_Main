using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SuperP
{
    public class EnemyTarget : MonoBehaviour, IDanmageable
    {
        [SerializeField]private float health = 500;
        Renderer mat;

        private void Start() {
            mat = transform.GetComponent<Renderer>();
        }

        private void Update() {
            if (health <= 0) {
                Destroy(gameObject);
            }
        }

        public void Danmage(float dameageAmount){
            health -= dameageAmount;
            Color color = mat.material.color;
            color.a -= dameageAmount/100;
            mat.material.color = color;
        }
    }
}