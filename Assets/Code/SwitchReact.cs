using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchReact : MonoBehaviour
{


    public void Rotat()
    {

        transform.DORotate(new Vector3(0, 0, 180), 2f, RotateMode.WorldAxisAdd);

    }
}
