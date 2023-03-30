using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private float movementSpeed = 7f;
    private float mMod = 1;
    private Vector3 mVector;
    Vector3 currentEulerAngles;
    public static float shootCooldown = 0.1f;
    public float health = 500;
    public HPBarScript HPBar;
    public static bool movementLocked = true;
    public static int coins;
    bool Spawned = true;

    public GameObject Enemy;

    public ParticleSystem SpawnEffect;
    float spawnTime;
    bool playedSpawn = false;

    public Animator CanvasAnim;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(0.0001f,0.0001f,0.0001f);
        health = 500f;
        if(PlayerPrefs.GetInt("COINS") != null){
            coins = PlayerPrefs.GetInt("COINS");
        }else{
            coins = 0;
        }
        Invoke("SpawnStuff",1f);
    }

    void SpawnStuff(){
        StartCoroutine(PlaySpawnAudio());
        SpawnEffect.Play();
    }

    void Death(){

    }

    IEnumerator PlaySpawnAudio(){
        yield return new WaitForSeconds(0.2f);
        spawnTime = Time.time;
        Spawned = false;
        CanvasAnim.SetBool("ShowHud", true);
        AudioControllerScript.Play("spawn");
        yield return new WaitForSeconds(1f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Spawned){
            if(!Spawned && !playedSpawn){
                
            }
            playedSpawn = true;
            float t = (Time.time - spawnTime) / 1;
            float amount = Mathf.SmoothStep(transform.localScale.x, 1, t);
            transform.localScale = new Vector3(amount,amount,amount);
            if(transform.localScale.x > 0.999999f){
                Spawned = true;
                movementLocked = false;
                transform.localScale = new Vector3(1,1,1);
            }
        }
        //Diagonal speed fix
        if(Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
        {
            mMod = 0.7f;//pythagoras xd
        }
        else
        {
            mMod = 1f;
        }

        //Movement Input
        mVector = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"),0f);
        
        //Check if dead
        if(health <= 0){
            Death();
        }

        if(Input.GetKeyDown("b")){
            Instantiate(Enemy);
        }
    }

    void FixedUpdate()
    {
        if(!movementLocked){
            //Movement
            transform.position = transform.position + mVector * movementSpeed * mMod * Time.deltaTime;


            //Player rotation
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - transform.position;
            float angle = Vector2.SignedAngle(Vector2.up, direction);
            transform.eulerAngles = new Vector3 (0, 0, angle);
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "EnemyBullet"){
            AudioControllerScript.Play("hurt");
            health = health - 50;
            HPBar.Move(this);
        }

        if(col.gameObject.tag == "Room"){
            GameControllerScript.RoomStatus(col.gameObject.name, 0);
        }
    }
}