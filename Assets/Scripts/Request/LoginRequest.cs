using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;

public class LoginRequest : BaseRequest
{

    private LoginPanel loginPanel;
    public override void Start()
    {
        
        requestCode = RequestCode.User;
        actionCode = ActionCode.Login;
        loginPanel=GetComponent<LoginPanel>();
        //loginPanel = GetComponent<LoginPanel>();
        base.Start();
    }
    public void SendRequest(string username, string password)
    {
        string data = username + "," + password;
        base.SendRequest(data);
        
    }

    public override void OnResponse(string data)
    {
  
        string[] response = data.Split(',');
              
       if(response[0]=="1")
       {
           loginPanel.OnResponse(response[0],"登陆成功");
           int id = int.Parse(response[1]);
           string nickName = response[2];
           int exp = int.Parse(response[3]);
           int level = int.Parse(response[4]);
           UserData ud=new UserData(id,nickName,exp,level);
           facade.SetUserData(ud);
       }
       if(response[0]=="0")
       {
           loginPanel.OnResponse(response[0],response[1]);
       }
    }

}
