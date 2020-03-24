using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawnManager : MonoBehaviour
{
	public GameObject spherePrefab;
	public Transform sphereParent;
	public int spawnAmount = 5;

	private void Start()
	{
		SpawnSpheres();
	}

	public void SpawnSpheres()
	{
		//Executar n repetições conforme o valor de "spawnAmount"
		for (int i = 0; i < spawnAmount; i++)
		{
			//Intanciar o prefab da esfera
			var sphere = Instantiate(spherePrefab, sphereParent);
			//Alterar a posição da esfera, recebendo valores aleatorios para X e Z
			sphere.transform.position = RandomPosition(23, 20);
		}
	}	

	private Vector3 RandomPosition(float xValue, float zValue)
	{
		Vector3 randomPos;
		//Sorteia um número aleatório entre o intervalo determinado pelo valor de xValue
		//Ou seja [-xValue, xValue]
		float x = Random.Range(xValue * -1, xValue);
		//Mesma coisa com zValue
		float z = Random.Range(zValue * -1, zValue);
		//Atribui os valores sorteados ao Vector
		randomPos = new Vector3(x , 0 , z);
		//Retornamos o Vector3
		return randomPos;
	}
}
