using System.Collections;
using System.Collections.Generic; // N�cessaire pour utiliser List
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

[System.Serializable] // Permet d'afficher la classe dans l'inspecteur
public class DialogueList
{
    [TextArea(2, 5)] // Permet de visualiser les strings sous forme de zone de texte
    public List<string> dialogues = new List<string>(); // Liste de dialogues
}

public class Narration : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Assignez votre TextMeshPro ici dans l'inspecteur
    public InputActionReference submitAction; // R�f�rence � votre action d'entr�e
    public float textSpeed = 0.05f; // Temps entre chaque caract�re

    // Liste de listes de cha�nes pour g�rer plusieurs ensembles de dialogues
    public List<DialogueList> dialogueSets = new List<DialogueList>
    {
        new DialogueList { dialogues = new List<string> { "Bienvenue dans l'application.", "Ceci est un exemple de texte.", "Vous pouvez passer au texte suivant en appuyant sur 'A'." } },
        new DialogueList { dialogues = new List<string> { "Texte du deuxi�me dialogue.", "Ceci est une nouvelle ligne.", "Appuyez sur 'A' pour continuer." } },
        new DialogueList { dialogues = new List<string> { "Texte du troisi�me dialogue.", "Vous avez termin� les dialogues." } }
    };

    public int currentDialogueIndex = 0; // Index de la liste de dialogues actuelle
    private int textIndex = 0; // Index du texte dans la liste actuelle
    private bool isTextDisplaying = false;

    void Start()
    {
        // D�marrer avec le premier texte
        textComponent.text = "";
        StartCoroutine(DisplayText(dialogueSets[currentDialogueIndex].dialogues[textIndex]));

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
        // V�rifier si on est dans la liste de dialogue actuelle
        if (textIndex < dialogueSets[currentDialogueIndex].dialogues.Count - 1) // Si il y a encore des textes � afficher
        {
            textIndex++;
            StartCoroutine(DisplayText(dialogueSets[currentDialogueIndex].dialogues[textIndex]));
        }
        else
        {
            // Ne rien faire si tous les textes de la liste actuelle ont �t� affich�s
        }
    }

    // M�thode pour mettre � jour le dialogue lorsque le currentDialogueIndex change
    public void ChangeDialogueSet()
    {
            currentDialogueIndex++;
            textIndex = 0; // R�initialiser l'index de texte
            StartCoroutine(DisplayText(dialogueSets[currentDialogueIndex].dialogues[textIndex]));
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
