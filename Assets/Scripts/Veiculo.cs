using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Veiculo
{
    //Campos da classe Veiculo (fields)

    protected int velocidade;
    protected string modelo;
    protected string ano;

    //Propriedades da classe

    public int Velocidade
    {
        get//Modificador de leitura
        {
            return velocidade;
        }
        set//Modificador de escrita
        {
            velocidade = value; //SetVelocidade(int value)
        }
    }

    public string Modelo
    {
        get
        {
            return modelo;
        }
    }

    public string Ano
    {
        get
        {
            return ano;
        }
    }

    public void Acelerar()
    {

    }

    public void Frear()
    {

    }

    public virtual void Buzinar()
    {
        Debug.Log("Veiculo");        
    }
}

//Criar a classe "Carro" que herda da classe "Veiculo"
public class Carro : Veiculo
{
    //Construtor da classe "Carro" que recebe 3 variáveis como parâmetros
    public Carro(int velocidade, string modelo, string ano)
    {
        this.velocidade = velocidade;   //Define a variavel da classe Carro com o valor da variável parâmetro
        this.modelo = modelo;
        this.ano = ano;
        
        Debug.Log("Modelo: " + modelo + " Ano: " + ano + " Velocidade: " + velocidade);        
    }

    public override void Buzinar()
    {
        base.Buzinar();

        Debug.Log("Carro");
    }
}

public class Moto : Veiculo
{
    //Construtor da classe "Moto" que recebe 3 variáveis como parâmetros
    public Moto(int velocidade, string modelo, string ano)
    {
        this.velocidade = velocidade;
        this.modelo = modelo;
        this.ano = ano;
        
        Debug.Log("Modelo: " + modelo + " Ano: " + ano + " Velocidade: " + velocidade);        
    }
}