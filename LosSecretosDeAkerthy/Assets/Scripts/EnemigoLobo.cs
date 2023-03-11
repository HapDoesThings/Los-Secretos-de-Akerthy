using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoLobo : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private float distancia; //La distancia que se mueve de un lado al otro en el eje X
    private float posicionInicialX; //La posicion inicial del movimiento
    [SerializeField] private float velocidad; //La velocidad a la que se mueve de un lado al otro

    private float posicionActual, posicionAnterior; //Las posiciones que utilizamos para calcular cuando tiene que hacer el flip del sprite
    private SpriteRenderer loboSR; //Variable para asignarle el Sprite Renderer del lobo
    private Animator loboAnim;

    private int vida; //La vida que tiene el enemigo lobo

    // Start is called before the first frame update
    void Start()
    {
        posicionInicialX = transform.position.x;
        distancia = 3.6f;
        velocidad = 2f;
        vida = 6;

        loboSR = GetComponent<SpriteRenderer>();
        loboSR.flipX = true; //empieza en true para que mire hacia la izquierda, ya que mira hacia la derecha de forma habitual
        loboAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //El movimiento en el eje X utilizando la funcion PingPong = new Vector2 (float posIniX  + Mathf.PingPong(float vel * Time.time, float dist), transform.position.y;
        transform.position = new Vector2(posicionInicialX + Mathf.PingPong(velocidad * Time.time, distancia), transform.position.y);

        //Comprobacion de la direccion para cambiar el sprite mediante flip
        posicionActual = transform.position.x;

        if (posicionActual < posicionAnterior)
        {
            loboSR.flipX = true;
        }

        if (posicionActual > posicionAnterior)
        {
            loboSR.flipX = false;
        }

        posicionAnterior = transform.position.x;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cuchillo")
        {
            loboAnim.SetTrigger("onHit");

            if (vida > 1)
            {
                vida -= 2;
            }

            if (vida == 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
