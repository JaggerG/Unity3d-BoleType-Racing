using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class CreatRoomRequest : BaseRequest
{
    private RoomPanel roomPanel;

    public override void Start()
    {
        requestCode = RequestCode.Room;
        actionCode = ActionCode.CreateRoom;
        roomPanel = GetComponent<RoomPanel>();
        base.Start();
    }

    public void SendRequest(String name)
    {
        //data:状态码（1成功，0失败),房间号
        string data = name;

        base.SendRequest(data);
    }

    public override void OnResponse(string data)
    {
        string[] response = data.Split(',');
        Debug.Log("createRoomResponse------>>"+data);
        Debug.Log(response[0]);
        if(response[0]=="1")
            roomPanel.OnCreatRoomResponse();
    }
}
