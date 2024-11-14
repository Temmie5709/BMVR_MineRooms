using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    // Vitesse de défilement sur l'axe X et Y
    public float scrollSpeedX = 0.5f;
    public float scrollSpeedY = 0.5f;

    // Référence au matériau
    private Material material;

    void Start()
    {
        // Récupère le matériau de l'objet
        material = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // Calcul du décalage en fonction du temps et de la vitesse
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;

        // Applique le décalage de texture au matériau
        material.mainTextureOffset = new Vector2(offsetX, offsetY);
    }
}
