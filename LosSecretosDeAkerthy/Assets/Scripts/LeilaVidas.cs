using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LeilaVidas : MonoBehaviour
{
    private int flores;
    private int setas;
    private float recargaDanyo = 1f;
    private bool danyoCond = true;
    private TextMeshProUGUI textoFlores;
    private TextMeshProUGUI textoSetas;
    public Rigidbody2D rb;
    public Animator anim;

    //VIDAS
    public Image[] vidas = new Image[4]; //Array que almacena las imagenes de las vidas
    private int contVidas; //Variable de enteros que almacena la cantidad de vidas del personaje

    void Start()
    {
        textoFlores = GameObject.Find("ContadorFlores").GetComponent<TextMeshProUGUI>();
        textoSetas = GameObject.Find("ContadorSetas").GetComponent<TextMeshProUGUI>();
        contVidas = vidas.Length;
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Flores")
        {
            flores++;
            textoFlores.text = flores.ToString();
            if (contVidas <= 3)
            {
                contVidas++;
                vidas[contVidas - 1].enabled = true;
            }
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "Setas")
        {
            setas++;
            textoSetas.text = setas.ToString();
            if (contVidas <= 3)
            {
                contVidas++;
                vidas[contVidas - 1].enabled = true;
            }
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.tag == "PasarANiv1")
        {
            SceneManager.LoadScene(5);
        }

        if (coll.gameObject.tag == "PasarANivTut")
        {
            SceneManager.LoadScene(4);
        }

        if (coll.gameObject.tag == "PasarANiv2" && setas >= 2)
        {
            SceneManager.LoadScene(6);
        }

        if (coll.gameObject.tag == "PasarAGanar" && flores >= 3)
        {
            SceneManager.LoadScene(2);
        }

        if (coll.gameObject.tag == "Enemigo_Lobo" && danyoCond)
        {
            if (contVidas >= 1)
            {
                StartCoroutine(RecibirDanyo());
            }

            if (contVidas <= 1)
            {
                SceneManager.LoadScene(1);
            }
        }
    }

    private IEnumerator RecibirDanyo()
    {
        danyoCond = false;
        contVidas--;
        vidas[contVidas].enabled = false;
        yield return new WaitForSeconds(recargaDanyo);
        danyoCond = true;
        anim.SetTrigger("Danyo");
    }
}

