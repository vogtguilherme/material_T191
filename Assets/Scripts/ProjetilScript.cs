using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilScript : MonoBehaviour
{    
    private float timeLimit = 3f;
    private float timer = 0;

    private void Update()
    {
        //Criar uma variável contadora
        timer += Time.deltaTime; //Atribuir o valor de "timer" com o tempo de atualização dos frames        
        //Comparar o valor do contador com o tempo limite
        //Se for igual ou maior...
        if(timer >= timeLimit)
        {
            //Resetar o contador
            timer = 0;
            //Destruir o Game Object
            Destroy(gameObject);
        }
    }

    //Detectar uma colisão
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Nome do objeto: " + other.gameObject.name);
        //Verificar qual objeto colidiu
        //Se for com o inimigo...
        if(other.gameObject.tag == "Enemy")
        {
            //Destruir/Desabilitar o objeto
            other.gameObject.SetActive(false);
            //Cria uma referência para a classe ScoreManager
            ScoreManager score;
            //Procura um objeto na cena com o nome "Score" e acessa o componente "ScoreManager"
            score = GameObject.Find("Score").GetComponent<ScoreManager>();
            //Adiciona 10 ao valor de "Points"
            score.Points = 10;
        }
    } 
}
