using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement m_PlayerMovement;    
    
    //Lista que armazena referências das esferas que estão na plataforma
    public List<SphereScript> playerSpheres = new List<SphereScript>();

    private void Awake()
    {
        m_PlayerMovement = GetComponent<PlayerMovement>();        
    }

    private void OnEnable()
    {
        GameManager.OnGameOver += DisableMovement;
    }

    public void AddSphere(SphereScript sphere)
    {
        //Adiciona o item que está sendo usado como parâmetro da função
        playerSpheres.Add(sphere);        
        //Ativar comportamentos da esfera
    }

    private void DisableMovement()
    {
        m_PlayerMovement.enabled = false;
    }

    private void OnDisable()
    {
        GameManager.OnGameOver -= DisableMovement;
    }
}