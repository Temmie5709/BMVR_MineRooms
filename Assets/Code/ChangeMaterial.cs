using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    // Cette fonction prend un Material en paramètre et l'applique au Renderer de l'objet
    public void SetMaterial(Material newMaterial)
    {

        Renderer renderer = GetComponent<Renderer>();

        // Vérifie si un Renderer est présent sur l'objet
        if (renderer != null)
        {
            renderer.material = newMaterial;
        }

    }
}
