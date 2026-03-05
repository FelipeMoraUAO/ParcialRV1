using UnityEngine;

public class PlataformaColor : MonoBehaviour
{
    public string colorCorrecto;

    private bool jugadorEncima = false;
    private string jugadorColor = "";

    void OnTriggerEnter(Collider other)
    {
        PlayerColor player = other.GetComponent<PlayerColor>();

        if (player != null)
        {
            jugadorEncima = true;
            jugadorColor = player.colorJugador;
        }
    }

    void OnTriggerExit(Collider other)
    {
        PlayerColor player = other.GetComponent<PlayerColor>();

        if (player != null)
        {
            jugadorEncima = false;
            jugadorColor = "";
        }
    }

    public bool JugadorEncima()
    {
        return jugadorEncima;
    }

    public bool EstaCorrecto()
    {
        return jugadorEncima && jugadorColor == colorCorrecto;
    }
}