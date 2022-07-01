using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Piece : MonoBehaviour 
{
    Turnos turnos;
    bool exited = false;
    public string time;
    public GameObject owner;
    public GameObject playerSpawn;
    public int moves = 0;

    void Start()
    {
        turnos = GameObject.FindWithTag("Turnos").GetComponent<Turnos>();
        owner = GameObject.FindWithTag(time);
        gameObject.GetComponent<SpriteRenderer>().sprite = owner.GetComponent<Dados>().avatar;
    }

    void ChoosePiece()
    {
        print(time+1);
        if(turnos.dieResult != 0 && owner.tag == turnos.player.tag && exited)
        {
            moves = turnos.dieResult;
            turnos.dieResult = 0;
            // turnos.NextPlayer();
        }
        else if(turnos.dieResult == 6 && owner.tag == turnos.player.tag && !exited)
        {
            exited = true;
            moves = 1;
            // turnos.NextPlayer();
        }
    }

    void OnMouseDown()
    {
        ChoosePiece();
    }

}
