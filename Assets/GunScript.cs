using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject Bullet;
    private Vector3 spawnPos;
    private float shotTime;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        shotTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        spawnPos = transform.position + transform.up * 0.7f;
        if (Input.GetMouseButtonDown(0) && !PauseMenuScript.menuShown_  && !PlayerScript.movementLocked){
            if(Time.time - shotTime > PlayerScript.shootCooldown){
                shotTime = Time.time;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        AudioControllerScript.Play("shoot1");
        Instantiate(Bullet, spawnPos,gameObject.transform.rotation);
    }
}