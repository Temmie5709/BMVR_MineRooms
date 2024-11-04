using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchReact : MonoBehaviour
{
    bool One_Pass = false;
    Narration Swite;

    public void Rotat()
    {
        transform.DORotate(new Vector3(0, 0, 180), 2f, RotateMode.WorldAxisAdd);
        if(One_Pass == false)
        {
            Swite.ChangeDialogueSet();
        }
        One_Pass = true;
    }
}
