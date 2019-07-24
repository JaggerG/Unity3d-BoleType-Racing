using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

using UnityEngine;
using UnityEngine.UI;


public class RoomPanel : BasePanel
{
    private RectTransform userRect;
    private RectTransform roomListRect;
    private VerticalLayoutGroup roomList;
    private GameObject roomItemPrefab;
    private List<UserData> udList = null;
    private ListRoomRequest listRoomRequest;
    private CreatRoomRequest createRoomRequest;
    private UserData ud = null;
    private UserData ud1 = null;
    private UserData ud2 = null;
    private RectTransform roomListContent;
    private Button CreateRooom;
    private Button ReturnButton;
    public bool isCreateRoom = false;
    private JoinRequest joinrequest;
    private bool isPopPanel = false;
    
    private bool isClearList = false;
   

    
    private void Start()
    {
        isClearList = false;
        joinrequest = GetComponent<JoinRequest>();
        createRoomRequest = GetComponent<CreatRoomRequest>();
        listRoomRequest = GetComponent<ListRoomRequest>();
        //userRect=transform.Find("User").GetComponent<RectTransform>();
        roomItemPrefab=Resources.Load("UIPanel/RoomItem") as GameObject;
        roomList = transform.Find("RoomList/Scroll View/Viewport/Content/RoomList").GetComponent<VerticalLayoutGroup>();
        roomListContent = transform.Find("RoomList/Scroll View/Viewport/Content").GetComponent<RectTransform>();
        transform.Find("User/CreateRoom").GetComponent<Button>().onClick.AddListener(OnCreateRoomClick);
        transform.Find("User/Refresh").GetComponent<Button>().onClick.AddListener(OnRefreshClick);
        transform.Find("User/Exit").GetComponent<Button>().onClick.AddListener(OnReturnClick);
        //roomListRect=transform.Find("RoomList").GetComponent<RectTransform>();
    }


    private void OnReturnClick()
    {
        uiMng.PopPanel();
        uiMng.PushPanel(UIPanelType.MainMenu);
    }
    private void OnRefreshClick()
    {
        listRoomRequest.SendRequest();
    }
   
    private void OnCreateRoomClick()
    {
        uiMng.PopPanel();
        uiMng.PushPanel(UIPanelType.VS);
        createRoomRequest.SendRequest(ud.NickName);
    }

    public void OnCreatRoomResponse()
    {
        Debug.Log("CreateResponse");
        isCreateRoom = true;
        


    }
    private void SetUserDetail()
    {
      
        ud = facade.GetUserData();
        transform.Find("User/Name").GetComponent<Text>().text = ud.NickName;
    }
    public override void OnEnter()
    {
       // EnterAnim();
       
       Debug.Log("RoomPanelEnter");
       gameObject.SetActive(true);
       SetUserDetail();
       if (listRoomRequest == null)
           listRoomRequest = GetComponent<ListRoomRequest>();
       listRoomRequest.SendRequest();
       
    }

    public override void OnExit()
    {
        
        Debug.Log("RoomPanelExit");
        gameObject.SetActive(false);
    }

    public override void OnPause()
    {
        Debug.Log("RoomPanelPause");
        gameObject.SetActive(false);
    }
   

    private void HideAnim()
    {
        userRect.DOLocalMoveX(-1000, 0.5f);
        roomListRect.DOLocalMoveX(1000, 0.5f);
    }

    private void EnterAnim()
    {
        
        userRect.localPosition=new Vector3(-1000,0);
        userRect.DOLocalMoveX(210,0.5f);


        roomListRect.localPosition=new Vector3(1000, 0);
        roomListRect.DOLocalMoveX(408,0.5f);

    }

    

    public void LoadRoomItemSync(List<UserData> udList)
    {
       // Debug.Log("--------udList--RoomPanle--"+udList[0].NickName);
        this.udList = udList;
      //  Debug.Log(this.udList[0].NickName);
    }
    public void LoadRoomItem(List<UserData> udList)
    {
      //  Debug.Log("--------loadRoomItem-------");

        RoomItem [] riArray = roomList.GetComponentsInChildren<RoomItem>();
        
        foreach(RoomItem ri in riArray)
        {
            ri.DestorySelf();
        }

        int count = udList.Count;
        for (int i = 0; i < count; i++)
        {
            GameObject roomItem = GameObject.Instantiate(roomItemPrefab);
            roomItem.transform.SetParent(roomList.transform);
            UserData ud = udList[i];
            roomItem.GetComponent<RoomItem>().SetRoomInfo(ud.NickName,ud.RoomId,this);
        }

        int roomCount = GetComponentsInChildren<RoomItem>().Length;
         Vector2 size = roomListContent.sizeDelta;
        roomListContent.sizeDelta=new Vector2(size.x,roomCount*roomItemPrefab.GetComponent<RectTransform>().sizeDelta.y);
    }

    private void Update()
    {
        if (udList != null)
        {
            
            LoadRoomItem(udList);
            udList = null;
        }
        
        if(ud1!=null||ud2!=null)
        {
            uiMng.PopPanel();
            BasePanel panel = uiMng.PushPanel(UIPanelType.VS);
            (panel as VSPanel).SetAllPlayerResSync(ud1,ud2);
            ud1 = null;
            ud2 = null;
        }

        if (isClearList)
        {
           
            RoomItem [] riArray = roomList.GetComponentsInChildren<RoomItem>();
            foreach(RoomItem ri in riArray)
            {
                ri.DestorySelf();
            }

            isClearList = false;
        }

        if (isCreateRoom)
        {
            BasePanel panel = uiMng.PushPanel(UIPanelType.VS);
            (panel as VSPanel).SetLocalPlayerResSync();
            isCreateRoom = false;
        }

        if (isPopPanel)
        {
            
            isPopPanel = false;
        }
        
        
    }

    public void ClearList()
    {
        isClearList = true;
    }
    public void OnJoinClick(string id)
    {
       
        joinrequest.SendRequest(id);
        
    }
    public override void OnResume()
    {
        Debug.Log("RoomPanel Resume");
        gameObject.SetActive(true);
        //listRoomRequest.SendRequest();
    }
    public void OnJoinResponse(UserData ud1, UserData ud2)
    {
        
        this.ud1 = ud1;
        this.ud2 = ud2;
    }
    
   
}
