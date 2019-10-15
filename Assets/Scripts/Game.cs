using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    Carro carro;    //Cria um objeto do tipo "Carro"
    Moto moto;      //Cria um objeto do tipo "Moto"

                    /*
                    // Start is called before the first frame update
                    void Start()
                    {        
                        //Criar uma instância da classe "Carro"
                        carro = new Carro(160, "HB20", "2019");
                        //Criar uma instância da classe "Moto"
                        moto = new Moto(280, "CB1000", "2018");        

                        //------        
                    }

                    private void Update()
                    {
                        if(Input.GetKeyDown(KeyCode.Space))
                        {
                            TocarBuzina(carro);
                            TocarBuzina(moto);
                        }
                    }

                    void TocarBuzina(Veiculo veiculo)
                    {
                        veiculo.Buzinar();
                    }*/

    Jogador jogador = new Jogador(100, 30);
    Inimigo inimigo = new Inimigo(100, 20);    

    void Combate(Jogador jog, Inimigo ini)
    {
        ini.vida -= jog.ataque;

        Debug.Log(ini.vida);
    }

    private void Start()
    {
        Combate(jogador, inimigo);
    }
}

public class Jogador
{
    //Atributos

    public int vida;
    public int ataque;

    //Funções (Metodos)

    public Jogador(int vida, int ataque)
    {
        this.ataque = ataque;
        this.vida = vida;
    }
}

public class Inimigo
{
    public int vida;
    public int ataque;

    public Inimigo(int vida, int ataque)
    {
        this.ataque = ataque;
        this.vida = vida;
    }
}

