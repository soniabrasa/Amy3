using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        // // Collider teletransporte
        // if (other.gameObject.CompareTag("TraslateFloorUp"))
        // {
        //     GetComponent<TranslateFloorUp>().Translate();
        // }

        if (other.gameObject.CompareTag("DoorCloser"))
        {
            Debug.Log($"{gameObject.name}.OnTriggerEnter({other.gameObject.name})");
            other.gameObject.GetComponentInParent<DoorMovement>().CloseDoor();
        }

        if (other.gameObject.CompareTag("DoorOpener"))
        {
            other.gameObject.GetComponentInParent<DoorMovement>().OpenDoor();
        }
    }
}
