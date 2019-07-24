using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Common;
using UnityEngine;
using Common;
public class PlayerManager : BaseManager
{
    private UserData _userData;
    private GameObject LocalPlayer;
    private GameObject RemotePlayer;
    private GameObject playerSyncRequest;
    private Transform playerPositions;
    private RoleType currentRoleType;
    private GameObject currentRoleGameObject;
    private GameObject remoteRoleGameObject;

    public void SetCurrentRoleType(int rt)
    {
        currentRoleType = (RoleType) rt;
    }
    public PlayerManager(GameFacade facade):base(facade){}

    public UserData userData
    {
        set{
            _userData = value;
        }
        get { return _userData; }
    }
    
    private Dictionary<RoleType,RoleData> roleDataDict =new Dictionary<RoleType, RoleData>(); 

    public void setPlayer(GameObject localPlayer,GameObject remotePlayer)
    {
        Debug.LogWarning("------------manager-------------------GetPlayer---------------------");
      
        this.LocalPlayer = localPlayer;
        this.RemotePlayer = remotePlayer;
    }

    private void InitRoleDataDict()
    {
        
       // Debug.Log("--------"+playerPositions.Find("Player1Pos").position);
        roleDataDict.Add(RoleType.Blue,new RoleData(RoleType.Blue,"Player1",new Vector3(130.7f,3.25f,-100f)));
        roleDataDict.Add(RoleType.Red,new RoleData(RoleType.Red,"Player2",new Vector3(127.93f,3.25f,-100f)));

    }

    public override void OnInit()
    {
        playerPositions = GameObject.Find("PlayerPosition").transform;
        InitRoleDataDict(); 
    }

    public void CreateSyncRequest()
    {
        
       // Debug.Log("-------current---------------->>>>>"+currentRoleGameObject.transform.position);
        
       // Debug.Log("-------remote---------------->>>>>"+remoteRoleGameObject.transform.position);
        playerSyncRequest=new GameObject("PlayerSyncRequest");
        playerSyncRequest.AddComponent<MoveRequest>().SetLocalPlayer(currentRoleGameObject.transform)
            .SetRemotePlayer(remoteRoleGameObject.transform);
    }

    public void SpawnRoles()
    {
        
        //TODO多人游戏的时候逻辑可能要重写
        foreach(RoleData rd in roleDataDict.Values)
        {
            GameObject go=GameObject.Instantiate(rd.RolePrefab , rd.SpawnPosition, Quaternion.identity);
            if (rd.RoleType == currentRoleType)
            {
                currentRoleGameObject = go;
                currentRoleGameObject.tag = "localPlayer";

            }
            else
            {
                remoteRoleGameObject = go;
            }
                
        }
    }

    public GameObject GetCurrentRoleGameObject()
    {
        return currentRoleGameObject;
    }


    public void AddControllScript()
    {
       
        //currentRoleGameObject.AddComponent<GameManager>();
    }

    public void GameOver()
    {
        //currentRoleGameObject.GetComponent<MoveRequest>().enabled = false;
        //currentRoleGameObject.GetComponent<MoveRequest>().GameOver();
        GameObject.Destroy(currentRoleGameObject);
        GameObject.Destroy(playerSyncRequest);
        GameObject.Destroy(remoteRoleGameObject);
        
    }

    
}
