using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColliderEvent : MonoBehaviour
{
    public List<GameObject> targetObjects; // Liste des objets avec lesquels on veut détecter le contact

    public UnityEvent onContact; // Événement déclenché au contact

    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet en collision fait partie de la liste
        if (targetObjects.Contains(other.gameObject))
        {
            // Lance l'événement
            onContact.Invoke();
        }
    }
}
