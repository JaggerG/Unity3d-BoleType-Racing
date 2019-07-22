using System.Collections;
using System.Collections.Generic;
using Common;
using DG.Tweening;
using UnityEngine;
using UnityEngineInternal;

public class MoveRequest : BaseRequest
{

    private Transform localPlayerTransform;
    private Transform remotePlayerTransform;
    private int syncRate = 25;

    private bool isSyncRemotePlayer = false;
    private Vector3 pos;
    
    
   
    
    public void Start()
    {
        requestCode = RequestCode.Game;
        actionCode = ActionCode.Move;
        base.Start();
        
        InvokeRepeating("SyncLocalPlayer",1 ,1f/syncRate);
    }
    void FixedUpdate()
    {
        if (isSyncRemotePlayer)
        {
            SyncRemotePlayer();
            isSyncRemotePlayer = false;
        }
    }
    
  
    
    
    public void SendRequest(float x, float y, float z)
    {
        string data = string.Format("{0},{1},{2}", x, y, z);
        base.SendRequest(data);
    }

    public MoveRequest SetLocalPlayer(Transform localPlayerTransform)
    {
        this.localPlayerTransform = localPlayerTransform;
        return this;
    }

    public MoveRequest SetRemotePlayer(Transform remotePlayerTransform)
    {
        this.remotePlayerTransform = remotePlayerTransform;
        return this;
    }
    private void SyncRemotePlayer()
    {
        remotePlayerTransform.position = pos;
       // Debug.Log("-------------sync Remote------->>>>>----"+remotePlayerTransform.position);
    }
    private void SyncLocalPlayer()
    {
        SendRequest(localPlayerTransform.position.x,localPlayerTransform.position.y,localPlayerTransform.position.z);
    }
    public override void OnResponse(string data)
    {
        //Debug.Log("----------------moveResponse--->>>>--------");
        pos = Parse(data);
        isSyncRemotePlayer = true;
    }

    private Vector3 Parse(string str)
    {
        string[] strs = str.Split(',');
        float x = float.Parse(strs[0]);
        float y = float.Parse(strs[1]);
        float z = float.Parse(strs[2]);
        return new Vector3(x, y, z);
    }
}
