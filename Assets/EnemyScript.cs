using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private bool playerInSight = false;
    public GameObject player;
    private float shotTime;
    public GameObject Gun;
    public float health = 200;
    public float healthMAX = 200;
    private float distance = 5f;
    private float movementSpeed = 1f;
    public EnemyHPBarScript HPBar;
    float shootCooldown = 1f;
    float turnSpeed = 1f;
    int ENEMYTIER = 1;

    bool dead = false;

    float deathTime = 0f;
    float deathDuration = 2f;

    // Start is called before the first frame update
    void Start()
    {
        shotTime = Time.time;
        player = GameObject.Find("Player");
        if(this.gameObject.name.Contains("Enemy1")){
            ENEMYTIER = 1;
            health = 200f;
            movementSpeed = 4.5f;
            distance = 5f;
            shootCooldown = 0.5f;
            turnSpeed = 10f;
        }else if(this.gameObject.name.Contains("Enemy2")){
            ENEMYTIER = 2;
            health = 350f;
            movementSpeed = 1.5f;
            distance = 3f;
            shootCooldown = 2f;
            turnSpeed = 1f;
        }else if(this.gameObject.name.Contains("Enemy3")){
            ENEMYTIER = 3;
            health = 400f;
            movementSpeed = 0.4f;
            distance = 5f;
            shootCooldown = 12f;
            turnSpeed = 3f;
        }else if(this.gameObject.name.Contains("Enemy4")){
            ENEMYTIER = 4;
            health = 450;
            movementSpeed = 2.8f;
            distance = 1.7f;
            shootCooldown = 3f;
            turnSpeed = 1f;
        }else if(this.gameObject.name.Contains("Enemy5")){
            ENEMYTIER = 5;
            health = 400f;
            movementSpeed = 1f;
            distance = 2f;
            turnSpeed = 1f;
        }
        healthMAX = health;
        
    }

    

    // Update is called once per frame
    void Update()
    {
        HPBar.UpdateHPText(this);
        
        //Check if player in sight
        RaycastHit2D hit = Physics2D.Raycast(transform.position, (player.transform.position-transform.position).normalized,15,2);
        Debug.DrawRay(transform.position, (player.transform.position-transform.position).normalized*15, Color.red);
        if(hit.collider != null){
            if (hit.collider.gameObject.tag == "Player"){
                float sTime = Time.time;
                playerInSight = true;
            }else{
                if(playerInSight){
                    float sTime = Time.time;
                }
                playerInSight = false;
            }
        }

        
        if(playerInSight && !dead){
            //Look at player
            Vector2 direction = (player.transform.position - transform.position).normalized;
            Debug.DrawRay(transform.position, direction * 10);
            Debug.DrawRay(transform.position, Vector2.up);
            float angle = Vector2.SignedAngle(Vector2.up, direction);
            if(Mathf.Sign(angle) == -1){
                angle = 360 - Mathf.Abs(angle);
            }
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Lerp(transform.rotation, q, turnSpeed * Time.deltaTime);
            
            //Shoot
            if(Time.time - shotTime > shootCooldown){
                shotTime = Time.time;
                Gun.GetComponent<EnemyGunScript>().Shoot();
            }

            //Move to player
            Vector3 targetPos = player.transform.position + (transform.position - player.transform.position).normalized * distance;
            Vector3 mDirection = (targetPos - transform.position).normalized;
            transform.position = transform.position + mDirection * movementSpeed * Time.deltaTime;
        }

        if(health <= 0){
            if(health <= 0 && !dead){
                deathTime = Time.time;
                AudioControllerScript.Play("death");
            }
            dead = true;
            float t = (Time.time - deathTime) / deathDuration;
            float amount = Mathf.SmoothStep(transform.localScale.x, 0, t);
            transform.localScale = new Vector3(amount,amount,amount);
            if(transform.localScale.x < 0.02){
                Destroy(gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Bullet"){
            AudioControllerScript.Play("hit");
            health = health - 50;
            HPBar.Move(this);
        }
    }
}