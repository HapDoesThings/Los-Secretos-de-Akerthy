using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public GameObject Dialogo1;
    public GameObject Dialogo2;
    public GameObject Dialogo3;
    public GameObject Dialogo4;
    public GameObject Dialogo5;
    public GameObject Dialogo6;
    public GameObject Dialogo7;
    public GameObject HUD;
    [SerializeField] private GameObject personajeLeila;

    public int contDialogo; //Esto ayudara a los dialogos para abrirlos


    // Start is called before the first frame update
    void Start()
    {
        personajeLeila = GameObject.FindGameObjectWithTag("Personaje");
        contDialogo = 1; // ponemos el contador en 1 para que el dialogo abra1 se 
        Dialogo1.SetActive(true); //aqui ponemos como estaran al inicio del juego cada uno
        Dialogo2.SetActive(false);
        Dialogo3.SetActive(false);
        Dialogo4.SetActive(false);
        Dialogo5.SetActive(false);
        Dialogo6.SetActive(false);
        Dialogo7.SetActive(false);
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

        if (!Dialogo2.activeSelf && contDialogo == 2)
        {
            Dialogo3.SetActive(true);
            contDialogo++;
        }

        if (!Dialogo3.activeSelf && contDialogo == 3)
        {
            Dialogo4.SetActive(true);
            contDialogo++;
        }

        if (!Dialogo4.activeSelf && contDialogo == 4)
        {
            Dialogo5.SetActive(true);
            contDialogo++;
        }

          if (!Dialogo5.activeSelf && contDialogo == 5)
        {
            Dialogo6.SetActive(true);
            contDialogo++;
        }

          if (!Dialogo5.activeSelf && contDialogo == 5)
        {
            Dialogo7.SetActive(true);
            contDialogo++;
            personajeLeila.GetComponent<LeilaMovimiento>().enabled = true;
        }

    }
}
