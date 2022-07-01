using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public Animator MenuScreen;
    public Animator SelectionScreen;

    public void Sair(){
        Application.Quit();
    }

    public void Creditos(){
        SceneManager.LoadScene("Creditos");
    }

    public void Selecao(){
       // Tirar a tela de St   art e ir pra de seleção
        MenuScreen.SetBool("ativo", false);
        SelectionScreen.SetBool("ativo", true);
    }

    public void Jogar(){
        SceneManager.LoadScene("tabuleiro");
    }

    public void Voltar(){
        MenuScreen.SetBool("ativo", true);
        SelectionScreen.SetBool("ativo", false);

    }
}
