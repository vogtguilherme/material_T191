using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereScript : MonoBehaviour
{
    public GameManager gameManager;     //Referência para o GameManager

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

    public bool IsPlataformed
    {
        get { return isPlataformed; }
    }

    public PlayerPickUp Player
    {
        get { return player; }
        set
        {
            player = value;

            Debug.Log("Nome do objeto que coletou: " + player.gameObject.name);
        }
    }

    bool isDropped = true;              //Variável que controla o "estado" da esfera
    bool isPlataformed = false;         //Variável que controla se a esfera foi colocada na Plataforma ou não
        
    PlayerPickUp player;                //Referência ao jogador que coletou essa esfera 

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
                //Chamar a função "AddPoints" no game manager e adicionar 1 ponto
                gameManager.AddPoints(1);
                //Acessar o componente "PlayerController" que está no mesmo GameObject que o jogador
                var playerController = player.gameObject.GetComponent<PlayerController>();
                //Chama a função "AddSphere" para adicionar esta esfera na lista que está em "PlayerController"
                playerController.AddSphere(this);
                //Marcar "isPlataformed" como true
                isPlataformed = true;

                Debug.Log("Soltou a esfera");
            }
        }
    }
}
