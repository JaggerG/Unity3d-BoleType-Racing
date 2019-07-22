using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
public class StartGameRequest : BaseRequest
{

    //private VSPanel vsPanel;
    public override void Start()
    {
     
        requestCode = RequestCode.Game;
        actionCode = ActionCode.StartGame;
       // vsPanel = GetComponent<VSPanel>();
        base.Start();
    }

    public void SendRequest()
    {
        base.SendRequest("0");
    }


   
    public override void OnResponse(string data)
    {
        Debug.Log("-----------data-----startGame------color----------"+data);
        Debug.Log("startPlayOnResponse");        
        int RoleType = Int32.Parse(data);
        facade.EnterPlayingSync();
        facade.SetCurrentRoleType(RoleType);
        
    }
}
