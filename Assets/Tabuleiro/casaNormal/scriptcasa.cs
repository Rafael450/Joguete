using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptcasa : MonoBehaviour
{
	public GameObject proximo;
	public GameObject anterior;
	public GameObject playerSpawn;
	public float velocidade = 1.0f;								//unidades por segundo
	List<GameObject> jogadoresAqui = new List<GameObject>();
	int movendo = -1;
	public void Chegou(GameObject player) {
		//print("chegou ok");
		jogadoresAqui.Add(player);
	}
    // Start is called before the first frame update
    void Start(){
        if (playerSpawn) {
			Chegou(playerSpawn);
			playerSpawn.transform.position = transform.position;
		}
		if (proximo) {proximo.GetComponent<scriptcasa>().anterior = gameObject;}
    }

    // Update is called once per frame
    void Update()
    {
		// Isso aqui é só pra testar, depois remover
        if (Input.GetKeyDown("space") && jogadoresAqui.Count > 0) {
			movendo = 0;
		}
		// Fim da parte pra remover
        if(movendo >= 0) {
			Vector3 desl = proximo.transform.position - jogadoresAqui[movendo].transform.position;
			desl = new Vector3(desl.x,desl.y,0);
			if (desl.magnitude > velocidade*Time.deltaTime) {
				jogadoresAqui[movendo].transform.position += desl*velocidade*Time.deltaTime/desl.magnitude;
			} else {
				jogadoresAqui[movendo].transform.position += desl;
				proximo.GetComponent<scriptcasa>().Chegou(jogadoresAqui[movendo]);
				jogadoresAqui.RemoveAt(movendo);
				movendo = -1;
			}
		}
    }
	
	public void debugmovStart(int index) {movendo = index;}
	
}
