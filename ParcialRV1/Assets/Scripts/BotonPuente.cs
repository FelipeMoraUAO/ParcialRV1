using UnityEngine;

public class BotonPuente : MonoBehaviour
{
    public GameObject cuboBloqueo;
    public float escalaPresionado = 0.2f;
    private Vector3 escalaOriginal;
    private bool presionado = false;

    void Start()
    {
        escalaOriginal = transform.localScale;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            presionado = true;
            transform.localScale = new Vector3(
                escalaOriginal.x,
                escalaPresionado,
                escalaOriginal.z
            );

            cuboBloqueo.SetActive(false);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            presionado = false;
            transform.localScale = escalaOriginal;

            cuboBloqueo.SetActive(true);
        }
    }
}