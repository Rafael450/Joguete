using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bifurcacao : MonoBehaviour
{
	public string time;
	public GameObject prox;
	public GameObject proxTime;
	
	public void Event(GameObject fulano) {
		if (fulano.tag == time) {GetComponent<scriptcasa>().proximo = proxTime;}
		else {GetComponent<scriptcasa>().proximo = prox;}
	}
    /* Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/
}
