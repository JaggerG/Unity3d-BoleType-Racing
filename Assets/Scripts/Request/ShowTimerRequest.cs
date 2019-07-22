using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class ShowTimerRequest : BaseRequest
{
    public override void Start()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.ShowTimer;
        base.Start();
    }

    public void SendRequest(string type,string counter)
    {
        string data =type+","+counter;
        base.SendRequest(data);
    }
    public override void OnResponse(string data)
    {
        string[] response = data.Split(',');
        if (response[0] == "1")
        {
            //开始游戏   
        }
        if (response[0] == "2")
        {
            facade.showTime(response[1]);

        }
    }
}
