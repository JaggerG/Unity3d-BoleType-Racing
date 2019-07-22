using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
public class RequestManager : BaseManager
{
    public RequestManager(GameFacade facade) : base(facade) { }

    private Dictionary<ActionCode, BaseRequest> requestDict = new Dictionary<ActionCode, BaseRequest>();

    public override void OnInit()
    {
        base.OnInit();
//        Debug.LogWarning("RequestManagerInit");
    }
    public void AddRequest(ActionCode actionCode,BaseRequest request)
    {
        //修改
//        Debug.LogWarning("AddRequest");
//        Debug.LogWarning("----------------"+actionCode);
        requestDict.Add(actionCode, request);
    }
    public void RemoveRequest(ActionCode actionCode)
    {
        //修改
        requestDict.Remove(actionCode);
    }
    public void HandleReponse(ActionCode actionCode, string data)
    {
//            Debug.LogWarning("Handle");
//            Debug.LogWarning(data);
//            Debug.LogWarning("ActionCode----------HandleReponse----------"+actionCode);
//            Debug.LogWarning(requestDict+"--------request");
              Debug.LogWarning("HandleReponse");
            BaseRequest request = requestDict.TryGet<ActionCode, BaseRequest>(actionCode);
            if (request == null)
            {
                Debug.LogWarning("无法得到ActionCode[" + actionCode + "]对应的Request类");return;
            }
            request.OnResponse(data);
    }
}
