using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoLobo : MonoBehaviour
{
    public GameObject DialogosLobo;
    public GameObject DialogoLobo1;
    public GameObject DialogoLobo2;
    public GameObject DialogoLobo3;
    public GameObject HUD;
    public GameObject personajeLeila;
    public int contDialogoLobo; //Esto ayudara a los dialogos para abrirlos

    //Start is called before the first frame update
    void Start()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        personajeLeila = GameObject.FindGameObjectWithTag("Personaje");
        contDialogoLobo = 1; // ponemos el contador en 1 para que el dialogo abra1 se 
        DialogosLobo.SetActive(false);
        DialogoLobo1.SetActive(false); //aqui ponemos como estaran al inicio del juego cada uno
        DialogoLobo2.SetActive(false);
        DialogoLobo3.SetActive(false);
        HUD.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (!DialogoLobo1.activeSelf && contDialogoLobo == 1) //con esto decimos que si el contador esta a 1 y el dialogo 1 esta desactivado se active el dialogo 2 y que le sume 1 mas al contador
        { 
            DialogoLobo2.SetActive(true);
            contDialogoLobo++;
        }

        if (!DialogoLobo2.activeSelf && contDialogoLobo == 2)
        {
            DialogoLobo3.SetActive(true);
            contDialogoLobo++;
        }

        if (!DialogoLobo3.activeSelf && contDialogoLobo == 3)
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
            DialogosLobo.SetActive(true);
            DialogoLobo1.SetActive(true);
            contDialogoLobo = 1;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }
   }
}
