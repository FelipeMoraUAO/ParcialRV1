using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject panelMenu;
    public GameObject panelInstrucciones;
    public GameObject panelControles;
    public GameObject panelCreditos;

    // PLAY
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // escena 2 del juego
    }

    // INSTRUCCIONES
    public void AbrirInstrucciones()
    {
        panelMenu.SetActive(false);
        panelInstrucciones.SetActive(true);
    }

    // CONTROLES
    public void AbrirControles()
    {
        panelMenu.SetActive(false);
        panelControles.SetActive(true);
    }

    // CREDITOS
    public void AbrirCreditos()
    {
        panelMenu.SetActive(false);
        panelCreditos.SetActive(true);
    }

    // VOLVER AL MENU
    public void VolverMenu()
    {
        panelMenu.SetActive(true);
        panelInstrucciones.SetActive(false);
        panelControles.SetActive(false);
        panelCreditos.SetActive(false);
    }

    // SALIR DEL JUEGO
    public void SalirJuego()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}