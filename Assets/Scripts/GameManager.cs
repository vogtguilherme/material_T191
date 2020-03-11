using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int points;

    //Função pública para adicionar um valor inteiro a variável "points"
    public void AddPoints(int points)
    {
        this.points += points;

        Debug.Log("Pontos: " + this.points);
    }
}
