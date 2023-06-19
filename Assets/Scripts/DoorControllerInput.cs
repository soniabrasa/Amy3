using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControllerInput : MonoBehaviour
{
    [SerializeField]
    PresenceDetector presenceDetector;

    [SerializeField]
    CaptureThing captureThing;

    [SerializeField]
    List<string> activeTags;

    protected bool openDoor;

    protected bool doorMoving;

    protected float elapsedTime;


    protected virtual void Start()
    {
        if (captureThing == null) { return; }
        else
        {
            // script.delegate de detección de captura de una thing.
            captureThing.OnThingUp += OnThingUpDetected;

        }
        if (presenceDetector == null) { return; }

        else
        {
            // script.delegate de detección de salida.
            // Cuando salta el aviso, el delegate envía sus parámetros
            presenceDetector.OnGameObjectDetectedExit += OnDetectedExit;
        }
    }


    void Update()
    {
    }

    protected virtual void OnThingUpDetected()
    {
        doorMoving = true;
        elapsedTime = 0f;
        openDoor = true;
    }

    protected virtual void OnDetectedExit(string detectorName, GameObject other)
    {
        if (activeTags.Contains(other.tag))
        {
            doorMoving = true;
            elapsedTime = 0f;
            openDoor = false;
        }
    }
}