using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchReact : MonoBehaviour
{
    bool One_Pass = true;
    public Narration Swite;
    public Light targetLight;
    public float delay = 3f;

    public void Rotat()
    {
        transform.DORotate(new Vector3(0, 0, 180), 2f, RotateMode.WorldAxisAdd);
        if(One_Pass == true)
        {
            Swite.ChangeDialogueSetByName("Switch");
            Invoke(nameof(EnableLight), delay);

        }
        One_Pass = false;
    }

    void EnableLight()
    {
        targetLight.DOIntensity(3.6f, 2f);
    }
}
