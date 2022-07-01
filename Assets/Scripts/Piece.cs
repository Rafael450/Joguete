using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Piece : MonoBehaviour 
{

    Turnos turnos;
    public string time;
    public int moves = 0;

    void Start()
    {
        turnos = GameObject.FindWithTag("Turnos").GetComponent<Turnos>();
    }

    void ChoosePiece()
    {
        if(turnos.dieResult != 0 && owner.tag == turnos.player.tag)
        {
            moves = turnos.dieResult;
            turnos.dieResult = 0;
            turnos.NextPlayer();
        }
    }

}
