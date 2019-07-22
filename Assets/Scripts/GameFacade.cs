using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Common;
public class GameFacade : MonoBehaviour
{

    public GameObject gameMng;
    private static GameFacade _instance;
    public static GameFacade Instance { get {
            if (_instance == null)
            {
                _instance = GameObject.Find("GameFacade").GetComponent<GameFacade>();
            }
            return _instance;
        } }

    //public GameObject test;
   
    private RequestManager requestMng;
    private ClientManager clientMng;
    private PlayerManager playerMng;
    private PropManager propMng;
    private UIManager uiMng;
    private CameraManager cameraMng;

    private bool isGameMsg = false;
    private bool isEnterPlaying = false;
    private bool isEnterGameCamera = false;
    private bool isShowTimer = false;
    private bool isShowTime = false;
    private bool isWiner = false;
    private bool isUpdate = false;
    private string times = "";
    private string gameovermsg= "";
    //private UserData _userData;
    
//    public UserData Udata
//    {
//        set{
//            _userData = value;
//        }
//        get { return _userData; }
//    }

    //private void Awake()
    //{
    //    if (_instance != null)
    //    {
    //        Destroy(this.gameObject);return;
    //    }
    //    _instance = this;
    //}

    // Use this for initialization
    void Awake () {
        InitManager();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateManager();
        if (isEnterPlaying)
        {
            EnterPlaying();
            
            
            isEnterPlaying = false;  
        }

        if (isEnterGameCamera)
        {
//            Debug.Log("---------------EnterGameCamera");
            cameraMng.EnterGame();
            gameMng.GetComponent<GameManager>().BeginGame();
            isEnterGameCamera = false;
        }

        if (isGameMsg)
        {
            uiMng.ShowMessage(gameovermsg);
            isGameMsg = false;
        }

        if (isShowTimer)
        {
            StartCoroutine(GameOverCount());
            isShowTimer = false;
        }

        if (isShowTime)
        {
            gameMng.GetComponent<GameManager>().showTime(times);
            isShowTime = false;
        }

        if (isUpdate)
        {
            UpdateScore();
            isUpdate = false;
        }
	}
    
    private void OnDestroy()
    {
        DestroyManager();
    }

    private void InitManager()
    {
        
        requestMng = new RequestManager(this);
        clientMng = new ClientManager(this);
        playerMng=new PlayerManager(this);
        propMng= new PropManager(this);
        uiMng=new UIManager(this);
        cameraMng=new CameraManager(this);
       
        
      
        requestMng.OnInit();
        clientMng.OnInit();
        playerMng.OnInit();
        uiMng.OnInit();
        cameraMng.OnInit();
       

    }
    private void DestroyManager()
    {
       
        requestMng.OnDestroy();
        clientMng.OnDestroy();
        playerMng.OnDestroy();
        uiMng.OnDestroy();
        cameraMng.OnDestroy();
     
    }
    private void UpdateManager()
    {
       
        requestMng.Update();
        clientMng.Update();
        playerMng.Update();
        uiMng.Update();
        cameraMng.Update();
      
    }

    public void AddRequest(ActionCode actionCode, BaseRequest request)
    {
        requestMng.AddRequest(actionCode, request);
    }

    public void RemoveRequest(ActionCode actionCode)
    {
        requestMng.RemoveRequest(actionCode);
    }
    public void HandleReponse(ActionCode actionCode, string data)
    {
       
       // Debug.LogWarning("Response");
        requestMng.HandleReponse(actionCode, data);
    }
    
    public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
    {
        clientMng.SendRequest(requestCode, actionCode, data);
    }

    public void SetUserData(UserData ud)
    {
        //Debug.Log("setUd--gamefacade--->"+ud.NickName);
        playerMng.userData = ud;
    }

    public void setBlock(bool block)
    {
        propMng.setBlock(true);
    }

    public void StartPlayer()
    {
        playerMng.CreateSyncRequest();
    }

    public void setPlayer(GameObject localPlayer, GameObject remotePlayer)
    {
        print("-------------------------------SetPlayer---------gamefacade------------");
        playerMng.setPlayer(localPlayer, remotePlayer);
    }

    public void SetCurrentRoleType(int rt)
    {
        playerMng.SetCurrentRoleType(rt);
    }

    public GameObject GetCurrentRoleGameObject()
    {
        return playerMng.GetCurrentRoleGameObject();
    }


    public void EnterPlayingSync()
    {
        isEnterPlaying = true;
    }
    private void EnterPlaying()
    {
        playerMng.SpawnRoles();
    }

    public void AddControlScript(int RoleType)
    {
        playerMng.AddControllScript();
        playerMng.CreateSyncRequest();
        gameMng.GetComponent<GameManager>().findPlayer(RoleType);
    }


    public void ShowMessage(string msg)
    {
        uiMng.ShowMessage(msg);
    }

    //在所有页面获取UserData
    public UserData GetUserData()
    {
        return playerMng.userData;
    }

    public GameObject getCameraTarget()
    {
        return gameMng.GetComponent<GameManager>().setCameraTarget();
    }

    public void EnterGameCamera()
    {
        isEnterGameCamera = true;
       
    }

    public void GameOver()
    {
        
    }

    public void FinishGame()
    {
       // gameMng.
    }

    //在FinishGameRequest调用
    public void showTimer()
    {
        isShowTimer = true;
        isWiner = true;
    }
    //在showTimeRequest调用
    public void showTime(string i)
    {
        times = i;
        if (i == "1")
        {
            isUpdate = true;
        }
        
        if (isWiner)
        {
            isShowTime = false;
            return;
        }
        isShowTime = true;
        
    }

    IEnumerator GameOverCount()
    {
        //倒计时时长
        int i = 5;
        while (i>0)
        {
            yield return new WaitForSeconds(1);
            
            gameMng.GetComponent<GameManager>().ShowTimer(i.ToString());
            gameMng.GetComponent<ShowTimerRequest>().SendRequest("2",i.ToString());
            i--;
            if (i == 0)
            {
                isUpdate = true;
            }
        } 
    }


    public void UpdateScore()
    {
        float time = gameMng.GetComponent<GameManager>().GetTime();
        float speed = gameMng.GetComponent<GameManager>().GetSpeed();
        gameMng.GetComponent<GameOverRequest>().SendRequest(time.ToString(),speed.ToString());
    }
//    public void GameOverMsg(string msg)
//    {
//
//        gameovermsg = msg;
//        isGameMsg = true;
//        
//    }

}
