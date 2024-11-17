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
        // Sauvegarde de l'�chelle initiale de l'objet
        initialScale = transform.localScale;
    }

    public void OnEnable()
    {
        // Ajoute les �couteurs d'�v�nements pour l'interaction de saisie et de rel�chement
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        interactable.selectEntered.RemoveListener(OnGrab);   // Retirer l'ancien �couteur s'il existe
        interactable.selectEntered.AddListener(OnGrab);      // Ajouter l'�couteur pour la saisie
        interactable.selectExited.AddListener(OnRelease);    // Ajouter l'�couteur pour le rel�chement
    }

    private void OnDisable()
    {
        // Retirer les �couteurs d'�v�nements lors de la d�sactivation du script
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        interactable.selectEntered.RemoveListener(OnGrab);    // Supprimer l'�couteur de saisie
        interactable.selectExited.RemoveListener(OnRelease);  // Supprimer l'�couteur de rel�chement
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        // R�initialise l'�chelle de l'objet lors de la saisie
        transform.localScale = initialScale;
        if (OnePass == true)
        {
            change.ChangeDialogueSetByName("GrabOn");
        }
        OnePass = false;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        // R�initialise l'�chelle de l'objet lors du rel�chement
        transform.localScale = initialScale;
        if (TwoPass == true)
        {
            change.ChangeDialogueSetByName("GrabOff");
        }
        TwoPass = false;
    }
}
