using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    // Vitesse de d�filement sur l'axe X et Y
    public float scrollSpeedX = 0.5f;
    public float scrollSpeedY = 0.5f;

    // R�f�rence au mat�riau
    private Material material;

    void Start()
    {
        // R�cup�re le mat�riau de l'objet
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Calcul du d�calage en fonction du temps et de la vitesse
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;

        // Applique le d�calage de texture au mat�riau
        material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
