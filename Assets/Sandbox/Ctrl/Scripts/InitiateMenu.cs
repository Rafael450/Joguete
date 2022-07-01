using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitiateMenu : MonoBehaviour
{
    public Animator FachadaNimator;
    public Animator Botao1;
    public Animator Botao2;
    public Animator Botao3;
    public Animator Background;
    void Start()
    {
        StartCoroutine(FirstAnimation());
    }

    private IEnumerator FirstAnimation(){
        yield return new WaitForSeconds(1f);
        FachadaNimator.SetTrigger("daleMeuNobre"); //Primeiro a fachada
        yield return new WaitForSeconds(1f);
        Botao1.SetTrigger("go");
        Botao2.SetTrigger("go");
        Botao3.SetTrigger("go"); //Os 3 botoes agora
        yield return new WaitForSeconds(0.6f);

        //Background aparece
        Background.SetTrigger("disappear");
        yield return new WaitForSeconds(3f);
        Destroy(Background.gameObject);
        
    }
}
