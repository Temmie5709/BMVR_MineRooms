using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Ajoutez ceci pour utiliser Toggle

public class ToggleLangue : MonoBehaviour
{
    public Toggle ToggleFr;
    public Toggle ToggleEn;

    // Fonction qui inverse les états des toggles
    public void ChangeToggle()
    {
        // Si le ToggleFr est activé
        if (ToggleFr.isOn)
        {
            ToggleFr.isOn = false;
            ToggleEn.isOn = true;
            GameManager.Instance.SetLangue("En");
        }
        else
        {
            ToggleFr.isOn = true;
            ToggleEn.isOn = false;
            GameManager.Instance.SetLangue("Fr");
        }
    }
}
