using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    private InputField phoneIf;
    private InputField passWordIf;
    private InputField repassWordIf;
    private InputField verifyCodeIf;
    private Toggle protocolToggle;
    private RegisterRequest registerRequest;
    private VerifyCodeRequest verifyCodeRequest;
    private int count;
    private Text VerifyText;
    private Button VerifyButton;
    private bool isGetVerifyCode;
    private bool isResponse;
    private string Response;

    private void Start()
    {
        isGetVerifyCode = false;
        isResponse = false;
        registerRequest = GetComponent<RegisterRequest>();
        verifyCodeRequest = GetComponent<VerifyCodeRequest>();
        phoneIf = transform.Find("phoneNum/phoneNumIF").GetComponent<InputField>();
        passWordIf = transform.Find("passWord/passWordIF").GetComponent<InputField>();
        repassWordIf = transform.Find("RepassWord/RepassWordIF").GetComponent<InputField>();
        verifyCodeIf = transform.Find("verifyCode/verifyCodeIF").GetComponent<InputField>();
        protocolToggle = transform.Find("ProtocolToggle").GetComponent<Toggle>();
        transform.Find("returnButton").GetComponent<Button>().onClick.AddListener(OnReturnClick);
        transform.Find("RegisterButton").GetComponent<Button>().onClick.AddListener(OnRegisterClick);
        transform.Find("verifyCodeButton").GetComponent<Button>().onClick.AddListener(OnSendVerifyCodeRequest);
        VerifyText = transform.Find("verifyCodeButton/Text").GetComponent<Text>();
        VerifyButton = transform.Find("verifyCodeButton").GetComponent<Button>();
    }


    private void Update()
    {
        if (isGetVerifyCode)
        {
            StartCoroutine(Timer());
        }

        if (isResponse)
        {
            
            isResponse = false;
            uiMng.ShowMessage(Response);
        }
    }

    public override void OnPause()
    {
        HideAnimation();
    }

    public override void OnResume()
    {
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.2f);
        transform.localPosition = new Vector3(1000, 0, 0);
        transform.DOLocalMove(Vector3.zero, 0.2f);
    }

    public void OnSendVerifyCodeRequest()
    {
       
        string msg = "";
        if (string.IsNullOrEmpty(phoneIf.text))
        {
            msg += "手机号码不能为空";
        }

        if (msg != "")
        {
            uiMng.ShowMessage(msg);
            return;
        }
       verifyCodeRequest.SendRequest(phoneIf.text);
    }
    public void OnRegisterClick()
    {
        Debug.Log("Register");
        
        string msg = "";
        
        if (string.IsNullOrEmpty(phoneIf.text))
        {
            msg += "手机号码不能为空";
        }

        if (string.IsNullOrEmpty(passWordIf.text))
        {
            msg += "密码不能为空";
        }

        if (string.IsNullOrEmpty(repassWordIf.text))
        {
            msg += "请输入确认密码";
        }

        if (repassWordIf.text != passWordIf.text)
        {
            msg += "密码不一致";
        }

        if (string.IsNullOrEmpty(verifyCodeIf.text))
        {
            msg += "验证码不能为空";
        }

        if (!protocolToggle.isOn)
        {
            msg += "请确认用户服务协议";
        }
        Debug.Log("----msg---"+msg+"-------");
        if (msg != "")
        {
            uiMng.ShowMessage(msg);
            return;
        }
        
        registerRequest.SendRequest(phoneIf.text,passWordIf.text,verifyCodeIf.text);
        
    }
    public void OnReturnClick()
    {
        uiMng.PushPanel(UIPanelType.Login);
    }
    public override void OnEnter()
    {
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;
        transform.DOScale(1, 0.2f);
        transform.localPosition=new Vector3(1000,0,0);
        transform.DOLocalMove(Vector3.zero, 0.2f);
    }


    public void OnResponsePanel(string response)
    {
        Response= response;
        isResponse = true;
    }
    public void GetVerifyCode()
    {
        isGetVerifyCode = true;
    }
    
    public override void OnExit()
    {
        base.OnExit();
        gameObject.SetActive(false);
    }
    private void HideAnimation()
    {
        transform.DOScale(0, 0.3f);
        transform.DOLocalMoveX(1000, 0.3f).OnComplete(() => gameObject.SetActive(false));
    }

    IEnumerator Timer()
    {
        isGetVerifyCode = false;
        VerifyText.text = "已发送";
        VerifyButton.enabled = false;
        count = 20;
        while (true)
        {
            if (count == 0)
            {
                VerifyText.text = "重新发送";
                VerifyButton.enabled= true;
                yield break;
            }
            yield return new WaitForSeconds(1f);
            VerifyText.text = count.ToString();
            count--;
        }

    }
}


