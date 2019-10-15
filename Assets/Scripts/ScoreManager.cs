using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   //Biblioteca de interface da Unity

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;   

    private int points = 0; //Isso é um campo ou membro da classe "ScoreManager"

    //Propriedade: é um tipo de variável que encapsula um campo privado
    public int Points   
    {
        get
        {
            return points;
        }

        set
        {
            points += value;

            UpdatePointsText();
        }
    }  

    void UpdatePointsText()
    {
        scoreText.text = "Points: " + points.ToString();
    }
}