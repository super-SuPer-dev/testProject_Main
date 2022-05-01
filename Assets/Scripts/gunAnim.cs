using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperP
{
    public class gunAnim : MonoBehaviour
    {
        Animator animator;
        void Start()
        {
            animator = GetComponent<Animator>();
        }

        void Update()
        {
            if(Input.GetMouseButtonDown(0)){
                animator.SetTrigger("isFire");
            }
        }
    }
}
