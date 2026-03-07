using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager1 : MonoBehaviour
{
    public GameObject panelMenu;
    

    // PLAY
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // escena 2 del juego
    }

}