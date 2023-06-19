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

    private void OnTriggerEnter(Collider other)
    {
        // se controla si el player colisiono con el transportador de las escaleras
        if (other.gameObject.CompareTag("TraslateFloorUp"))
        {
            GetComponent<TranslateFloorUp>().Translate();
        }
        // se controla si el player colisiono con el collider para cerrar puertas
        if (other.gameObject.CompareTag("CloserDoor"))
        {
            other.gameObject.GetComponentInParent<DoorMovement>().CloseDoor();
        }
        // se controla si el player colisiono con el collider para abrirr puertas
        if (other.gameObject.CompareTag("OpenerDoor"))
        {
            other.gameObject.GetComponentInParent<DoorMovement>().OpenDoor();
        }
    }
}
