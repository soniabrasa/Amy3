using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutputDoorController : MonoBehaviour
{

    public bool openDoor = false;
    public bool movingDoor = false;

    public GameObject leftDoor;
    public GameObject rightDoor;

    public Transform leftDoorClosedPoint;
    public Transform leftDoorOpenedPoint;
    public Transform rightDoorClosedPoint;
    public Transform rightDoorOpenedPoint;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movingDoor)
        {
            if (openDoor)
            {
                //Abrimos a porta esquerda
                Vector3 position = leftDoor.transform.position;
                position.x = DoorPosition(leftDoorClosedPoint.transform.position.x, leftDoorOpenedPoint.transform.position.x, Time.time);
                leftDoor.transform.position = position;

                //Abrimos a porta dereita
                position = rightDoor.transform.position;
                position.x = DoorPosition(rightDoorClosedPoint.transform.position.x, rightDoorOpenedPoint.transform.position.x, Time.time);
                rightDoor.transform.position = position;

                if (Mathf.Abs(leftDoor.transform.position.x - leftDoorOpenedPoint.transform.position.x) <= 0.01f)
                {
                    movingDoor = false;
                }

            }
            else
            {
                //Pechamos a porta esquerda
                Vector3 position = leftDoor.transform.position;
                position.x = DoorPosition(leftDoorOpenedPoint.transform.position.x, leftDoorClosedPoint.transform.position.x, Time.time);
                leftDoor.transform.position = position;
                //Pechamos a porta dereita
                position = rightDoor.transform.position;
                position.x = DoorPosition(rightDoorOpenedPoint.transform.position.x, rightDoorClosedPoint.transform.position.x, Time.time);
                rightDoor.transform.position = position;

                if (Mathf.Abs(rightDoor.transform.position.x - rightDoorClosedPoint.transform.position.x) <= 0.01f)
                {
                    movingDoor = false;
                }

            }
        }

    }

    private float DoorPosition(float from, float to, float time)
    {
        return Mathf.SmoothStep(from, to, Mathf.PingPong(time * 1.5f, 1));
    }

}
