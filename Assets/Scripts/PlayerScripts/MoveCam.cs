using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperP.PlayerScripts
{
    public class MoveCam : MonoBehaviour
    {
        [SerializeField] Transform CameraPosition;
        void Update()
        {
            transform.position = CameraPosition.position;
        }
    }
}