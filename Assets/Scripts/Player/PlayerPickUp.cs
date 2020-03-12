using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    private bool isCarrying = false;
    
    public Transform pickup;        //Referência para a esfera que estiver colidindo

    private void Update()
    {
        //Verificar input
        if(Input.GetKeyDown(KeyCode.E))
        {
            //Verificar se o jogador está carregando uma esfera            
            if (isCarrying) //isCarrying == true
            {
                // Soltar
                Drop();
            }
            //Senão...
            else
            {
                //Coletar
                Collect();
            }
        }      
    }

    void Collect()
    {
        if (pickup == null)
            return;

        //Cria uma referência para a classe SphereScript e tenta acessá-la através do GameObject "pickup"
        SphereScript sphereScript = pickup.GetComponent<SphereScript>();    
        //Se a referência não tem valor nulo...
        if(sphereScript != null)
        {
            //Se a esfera ainda não foi plataformed
            if (sphereScript.IsPlataformed)  //sphereScript.IsPlataformed == true
            {
                Debug.Log("Essa esfera já foi plataformed");
                return;
            }
            //Transformar o objeto armazenado na referência em filho deste Transform(Jogador)
            pickup.parent = transform;
            //Cria um vetor para definir a nova posição da esfera
            Vector3 novaPosicao = new Vector3(0, .5f, 0);
            //Mudar a posição do objeto em relação ao pai
            pickup.localPosition = novaPosicao;
            //Altera o valor de "isCarrying" para true, variável que controla a ação de input
            isCarrying = true;
            //Altera o valor da propriedade "IsDropped" para falso
            sphereScript.IsDropped = false;
            //Definir a variável "Player" do "sphereScript" como este objeto
            sphereScript.Player = this;
        }
    }

    void Drop()
    {
        if (pickup == null)
            return;
        
        //Deixar o objeto coletado sem pai
        pickup.parent = null;
        //Cria um Vector3 e armazena as coordenadas x e z do jogador
        Vector3 dropPosition = new Vector3(transform.position.x, 0, transform.position.z);
        //Definir a posicao do objeto para o valor do Vector3
        pickup.position = dropPosition;
        //Altera o valor de "isCarrying" para false
        isCarrying = false;
        //Cria uma referência para a classe SphereScript e tenta acessá-la através do GameObject "pickup"
        SphereScript sphereScript = pickup.GetComponent<SphereScript>();
        //Se a referência não tem valor nulo...
        if (sphereScript != null)
        {
            //Altera o valor da propriedade "IsDropped" para true
            sphereScript.IsDropped = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Verificar a tag do objeto que entrou no Trigger

        //Se for "Collectable"...
        if(other.tag == "Collectable")
        {
            //Mostrar o nome do objeto
            Debug.Log(other.gameObject.name);
            if(!isCarrying)
            {
                //Armazenar o objeto que colidiu na referência
                pickup = other.gameObject.transform;
            }
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        //Se for "Collectable"...
        if (other.tag == "Collectable")
        {           
            if (!isCarrying)
            {
                //Armazenar o objeto que colidiu na referência
                pickup = null;
            }
        }
    }
}

  