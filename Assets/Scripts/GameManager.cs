using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameOver;  //Evento disparado quando a condição de fim de jogo é atingida

    private int points;
    private int collectedSpheresCount;      //Número de esferas que foram coletadas (na plataforma)

    private bool isOver = false;            //Flag que sinaliza quando o jogo acabou

    private ScoreManager m_ScoreManager;    

    [SerializeField]
    private SphereScript[] spheres;

    public GameObject player;               //Referência para o GameObject do jogador  
    public Transform startPosition;         //Referência para o Transform com a posição inicial do jogador
    public Transform sphereHolder;          //Referência para o transform que possui todas esferas como filhas

    public int sphereCount { get; private set; }

    //Propriedade da variável privada "points" somente de acesso
    public int Points
    {
        get
        {
            return points;
        }
    }

    private void Awake()
    {
        //Acessar o componente "ScoreManager" deste mesmo GameObject
        m_ScoreManager = GetComponent<ScoreManager>();
        //Inicializa o array com o número de objetos que são filhos do transform "sphereHolder"
        spheres = new SphereScript[sphereHolder.childCount];
    }

    private void Start()
    {
        //Altera a posição do jogador para a posição do Transform de referência
        player.transform.position = startPosition.position;
        //Executa um loop que realiza um número de repetições conforme o tamanho do vetor "spheres"
        for (int i = 0; i < spheres.Length; i++)
        {
            //Armazenar as referências das esferas que são filhas do "sphereHolder"
            spheres[i] = sphereHolder.GetChild(i).GetComponent<SphereScript>();
        }
        //Define o valor de "sphereCount" para o número de objetos que são filhos de "sphereHolder"
        sphereCount = sphereHolder.childCount;        
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            //Se a flag "isOver" for verdadeira...
            if (isOver)
            {
                //Reiniciar a cena
                ResetLevel();
            }
        }
    }    

    //Função pública para adicionar um valor inteiro a variável "points"
    public void AddPoints(int points)
    {
        this.points += points;

        Debug.Log("Pontos: " + this.points);
        
        //Invoca a função "ChangeScore" que irá atualizar a interface com a pontuação atual
        m_ScoreManager.ChangeScore();

        collectedSpheresCount++;

        CountSpheres();
    }

    private void CountSpheres()
    {
        if(collectedSpheresCount == spheres.Length)
        {
            //Começar o game over

            //Se o evento "OnGameOver" não for nulo...
            if(OnGameOver != null)
            {
                //Disparar o evento
                OnGameOver();   //OnGameOver.Invoke();
                                //Para limpar todas funções de um evento usa-se OnGameOver = null;

                //Alterar o valor do bool "isOver" para true, indicando que o jogo acabou
                isOver = true;
            }
        }
    }

    void ResetLevel()
    {
        //Carrega a cena atual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}