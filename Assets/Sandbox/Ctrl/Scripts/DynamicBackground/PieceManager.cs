using System.Collections.Generic;
using UnityEngine;

public class PieceManager : MonoBehaviour
{
    [HideInInspector]
    public List<GameObject> pieceList;
    public int maxCount;
    [HideInInspector]
    public int count;
    void Awake()
    {
        count = 0;
        pieceList = new List<GameObject>();
    }

    public void AddPiece(GameObject next){
        pieceList.Add(next);
        count++;
    }

    public void RemovePiece(GameObject toRemove){
        pieceList.Remove(toRemove);
        count--;
    }
}
