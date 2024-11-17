using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject menuPrincipal; 
    public GameObject menuOptions;
    public GameObject Credit;


    void Start()
    {
        menuPrincipal.SetActive(true);
        menuOptions.SetActive(false);
        Credit.SetActive(false);
    }

    // Méthode pour le bouton "Options"
    public void AfficherOptions()
    {
        Debug.Log("Opyion");
        menuPrincipal.SetActive(false); 
        menuOptions.SetActive(true);    
    }

   public void AfficherCredit()
    {

        Debug.Log("Crdit");
        menuPrincipal.SetActive(false);
        Credit.SetActive(true);
   }

    // Méthode pour le bouton "Retour"
    public void RetourMenuPrincipal()
    {
        menuPrincipal.SetActive(true);
        menuOptions.SetActive(false);
        Credit.SetActive(false);
    }
}
