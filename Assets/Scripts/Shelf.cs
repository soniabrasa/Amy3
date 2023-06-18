using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{
    [SerializeField]
    GameObject thingPrefab;

    [SerializeField]
    List<GameObject> things;


    float initThingPositionY;
    float nextThingPositionY;

    void Awake()
    {
        things = new List<GameObject>();
        initThingPositionY = 0.35f;
        nextThingPositionY = 0.085f;
    }


    public void SpawnThing(int numThing)
    {
        Debug.Log($"{gameObject.name}.SpawnThing({numThing})");

        Vector3 thingPosition = transform.position;

        // Zero para X y Z
        thingPosition.y += initThingPositionY
            + nextThingPositionY * things.Count;

        Debug.Log($"\t Position Thing {thingPosition}");

        // Instantiate(Object original, Vector3 position, Quaternion rotation);
        GameObject thing = Instantiate(thingPrefab, thingPosition, Quaternion.identity);

        thing.name = $"Thing_{numThing}";

        // Para que las things se aniden en este GameObject
        thing.transform.parent = transform;

        things.Add(thing);
    }
}
