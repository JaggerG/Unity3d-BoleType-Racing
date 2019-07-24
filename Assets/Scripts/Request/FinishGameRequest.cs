using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class FinishGameRequest :BaseRequest
{
    public override void Start()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.FinishGame;
        base.Start();
    }

    public void SendRequest(string data)
    {
        facade.finishStopTime();
        
        base.SendRequest(data);
    }

    public override void OnResponse(string data)
    {

        facade.showResult(data);
    }
}
