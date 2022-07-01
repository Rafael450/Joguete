using UnityEngine;

public class Dados : MonoBehaviour
{
    void Awake(){
        GameObject[] others = GameObject.FindGameObjectsWithTag(gameObject.tag);

        if (others.Length > 1){
            foreach (GameObject g in others)
            {
                if (g == gameObject) Destroy(gameObject);
            }
        }
        else{
            DontDestroyOnLoad(gameObject);
        }
    }
    public Sprite avatar;
    public bool isPlayer;
}
