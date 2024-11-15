using UnityEngine;

public class LanguageManager : MonoBehaviour
{
    // Méthode pour le Toggle français activé
    public void OnFrenchSelected()
    {
        Debug.Log("La langue sélectionnée est le Français.");
    }

    // Méthode pour le Toggle anglais activé
    public void OnEnglishSelected()
    {
        Debug.Log("La langue sélectionnée est l'Anglais.");
    }

    // Méthode pour le Toggle français désactivé
    public void OnFrenchDeselected()
    {
        Debug.Log("Le français a été désélectionné.");
    }

    // Méthode pour le Toggle anglais désactivé
    public void OnEnglishDeselected()
    {
        Debug.Log("L'anglais a été désélectionné.");
    }
}
