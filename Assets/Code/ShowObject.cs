using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true); // Activer cet objet
    }
}
