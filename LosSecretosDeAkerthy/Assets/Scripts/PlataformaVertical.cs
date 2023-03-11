using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaVertical : MonoBehaviour
{
    private PlatformEffector2D effectorPlat;
    private float waitTime; //Variable que servira de tiempo de espera

    // Start is called before the first frame update
    void Start()
    {
        effectorPlat = GetComponent<PlatformEffector2D>();
        waitTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Cuando el jugador suelte la tecla S le pondremos un waitTime de 0.5 a la plataforma
        if (Input.GetKeyUp(KeyCode.S))
        {
            waitTime = 0.1f;
        }

        //Cuando el jugador pulse la tecla S, si el waitTime es menor o igual a 0, cambiamos el sentido de la plataforma
        //para atravesarla desde arriba hacia abajo
        //y ponemos un waitTime a la plataforma de 0.5
        if (Input.GetKey(KeyCode.S))
        {
            if (waitTime <= 0)
            {
                effectorPlat.rotationalOffset = 180f;
                waitTime = 0.05f;
            }
            else //Si el waitTime no es 0.5 lo decrementa poco a poco con Time.deltaTime
            {
                waitTime -= Time.deltaTime;
            }
        }

        //Cuando el jugador pulse la tecla ESPACIO o W la plataforma pasa al sentido original, dejando pasar al jugador desde abajo hacia arriba
        if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.W))
        {
            waitTime = 0.05f;
            effectorPlat.rotationalOffset = 0;
        }
    }
}
