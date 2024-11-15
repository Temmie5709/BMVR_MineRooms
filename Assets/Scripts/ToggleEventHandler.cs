using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToggleEventHandler : MonoBehaviour
{
    // UnityEvents pour chaque langue
    [SerializeField] private UnityEvent toggleFROnEvent;  // Événement pour le Toggle français activé
    [SerializeField] private UnityEvent toggleENOnEvent;  // Événement pour le Toggle anglais activé

    [SerializeField] private UnityEvent toggleFROffEvent; // Événement pour le Toggle français désactivé
    [SerializeField] private UnityEvent toggleENOffEvent; // Événement pour le Toggle anglais désactivé

    // Références aux Toggle
    [SerializeField] private Toggle toggleFR;  // Toggle français
    [SerializeField] private Toggle toggleEN;  // Toggle anglais

    private void Start()
    {
        // Vérifiez si les toggles sont bien assignés
        if (toggleFR != null && toggleEN != null)
        {
            // Associez les méthodes aux changements d'état des toggles
            toggleFR.onValueChanged.AddListener(OnToggleFRValueChanged);
            toggleEN.onValueChanged.AddListener(OnToggleENValueChanged);
        }
    }

    // Méthode qui se déclenche lorsque l'état du Toggle français change
    private void OnToggleFRValueChanged(bool isOn)
    {
        if (isOn)
        {
            toggleFROnEvent.Invoke();  // Appeler l'événement ToggleFROn
            toggleEN.isOn = false;     // Désactive le Toggle anglais
            toggleENOffEvent.Invoke(); // Appeler l'événement ToggleENOff
        }
        else
        {
            toggleFROffEvent.Invoke(); // Appeler l'événement ToggleFROff
        }
    }

    // Méthode qui se déclenche lorsque l'état du Toggle anglais change
    private void OnToggleENValueChanged(bool isOn)
    {
        if (isOn)
        {
            toggleENOnEvent.Invoke();  // Appeler l'événement ToggleENOn
            toggleFR.isOn = false;     // Désactive le Toggle français
            toggleFROffEvent.Invoke(); // Appeler l'événement ToggleFROff
        }
        else
        {
            toggleENOffEvent.Invoke(); // Appeler l'événement ToggleENOff
        }
    }
}
