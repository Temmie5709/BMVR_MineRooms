using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    // M�thode pour le Toggle fran�ais activ�
    public void OnFrenchSelected()
    {
        Debug.Log("La langue s�lectionn�e est le Fran�ais.");
    }

    // M�thode pour le Toggle anglais activ�
    public void OnEnglishSelected()
    {
        Debug.Log("La langue s�lectionn�e est l'Anglais.");
    }

    // M�thode pour le Toggle fran�ais d�sactiv�
    public void OnFrenchDeselected()
    {
        Debug.Log("Le fran�ais a �t� d�s�lectionn�.");
    }

    // M�thode pour le Toggle anglais d�sactiv�
    public void OnEnglishDeselected()
    {
        Debug.Log("L'anglais a �t� d�s�lectionn�.");
    }
}
