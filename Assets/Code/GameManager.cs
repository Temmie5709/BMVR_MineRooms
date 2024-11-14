using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance = null;
    public AudioSource soundStream;


    void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("Freuteu");
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


}
