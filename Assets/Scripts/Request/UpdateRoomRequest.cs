using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
public class UpdateRoomRequest : BaseRequest
{
    private VSPanel vsPanel;
    public override void Start()
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.UpdateRoom;
        vsPanel = GetComponent<VSPanel>();
        Debug.Log("updateRoomTothe ActonCode");
        base.Start();
    }

    public override void OnResponse(string data)
    {
        string[] response = data.Split(',');
        UserData ud1 = null;
        UserData ud2 = null;
        ud1=new UserData(response[1]);
        ud2=new UserData(response[2]);
         
       vsPanel.SetAllPlayerResSync(ud1,ud2);
    }
}
