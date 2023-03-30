using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private float bulletSpeed = 9f;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - startTime > 4){
            Death();
        }
        transform.position = transform.position + transform.up * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag != "Bullet" && col.gameObject.tag != "EnemyBullet" && col.gameObject.tag != "Door" && col.gameObject.tag != "Room"){
            Death();
        }
    }

    void Death(){
        Destroy(gameObject);
    }
}
