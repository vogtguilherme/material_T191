using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int points;

    private ScoreManager m_ScoreManager;

    public GameObject player;               //Referência para o GameObject do jogador  
    public Transform startPosition;         //Referência para o Transform com a posição inicial do jogador

    private void Awake()
    {
        //Acessar o componente "ScoreManager" deste mesmo GameObject
        m_ScoreManager = GetComponent<ScoreManager>();
    }

    private void Start()
    {
        //Altera a posição do jogador para a posição do Transform de referência
        player.transform.position = startPosition.position;
    }

    private void Update()
    {
        //Input para mostrar a imagem de game over (REMOVER DEPOIS)
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            m_ScoreManager.DisplayGameOverImage();
        }
    }

    //Propriedade da variável privada "points" somente de acesso
    public int Points
    {
        get
        {
            return points;
        }
    }

    //Função pública para adicionar um valor inteiro a variável "points"
    public void AddPoints(int points)
    {
        this.points += points;

        Debug.Log("Pontos: " + this.points);
        //Invoca a função "ChangeScore" que irá atualizar a interface com a pontuação atual
        m_ScoreManager.ChangeScore();
    }
}