using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngineInternal;

public class VSPanel : BasePanel
{

    private Text LocalPlayerUserName;
    private Text RemotePlayerUserName;
    private Text WaitText;
    private QuitRoomRequest quitRoomRequest;
    private StartGameRequest startGameRequest;

    private bool isPopPanel = false;
    private bool isPushPanel = false;
    private bool isGameBegin = false;
   // private Button ExitRoomButton;
   // private Button BeginButton;
    

    private UserData Ud=null;
    private UserData ud1=null;
    private UserData ud2=null;
    private void Start()
    {
        LocalPlayerUserName = transform.Find("self/NameText").GetComponent<Text>();
        RemotePlayerUserName = transform.Find("opponent/RemotePlayer/NameText").GetComponent<Text>();
        WaitText = transform.Find("opponent/WaitText").GetComponent<Text>();
        transform.Find("ExitRoom").GetComponent<Button>().onClick.AddListener(OnExitRoomClick);
        transform.Find("Begin").GetComponent<Button>().onClick.AddListener(OnBeginClick);
        quitRoomRequest = GetComponent<QuitRoomRequest>();
        startGameRequest = GetComponent<StartGameRequest>();
        gameObject.SetActive(true);
    }


    private void OnExitRoomClick()
    {
        quitRoomRequest.SendRequest("0");

    }
    public void OnExitRoomResponse()
    {
        isPopPanel = true;
    }

    public void OnStartPlayResponse()
    {
        isGameBegin = true;
    }

    private void OnBeginClick()
    {
        startGameRequest.SendRequest();
    }

    public override void OnResume()
    {
        gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Ud != null)
        {
            SetLocalPlayerRes(Ud.NickName);
        }

        if (ud2 == null)
        {
            ClearRemoteRes();
        }
        if (ud1 != null &&ud2 != null)
        {
            SetLocalPlayerRes(ud1.NickName);
            SetRemotePlayerRes(ud2.NickName);
        }
        if (isPopPanel)
        {
            Debug.Log("ExitRoom");
            uiMng.PopPanel();
            BasePanel panel=uiMng.PushPanel(UIPanelType.Room);
            (panel as RoomPanel).isCreateRoom = false;
            isPopPanel = false;
        }

        if (isGameBegin)
        {
            uiMng.PopPanel();
            gameObject.SetActive(false);
            isGameBegin = false;
        }
    }
    
    

    public void SetLocalPlayerResSync()
    {
        this.Ud= facade.GetUserData();
    }

    public void SetAllPlayerResSync(UserData ud1, UserData ud2)
    {
        this.ud1 = ud1;
        this.ud2 = ud2;
    }

    
    
//    public override void OnEnter()
//    {
//          gameObject.SetActive(true);
//    }

//    public override void OnPause()
//    {
//        gameObject.SetActive(false);
//    }

    public void SetLocalPlayerRes(string userName)
    {
        
        LocalPlayerUserName.text = userName;
    }

    public void SetRemotePlayerRes(string userName)
    {
        WaitText.enabled = false;
        RemotePlayerUserName.enabled = true;
        
        RemotePlayerUserName.text = userName;
    }


    public void ClearRemoteRes()
    {
        WaitText.enabled = true;
        RemotePlayerUserName.enabled = false;
        
    }

    public override void OnExit()
    {
        Debug.Log("PopVsPanel");
        ud1 = null;
        ud2 = null;
        gameObject.SetActive(false);
    }

    public override void OnEnter()
    {
        Debug.Log("EnterVsPanel");
        gameObject.SetActive(true);
    }

    public override void OnPause()
    {
        Debug.Log("PauseVsPnale");
        gameObject.SetActive(false);
    }
    public void OnBeginClickResponse()
    {
        uiMng.PopPanel();
    }
}
