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

    public void SendRequest(string time,string speed)
    {
        Debug.Log("result----------------"+time+"--------"+speed);
        string data = "+";
        data += "'time':'" + time + "',";
        data += "'speed':'" + speed + "'-";
        base.SendRequest(data);
    }

    public override void OnResponse(string data)
    {
        
        //facade.GameOverMsg(data);
        facade.SetGameOverPanel(data);
        Debug.Log(data);
    }
}
