using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ToggleEventHandler : MonoBehaviour
{
    // UnityEvents pour chaque langue
    [SerializeField] private UnityEvent toggleFROnEvent;  // �v�nement pour le Toggle fran�ais activ�
    [SerializeField] private UnityEvent toggleENOnEvent;  // �v�nement pour le Toggle anglais activ�

    [SerializeField] private UnityEvent toggleFROffEvent; // �v�nement pour le Toggle fran�ais d�sactiv�
    [SerializeField] private UnityEvent toggleENOffEvent; // �v�nement pour le Toggle anglais d�sactiv�

    // R�f�rences aux Toggle
    [SerializeField] private Toggle toggleFR;  // Toggle fran�ais
    [SerializeField] private Toggle toggleEN;  // Toggle anglais

    private void Start()
    {
        // V�rifiez si les toggles sont bien assign�s
        if (toggleFR != null && toggleEN != null)
        {
            // Associez les m�thodes aux changements d'�tat des toggles
            toggleFR.onValueChanged.AddListener(OnToggleFRValueChanged);
            toggleEN.onValueChanged.AddListener(OnToggleENValueChanged);
        }
    }

    // M�thode qui se d�clenche lorsque l'�tat du Toggle fran�ais change
    private void OnToggleFRValueChanged(bool isOn)
    {
        if (isOn)
        {
            toggleFROnEvent.Invoke();  // Appeler l'�v�nement ToggleFROn
            toggleEN.isOn = false;     // D�sactive le Toggle anglais
            toggleENOffEvent.Invoke(); // Appeler l'�v�nement ToggleENOff
        }
        else
        {
            toggleFROffEvent.Invoke(); // Appeler l'�v�nement ToggleFROff
        }
    }

    // M�thode qui se d�clenche lorsque l'�tat du Toggle anglais change
    private void OnToggleENValueChanged(bool isOn)
    {
        if (isOn)
        {
            toggleENOnEvent.Invoke();  // Appeler l'�v�nement ToggleENOn
            toggleFR.isOn = false;     // D�sactive le Toggle fran�ais
            toggleFROffEvent.Invoke(); // Appeler l'�v�nement ToggleFROff
        }
        else
        {
            toggleENOffEvent.Invoke(); // Appeler l'�v�nement ToggleENOff
        }
    }
}
