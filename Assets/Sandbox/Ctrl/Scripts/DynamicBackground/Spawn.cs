using System.Collections;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public PieceManager manager;
    public GameObject prefab;
    public int initialQuant;

    //IMPORTANT: CELL SIZE MUST MATCH WITH PIECE STEP LENGTH
    public float gridCellSize;
    public float maxDistance;

    void Start(){
        int i;
        for (i = 0; i < initialQuant; i++){
            SpawnPiece(ChooseRandomPosition());
        }
    }
    private Vector3 ChooseRandomPosition(){
        //We must return a position inside the rectangular grid
        int maxCoord = (int) (maxDistance/gridCellSize);
        Vector3 position = gridCellSize * new Vector3(Random.Range(-maxCoord, maxCoord+1),Random.Range(-maxCoord,maxCoord+1),0);
        return position;
    }

    public void SpawnPiece(Vector3 position){
        GlobalParameters global = GameObject.Find("GlobalValues").GetComponent<GlobalParameters>();
        Color newColor = global.mainColors[Random.Range(0,4)];
        Sprite template = global.allTemplates[Random.Range(0,6)];
        //Radial spawning for easy testing
        GameObject next = Instantiate(prefab, position, Quaternion.identity);
        next.GetComponent<SpriteRenderer>().color = newColor;
        next.GetComponent<SpriteRenderer>().sprite = template;
        manager.AddPiece(next);
    }

    public void DestroyPiece(GameObject piece){
        piece.GetComponent<Animator>().SetBool("die", true);
        //Dequeue for no more checks and destroy
        manager.RemovePiece(piece);
        Destroy(piece, 1);
        //WAIT A BIT TO SPAWN THE NEXT, ELSE UNITY WILL CERTAINLY CRASH
        StartCoroutine(SpawnSon());
    }
    private IEnumerator SpawnSon(){
        yield return new WaitForSeconds(1.1f);
        if (manager.count < manager.maxCount) SpawnPiece(ChooseRandomPosition());
    }
}
