using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;


//Credit to Brackeys youtube tutorial on Audio managers, as the majority of this code and learning how to use it was made by him.
[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0, 1)]
    public float volume = 1;
    [Range(-3, 3)]
    public float pitch = 1;
    public bool loop = false;
    public bool playOnAwake = false;
    public AudioSource source;

    public Sound()
    {
        volume = 1;
        pitch = 1;
        loop = false;
    }
}

public class AudioManager : MonoBehaviour
{

    public Slider volumeSlider; // Assignez le slider ici via l'inspecteur


    public Sound[] sounds;

    public static AudioManager instance;
    //AudioManager

    void Awake()
    {
        instance = this;

        foreach (Sound s in sounds)
        {
            if (!s.source)
                s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;
            s.source.playOnAwake = s.playOnAwake;
            if (s.playOnAwake)
                s.source.Play();

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    void Start()
    {
        // D�finir la valeur du slider avec le volume actuel
        volumeSlider.value = AudioListener.volume;

        // Abonner la m�thode de mise � jour du volume
        volumeSlider.onValueChanged.AddListener(ChangeVolume);
    }

    // M�thode pour modifier le volume
    public void ChangeVolume(float volume)
    {
        AudioListener.volume = volume; // Ajuste le volume global
    }


public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found");
            return;
        }

        s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        s.source.Stop();
    }
}