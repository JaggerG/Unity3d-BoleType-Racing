using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineCollider : MonoBehaviour
{
    // Start is called before the first frame update

   
    
    private FinishGameRequest finishGameRequest;

    private void  Start()
    {
        finishGameRequest = GetComponent<FinishGameRequest>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="localPlayer")
        {
           // Debug.Log("beginFinished------------>");
            finishGameRequest.SendRequest("0");
        }
    }
}
