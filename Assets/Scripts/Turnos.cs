using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turnos : MonoBehaviour
{
    int playerIndex = 0;
    public GameObject player;
    public Die dieScript;
    public List<GameObject> players = new List<GameObject>();
    public int dieResult = 0;

    void Start()
    {
        dieScript = GameObject.Find("Die").GetComponent<Die>();
    }

    public void NextPlayer()
    {
        playerIndex++;
        if (playerIndex >= players.Count)
        {
            playerIndex = 0;
        }
        player = players[playerIndex];
    }

    public void RollDie()
    {
        dieResult = Random.Range(1, 7);
    }
}
