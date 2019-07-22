using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : BasePanel
{
    public Text RoomName;

    public Text RoomMember;

    public Button joinButton;

    private JoinRequest joinRequest;
    private string RoomId;

    private RoomPanel roomPanel;
    // Start is called before the first frame update
    void Start()
    {
        if (joinButton != null)
        {
            joinButton.onClick.AddListener(OnJoinButton);
        }

        joinRequest = GetComponent<JoinRequest>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRoomInfo(string RoomName, int RoomId,RoomPanel panel)
    {
        SetRoomInfo(RoomName,RoomId.ToString(),panel);
    }


    public void SetRoomInfo(string RoomName, string RoomId,RoomPanel panel)
    {
        this.RoomName.text = RoomName;
        this.RoomId = RoomId;
        this.roomPanel = panel;
    }
   

    private void OnJoinButton()
    {
        roomPanel.OnJoinClick(RoomId);
    }


    public void DestorySelf()
    {
        GameObject.Destroy(this.gameObject);
    }

 
}
