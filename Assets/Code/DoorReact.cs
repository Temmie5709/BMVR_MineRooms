using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorReact : MonoBehaviour
{
    public string sceneName;
    public AudioClip transitionSound;
    public void LoadSceneByName()
    {
        GameManager.Instance.PlaySound(transitionSound);
        SceneManager.LoadScene(sceneName);
    }
}
