using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogosEnte : MonoBehaviour
{
    public GameObject DialogoEnte;
    public GameObject DialogoEnte1;
    public GameObject DialogoEnte2;
    public GameObject HUD;
    public GameObject personajeLeila;
    private int contDialogoEnte; //Esto ayudara a los dialogos para abrirlos

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        personajeLeila = GameObject.FindGameObjectWithTag("Personaje");
        contDialogoEnte = 0; // ponemos el contador en 1 para que el dialogo abra1 se 
        DialogoEnte.SetActive(false);
        DialogoEnte1.SetActive(false);  //aqui ponemos como estaran al inicio del juego cada uno
        DialogoEnte2.SetActive(false);
        HUD.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogoEnte1.activeSelf && contDialogoEnte == 1) //con esto decimos que si el contador esta a 1 y el dialogo 1 esta desactivado se active el dialogo 2 y que le sume 1 mas al contador
        { 
            DialogoEnte2.SetActive(true);
            contDialogoEnte++;
        }

        if (!DialogoEnte2.activeSelf && contDialogoEnte == 2)
        {
            HUD.SetActive(true);
            personajeLeila.GetComponent<LeilaMovimiento>().enabled = true;
        }
    }
    
   private void OnTriggerEnter2D(Collider2D coll) //con esto hacemos que cuando el personaje entre en contacto con el collider el dialogo 1 apareceria
   {
        if (coll.gameObject.tag == "Personaje")
        {
            personajeLeila.GetComponent<LeilaMovimiento>().enabled = false;
            DialogoEnte.SetActive(true);
            DialogoEnte1.SetActive(true);
            contDialogoEnte = 1;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
   }
}
