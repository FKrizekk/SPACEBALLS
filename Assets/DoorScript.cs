using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Animator anim;
    

    public void Open(){
        anim.SetBool("DoorOpen",true);
    }

    public void Close(){
        anim.SetBool("DoorOpen",false);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.name == "Player"){
            GameControllerScript.RoomStatus(transform.parent.gameObject.name,1);
        }
    }
}
