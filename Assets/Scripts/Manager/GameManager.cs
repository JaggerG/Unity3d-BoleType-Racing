using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;

public class GameManager : MonoBehaviour
{
    public GameObject subTitle;

    public GameObject CountDownText;
    public Text WhiteText;
    public Text RedText;
   // public GameObject car;
   // public GameObject cube;
    private string currentBlock = "123456";
    private int numCount;
    private bool isBegin;
    private bool isShowSubTitle;
    private float TotalTime=0;
    private float speed=0;
    private float Time;
    public GameObject Timer;
    private Text TimerText;
    private bool isCount = true;
    private int _typeCount;


    public void ShowTimer(string time)
    {
        CountDownText.SetActive(true);
        CountDownText.GetComponent<Text>().text = time;
    }

    
    

    string transNum(char block)
    {
        
        
            switch (block)
            {
                case '0':
                    return "Alpha0";
                    break;
                case '1':
                    return "Alpha1";
                    break;
                case '2':
                    return "Alpha2";
                    break;
                case '3':
                    return "Alpha3";
                    break;
                case '4':
                    return "Alpha4";
                    break;
                case '5':
                    return "Alpha5";
                    break;
                case '6':
                    return "Alpha6";
                    break;
                case '7':
                    return "Alpha7";
                    break;
                case '8':
                    return "Alpha8";
                    break;
                case '9':
                    return "Alpha9";
                    break;
                default: return "";
            }
    }
    
    
    
    void Start ()
    {

        Init();
    }

    public void Init()
    {
        //TimerText.text = "";
        CountDownText.SetActive(false);
      
        Time = 0;
        speed=0;
        TotalTime=0;
        isBegin = false;
        isShowSubTitle = false;
        numCount = 0;
//        currentBlock[0] = "Alpha1";
//        currentBlock[1] = "Alpha2";
//        currentBlock[3] = "Alpha3";
        RedText.text="";
        WhiteText.text = "love_of_my_life_you_heart_me_you_broken_my_love_and_now_you_leave_me_love_of_my_life_cant_you_see_bring_it_back_bring_it_back_dont_take_away_from_me_because_you_dont_konw_what_is_to_me_love_of_my_life_love_of_my_life_oh_you_will_remmber_when_there_blow_over";
        //print(WhiteText.text.Length);
        _typeCount = 0;
        //print(WhiteText.text.ToString().Substring(1,WhiteText.text.Length-1));
        TimerText = Timer.GetComponent<Text>();

    }


    public void resetGame()
    {
        Time = 0;
        speed=0;
        TotalTime=0;
        isBegin = false;
        isShowSubTitle = false;
        numCount = 0;
        RedText.text="";
        CountDownText.SetActive(false);
        subTitle.SetActive(false);
    }


    /// <summary>
    /// 大小写控制
    /// </summary>

//    void OnGUI()
//    {
//        if (Input.anyKeyDown)
//        {
//            Event e = Event.current;
//
//
//            if (e.keyCode.ToString() == transNum(currentBlock[numCount]))
//            {
//                print("right");
//                print(e.keyCode.ToString());
//                
//                numCount++;
//                if (numCount > 3)
//                {
//                    Destroy(cube);
//                }
//            }
//                
//        }
//    }


    

    public void showTime(string time)
    {
        
        CountDownText.SetActive(true);
       
        CountDownText.GetComponent<Text>().text = time;
    }

    public float GetTime()
    {
        return Time;
    }

    public float GetSpeed()
    {
        return speed;
    }
   private GameObject car;
    
    public void  findPlayer(int type)
    {
        if (type == 0)
        {
            car = GameObject.Find("Player1(Clone)");
            
        }
        else if(type==1)
        {
            car = GameObject.Find("Player2(Clone)");
        }

       // print("-----------------------getCar-----------------------"+car);
    }


    public GameObject setCameraTarget()
    {
        return car;
    }


    public void StopTimeCount()
    {
       Debug.Log("stopCoroutine");
       isCount = false;
        StopCoroutine(TimeCount());
    }
    public void BeginGame()
    {
        
        ///Debug.Log("---------------------beignGameeeeeee-----------------------");
        isShowSubTitle = true;
        isBegin = true;
        Time = 0;
        Timer.SetActive(true);
        StartCoroutine(TimeCount());
    }

   

    IEnumerator TimeCount()
    {
        while (isCount)
        {
            yield return new WaitForSeconds(0.1f);
            Time += 0.1f;
            TimerText.text = Time.ToString("F2");
        }        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (isShowSubTitle)
        {
            //Debug.Log("-------------------setWHITE-------------");
            subTitle.SetActive(true);
            isShowSubTitle = false;
        }
        if (isBegin)
        {
            

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.Minus))
            {
                print("?");
            }
//        if (Input.GetKeyDown(KeyCode.LeftShift))
//        {
//            print("shfit");
//        }

            if (WhiteText.text[_typeCount].ToString() == "_")
            {
                if (Input.GetKeyDown("space"))
                {
                    if ((_typeCount + 2) > WhiteText.text.Length)
                    {
                        _typeCount = 0;
                        return;
                    }
                        

                    RedText.text += "_";

//				print("RED-----------");
//				print(_typeCount);
//				print(RedText.text);
                    if (_typeCount >= 14)
                    {
                        WhiteText.text = WhiteText.text.ToString().Substring(1, WhiteText.text.Length - 1);
                        RedText.text = WhiteText.text.ToString().Substring(0, 14);
                        if (car.GetComponent<Rigidbody>().velocity.x >= 6)
                            return;
                        car.GetComponent<Rigidbody>().AddForce(0, 0, 50, ForceMode.Force);
                        //RedText.text = RedText.text.ToString().Substring(1, RedText.text.Length-1);


                        return;
                    }

                    if (car.GetComponent<Rigidbody>().velocity.x >= 6)
                        return;
                    car.GetComponent<Rigidbody>().AddForce(0, 0, 50, ForceMode.Force);

                    _typeCount++;

                    return;
                }

                return;
            }
            else if (Input.GetKeyDown(WhiteText.text[_typeCount].ToString()))
            {
                RedText.text += WhiteText.text[_typeCount].ToString();


//			print("WHITE-----------");
//			print(_typeCount);
                if (_typeCount >= 14)
                {
                    WhiteText.text = WhiteText.text.ToString().Substring(1, WhiteText.text.Length - 1);
                    RedText.text = WhiteText.text.ToString().Substring(0, 14);
                    if (car.GetComponent<Rigidbody>().velocity.x >= 6)
                        return;
                    car.GetComponent<Rigidbody>().AddForce(0, 0, 50, ForceMode.Force);
                    //RedText.text = RedText.text.ToString().Substring(1, RedText.text.Length - 1);


                    return;
                }

                if (car.GetComponent<Rigidbody>().velocity.x >= 6)
                    return;
                car.GetComponent<Rigidbody>().AddForce(0, 0, 50, ForceMode.Force);
                if ((_typeCount + 2) > WhiteText.text.Length)
                {
                    _typeCount = 0;
                    return;
                }

                if ((_typeCount + 2) > WhiteText.text.Length)
                {
                    _typeCount = 0;
                    return;
                }
                
                _typeCount++;

               
                  

            }
        }

    }

}
