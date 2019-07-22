using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCollider : MonoBehaviour
{
    // Start is called before the first frame update

   
    private GameOverRequest gameOverRequest;

    private void  Start()
    {
        gameOverRequest = GetComponent<GameOverRequest>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player1(Clone)"||other.gameObject.name=="Player2(Clone)")
        {
            //gameOver;
           
            //Debug.Log("-------------------gameOver-----------------------");
        }
    }
}
