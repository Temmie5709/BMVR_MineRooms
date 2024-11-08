using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Events;

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
        foreach (var namedDialogue in namedDialogues)
        {
            if (!dialogueSets.ContainsKey(namedDialogue.name))
            {
                dialogueSets.Add(namedDialogue.name, namedDialogue);
            }
        }

        // Configure l'AudioSource pour les sons de typewriter
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = typeSound;
        audioSource.volume = typeSoundVolume;
        audioSource.playOnAwake = false;
        audioSource.loop = true; // Permet de boucler le son
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
            currentDialogueList = language == "Fr" ? namedDialogue.dialoguesFr : namedDialogue.dialoguesEn;
            textIndex = 0;

            if (currentDialogueList.dialogues.Count > 0)
            {
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

        // D�marrer le son en continu � un point al�atoire
        if (typeSound != null && audioSource != null)
        {
            float randomStartTime = Random.Range(0f, typeSound.length); // Point de d�part al�atoire
            audioSource.time = randomStartTime;
            audioSource.Play();
        }

        // Affiche le texte caract�re par caract�re
        foreach (char c in text)
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }

        // Arr�ter le son une fois le texte compl�tement affich�
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
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
