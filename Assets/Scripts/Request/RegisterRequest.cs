using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class RegisterRequest : BaseRequest
{
    private RegisterPanel registerPanel;
    public override void Start()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.Register;
        registerPanel = GetComponent<RegisterPanel>();
        base.Start();
    }

    public void SendRequest(string phoneNum, string password, string verifyCode)
    {
        string data = "+'phone':'" + phoneNum + "','passWord':'" + password + "','verifyCode':'" + verifyCode + "'-";
        base.SendRequest(data);
    }

    public override void OnResponse(string data)
    {
        string[] str = data.Split(',');
        if (str[0] == "1")
        {
            registerPanel.OnResponsePanel("注册成功");
        }

        if (str[0] == "0")
        {
            registerPanel.OnResponsePanel(str[1]);
        }
    }
}
