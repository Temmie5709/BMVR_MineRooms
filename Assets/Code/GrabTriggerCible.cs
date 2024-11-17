using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabTriggerCible : MonoBehaviour
{
    public Narration change;
    bool OnePass = true;
    bool TwoPass = true;
    private Vector3 initialScale;

    private void Awake()
    {
        // Sauvegarde de l'échelle initiale de l'objet
        initialScale = transform.localScale;
    }

    public void OnEnable()
    {
        // Ajoute les écouteurs d'événements pour l'interaction de saisie et de relâchement
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        interactable.selectEntered.RemoveListener(OnGrab);   // Retirer l'ancien écouteur s'il existe
        interactable.selectEntered.AddListener(OnGrab);      // Ajouter l'écouteur pour la saisie
        interactable.selectExited.AddListener(OnRelease);    // Ajouter l'écouteur pour le relâchement
    }

    private void OnDisable()
    {
        // Retirer les écouteurs d'événements lors de la désactivation du script
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        interactable.selectEntered.RemoveListener(OnGrab);    // Supprimer l'écouteur de saisie
        interactable.selectExited.RemoveListener(OnRelease);  // Supprimer l'écouteur de relâchement
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // Réinitialise l'échelle de l'objet lors de la saisie
        transform.localScale = initialScale;
        if (OnePass == true)
        {
            change.ChangeDialogueSetByName("GrabOn");
        }
        OnePass = false;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // Réinitialise l'échelle de l'objet lors du relâchement
        transform.localScale = initialScale;
        if (TwoPass == true)
        {
            change.ChangeDialogueSetByName("GrabOff");
        }
        TwoPass = false;
    }
}
