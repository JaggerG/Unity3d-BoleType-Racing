using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
//using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;


public class StartPanel : BasePanel
{
    private Button startButton;
    private Animator btnAnimator;

    public override void OnEnter()
    {
        base.OnEnter();
        startButton = transform.Find("StartButton").GetComponent<Button>();
        btnAnimator = startButton.GetComponent<Animator>();
        startButton.onClick.AddListener(OnStartClick);
        
    }

    private void OnStartClick()
    {
        uiMng.PushPanel(UIPanelType.Login);
    }

    public override void OnPause()
    {
        base.OnPause();
        btnAnimator.enabled = false;
        startButton.transform.DOScale(0, 0.3f).OnComplete(() => startButton.gameObject.SetActive(false));
        
    }

    public override void OnExit()
    {
        gameObject.SetActive(false);
        base.OnExit();
    }

    public override void OnResume()
    {
        
//        base.OnResume();
//        startButton.gameObject.SetActive(true);
//        startButton.transform.DOScale(1, 0.3f).OnComplete(() => btnAnimator.enabled = true);
    }
}
