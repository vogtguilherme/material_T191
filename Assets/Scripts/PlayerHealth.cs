using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    
    //--
    //Declaração de variáveis

    private int health = 100; //Variável ou campo

    public int Health //Propriedade
    {
        get
        {
            return health;
        }
        set
        {
            health = value;

            MostraVida();
        }
    }

    void MostraVida()
    {
        Debug.Log("A vida é: " + health);
    }

    //--
    //Declaração de funções
}
