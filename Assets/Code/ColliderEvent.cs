using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEvent : MonoBehaviour
{
    public List<GameObject> targetObjects; // Liste des objets avec lesquels on veut d�tecter le contact

    public UnityEvent onContact; // �v�nement d�clench� au contact

    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet en collision fait partie de la liste
        if (targetObjects.Contains(other.gameObject))
        {
            // Lance l'�v�nement
            onContact.Invoke();
        }
    }
}
