using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    public InputActionReference gachette;
    public LayerMask rayCastMask;
    public float MaxDist = 1000;

    private LineRenderer lineRenderer;

    void Start()
    {
        // Ajouter et configurer le LineRenderer
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.startWidth = 0.01f;
        lineRenderer.endWidth = 0.01f;
        lineRenderer.material = new Material(Shader.Find("Unlit/Color"));
        lineRenderer.material.color = Color.red; // Couleur de la ligne
        lineRenderer.enabled = false; // Désactivé au début
    }

    void Update()
    {
        // Effectuer un raycast en continu pour vérifier si on vise un objet du LayerMask
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, MaxDist, rayCastMask))
        {
            // Afficher la ligne jusqu'à l'objet visé
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position); // Départ de la ligne
            lineRenderer.SetPosition(1, hit.point); // Fin de la ligne au point d'impact

            // Si le bouton est pressé, déclencher le comportement
            if (gachette.action.triggered)
            {
                RaycastableBehaviour currentBehav = hit.transform.gameObject.GetComponent<RaycastableBehaviour>();
                if (currentBehav != null)
                {
                    currentBehav.TriggerBehaviour();
                }
            }
        }
        else
        {
            // Masquer la ligne si aucun objet n'est visé
            lineRenderer.enabled = false;
        }
    }
}
