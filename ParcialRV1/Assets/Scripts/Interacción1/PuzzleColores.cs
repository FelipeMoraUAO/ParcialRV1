using UnityEngine;
using System.Collections;

public class PuzzleColores : MonoBehaviour
{
    public PlataformaColor[] plataformas;
    public GameObject puerta;

    public float tiempoMemorizar = 3f;
    public float tiempoVerificacion = 2f;

    private bool puzzleActivo = false;
    private bool verificando = false;

    void Start()
    {
        StartCoroutine(SecuenciaMemorizar());
    }

    IEnumerator SecuenciaMemorizar()
    {
        puzzleActivo = false;
        verificando = false;

        // ENCENDER PLATAFORMAS
        foreach (var p in plataformas)
        {
            Renderer r = p.GetComponent<Renderer>();

            if (r != null)
                r.material.EnableKeyword("_EMISSION");
        }

        yield return new WaitForSeconds(tiempoMemorizar);

        // APAGAR PLATAFORMAS
        foreach (var p in plataformas)
        {
            Renderer r = p.GetComponent<Renderer>();

            if (r != null)
                r.material.DisableKeyword("_EMISSION");
        }

        puzzleActivo = true;
    }

    void Update()
    {
        if (!puzzleActivo || verificando)
            return;

        if (TodosEncima())
        {
            verificando = true;
            StartCoroutine(VerificarResultado());
        }
    }

    bool TodosEncima()
    {
        int contador = 0;

        foreach (var p in plataformas)
        {
            if (p.JugadorEncima())
                contador++;
        }

        return contador == plataformas.Length;
    }

    IEnumerator VerificarResultado()
    {
        yield return new WaitForSeconds(tiempoVerificacion);

        bool todosCorrectos = true;

        foreach (var p in plataformas)
        {
            if (!p.EstaCorrecto())
            {
                todosCorrectos = false;
                break;
            }
        }

        if (todosCorrectos)
        {
            AbrirPuerta();
        }
        else
        {
            yield return StartCoroutine(Fallo());
        }

        verificando = false;
    }

    void AbrirPuerta()
    {
        puzzleActivo = false;

        puerta.transform.position += Vector3.up * 5f;

        Debug.Log("PUERTA ABIERTA");
    }

    IEnumerator Fallo()
    {
        Debug.Log("FALLARON");

        yield return new WaitForSeconds(1f);

        StartCoroutine(SecuenciaMemorizar());
    }
}