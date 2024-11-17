using UnityEngine;

public class QuitGame : MonoBehaviour
{
    // M�thode pour quitter le jeu
    public void QuitApplication()
    {
#if UNITY_EDITOR
        // Si vous �tes en mode �dition dans Unity, arr�ter l'ex�cution
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // Si vous �tes dans une build, quitter l'application
            Application.Quit();
#endif

    }
}
