using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Button = UnityEngine.UI.Button;

public class MainMenuPanel : BasePanel
{

    private Button SinglePlayButton;
    private Button MultiPlayButton;
    private Button RankButton;
    private Button CallButton;
    private Button StoreButton;
    private Button SettingButton;
    private Button ExitButton;

    void Start()
    {
        transform.Find("singlePlay").GetComponent<Button>();
        transform.Find("multiPlay").GetComponent<Button>().onClick.AddListener(OnMultiPlayButton);
        transform.Find("rank").GetComponent<Button>();
        transform.Find("Name").GetComponent<Button>();
        transform.Find("Store").GetComponent<Button>();
        transform.Find("setting").GetComponent<Button>();
        transform.Find("exit").GetComponent<Button>().onClick.AddListener(OnExitButton);
    }
    
    
    private void OnSinglePlayButton(){}

    private void OnMultiPlayButton()
    {
        uiMng.PopPanel();
        uiMng.PushPanel(UIPanelType.Room);
    }
    private void OnRankButton(){}
    private void OnCallButton(){}
    private void OnStoreButton(){}
    private void OnSettingButton(){}

    private void OnExitButton()
    {
        uiMng.PopPanel();
        uiMng.PushPanel(UIPanelType.Login);
    }
    
    
    public override void OnEnter()
    {
        base.OnEnter();
        gameObject.SetActive(true);
    }

    public override void OnPause()
    {
        base.OnPause();
        gameObject.SetActive(false);
    }

    public override void OnExit()
    {
        gameObject.SetActive(false);
    }

    public override void OnResume()
    {
        base.OnResume();
        gameObject.SetActive(true);
    }


   
}
