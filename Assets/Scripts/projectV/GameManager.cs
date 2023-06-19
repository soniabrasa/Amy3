using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject[] shelfArray;
    public Material[] materials;

    public GameObject InputDoubleDoor;
    public GameObject OutputDoubleDoor;

    void Awake() {        
        instance = this;
    }

    // Start is called before the first frame update
    void Start() {

        GameObject selectedShelf;

        for (int i=0; i<20; i++) {
            selectedShelf = shelfArray[Random.Range(0, shelfArray.Length)];            
            selectedShelf.GetComponent<Shelf>().AddThing(materials[Random.Range(0, materials.Length)]);
        }
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OpenInputDoors() {
        InputDoubleDoor.GetComponent<InputDoorController>().openDoor = true;     
        InputDoubleDoor.GetComponent<InputDoorController>().movingDoor = true;     
    }

    public void CloseInputDoors() {
        InputDoubleDoor.GetComponent<InputDoorController>().openDoor = false;     
        InputDoubleDoor.GetComponent<InputDoorController>().movingDoor = true;     
    }

    public void OpenOutputDoors() {
        OutputDoubleDoor.GetComponent<InputDoorController>().openDoor = true;     
        OutputDoubleDoor.GetComponent<InputDoorController>().movingDoor = true;     
    }
    
    public void CloseOutputDoors() {
        OutputDoubleDoor.GetComponent<InputDoorController>().openDoor = false;     
        OutputDoubleDoor.GetComponent<InputDoorController>().movingDoor = true;     
    }


}
