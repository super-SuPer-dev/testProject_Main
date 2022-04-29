using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SuperP.PlayerScripts;
using SuperP.WeaponData;

namespace SuperP
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] WeaponDataObject gunData;
        //[SerializeField] float bulletForce = 100f;
        [SerializeField] Transform shoot;
        [SerializeField] Camera cam;

        [SerializeField] Text guntext;

        [SerializeField] ParticleSystem gunEffect;
        [SerializeField] GameObject impactEffect;
        [SerializeField] AudioSource sounds;

        // private void Update() {
        //     RaycastHit inn;
        //     Physics.Raycast(shoot.transform.position,transform.TransformDirection(Vector3.forward),out inn,100f);
        //     Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward) * inn.distance, Color.red);
        // }

        private void Start() {
            gunData.current_Ammo = gunData.magSize;
            gunData.ammo = gunData.mexAmmo;

            PlayerShoot.shootInput += Shoot;
            PlayerShoot.reloadInput += Reload;
            UpdateText();
        }

        private void OnDisable() {
            PlayerShoot.shootInput -= Shoot;
            PlayerShoot.reloadInput -= Reload;
        }

        public void Shoot(){
            if (gunData.current_Ammo > 0){
                gunData.current_Ammo--;
                sounds.Play();
                gunEffect.Play();
                RaycastHit hit;
                if (Physics.Raycast(cam.transform.position,cam.transform.TransformDirection(Vector3.forward),out hit,100f)){
                    IDanmageable danmageable = hit.collider.GetComponent<IDanmageable>();
                    if (danmageable != null){
                        danmageable.Danmage(gunData.danmage);
                    }
                    GameObject C = Instantiate(impactEffect,hit.point,Quaternion.LookRotation(hit.normal));
                    Destroy(C,0.5f);
                }
                
                
                // GameObject B = Instantiate(gunData.bullet_prefab,shoot.transform.position,Quaternion.identity);
                // Rigidbody rb = B.GetComponent<Rigidbody>();
                // Vector3 shootdir = cam.transform.forward * bulletForce;
                // rb.AddForce(shootdir,ForceMode.Impulse);
                // Destroy(B,10f);
            }
            UpdateText();
        }
        public void Reload(){
            StartCoroutine(DoReload());
        }

        IEnumerator DoReload(){
            int reloadAmmo = gunData.magSize - gunData.current_Ammo;
            yield return new WaitForSeconds(gunData.reloadtime);
            gunData.ammo -= reloadAmmo;
            gunData.current_Ammo += reloadAmmo;
            UpdateText();
        }

        private void UpdateText(){
            guntext.text = "Ammo: "+ gunData.current_Ammo + "/" + gunData.ammo;
        }
    }
}

