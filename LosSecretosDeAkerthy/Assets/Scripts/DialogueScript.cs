using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueScript : MonoBehaviour
{

    public TextMeshProUGUI dialogueText;

    public string[] lines; //con esto controlaremos el numero de lineas que apareceran 

    public float textSpeed = 0.05f; // con esto controlaremos la velocidad con la que se escribe el texto

    int index; 

    void Start() //con esto indicaremos que cuando aparezca en pantalla empezara a reproducirse el texto solo
    {
        dialogueText.text = string.Empty;
        StartDialogue();
    }

    void Update() // con esto indicaremos que al apretar enter aparecera la linea completa y en caso de que ya este completa aparecera la siguiente linea
    {
      if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Mouse0))
      {
        if (dialogueText.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            dialogueText.text = lines[index];

        }
      }
    }

    public void StartDialogue() //esto es una corutina
    {
        index = 0;

        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine() // con esto hacemos que las letras se vayan escribiendo una a una en el text mesh pro automaticamente estando el juego en play
    {
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogueText.text += letter;

            yield return new WaitForSeconds(textSpeed);

        }

    }

    public void NextLine() //con esto indicamos que cuando la linea este completa se cierre automaticamente 
    {
        if (index <lines.Length - 1)
        {
            index++;
            dialogueText.text = string.Empty;
            StartCoroutine(WriteLine());
        
        }
        else
        {
            gameObject.SetActive(false);

        }

    }


}
