using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogoConejo : MonoBehaviour
{
    public GameObject DialogosConejo;
    public GameObject DialogoConejo1;
    public GameObject DialogoConejo2;
    public GameObject DialogoConejo3;
    public GameObject DialogoConejo4;
    public GameObject DialogoConejo5;
    public GameObject HUD;
    public GameObject personajeLeila;
    public int contDialogoConejo;  //Esto ayudara a los dialogos para abrirlos

    //Start is called before the first frame update
    void Start()
    {
        this.GetComponent<BoxCollider2D>().enabled = true;
        personajeLeila = GameObject.FindGameObjectWithTag("Personaje");
        contDialogoConejo = 1; // ponemos el contador en 1 para que el dialogo abra1 se 
        DialogosConejo.SetActive(false);
        DialogoConejo1.SetActive(false);  //aqui ponemos como estaran al inicio del juego cada uno
        DialogoConejo2.SetActive(false);
        DialogoConejo3.SetActive(false);
        DialogoConejo4.SetActive(false);
        DialogoConejo5.SetActive(false);
        HUD.SetActive(true);
    }

    //Update is called once per frame
    void Update()
    {
        if (!DialogoConejo1.activeSelf && contDialogoConejo == 1)  //con esto decimos que si el contador esta a 1 y el dialogo 1 esta desactivado se active el dialogo 2 y que le sume 1 mas al contador
       { 
            DialogoConejo2.SetActive(true);
            contDialogoConejo++;
        }

        if (!DialogoConejo2.activeSelf && contDialogoConejo == 2)
        {
            DialogoConejo3.SetActive(true);
            contDialogoConejo++;
        }

        if (!DialogoConejo3.activeSelf && contDialogoConejo == 3)
        {
            DialogoConejo4.SetActive(true);
            contDialogoConejo++;
        }

        if (!DialogoConejo4.activeSelf && contDialogoConejo == 4)
        {
            DialogoConejo5.SetActive(true);
            contDialogoConejo++;
        }

        if (!DialogoConejo5.activeSelf && contDialogoConejo == 5)
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
            DialogosConejo.SetActive(true);
            DialogoConejo1.SetActive(true);
            contDialogoConejo = 1;
            this.GetComponent<BoxCollider2D>().enabled = false;
        }

   }
}
