using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ButtonBounce : MonoBehaviour
{
    public float moveDistance = 0.2f; // Distance du déplacement vers le bas
    public float moveDuration = 0.2f; // Durée du déplacement

    private Vector3 initialPosition;

    void Start()
    {
        // Sauvegarde de la position initiale du bouton
        initialPosition = transform.localPosition;
    }

    public void Bounce()
    {
        // Descend le bouton
        transform.DOLocalMoveY(initialPosition.y - moveDistance, moveDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                // Remonte le bouton à sa position initiale
                transform.DOLocalMoveY(initialPosition.y, moveDuration)
                    .SetEase(Ease.InQuad);
            });
    }
}
