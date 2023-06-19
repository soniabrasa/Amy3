using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureThing : MonoBehaviour
{
    GameObject myThing;

    GameObject lightHouse;

    Vector3 pointTransportingThing;
    bool hasThing;

    void Start()
    {
        hasThing = false;
        pointTransportingThing = new Vector3(0f, 1f, 0.3f);

        lightHouse = GameObject.Find("LightHouse");
        lightHouse.SetActive(false);
    }


    void Update()
    {
        if (Input.GetButtonDown("Interaction"))
        {
            Debug.Log($"{gameObject.name}.Input Interaction");

            while (!hasThing)
            {
                Transform shelf = SearchShelf();

                if (shelf != null)
                {
                    if (shelf.GetComponent<Shelf>().DameThing() != null)
                    {
                        myThing = shelf.GetComponent<Shelf>().DameThing();
                        hasThing = true;
                        // ThingUp();


                        Debug.Log($"\t My thing {myThing.name}");
                    }
                }
            }
        }

        if (myThing != null)
        {
            // Debug.Log($"{gameObject.name}.My thing {myThing.name}");
            ThingUp();
            Material m = myThing.GetComponentInChildren<MeshRenderer>().material;
            LightHouseOn(m);
        }

        else
        {
            // Debug.Log($"{gameObject.name}.My thing NULL");
        }
    }

    void LightHouseOn(Material material)
    {
        lightHouse.SetActive(true);
        lightHouse.GetComponent<MeshRenderer>().material = material;
    }

    void ThingUp()
    {
        Debug.Log($"{gameObject.name}.ThingUp({myThing.name})");

        myThing.transform.parent = transform;
        // myThing.GetComponent<Rigidbody>().isKinematic = true;
        myThing.transform.localPosition = pointTransportingThing;
        myThing.transform.localRotation = Quaternion.identity;
    }

    void ThingDown()
    {
        Debug.Log($"{gameObject.name}.ThingDown({myThing.name})");
    }

    Transform SearchShelf()
    {
        RaycastHit hit;

        // Altura del objeto
        float objectH = 0.4f;

        Vector3 origin = transform.position
            + transform.forward * 0.1f
            + transform.up * objectH;

        Vector3 direction = transform.forward;

        float maxDistance = 0.5f;

        if (Physics.Raycast(origin, direction, out hit, maxDistance))
        {
            // Comprobamos si el objeto es un Shelf
            if (hit.collider.gameObject.CompareTag("Shelf"))
            {
                Debug.Log($"{gameObject.name}.SearchShelf({hit.collider.gameObject.name})");
                return hit.collider.transform;
            }
        }

        // Para ver el Raycast en modo play en la pestaña Scene (Gizmos)
        Debug.DrawRay(origin, direction * maxDistance, Color.red);

        return null;
    }
}
