using System.Collections;
using UnityEngine;

public class StartInfoPanel : MonoBehaviour
{
    public GameObject infoPanel;
    public float tiempoVisible = 5f; 

    void Start()
    {
        infoPanel.SetActive(true);
        StartCoroutine(OcultarPanel());
    }

    IEnumerator OcultarPanel()
    {
        yield return new WaitForSeconds(tiempoVisible);
        infoPanel.SetActive(false);
    }
}