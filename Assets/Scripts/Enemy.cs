using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager game;

    private Transform playerPosition;

    private void Start()
    {
        playerPosition = game.player;
    }
}
