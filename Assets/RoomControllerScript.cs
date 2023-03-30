using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomControllerScript : MonoBehaviour
{
    public DoorScript[] Doors;

    public GameObject[] RoomEnemies;

    int deadEnemies = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        deadEnemies = 0;
        for(int i = 0; i<RoomEnemies.Length;i++){
            if(RoomEnemies[i] == null){
                deadEnemies++;
            }
        }

        if(deadEnemies == RoomEnemies.Length){
            GameControllerScript.RoomStatus(this.gameObject.name,2);
        }        
    }

    public void Open(){
        foreach (var door in Doors)
        {
            if(door != null){
                door.Open();
            }
        }
    }

    public void Close(){
        foreach (var door in Doors)
        {
            if(door != null){
                door.Close();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Player"){
            GameControllerScript.RoomStatus(gameObject.name,0);
        }
    }
}
