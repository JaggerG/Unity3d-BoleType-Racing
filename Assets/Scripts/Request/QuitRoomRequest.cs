using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
public class QuitRoomRequest : BaseRequest
{

    private VSPanel vsPanel;
    public override void Start()
    {
        
        requestCode = RequestCode.Room;
        actionCode = ActionCode.QuitRoom;
        vsPanel = GetComponent<VSPanel>();
        base.Start();
    }

    public void SendRequest(string data)
    {
        base.SendRequest(data);  
    }
    
    public override void OnResponse(string data)
    {
        
        //房间解散
        if (data == "2")
        {
            //TODO解散房间
            vsPanel.OnExitRoomResponse();
            return;
        }

        string[] response = data.Split(',');
        if (response[0]== "1")
        {
            
            UserData ud1 = null;
            UserData ud2 = null;
            ud1=new UserData(response[1]);
            vsPanel.SetAllPlayerResSync(ud1,ud2);
        }
    }
}
