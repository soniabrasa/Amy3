using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    List<GameObject> selfs;

    int totalThings = 20;

    void Start()
    {
        SpawnThings();
    }


    void Update()
    {
    }

    void SpawnThings()
    {
        for (int i = 0; i < totalThings; i++)
        {
            int rdmSelf = Random.Range(0, selfs.Count);

            GameObject self = selfs[rdmSelf];

            self.GetComponent<Shelf>().SpawnThing(i);
        }
    }
}
