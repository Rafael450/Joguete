using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Piece : MonoBehaviour 
{
    Turnos turnos;
    Sprite sprite_;
    bool exited = false;
    public string time;
    public GameObject owner;
    public int moves = 0;

    void Start()
    {
        turnos = GameObject.FindWithTag("Turnos").GetComponent<Turnos>();
        owner = GameObject.FindWithTag(time);
        // sprite_ = owner.GetComponent<Script>().sprite;
    }

    void ChoosePiece()
    {
        if(turnos.dieResult != 0 && time == turnos.player.tag && exited)
        {
            moves = turnos.dieResult;
            turnos.dieResult = 0;
            turnos.NextPlayer();
        }
        else if(turnos.dieResult == 6 && time == turnos.player.tag && !exited)
        {
            exited = true;
            moves = 1;
        }
    }

}
