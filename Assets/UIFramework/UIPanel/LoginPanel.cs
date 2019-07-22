using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Common;
using UnityEngine.UI;
using System;

public class LoginPanel : BasePanel
{

   private Button closeButton;
   private InputField usernameIf;
   private InputField passwordIf;
   private LoginRequest loginRequest;
   private string Response;
   private bool isResponse;
   private string ResponseCode;
   private void Start()
   {
      loginRequest = GetComponent<LoginRequest>();
      usernameIf = transform.Find("userName/userNameIF").GetComponent<InputField>();
      passwordIf = transform.Find("passWord/passWordIF").GetComponent<InputField>();
      transform.Find("LoginButton").GetComponent<Button>().onClick.AddListener(OnLoginClick);
      transform.Find("RegisterButton").GetComponent<Button>().onClick.AddListener(OnRegisterClick);
      
   }

   void Update()
   {
      if (isResponse&&ResponseCode=="1")
      {
         uiMng.ShowMessage(Response);
         isResponse = false;
         uiMng.PopPanel();
         uiMng.PushPanel(UIPanelType.MainMenu);
      }
      else
      {
         uiMng.ShowMessage(Response);
         isResponse = false;
      }
   }

   private void OnRegisterClick()
   {
      uiMng.PopPanel();
      uiMng.PushPanel(UIPanelType.Register);
      
   }
   private void OnLoginClick()
   {
      string msg = "";
      if (string.IsNullOrEmpty(usernameIf.text))
      {
         msg += "用户名不能为空";
      }

      if (string.IsNullOrEmpty(passwordIf.text))
      {
         msg += "密码不能为空";
      }

      if (msg != "")
      {
         uiMng.ShowMessage(msg);
         return;
      }
      loginRequest.SendRequest(usernameIf.text,passwordIf.text);
   }
   public override void OnEnter()
   {
      base.OnEnter();

      EnterAnimation();
   }

   public override void OnPause()
   {
      EnterAnimation();
   }

   public override void OnExit()
   {
      HideAnimation();
   }

   private void EnterAnimation()
   {
      gameObject.SetActive(true);
      transform.localScale = Vector3.zero;
      transform.DOScale(1, 0.2f);
      transform.localPosition=new Vector3(1000,0,0);
      transform.DOLocalMove(Vector3.zero, 0.2f);
   }

   private void HideAnimation()
   {
      //transform.DOScale(0, 0.3f);
      transform.DOLocalMoveX( 1000, 0.3f).OnComplete(() => gameObject.SetActive(false));
   }

   public void OnResponse(string responseCode,string response)
   {
      
      Response = response;
      isResponse = true;
      ResponseCode = responseCode;

   }
   
}
