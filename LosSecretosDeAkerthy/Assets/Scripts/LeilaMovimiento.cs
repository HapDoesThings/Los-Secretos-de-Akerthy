using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LeilaMovimiento : MonoBehaviour
{
    private float horizontal; //Esta variable sirve para saber si el movimiento horizontal es 0, va a la izquierda o a la derecha
    private float vel = 6.5f; //Velocidad horizontal
    private float potSalto = 6.5f; //Valor de la potencia del salto
    private float potEsquive = 15f; //Valor de la potencia del esquive
    private float tiempoEsquive = 0.2f; //Tiempo durante el que se hace la accion de esquivar
    private float recargaEsquive = 1f; //Tiempo en el que no se puede hacer un esquive despues de haber esquivado
    private float gravedadInicial; //Variable que guarda la gravedad del Rigid Body
    private float distSuelo = 1.1f; //Variable decimal que sirve para averiguar la distancia desde el punto de pivote del personaje hasta el suelo
    private float tiempoAtaque = 0.5f; //Tiempo durante el que se hace la accion de atacar
    private float recargaAtaque = 1f; //Tiempo en el que no se puede hacer un ataque despues de haber atacado
    

    private bool miraDerecha; //Variable que es true cuando mira a la derecha y false si mira a la izquierda 
    private bool saltoCond; // Variable que es true cuando la condicion de salto se cumple y false cuando no
    private bool tocarSuelo; //Variable que es true si esta tocando el suelo y false cuando no
    private bool esquiveCond = true; //Variable que es true si se puede esquivar y false si no
    private bool estaEsquivando; //Variable que es true si esta esquivando y false si no
    private bool ataqueCond = true; //Variable que es true si se puede atacar y false si no
    private bool estaAtacando; //Variable que es true si esta atacando y false si no

    [SerializeField] private Rigidbody2D rbLeila; //Variable que almacena informacion del Rigid Body del personaje
    [SerializeField] private Animator animLeila; //Variable que almacena informacion del Animator del personaje
    [SerializeField] private SpriteRenderer srLeila; //Variable que almacena informacion del Sprite Renderer del personaje
    [SerializeField] private TrailRenderer trLeila; //Varialbe que almacena informacion del TrailRenderer del personaje
    [SerializeField] private Transform checkerSuelo; //Variable que almacena informacion del Transform del hijo CheckerSuelo
    [SerializeField] private LayerMask layerSuelo; //Variable que sirve para asaber si la layer en cuestion es el suelo
    [SerializeField] private LayerMask layerPlataforma; //Variable que sirve para asaber si la layer en cuestion es una plataforma

    void Start()
    {
        rbLeila = GetComponent<Rigidbody2D>();
        animLeila = GetComponent<Animator>();
        srLeila = GetComponent<SpriteRenderer>();
        checkerSuelo = GetComponentInChildren<Transform>(true);
        gravedadInicial = rbLeila.gravityScale;
    }

    //Funcion que cambia de orientacion al personaje si mira a la derecha o izquierda
    private void Flip()
    {
        //Comprobamos si el personaje esta mirando hacia la derecha o hacia la izquierda
        //dependiendo de si el valor del movimiento es positivo o negativo
        if(miraDerecha && horizontal > 0f || !miraDerecha && horizontal < 0f)
        {
            Vector3 localScale = transform.localScale;
            miraDerecha = !miraDerecha;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void TocarSuelo()
    {
        if (Physics2D.Raycast(transform.position, Vector2.down, distSuelo, layerSuelo) || Physics2D.Raycast(transform.position, Vector2.down, distSuelo, layerPlataforma))
        {
            tocarSuelo = true;
        }
        else
        {
            tocarSuelo = false;
        }
    }

    private void Update()
    {
        //MOVIMIENTO HORIZONTAL (DIRECCION)
        horizontal = Input.GetAxis("Horizontal"); //Input.GetAxis le da los valores Horizontales para saber si mira a la derecha o la izquierda

        Flip();

        //Comprobamos la distancia del punto de pivote del personaje hasta el suelo
        Debug.DrawRay(transform.position, Vector2.down * distSuelo, new Color(1, 1, 1));

        TocarSuelo();

        if (((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W))) && tocarSuelo)
        {
            saltoCond = true;
        }

        if (Input.GetKey(KeyCode.Mouse1) && esquiveCond)
        {
            StartCoroutine(Esquivar());
        }

        if (Input.GetKey(KeyCode.Mouse0) && ataqueCond)
        {
            StartCoroutine(Atacar());
        }

        //ANIMACIONES
        animLeila.SetBool("Suelo", tocarSuelo);
        animLeila.SetFloat("Vel", Mathf.Abs(rbLeila.velocity.x));
    }

    private void FixedUpdate()
    {
        //MOVIMIENTO HORIZONTAL (VELOCIDAD)
        if (!estaEsquivando && !estaAtacando)
        {
            rbLeila.velocity = new Vector2(horizontal * vel, rbLeila.velocity.y); //Le asignamos una velocidad al personaje que dependera del eje horizontal
        }

        //Si el personaje esta tocando el suelo y el jugador pulsa las teclas ESPACIO o W y esta tocando el suelo
        if (saltoCond)
        {
            rbLeila.AddForce(Vector2.up * potSalto, ForceMode2D.Impulse);

            saltoCond = false; //Ponemos la condicion de salto a false para que no pueda volver a saltar hasta que toque el suelo otra vez
        }

        //Si el jugador suelta la tecla antes de que la potencia de salto llegue al maximo, la potencia de salto decrece
        if (saltoCond && rbLeila.velocity.y > 0f)
        {
            rbLeila.velocity = new Vector2(rbLeila.velocity.x, rbLeila.velocity.y * 0.5f);
        }
    }

    //Corrutina que permite esquivar
    private IEnumerator Esquivar()
    {
        //Cambiamos los valores de la condicion de esquive y si esta esquivando a false y true respectivamente
        esquiveCond = false;
        estaEsquivando = true;

        //Cambiamos la gravedad del personaje a 0 para que no se vea afectada por el esquive
        rbLeila.gravityScale = 0f;

        //Cambiamos la velocidad del personaje para aplicar la potencia de esquive en el eje X
        rbLeila.velocity = new Vector2(potEsquive * transform.localScale.x, 0f);
        animLeila.SetTrigger("estaEsquivando");

        //Cambiamos el emitting del Trail Renderer a true para que deje una estela cuando esquive
        trLeila.emitting = true;

        //Hacemos que el personaje deje de esquivar pasado el tiempo de la variable tiempoEsquive
        yield return new WaitForSeconds(tiempoEsquive);
        trLeila.emitting = false;
        rbLeila.gravityScale = gravedadInicial;
        estaEsquivando = false;
        yield return new WaitForSeconds(recargaEsquive);
        esquiveCond = true;
    }

    //Corrutina que permite Atacar
    private IEnumerator Atacar()
    {
        //Cambiamos los valores de la condicion de ataque y si esta atacando a false y true respectivamente
        ataqueCond = false;
        estaAtacando = true;

        animLeila.SetTrigger("Atacar");

        //Hacemos que el personaje deje de atacar pasado el tiempo de la variable tiempoAtaque
        yield return new WaitForSeconds(tiempoAtaque);
        estaAtacando = false;
        yield return new WaitForSeconds(recargaAtaque);
        ataqueCond = true;
    }
}
