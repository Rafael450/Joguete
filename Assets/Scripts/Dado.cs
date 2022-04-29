using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dado : MonoBehaviour 
{
    //ESSE CÓDIGO É UM PROTÓTIPO

    private TMP_Text changer;
    public int resultado = 1;
    public GameObject textodado;

    void Start()
    {
        changer = textodado.GetComponent<TextMeshProUGUI>();
    }

    public void DadoThrower()
    {
        resultado = Random.Range(1, 7);
        changer.text = resultado.ToString();      
    }
}
