using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tier2BulletScript : MonoBehaviour
{
    private float bulletSpeed = 9f;
    private float startTime;
    bool LockedOn = false;
    GameObject player;
    float turnSpeed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        startTime = Time.time;
        Invoke("LockOn",0.25f);
    }

    void LockOn(){
        LockedOn = true;
        Invoke("LockOff",0.25f);
    }

    void LockOff(){
        LockedOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(LockedOn){
            Vector2 direction = (player.transform.position - transform.position).normalized;
            Debug.DrawRay(transform.position, direction * 10);
            Debug.DrawRay(transform.position, Vector2.up);
            float angle = Vector2.SignedAngle(Vector2.up, direction);
            if(Mathf.Sign(angle) == -1){
                angle = 360 - Mathf.Abs(angle);
            }
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, q, turnSpeed * Time.deltaTime);
        }
        if(Time.time - startTime > 4){
            Death();
        }
        transform.position = transform.position + transform.up * bulletSpeed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag != "Bullet" && col.gameObject.tag != "EnemyBullet"){
            Death();
        }
    }

    void Death(){
        Destroy(gameObject);
    }
}
