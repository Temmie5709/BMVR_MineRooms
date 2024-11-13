using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchReact : MonoBehaviour
{
    bool OnePass = true;
    public Narration Swite;
    public Light targetLight;
    public float delayMove = 3.5f, lightTime = 2f;
    private float intensity = 3.6f;


    public void Rotat()
    {
        transform.DORotate(new Vector3(0, 0, 180), delayMove, RotateMode.WorldAxisAdd);
        if(OnePass == true)
        {
            Swite.ChangeDialogueSetByName("Switch");
        }
        OnePass = false;
    }

    public void EnableLight()
    {
        targetLight.DOIntensity(intensity, lightTime);
    }
}
