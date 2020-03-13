using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text pointsText;             //Referência ao componente de texto que mostra os pontos na UI
    public GameObject gameOverImage;

    private GameManager gameManager;    //Referência ao GameManager

    string pointsPrefix = "Points: ";

    private void Awake()
    {
        //Acessar o componente "GameManager" deste mesmo GameObject
        gameManager = GetComponent<GameManager>();        
    }

    private void Start()
    {
        //Chama função "ChangeScore" para alterar o valor da 
        ChangeScore();
    }

    public void ChangeScore()
    {
        //Atribui o valor de Points para a string do componente "pointsText"
        pointsText.text = pointsPrefix + gameManager.Points.ToString();
    }

    //Função para mostrar a imagem de game over
    public void DisplayGameOverImage()
    {
        gameOverImage.SetActive(true);        
    }
}