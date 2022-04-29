using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace SuperP.PlayerScripts
{
    public class PlayerShoot : MonoBehaviour
    {
        public static Action shootInput;
        public static Action reloadInput;

        private void Update() {
            if(Input.GetButtonDown("Fire1")){
                shootInput?.Invoke();
            }
            if(Input.GetKeyDown(KeyCode.R)){
                reloadInput?.Invoke();
            }
        }
    }

}
