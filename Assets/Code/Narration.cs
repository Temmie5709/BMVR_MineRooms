using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Security.Cryptography.X509Certificates;

[System.Serializable]
public class DialogLine
{
    public string line = "";
    public UnityEvent lineEvent;
}

[System.Serializable]
public class DialogueList
{
    public List<DialogLine> dialogues = new List<DialogLine>();
}

public class Narration : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public InputActionReference submitAction;
    public float textSpeed = 0.05f;
    public string language = "Fr";

    public Image continueIcon;

    public AudioClip typeSound; // Son de typewriter
    public float typeSoundVolume = 0.5f; // Volume du son de typewriter

    private AudioSource audioSource;

    public Dictionary<string, NamedDialogue> dialogueSets = new Dictionary<string, NamedDialogue>();
    public List<NamedDialogue> namedDialogues = new List<NamedDialogue>();

    public DialogueList currentDialogueList;
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
        foreach (var namedDialogue in namedDialogues)
        {
            if (!dialogueSets.ContainsKey(namedDialogue.name))
            {
                dialogueSets.Add(namedDialogue.name, namedDialogue);
            }
        }

        // Affiche le contenu de dialogueSets pour déboguer
        foreach (var key in dialogueSets.Keys)
        {
            Debug.Log($"Dialogue key in dictionary: {key}");
        }

        // Configure l'AudioSource pour les sons de typewriter
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = typeSound;
        audioSource.volume = typeSoundVolume;
        audioSource.playOnAwake = false;
        audioSource.loop = true;
    }

    void Start()
    {
        submitAction.action.Enable();
        ChangeDialogueSetByName("Start");

        if (continueIcon != null) continueIcon.enabled = false;
    }

    void Update()
    {
        if (submitAction.action.triggered && !isTextDisplaying && currentDialogueList != null)
        {
            if (continueIcon != null) continueIcon.enabled = false;
            NextText();
        }
    }

    public void ChangeDialogueSetByName(string dialogueName)
    {
        if (dialogueSets.TryGetValue(dialogueName, out var namedDialogue))
        {
            // Sélectionner le dialogue en fonction de la langue
            currentDialogueList = language == "Fr" ? namedDialogue.dialoguesFr : namedDialogue.dialoguesEn;
            textIndex = 0;

            if (currentDialogueList.dialogues.Count > 0)
            {
                // Invoquer l'événement de la première ligne avant de commencer l'affichage du texte
                currentDialogueList.dialogues[textIndex].lineEvent.Invoke();
                StartCoroutine(DisplayText(currentDialogueList.dialogues[textIndex].line));
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
            currentDialogueList.dialogues[textIndex].lineEvent.Invoke();
            StartCoroutine(DisplayText(currentDialogueList.dialogues[textIndex].line));
        }
    }

    IEnumerator DisplayText(string text)
    {
        isTextDisplaying = true;
        textComponent.text = "";

        // Démarrer le son en continu à un point aléatoire
        if (typeSound != null && audioSource != null)
        {
            float randomStartTime = Random.Range(0f, typeSound.length); // Point de départ aléatoire
            audioSource.time = randomStartTime;
            audioSource.Play();
        }

        // Affiche le texte caractère par caractère
        foreach (char c in text)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        // Arrêter le son une fois le texte complètement affiché
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        // Le texte est entièrement affiché, on affiche l'icône de suite
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
