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
        players.Add(GameObject.FindWithTag("Blue"));
        players.Add(GameObject.FindWithTag("Red"));
        players.Add(GameObject.FindWithTag("Black"));
        players.Add(GameObject.FindWithTag("Yellow"));
        player = players[0];
        gameObject.GetComponent<SpriteRenderer>().sprite = player.GetComponent<Dados>().avatar;
        gameObject.GetComponent<SpriteRenderer>().color = ReturnColor(playerIndex);
        dieScript = GameObject.Find("Die").GetComponent<Die>();
    }

    private Color ReturnColor(int player_)
    {
        if(player_ == 0) return new Color(83f/255f, 157f/255f, 255f/255f, 1);
        else if(player_ == 1) return new Color(255f/255f, 111f/255f, 83f/255f, 1);
        else if(player_ == 2) return new Color(101f/255f, 101f/255f, 101f/255f, 1);
        else return new Color(245f/255f, 255f/255f, 83f/255f, 1);
    }

    public void NextPlayer()
    {
        playerIndex++;
        if (playerIndex >= players.Count)
        {
            playerIndex = 0;
        }
        player = players[playerIndex];
        gameObject.GetComponent<SpriteRenderer>().sprite = player.GetComponent<Dados>().avatar;
        gameObject.GetComponent<SpriteRenderer>().color = ReturnColor(playerIndex);
        print(gameObject.GetComponent<SpriteRenderer>().color);

    }

    public int RollDie()
    {
        dieResult = Random.Range(1, 7);
        NextPlayer();
        return dieResult;
    }


}
