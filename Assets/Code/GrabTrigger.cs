using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabTrigger : MonoBehaviour
{
    public Narration change;
    bool OnePass = true;
    private Vector3 initialScale;

    private void Awake()
    {
        initialScale = transform.localScale;
    }

    public void OnEnable()
    {
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        interactable.selectEntered.AddListener(OnGrab);
        interactable.selectExited.AddListener(OnRelease);
    }

    private void OnDisable()
    {
        var interactable = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();
        interactable.selectEntered.RemoveListener(OnGrab);
        interactable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        transform.localScale = initialScale;
        if (OnePass == true)
        {
            change.ChangeDialogueSetByName("Grab");
        }
        OnePass = false;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        transform.localScale = initialScale;
    }
}

