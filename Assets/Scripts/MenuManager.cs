using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPrincipal; // Assigner le Canvas du menu principal dans l'inspecteur
    public GameObject menuOptions;   // Assigner le Canvas du menu d'options dans l'inspecteur

    void Start()
    {
        // On commence en affichant le menu principal et en masquant le menu d'options
        menuPrincipal.SetActive(true);
        menuOptions.SetActive(false);
    }

    // Méthode pour le bouton "Options"
    public void AfficherOptions()
    {
        menuPrincipal.SetActive(false); // Masque le menu principal
        menuOptions.SetActive(true);    // Affiche le menu d'options
    }

    // Méthode pour le bouton "Retour"
    public void RetourMenuPrincipal()
    {
        menuPrincipal.SetActive(true);  // Affiche le menu principal
        menuOptions.SetActive(false);   // Masque le menu d'options
    }
}
