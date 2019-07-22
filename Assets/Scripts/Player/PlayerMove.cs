using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    


    public void MoveTheCar()
    {
        this.GetComponent<Rigidbody>().AddForce(50,0,0,ForceMode.Force);
    }
}
