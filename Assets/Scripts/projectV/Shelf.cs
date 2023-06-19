using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shelf : MonoBehaviour
{

    private List<Transform> thingsList;
    public GameObject thingPrefab;

    void Awake()
    {
        thingsList = new List<Transform>();
    }

    public void AddThing(Material material)
    {

        GameObject go = Instantiate(thingPrefab,
                                    new Vector3(transform.position.x, transform.position.y + 0.35f + 0.085f * (float)thingsList.Count, transform.position.z),
                                    Quaternion.identity);
        go.transform.parent = transform;

        go.GetComponent<MeshRenderer>().material = material;

        thingsList.Add(go.transform);
    }

    public void GiveThing(Transform transform)
    {

        if (thingsList.Count > 0)
        {
            Transform t = thingsList[thingsList.Count - 1];
            t.parent = transform;
            t.name = "ThingCatched";
            t.localPosition = new Vector3(0f, 1f, 0.3f);
            thingsList.RemoveAt(thingsList.Count - 1);
            Player.AmyHasThing = true;
        }

    }

}
