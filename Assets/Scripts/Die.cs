using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    Turnos turnos;
    public Sprite[] dieSprites;
    public Sprite currentSprite;

    void Start()
    {
        turnos = GameObject.FindWithTag("Turnos").GetComponent<Turnos>();
        currentSprite = dieSprites[0];
        GetComponent<SpriteRenderer>().sprite = currentSprite;
    }

    // void dieAnimation(int frame, float time)
    // {
    //     if(time >= 0.1f && frame < 10)
    //     {
    //         time = 0;
    //         currentSprite = dieSprites[Random.Range(1, dieSprites.Length)];
    //         GetComponent<SpriteRenderer>().sprite = currentSprite;
    //         frame++;
    //         time += Time.deltaTime;
    //         dieAnimation(frame, time);
    //     }
    // }

    public void Throw()
    {
        int result = turnos.RollDie();
        print(result);
        // dieAnimation(0, 0);
        currentSprite = dieSprites[result];
        GetComponent<SpriteRenderer>().sprite = currentSprite;
    }

    private void OnMouseDown()
    {
        Throw();
        // if (Input.GetMouseButtonDown(0))
        // {
        //     RaycastHit hit;
        //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //     if (Physics.Raycast(ray, out hit, 100.0f))
        //     {
        //         if (hit.transform != null)
        //         {
                    
        //         }
        //     }
        // }
    }


}
