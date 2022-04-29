using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperP
{
    public class bullet_Script : MonoBehaviour
    {
        Rigidbody rb;
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision other) {
            if(other.transform.tag == "Enemy") {
                Destroy(gameObject);
            }
        }
    }
}

