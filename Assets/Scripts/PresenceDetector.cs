using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresenceDetector : MonoBehaviour
{
    // Firma del Delegate con parámetros
    public delegate void OnGameObjectDetectedDelegate
    (
        string zoneDetectorTag, GameObject detectedObject
    );

    // Delegates
    public OnGameObjectDetectedDelegate OnGameObjectDetectedEnter;
    public OnGameObjectDetectedDelegate OnGameObjectDetectedExit;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log($"PresenceDetector.OnTriggerEnter({other.gameObject.name}) in " + gameObject.name);

        // Si hay suscriptores al Delegate
        if (OnGameObjectDetectedEnter != null)
        {
            // Se anuncia que el gameObject other ha entrado en un trigger

            OnGameObjectDetectedEnter(gameObject.name, other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log($"PresenceDetector.OnTriggerExit({other.gameObject.name}) in " + gameObject.name);

        // Si hay suscriptores al Delegate
        if (OnGameObjectDetectedExit != null)
        {
            // Se anuncia que el gameObject other ha salido de un trigger

            OnGameObjectDetectedExit(gameObject.name, other.gameObject);
        }
    }
}