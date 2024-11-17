using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // Méthode pour quitter le jeu
    public void QuitApplication()
    {
#if UNITY_EDITOR
        // Si vous êtes en mode édition dans Unity, arrêter l'exécution
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Si vous êtes dans une build, quitter l'application
            Application.Quit();
#endif

    }
}
