using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController1 : MonoBehaviour
{
    public GameObject Dialogo1;
    public GameObject Dialogo2;
    public GameObject HUD;
    private GameObject personajeLeila;

    public int contDialogo; //Esto ayudara a los dialogos para abrirlos

    // Start is called before the first frame update
    void Start()
    {
        personajeLeila = GameObject.FindGameObjectWithTag("Personaje");
        contDialogo = 1; // ponemos el contador en 1 para que el dialogo abra1 se 
        Dialogo1.SetActive(true); //aqui ponemos como estaran al inicio del juego cada uno
        Dialogo2.SetActive(false);
        HUD.SetActive(false);
        personajeLeila.GetComponent<LeilaMovimiento>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Dialogo1.activeSelf && contDialogo == 1) //con esto decimos que si el contador esta a 1 y el dialogo 1 esta desactivado se active el dialogo 2 y que le sume 1 mas al contador
        { 
            Dialogo2.SetActive(true);
            contDialogo++;
        }

        if (!Dialogo2.activeSelf && contDialogo == 2)//si el contador esta a 2 y el dialogo 2 no esta activado se activara el HUD
        {
            HUD.SetActive(true);
            personajeLeila.GetComponent<LeilaMovimiento>().enabled = true;
            this.enabled = false;
        }
    }
}
