using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thing : MonoBehaviour
{
    [SerializeField]
    List<Material> thingMaterials;

    void Start()
    {
        int thingIndex = Random.Range(0, thingMaterials.Count);

        // GetComponent<MeshRenderer>().material = thingMaterials[thingIndex];
        GetComponentInChildren<MeshRenderer>().material = thingMaterials[thingIndex];
    }
}
