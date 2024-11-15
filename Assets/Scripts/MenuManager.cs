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
    }

    // M�thode pour le bouton "Options"
    public void AfficherOptions()
    {
        menuPrincipal.SetActive(false); 
        menuOptions.SetActive(true);    
    }

   public void AfficherCredit()
    {
        menuPrincipal.SetActive(false);
        menuOptions.SetActive(false);
        Credit.SetActive(true);
   }

    // M�thode pour le bouton "Retour"
    public void RetourMenuPrincipal()
    {
        menuPrincipal.SetActive(true);  
        menuOptions.SetActive(false);   
    }
}
