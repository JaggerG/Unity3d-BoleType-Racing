using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using UnityEngine.Rendering;

public class JoinRequest :BaseRequest
{
   private RoomPanel roomPanel
      ;
   public override void Start()
   {

      roomPanel = GetComponent<RoomPanel>();
      requestCode = RequestCode.Room;
      actionCode = ActionCode.JoinRoom;
      base.Start();
   }

   public void SendRequest(string RoomId)
   {
      
      //data:状态码(0成功，1失败),玩家名字
      string data = "+'RoomId':'"+RoomId+"'-";
      base.SendRequest(data);
   }

   public override void OnResponse(string data)
   {
      string[] response = data.Split(',');
      UserData ud1 = null;
      UserData ud2 = null;
      if (response[0] == "0")
      {
         return;
      }
      
      if (response[0] == "1")
      {
         ud1=new UserData(response[1]);
         ud2=new UserData(response[2]);
         
      }
      
      roomPanel.OnJoinResponse(ud1,ud2);
      
      
   }
}
