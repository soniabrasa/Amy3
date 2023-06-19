using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMovement : MonoBehaviour
{
    // Transform de ambas hojas de ambas puertas
    public Transform leftDoorClosedPoint;
    public Transform leftDoorOpenedPoint;
    public Transform rightDoorClosedPoint;
    public Transform rightDoorOpenedPoint;
    public Transform leftDoor;
    public Transform rightDoor;

    bool openDoor = false;
    bool doorMoving = false;

    float period = 1.5f;
    float elapsedTime, t;


    void Start()
    {
        period = 1.5f;
    }


    void Update()
    {
        if (doorMoving)
        {
            elapsedTime += Time.deltaTime;

            t = Mathf.SmoothStep(0f, 1f, elapsedTime / period);

            if (t >= 1f) { doorMoving = false; }

            if (openDoor)
            {
                Debug.Log($"{gameObject.name}.Update OpenDoor = {openDoor}");
                leftDoor.position = Vector3.Lerp(
                    leftDoorClosedPoint.position,
                    leftDoorOpenedPoint.position,
                    t);
                rightDoor.position = Vector3.Lerp(
                    rightDoorClosedPoint.position,
                    rightDoorOpenedPoint.position,
                    t);
                // transform.position = Vector3.Lerp(startPoint, endPoint, t);
            }

            else
            {
                leftDoor.position = Vector3.Lerp(
                    leftDoorOpenedPoint.position,
                    leftDoorClosedPoint.position,
                    t);
                rightDoor.position = Vector3.Lerp(
                    rightDoorOpenedPoint.position,
                    rightDoorClosedPoint.position,
                    t);
                // transform.position = Vector3.Lerp(endPoint, startPoint, t);
            }
        }
    }

    public void OpenDoor()
    {
        Debug.Log($"{gameObject.name}.OpenDoor()");

        doorMoving = true;
        elapsedTime = 0f;
        openDoor = false;
    }

    public void CloseDoor()
    {
        doorMoving = true;
        elapsedTime = 0f;
        openDoor = true;
    }
}
