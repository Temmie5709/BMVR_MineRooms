using UnityEngine;
using DG.Tweening;

public class BounceMovement : MonoBehaviour
{
    // Paramètres pour le mouvement
    public float moveDistance = 2f; // Distance de déplacement vers le haut et vers le bas
    public float duration = 1f;     // Durée d'une boucle (haut-bas)

    private void Start()
    {
        StartBouncing();
    }

    private void StartBouncing()
    {
        // Enregistrer la position initiale
        Vector3 startPos = transform.position;

        // Déplacer vers le haut puis revenir vers le bas en boucle
        transform.DOMoveY(startPos.y + moveDistance, duration)
            .SetEase(Ease.InOutExpo)
            .OnComplete(() =>
            {
                // Retourner à la position de départ
                transform.DOMoveY(startPos.y, duration).SetEase(Ease.InOutQuad).OnComplete(StartBouncing); 
            });
    }
}
