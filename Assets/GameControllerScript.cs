using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    //End
    public DoorScript EndDoor;
    bool puzzleSolved = false;
    bool EndDoorOpened = false;

    //RoomsStatus
    public static int Room1Status = 0;
    public static int Room2Status = 0;
    public static int Room3Status = 0;
    public static int Room4Status = 0;
    public static int Room5Status = 0;
    public static int Room6Status = 0;
    public static int Room7Status = 0;
    public static int Room8Status = 0;
    //0 - unfinished not open
    //1 - unfinished open
    //2 - finished open

    void Start()
    {
        
    }

    void Update()
    {
        //Check if endDoor needs to be opened
        if(puzzleSolved && !EndDoorOpened){
            EndDoorOpened = true;
            EndDoor.Open();
        }

        if(Room1Status == 1 || Room1Status == 2){
            
            GameObject.Find("Room1").GetComponent<RoomControllerScript>().Open();
        }else{
            if(GameObject.Find("Room1") != null){
                GameObject.Find("Room1").GetComponent<RoomControllerScript>().Close();
            }
        }
        if(Room2Status == 1 || Room2Status == 2){
            GameObject.Find("Room2").GetComponent<RoomControllerScript>().Open();
        }else{
            if(GameObject.Find("Room2") != null){
                GameObject.Find("Room2").GetComponent<RoomControllerScript>().Close();
            }
        }
        if(Room3Status == 1 || Room3Status == 2){
            GameObject.Find("Room3").GetComponent<RoomControllerScript>().Open();
        }else{
            if(GameObject.Find("Room3") != null){
                GameObject.Find("Room3").GetComponent<RoomControllerScript>().Close();
            }
        }
        if(Room4Status == 1 || Room4Status == 2){
            GameObject.Find("Room4").GetComponent<RoomControllerScript>().Open();
        }else{
            if(GameObject.Find("Room4") != null){
                GameObject.Find("Room4").GetComponent<RoomControllerScript>().Close();
            }
        }
        if(Room5Status == 1 || Room5Status == 2){
            GameObject.Find("Room5").GetComponent<RoomControllerScript>().Open();
        }else{
            if(GameObject.Find("Room5") != null){
                GameObject.Find("Room5").GetComponent<RoomControllerScript>().Close();
            }
        }
        if(Room6Status == 1 || Room6Status == 2){
            GameObject.Find("Room6").GetComponent<RoomControllerScript>().Open();
        }else{
            if(GameObject.Find("Room6") != null){
                GameObject.Find("Room6").GetComponent<RoomControllerScript>().Close();
            }
        }
        if(Room7Status == 1 || Room7Status == 2){
            GameObject.Find("Room7").GetComponent<RoomControllerScript>().Open();
        }else{
            if(GameObject.Find("Room7") != null){
                GameObject.Find("Room7").GetComponent<RoomControllerScript>().Close();
            }
        }
        if(Room8Status == 1 || Room8Status == 2){
            GameObject.Find("Room8").GetComponent<RoomControllerScript>().Open();
        }else{
            if(GameObject.Find("Room8") != null){
                GameObject.Find("Room8").GetComponent<RoomControllerScript>().Close();
            }
        }
    }

    public static void RoomStatus(string room, int status){
        switch (status)
        {
            case 1:
                switch (room)
                {
                    case "Room1":
                        if(Room1Status != 2){
                            Room1Status = 1;
                        }
                        break;
                    case "Room2":
                        if(Room2Status != 2){
                            Room2Status = 1;
                        }
                        break;
                    case "Room3":
                        if(Room3Status != 2){
                            Room3Status = 1;
                        }
                        break;
                    case "Room4":
                        if(Room4Status != 2){
                            Room4Status = 1;
                        }
                        break;
                    case "Room5":
                        if(Room5Status != 2){
                            Room5Status = 1;
                        }
                        break;
                    case "Room6":
                        if(Room6Status != 2){
                            Room6Status = 1;
                        }
                        break;
                    case "Room7":
                        if(Room7Status != 2){
                            Room7Status = 1;
                        }
                        break;
                    case "Room8":
                        if(Room8Status != 2){
                            Room8Status = 1;
                        }
                        break;
                }
                break;
            case 2:
                switch (room)
                {
                    case "Room1":
                        Room1Status = 2;
                        break;
                    case "Room2":
                        Room2Status = 2;
                        break;
                    case "Room3":
                        Room3Status = 2;
                        break;
                    case "Room4":
                        Room4Status = 2;
                        break;
                    case "Room5":
                        Room5Status = 2;
                        break;
                    case "Room6":
                        Room6Status = 2;
                        break;
                    case "Room7":
                        Room7Status = 2;
                        break;
                    case "Room8":
                        Room8Status = 2;
                        break;
                }
                break;
            case 0:
                switch (room)
                {
                    case "Room1":
                        Room1Status = 0;
                        break;
                    case "Room2":
                        Room2Status = 0;
                        break;
                    case "Room3":
                        Room3Status = 0;
                        break;
                    case "Room4":
                        Room4Status = 0;
                        break;
                    case "Room5":
                        Room5Status = 0;
                        break;
                    case "Room6":
                        Room6Status = 0;
                        break;
                    case "Room7":
                        Room7Status = 0;
                        break;
                    case "Room8":
                        Room8Status = 0;
                        break;
                }
                break;
        }
    }
}