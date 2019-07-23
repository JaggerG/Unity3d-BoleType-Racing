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
        
        Debug.Log("------------FinishResponse----"+data);
        if (data == "1")
        {
            //TODO胜利同步时间
            facade.showTimer();
        }

        if (data == "2")
        {
            //TODO开始结束游戏  
        }
    }
}
