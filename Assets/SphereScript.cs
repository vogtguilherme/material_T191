using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    public GameManager gameManager;     //Referência para o GameManager

    bool isDropped = true;              //Variável que controla o "estado" da esfera

    public bool IsDropped               //Propriedade da variável "isDropped"
    {
        get
        {
            return isDropped;
        }
        set
        {
            isDropped = value;
        }
    }

    private void Awake()
    {
        if(gameManager == null)
            //Procurar na hierarquia um objeto com o nome "Game Manager"
            //e atribuir o componente "GameManager" a variavel de referência
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    //Detectar colisao da esfera em relação a plataforma
    private void OnTriggerEnter(Collider other)
    {
        //Se o outro trigger tiver o nome de "Plataforma"
        if (other.gameObject.name == "Plataforma")
        {            
            Debug.Log("A gente já chegou");

            //Descobrir se o jogador soltou a esfera
            //Se o valor da variável for true...
            if (isDropped == true)
            {
                //Contar os pontos e impedir que ele pegue a esfera de novo

                gameManager.AddPoints(1);

                Debug.Log("Soltou a esfera");
            }
        }
    }
}
