using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATMScript : MonoBehaviour
{
    public GameObject player;
    public GameObject canvas;
    bool atATM = false;
    bool playedBlip = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        CameraScript.setATM(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position,player.transform.position) < 3){
            if(!playedBlip){
                AudioControllerScript.Play("blip");
                playedBlip = true;
            }
            canvas.SetActive(true);
            if(Input.GetKeyDown("e") && !atATM){
                OpenATM();
            }else if(Input.GetKeyDown("e") && atATM){
                CloseATM();
            }
            
        }else{
            canvas.SetActive(false);
            playedBlip = false;
            if(Input.GetKeyDown("e") && atATM){
                CloseATM();
            }
        }
        
    }

    void OpenATM(){
        PlayerScript.movementLocked = true;
        CameraScript.isAtATM = true;
        atATM = true;
    }

    void CloseATM(){
        PlayerScript.movementLocked = false;
        CameraScript.isAtATM = false;
        atATM = false;
    }

    public void BuyRohlik(){

    }

    public void BuyCookie(){
        
    }
}
