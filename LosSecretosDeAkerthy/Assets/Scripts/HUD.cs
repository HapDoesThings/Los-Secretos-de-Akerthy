using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    private GameObject barraVida;
    private Sprite vida3, vida2, vida1, vida0;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    private void BarraVida(int salud) //Con esto la barra de vida se actualizara correspondiendo con las vidas que le quedan a los personajes
    {
            if (salud == 2) barraVida.GetComponent<Image>().sprite = vida2;
            if (salud == 1) barraVida.GetComponent<Image>().sprite = vida1;
    }

    private void muertePlayer() //en caso de que el personaje muera el hud queda a 0
    {
        barraVida.GetComponent<Image>().sprite = vida0;

    }

    // Update is called once per frame
    void Update()
    {
        

        
    }
}
