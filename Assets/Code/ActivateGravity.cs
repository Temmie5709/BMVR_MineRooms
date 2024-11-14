using UnityEngine;

public class ActivateGravity : MonoBehaviour
{
    public GameObject[] objets3D;
    private int NbPass = 0;
    public Narration change;

    void Start()
    {
        foreach (GameObject obj in objets3D)
        {
            if (obj != null) // Vérifie si l'objet n'est pas nul
            {
                obj.SetActive(false); // Désactive l'objet
            }
        }

    }

    public void PokeTrigRight()
    {

        switch (NbPass)
        {
            case 0:
                change.ChangeDialogueSetByName("Right");
                EnableBounds();
                NbPass = 1;
                break;

            case 1:
                change.ChangeDialogueSetByName("TwoPass");
                NbPass = 2;
                break;

            case 2:
                break;
            
        }
    }
    public void PokeTrigLeft()
    {
        switch (NbPass)
        {
            case 0:
                change.ChangeDialogueSetByName("Left");
                EnableBounds();
                NbPass = 1;
                break;

            case 1:
                change.ChangeDialogueSetByName("TwoPass");
                NbPass = 2;
                break;

            case 2:
                break;

        }
    }


    void EnableBounds()
    {;

        foreach (GameObject obj in objets3D)
        {
            Rigidbody rb = obj.GetComponent<Rigidbody>();

            // Vérifier si l'objet a un Rigidbody
            if (rb != null)
            {
                // Activer la gravité du Rigidbody
                rb.useGravity = true;
            }
                obj.SetActive(true);

        }
    }
}
