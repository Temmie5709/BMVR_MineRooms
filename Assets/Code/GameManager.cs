using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public AudioSource soundStream;
    private string Language = "En";


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip soundClipToPlay)
    {
        soundStream.clip = soundClipToPlay;
        soundStream.Play();
    }

    public string GetLangue()
    {
        return Language;
    }

    public void SetLangue(string Lang)
    {
        Language = Lang;    
    }
}
