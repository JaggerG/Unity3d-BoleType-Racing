using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class GameOverRequest : BaseRequest
{
    public override void Start()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.GameOver;
        base.Start();
    }

    public void SendRequest(string data)
    {
        data = "0";
        base.SendRequest(data);
    }

    public override void OnResponse(string data)
    {
        
        //facade.GameOverMsg(data);
    }
}
