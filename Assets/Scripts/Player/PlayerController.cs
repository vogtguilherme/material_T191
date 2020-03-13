using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Lista que armazena referências das esferas que estão na plataforma
    public List<SphereScript> playerSpheres = new List<SphereScript>();

    public void AddSphere(SphereScript sphere)
    {
        //Adiciona o item que está sendo usado como parâmetro da função
        playerSpheres.Add(sphere);        
        //Ativar comportamentos da esfera
    }
}