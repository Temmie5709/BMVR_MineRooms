using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Narration : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Assignez votre TextMeshPro ici dans l'inspecteur
    public InputActionReference submitAction; // R�f�rence � votre action d'entr�e
    public float textSpeed = 0.05f; // Temps entre chaque caract�re
    private string[] texts = new string[] {
        "Bienvenue dans l'application.",
        "Ceci est un exemple de texte.",
        "Vous pouvez passer au texte suivant en appuyant sur 'A'."
    };
    private int index = 0;
    private bool isTextDisplaying = false;

    void Start()
    {
        // D�marrer avec le premier texte
        textComponent.text = "";
        StartCoroutine(DisplayText(texts[index]));

        // Assurez-vous d'activer l'action
        submitAction.action.Enable();
    }

    void Update()
    {
        // V�rifier si le bouton "A" est press�
        if (submitAction.action.triggered && !isTextDisplaying)
        {
            NextText();
        }
    }

    void NextText()
    {
        if (index < texts.Length - 1)
        {
            index++;
            StartCoroutine(DisplayText(texts[index]));
        }
    }

    IEnumerator DisplayText(string text)
    {
        isTextDisplaying = true;
        textComponent.text = "";

        foreach (char c in text)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        isTextDisplaying = false;
    }

    private void OnDisable()
    {
        // D�sactivez l'action lors de la d�sactivation du script
        submitAction.action.Disable();
    }
}
