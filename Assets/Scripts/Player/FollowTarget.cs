using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;
    private float smoothing = 2;

    private void Start()
    {
        offset = gameObject.GetComponent<Transform>().position - target.position;
    }
    // Update is called once per frame
    void Update () {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
       // transform.LookAt(target);
    }
}