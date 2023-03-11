using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseInGame : MonoBehaviour
{
    public GameObject menuPausa;
    public Canvas canvasPausa;
    public GameObject personajeLeila;

    private void Start()
    {
        personajeLeila = GameObject.FindGameObjectWithTag("Personaje");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausa();
        }
    }

    public void Pausa()
    {
        canvasPausa.GetComponent<Canvas>().enabled = true;
        personajeLeila.GetComponent<LeilaMovimiento>().enabled = false;
        Time.timeScale = 0f;
    }

    public void Reanudar()
    {
        canvasPausa.GetComponent<Canvas>().enabled = false;
        personajeLeila.GetComponent<LeilaMovimiento>().enabled = true;
        Time.timeScale = 1f;
    }

    public void VolverMenuPrin(int numEscena)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(numEscena);
    }
}
