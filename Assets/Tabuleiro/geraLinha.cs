using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geraLinha : MonoBehaviour
{
	public GameObject template;
	public int quantidade = 1;
	public Vector3 deslocamento;
	public GameObject anterior;
	public GameObject seguinte;
	public List<GameObject> filhos = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
		GameObject curr;
		GameObject prev = anterior;
        for (float i = 0; i < quantidade; i++) {
			curr = Instantiate(template,transform.position + deslocamento*i,Quaternion.identity,transform);
			filhos.Add(curr);
			curr.GetComponent<scriptcasa>().anterior = prev;
			if (prev.GetComponent<scriptcasa>() != null) {
				prev.GetComponent<scriptcasa>().proximo = curr;
			} else {
				prev.GetComponent<geraLinha>().seguinte = curr;
			}
			prev = curr;
		}
		prev.GetComponent<scriptcasa>().proximo = seguinte;
		if (seguinte.GetComponent<scriptcasa>() != null) {
			seguinte.GetComponent<scriptcasa>().anterior = prev;
		} else {
			seguinte.GetComponent<geraLinha>().anterior = prev;
		}
		
		if (anterior.GetComponent<bifurcacao>() != null) {
			bifurcacao antes = anterior.GetComponent<bifurcacao>();
			if (antes.prox == gameObject) {
				antes.prox = filhos[0];
			}
			if (antes.proxTime == gameObject) {
				antes.proxTime = filhos[0];
			}
		}
    }

    /* Update is called once per frame
    void Update()
    {
        
    }*/
}
