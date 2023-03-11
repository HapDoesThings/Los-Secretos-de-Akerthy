using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoEnte : MonoBehaviour
{
    private SpriteRenderer enteSR; //Variable para asignarle el Sprite Renderer del ente
    private Animator enteAnim;

    private int vida; //La vida que tiene el enemigo ente

    // Start is called before the first frame update
    void Start()
    {
        vida = 6;

        enteSR = GetComponent<SpriteRenderer>();
        enteSR.flipX = true; //empieza en true para que mire hacia la izquierda, ya que mira hacia la derecha de forma habitual
        enteAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cuchillo")
        {
            enteAnim.SetTrigger("onHit");

            if (vida > 1)
            {
                vida -= 2;
            }

            if (vida <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

}
