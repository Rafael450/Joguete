using UnityEngine;

public class PositioningManager : MonoBehaviour
{
    //IMPORTANT: CELL SIZE MUST MATCH WITH PIECE STEP LENGTH
    public float gridCellSize;
    public float maxDistance;
    public Vector3 ChooseRandomPosition(){
        //We must return a position inside the rectangular grid
        int maxCoord = (int) (maxDistance/gridCellSize);
        Vector3 position = gridCellSize * new Vector3(Random.Range(0, maxCoord+1),Random.Range(0,maxCoord+1),0);
        return position;
    }
}
