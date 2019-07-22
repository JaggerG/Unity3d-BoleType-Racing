using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanel : BasePanel
{
    private Text text;
    private float showTime = 1;
    private string message = null;

    private void Update()
    {
        if (message != null)
        {
            ShowMessage(message);
            message = null;
        }
    }
    public override void OnEnter()
    {
        base.OnEnter();
        text = GetComponent<Text>();
        text.enabled = false;
        uiMng.InjectPanel(this);
        
       
    }

    public void ShowMessage(string msg)
    {
        text.color = Color.white;
        text.text = msg;
        text.enabled = true;
        Invoke("Hide",showTime);
        text.CrossFadeAlpha(1,1,false);
    }

    public void ShowMessages(string msg)
    {
        text.color = Color.white;
        text.text = msg;
        text.enabled = true;
      
    }
    
    private void Hide()
    {
        text.CrossFadeAlpha(0,1,false);
    }

    public void ShowMessageSync(string msg)
    {
        message = msg;
    }
}
