using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerHealth))] //É bizu
public class PlayerMovement : MonoBehaviour
{
    //--
    //Declaração de variáveis

    public float velocidade = 3.5f;         //Definição da variável velocidade    

    private PlayerHealth m_PlayerHealth;    //Referência ao componente PlayerHealth
    private Rigidbody m_Rigidbody;          //Referência ao componente Rigidbody
    private Renderer m_Renderer;            //Referência ao componente Renderer   

    //--
    //Declaração de funções

    private void Awake()
    {
        //Acessar o componente "Rigidbody" que está neste Game Object
        m_Rigidbody = gameObject.GetComponent<Rigidbody>();

        //Acessar o componente "PlayerHealth" que está neste Game Object
        m_PlayerHealth = gameObject.GetComponent<PlayerHealth>();
        //m_PlayerHealth = gameObject.AddComponent<PlayerHealth>();

        //Acessar o componente "Renderer" que está neste Game Object
        m_Renderer = gameObject.GetComponent<Renderer>();        
    }

    //Função executada na primeira atualização de frame
    private void Start()
    {
        //Acessar a propriedade Material do Renderer, e modificar a cor do material   
        m_Renderer.material.color = Color.black;

        m_PlayerHealth.Health = 50;
    }

    //Função chamada a cada frame executado no jogo
    void Update()
    {
        //Executa a função "Movement"
        Movement();
        //Executa a função "Rotation"
        Rotation();
    }

    void Rotation()
    {
        //Input.GetKeyDown(); - Quando a tecla é apertada (1 frame)
        //Input.GetKeyUp(); - Quando a tecla é soltada (1 frame)
        //Input.GetKey(); - Quando a tecla é pressionada

        //Se a tecla "seta esquerda" ou "A" for apertada
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            Debug.Log("Se movimentando para esquerda");
            //Criar um vetor que vai receber o valor atual da rotação do objeto
            Vector3 rotation = transform.rotation.eulerAngles;
            //Altera o valor de y do vetor
            rotation.y = -0.5f;
            //Executa a função Rotate passando o vetor rotation como parâmetro, multiplicando pela velocidade
            transform.Rotate(rotation * velocidade * 2);
        }

        //Se a tecla "seta direita" ou "D" for apertada
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            Debug.Log("Se movimentando para direita");
            //Criar um vetor que vai receber o valor atual da rotação do objeto
            Vector3 rotation = transform.rotation.eulerAngles;
            //Altera o valor de y do vetor
            rotation.y = 0.5f;
            //Executa a função Rotate passando o vetor rotation como parâmetro, multiplicando pela velocidade
            transform.Rotate(rotation * velocidade * 2);
        }
    }

    void Movement()
    {
        //Verificar se a tecla W ou a seta pra cima está sendo apertada
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            Debug.Log("Se movimentando para frente");

            //Vector3 (x, y, z)
            //Deslocar no eixo z
            transform.Translate(0, 0, 0.1f * velocidade);            
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            Debug.Log("Se movimentando para trás");

            transform.Translate(0, 0, -0.1f * velocidade);
        }        
    }
}
