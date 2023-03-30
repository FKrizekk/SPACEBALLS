using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player;
    Vector3 targetPosition;
    float targetSize;
    public static bool isAtATM = false;
    public static GameObject ATM;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void setATM(GameObject atm){
        ATM = atm;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAtATM){
            targetPosition = new Vector3(ATM.transform.position.x,ATM.transform.position.y+0.63f,-10);
            targetSize = 0.66f;
        }else{
            targetPosition = new Vector3(player.transform.position.x,player.transform.position.y,-10);
            targetSize = 5f;
        }
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Slerp(transform.position, targetPosition, 10f*Time.deltaTime);
        GetComponent<Camera>().orthographicSize = Mathf.SmoothStep(GetComponent<Camera>().orthographicSize,targetSize, 10*Time.deltaTime);
    }
}
