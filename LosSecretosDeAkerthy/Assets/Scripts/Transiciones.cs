using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transiciones : MonoBehaviour
{
    Animator anim; //Animator del canvas de transicion

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //Hacemos una corrutina que utilice el numero de la escena a la que se quiere pasar para que haga la animacion del canvas y pase a la escena en cuestion
    public IEnumerator TransicionCorrutina(int escena)
    {
        anim.SetTrigger("Transicion");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(escena);
    }
}