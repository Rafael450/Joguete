using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieceMovements : MonoBehaviour
{
    [HideInInspector]
    public Spawn spawnFunctions;
    [HideInInspector]
    public PieceManager manager;
    public GameObject prefab;
    public float distancePerStep;
    private float timeCounter;
    public Animator anim;
    public float radius;
    private bool marked2die = false;
    void Start(){
        GameObject aux = GameObject.Find("DynamicBackgroundManager");
        spawnFunctions = aux.GetComponent<Spawn>();
        manager = aux.GetComponent<PieceManager>();
        StartCoroutine(MovingProtocol());
    }

    private void Move(){
        //Choose one direction between the 8 available (0, 45, 90, 135, ..., 315)
        int dirAux = Random.Range(0,8);
        /*Listen, maybe I should make a way the pieces stay in the middle with
        higher probability, I might do it later*/

        Vector3 direction = Quaternion.AngleAxis(45*dirAux, Vector3.forward) * Vector3.right; //Rotates unitary vector to define direction
        if (dirAux%2 == 0)StartCoroutine(MoveSlowly(direction));
        else StartCoroutine(MoveSlowly(direction * Mathf.Sqrt(2))); //Diagonal if 45, 135, ...
        //If there is another dude in the spot, KILL IT (I will do it via trigger maybe)
    }

    private IEnumerator MoveSlowly(Vector3 dir){
        //Lets split the movement in 10 small steps
        int i;
        for (i=0; i < 10; i++){
            transform.position += 0.1f * distancePerStep * dir;
            yield return new WaitForSeconds(.05f);
        }
        StartCoroutine(MovingProtocol());
    }
    private IEnumerator MovingProtocol(){
        float time = Random.Range(0.7f,3.5f);
        yield return new WaitForSeconds(time);
        Move();
    }

    void CollisionCheck(){
        float distance;
        Vector3 boundCheck;
        boundCheck = transform.position;
        if (boundCheck.x > spawnFunctions.maxDistance || boundCheck.x < -spawnFunctions.maxDistance || boundCheck.y > spawnFunctions.maxDistance || boundCheck.y < -spawnFunctions.maxDistance){
            marked2die = true;
            gameObject.GetComponent<SpriteRenderer>().sortingOrder=1;
            spawnFunctions.DestroyPiece(gameObject);
        }
        
        else{
            foreach (GameObject target in manager.pieceList){
            if (target == gameObject) continue;
            distance = (transform.position - target.transform.position).magnitude;
            if (distance < 2*radius){
                marked2die = true;
                gameObject.GetComponent<SpriteRenderer>().sortingOrder=1;
                spawnFunctions.DestroyPiece(gameObject);
                break;
            }
        }
        }
    }

    void Update(){
        if (!marked2die) CollisionCheck();
    }
    
}
