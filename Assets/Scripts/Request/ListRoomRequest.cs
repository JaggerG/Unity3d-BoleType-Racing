using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class ListRoomRequest : BaseRequest
{
    private RoomPanel roomPanel;
    public override void Start()
    {
        
        requestCode = RequestCode.Room;
        actionCode = ActionCode.ListRoom;
        roomPanel = GetComponent<RoomPanel>();
        base.Start();
    }

    public void SendRequest()
    {
        string data = "0";
        requestCode = RequestCode.Room;
        actionCode = ActionCode.ListRoom;
        roomPanel = GetComponent<RoomPanel>();
        Debug.Log("ListRoomRequest-----requestCode-------->"+requestCode+"-----actionCode---"+actionCode);
        base.SendRequest(data);

    }

    public override void OnResponse(string data)
    {
        //data:状态码(1成功，0失败)，房间名，房间人数，房间号

        if (data == "0")
        {
            roomPanel.ClearList();
            return;
        }
        
        
        List<UserData> udList = new List<UserData>();
        
      
        
        string[] response = data.Split('|');
          
        
        if (response[0] != "0")
        {
          
            string[] udArray = response[1].Split('/');
            if (udArray.Length == 2)
            {
                Debug.Log("-----------fuck-------"+udArray[0]);
                string[] strs = udArray[0].Split(',');
                udList.Add(new UserData(strs[0],int.Parse(strs[2])));
            }
            else
            {
                foreach (string ud in udArray)
                {

                    string[] strs = ud.Split(',');
                    udList.Add(new UserData(strs[0], int.Parse(strs[2])));
                }
            }
        }
        
        
        Debug.Log("-----------SetUdList--------");
        roomPanel.LoadRoomItemSync(udList);
        Debug.Log("-----------SetUdList11111--------");

    }

    
}
