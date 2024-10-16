using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class PlayerController : MonoBehaviour
{
    public InputActionReference gachette; 
    public LayerMask rayCastMask;
    public float MaxDist = 1000;

    void Update()
    {
        if (gachette.action.triggered)
        {
            // Effectuer un raycast vers l'avant de la main (ou de la caméra selon la configuration)
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, MaxDist, rayCastMask))
            {
                RaycastableBehaviour currentBehav = hit.transform.gameObject.GetComponent<RaycastableBehaviour>();
                currentBehav.TriggerBehaviour();
            }
        }
    }
}
