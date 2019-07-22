using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class HeartBeat :BaseRequest
{
    private HeartBeat heartBeatRequest;
    public override void Start()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.HeartBeat;
        heartBeatRequest = GetComponent<HeartBeat>();
        
        base.Start();
    }

    public void SendRequest(string data)
    {
        base.SendRequest(data);
    }
    public override void OnResponse(string data)
    {
        Debug.Log(data);
        heartBeatRequest.SendRequest("hello");
    }
}
