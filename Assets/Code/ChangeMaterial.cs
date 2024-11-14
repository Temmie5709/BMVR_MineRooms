using UnityEngine;

public class ChangeMaterial : MonoBehaviour
{
    // Cette fonction prend un Material en param�tre et l'applique au Renderer de l'objet
    public void SetMaterial(Material newMaterial)
    {

        Renderer renderer = GetComponent<Renderer>();

        // V�rifie si un Renderer est pr�sent sur l'objet
        if (renderer != null)
        {
            renderer.material = newMaterial;
        }

    }
}
