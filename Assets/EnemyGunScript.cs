using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGunScript : MonoBehaviour
{
    //Global
    private Vector3 spawnPos;

    //Tier1
    public GameObject Bullet;
    
    //Tier2
    public GameObject Tier2Bullet;

    //Tier3
    public ParticleSystem ps;


    void Start(){

    }
    
    void Update()
    {
        spawnPos = transform.position + transform.up * 0.7f;
    }

    IEnumerator LaserShoot(){
        AudioControllerScript.Play("laser");
        yield return new WaitForSeconds(1.5f);
        ps.Play();
    }

    public void Shoot()
    {
        if(this.gameObject.name.Contains("Enemy1")){
            Instantiate(Bullet, spawnPos,gameObject.transform.rotation);
        }else if(this.gameObject.name.Contains("Enemy2")){
            Instantiate(Tier2Bullet, transform.position + transform.right * 0.7f,Quaternion.Euler(gameObject.transform.eulerAngles + new Vector3(0, 0, -50)));
            Instantiate(Tier2Bullet, transform.position - transform.right * 0.7f,Quaternion.Euler(gameObject.transform.eulerAngles - new Vector3(0, 0, -50)));
        }else if(this.gameObject.name.Contains("Enemy3")){
            StartCoroutine(LaserShoot());
        }else if(this.gameObject.name.Contains("Enemy4")){

        }else if(this.gameObject.name.Contains("Enemy5")){

        }
    }
}
