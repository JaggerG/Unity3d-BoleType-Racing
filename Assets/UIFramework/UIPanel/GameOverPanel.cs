using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel :BasePanel
{
    private Text fName;
    private Text sName;
    private Text fTime;
    private Text sTime;
    private string Result;
    private bool isShowResult = false;
    private GameObject ResultText;
    
  
    
    
    public void showResult(string result)
    {
        if (result == "1")
        {
            Result = "胜利";
            isShowResult = true;
        }

        if (result == "2")
        {
            Result = "失败";
            isShowResult = true;
        }
    }

    
    
    void Start()
    {
        transform.Find("Continue").GetComponent<Button>().onClick.AddListener(Continue);
        ResultText = transform.Find("Win").gameObject;
        ResultText.GetComponent<Button>().onClick.AddListener(Continue);
    }

    private void Update()
    {
        if (isShowResult)
        {
            ResultText.SetActive(true);
            ResultText.GetComponent<Text>().text = Result;
            isShowResult = false;
        }
    }

    public void Continue()
    {
        uiMng.PopPanel();
        //uiMng.PopPanel();
        uiMng.PushPanel(UIPanelType.Room);
        facade.GameOver();
    }
    public void setPanel(string data)
    {
        string[] response = data.Split('|');
        string[] result = response[1].Split('/');
        string[] player1 = result[0].Split(',');
        string[] player2 = result[1].Split(',');

        if (float.Parse(player1[1]) > float.Parse(player2[1]))
        {
            fName.text = player1[0];
            fTime.text = float.Parse(player1[1]).ToString("F2");
            sName.text = player2[0];
            sTime.text = float.Parse(player2[1]).ToString("F2");
        }
        else
        {
            fName.text = player2[0];
            fTime.text = float.Parse(player2[1]).ToString("F2");
            sName.text = player1[0];
            sTime.text = float.Parse(player1[1]).ToString("F2");
        }
    }

    public override void OnExit()
    {
        gameObject.SetActive(false);
        base.OnExit();
    }

    public override void OnEnter()
    {
        fName = transform.Find("HeadPanel/first/Name").GetComponent<Text>();
        sName = transform.Find("HeadPanel/Second/Name").GetComponent<Text>();
        fTime = transform.Find("HeadPanel/first/Time").GetComponent<Text>();
        sTime = transform.Find("HeadPanel/Second/Time").GetComponent<Text>();
        gameObject.SetActive(true);
    }
}
