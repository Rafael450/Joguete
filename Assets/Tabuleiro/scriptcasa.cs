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
		if (player.GetComponent<Piece>() != null && player.GetComponent<Piece>().moves > 0) {
			movendo = jogadoresAqui.Count - 1;
			player.GetComponent<Piece>().moves--;
			if (GetComponent<bifurcacao>() != null) {GetComponent<bifurcacao>().Event(jogadoresAqui[movendo]);}
		} else if (player.GetComponent<Piece>() != null && player.GetComponent<Piece>().moves == 0) {
			for (int i = 0; i < jogadoresAqui.Count; i++) { 
				if (jogadoresAqui[i].tag != jogadoresAqui[jogadoresAqui.Count-1].tag) {
					jogadoresAqui[i].GetComponent<Piece>().moves = 1;
					jogadoresAqui[i].GetComponent<Piece>().playerSpawn.GetComponent<scriptcasa>().Chegou(jogadoresAqui[i]);
					jogadoresAqui.RemoveAt(i);
					i--;
				}
			}
		}
	}
    // Start is called before the first frame update
    void Start(){
        if (playerSpawn) {
			Chegou(playerSpawn);
			playerSpawn.transform.position = transform.position + new Vector3(0,0,playerSpawn.transform.position.z-transform.position.z);
			playerSpawn.GetComponent<Piece>().playerSpawn = gameObject;
		}
		if (proximo) {
			if (proximo.GetComponent<scriptcasa>()) {proximo.GetComponent<scriptcasa>().anterior = gameObject;}
		}
    }

    // Update is called once per frame
    void Update()
    {
		// Teste de movimento
        if (jogadoresAqui.Count > 0 && jogadoresAqui[0].GetComponent<Piece>() != null && jogadoresAqui[0].GetComponent<Piece>().moves > 0) {
			movendo = 0;
			//while (not)
			if (GetComponent<bifurcacao>() != null) {GetComponent<bifurcacao>().Event(jogadoresAqui[movendo]);}
			jogadoresAqui[0].GetComponent<Piece>().moves--;

		} else {
			if(movendo >= 0) {
				Vector3 desl = proximo.transform.position - jogadoresAqui[movendo].transform.position;
				desl = new Vector3(desl.x,desl.y,0);
				if (proximo.GetComponent<geraLinha>() != null) {
					//gerador de linha não fez o trabalho dele
					proximo = proximo.GetComponent<geraLinha>().filhos[0];
				}
				
				if (desl.magnitude > velocidade*Time.deltaTime) {
					jogadoresAqui[movendo].transform.position += desl*velocidade*Time.deltaTime/desl.magnitude;
				} else  {
					jogadoresAqui[movendo].transform.position += desl;
					proximo.GetComponent<scriptcasa>().Chegou(jogadoresAqui[movendo]);
					jogadoresAqui.RemoveAt(movendo);
					movendo = -1;
				}
			}
		}
    }
	
	public void debugmovStart(int index) {movendo = index;}
	
}
