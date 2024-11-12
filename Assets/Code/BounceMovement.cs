using UnityEngine;
using DG.Tweening;

public class BounceMovement : MonoBehaviour
{
    // Param�tres pour le mouvement
    public float moveDistance = 2f; // Distance de d�placement vers le haut et vers le bas
    public float duration = 1f;     // Dur�e d'une boucle (haut-bas)

    private void Start()
    {
        StartBouncing();
    }

    private void StartBouncing()
    {
        // Enregistrer la position initiale
        Vector3 startPos = transform.position;

        // D�placer vers le haut puis revenir vers le bas en boucle
        transform.DOMoveY(startPos.y + moveDistance, duration)
            .SetEase(Ease.InOutExpo)
            .OnComplete(() =>
            {
                // Retourner � la position de d�part
                transform.DOMoveY(startPos.y, duration).SetEase(Ease.InOutQuad).OnComplete(StartBouncing); 
            });
    }
}
