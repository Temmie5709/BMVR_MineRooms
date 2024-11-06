using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI; // Ajout� pour utiliser l'Image

[System.Serializable]
public class DialogueList
{
    [TextArea(2, 5)]
    public List<string> dialogues = new List<string>();
}

public class Narration : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public InputActionReference submitAction;
    public float textSpeed = 0.05f;
    public string language = "Fr";

    // Nouvelle r�f�rence � l'image d'indicateur en bas � droite
    public Image continueIcon; // Assignez l'image dans l'inspecteur Unity

    // Dictionnaire pour stocker les dialogues nomm�s
    public Dictionary<string, NamedDialogue> dialogueSets = new Dictionary<string, NamedDialogue>();

    [SerializeField] private List<NamedDialogue> namedDialogues = new List<NamedDialogue>();

    private DialogueList currentDialogueList;
    private int textIndex = 0;
    private bool isTextDisplaying = false;

    [System.Serializable]
    public class NamedDialogue
    {
        public string name;
        public DialogueList dialoguesFr;
        public DialogueList dialoguesEn;
    }

    void Awake()
    {
        // Ajouter chaque dialogue nomm� au dictionnaire
        foreach (var namedDialogue in namedDialogues)
        {
            if (!dialogueSets.ContainsKey(namedDialogue.name))
            {
                dialogueSets.Add(namedDialogue.name, namedDialogue);
            }
        }
    }

    void Start()
    {
        // Activer l'action et d�finir le dialogue par d�faut sur "Start"
        submitAction.action.Enable();
        ChangeDialogueSetByName("Start");

        // Masquer l'ic�ne de suite au d�marrage
        if (continueIcon != null) continueIcon.enabled = false;
    }

    void Update()
    {
        if (submitAction.action.triggered && !isTextDisplaying && currentDialogueList != null)
        {
            // Masquer l'ic�ne de suite lors de la transition vers le texte suivant
            if (continueIcon != null) continueIcon.enabled = false;
            NextText();
        }
    }

    public void ChangeDialogueSetByName(string dialogueName)
    {
        if (dialogueSets.TryGetValue(dialogueName, out var namedDialogue))
        {
            currentDialogueList = language == "Fr" ? namedDialogue.dialoguesFr : namedDialogue.dialoguesEn;
            textIndex = 0;

            if (currentDialogueList.dialogues.Count > 0)
            {
                StartCoroutine(DisplayText(currentDialogueList.dialogues[textIndex]));
            }
            else
            {
                Debug.LogWarning($"Dialogue set '{dialogueName}' is empty for language '{language}'.");
            }
        }
        else
        {
            Debug.LogWarning($"Dialogue set '{dialogueName}' not found.");
        }
    }

    void NextText()
    {
        if (currentDialogueList != null && textIndex < currentDialogueList.dialogues.Count - 1)
        {
            textIndex++;
            StartCoroutine(DisplayText(currentDialogueList.dialogues[textIndex]));
        }
    }

    IEnumerator DisplayText(string text)
    {
        isTextDisplaying = true;
        textComponent.text = "";

        // Affiche le texte caract�re par caract�re
        foreach (char c in text)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        // Le texte est enti�rement affich�, on affiche l'ic�ne de suite
        if (continueIcon != null) continueIcon.enabled = true;
        isTextDisplaying = false;
    }

    private void OnDisable()
    {
        submitAction.action.Disable();
    }

    void GetNameList()
    {
        
    }
}
