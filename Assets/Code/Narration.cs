using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class Narration : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Assignez votre TextMeshPro ici dans l'inspecteur
    public InputActionReference submitAction; // Référence à votre action d'entrée
    public float textSpeed = 0.05f; // Temps entre chaque caractère
    private string[] texts = new string[] {
        "Bienvenue dans l'application.",
        "Ceci est un exemple de texte.",
        "Vous pouvez passer au texte suivant en appuyant sur 'A'."
    };
    private int index = 0;
    private bool isTextDisplaying = false;

    void Start()
    {
        // Démarrer avec le premier texte
        textComponent.text = "";
        StartCoroutine(DisplayText(texts[index]));

        // Assurez-vous d'activer l'action
        submitAction.action.Enable();
    }

    void Update()
    {
        // Vérifier si le bouton "A" est pressé
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
        // Désactivez l'action lors de la désactivation du script
        submitAction.action.Disable();
    }
}
