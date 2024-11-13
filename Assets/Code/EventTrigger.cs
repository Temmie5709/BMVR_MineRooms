using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{
    // UnityEvent pour appeler une fonction dans un autre script via l’inspecteur
    public UnityEvent onTriggerEvent;

    public void TriggerEvent()
    {
        // Appelle toutes les fonctions assignées dans l'inspecteur
        if (onTriggerEvent != null)
        {
            onTriggerEvent.Invoke();
            Debug.Log("Événement déclenché via UnityEvent.");
        }
        else
        {
            Debug.LogWarning("Aucune fonction assignée à onTriggerEvent !");
        }
    }
}
