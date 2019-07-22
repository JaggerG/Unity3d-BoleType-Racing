using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;

public class VerifyCodeRequest :BaseRequest
{
    private RegisterPanel VerifyCode;
    public override void Start()
    {
        requestCode = RequestCode.User;
        actionCode = ActionCode.VerifyCode;
        VerifyCode = GetComponent<RegisterPanel>();
        base.Start();
    }

    public void SendRequest(string phoneNum)
    {
        string data = "+'phone':'" + phoneNum + "'-";
        base.SendRequest(data);
    }

    public override void OnResponse(string data)
    {
        
        if (data=="1")
        {
            VerifyCode.GetVerifyCode();
        }
        
    }
}
