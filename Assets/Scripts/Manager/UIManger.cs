using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManger : MonoBehaviour
{
    // Start is called before the first frame update public GameObject loginPanel;
//    public GameObject registerPanel;
//    public GameObject loginPanel;
//    public GameObject IndexPanel;
//    public GameObject RoomPanel;
//    public GameObject NamePanel;
//    public GameObject RankPanel;
//    public GameObject StorePanel;
//    public GameObject VsPanel;
//    public GameObject ComfirPanel;
//    public GameObject RegisterButton;
//    public Text msg;
//    public Text Rphone;
//    public Text Rpassword;
//   // public Text Rrepassword;
//    public Toggle protocol;
//    public Text verifyCode;
//    public Text VerifyCodeText;
//    public Text LuserName;
//    public Text LPassWord;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


//    public void multiPlay()
//    {
//        SceneManager.LoadScene("Game");
//    }
//
//    public void Purchase()
//    {
//        ComfirPanel.SetActive(true);
//        
//    }
//
//    public void CanclePurchase()
//    {
//        ComfirPanel.SetActive(false);
//    }
//    public void CreatRoom()
//    {
//        RoomPanel.SetActive(false);
//        VsPanel.SetActive(true);
//    }
//    public void ExitRoom()
//    {
//        RoomPanel.SetActive(true);
//        VsPanel.SetActive(false);
//    }
//    public void storePanel()
//    {
//        StorePanel.SetActive(true);
//        IndexPanel.SetActive(false);
//    }
//
//    public void StoreClose()
//    {
//        StorePanel.SetActive(false);
//        IndexPanel.SetActive(true);
//    }
//    public void rankPanel()
//    {
//        IndexPanel.SetActive(false);
//        RankPanel.SetActive(true);
//    }
//    public void rankClose()
//    {
//        IndexPanel.SetActive(true);
//        RankPanel.SetActive(false);
//    }
//    public void namePanel()
//    {
//        NamePanel.SetActive(true);
//        IndexPanel.SetActive(false);
//    }
//
//    public void NameClose()
//    {
//        NamePanel.SetActive(false);
//        IndexPanel.SetActive(true);
//    }
//
//    public void RoomReturn()
//    {
//        RoomPanel.SetActive(false);
//        IndexPanel.SetActive(true);
//    }
//    public void loginButton1()
//    {
//        
//
//        if (LuserName.text == "123")
//        {
//            Message("用户名不正确");
//            
//        }
//        
//        else if (LPassWord.text == "123")
//        {
//            Message("密码不正确");
//        }
//        else if (LPassWord.text == "")
//        {
//            Message("密码不能为空");
//        }
//        else if (LuserName.text == "")
//        {
//            Message("用户名不能为空");
//        }
//        else
//        {
//            loginPanel.SetActive(false);
//            IndexPanel.SetActive(true);
//        }
//        
//        
//        
//    }
//    public void loginButton()
//    {
//        registerPanel.SetActive(false);
//        loginPanel.SetActive(true);
//        print("login");
//    }
//    public void registerButton()
//    {
//        loginPanel.SetActive(false);
//        registerPanel.SetActive(true);
//        print("register");
//    }
//    public void multiPlayButton()
//    {
//        IndexPanel.SetActive(false);
//        RoomPanel.SetActive(true);
//    }
//
//    public void Register1Button()
//    {
//        if (Rphone.text == "")
//        {
//            Message("用户名不能为空");
//        }
//       else if (Rpassword.text == "")
//        {
//            Message("密码不能为空");
//        }
//       else if(protocol.isOn==false)
//        {
//            Message("请先同意用户服务协议");
//        }
//        else if(verifyCode.text=="")
//        {
//            Message("验证码不能为空");
//        }
//        else
//        {
//            Message("注册成功");
//        }
//        
//    }
//
//
//    public void Message(string message)
//    {
//        msg.text = message;
//        StartCoroutine(showMsg());
//
//    }
//
//    IEnumerator showMsg()
//    {
//        
//        yield return new WaitForSeconds(1);
//        msg.text = "";
//    }
//
//
//    public void VerifyCode()
//    {
//        VerifyCodeText.text = "已发送";
//    }
    
}
