using UnityEngine;
using UnityEngine.EventSystems;

public class HitboxRaycastDetector : MonoBehaviour
{
    public EventTrigger eventTrigger; // Référence au script EventTrigger
    public float rayDistance = 5f;    // Distance maximale du Raycast

    private bool hasDetected = false; // Variable pour éviter les déclenchements en boucle

    void Update()
    {
        // Lance un rayon vers l'avant
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Vérifie s'il touche un objet avec le tag "Hitbox"
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("HitBox") && !hasDetected)
            {
                // Déclenche l'événement une seule fois
                if (eventTrigger != null)
                {
                    eventTrigger.TriggerEvent();
                    hasDetected = true; // Marque la détection pour éviter les répétitions
                }
                else
                {
                    Debug.LogWarning("EventTrigger n'est pas assigné !");
                }
            }
        }
        else
        {
            // Réinitialise l'état de détection si le rayon ne touche plus la hitbox
            hasDetected = false;
        }
    }

    private void OnDrawGizmos()
    {
        // Dessine le rayon dans l'éditeur pour visualiser sa direction et sa portée
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * rayDistance);
    }
}
