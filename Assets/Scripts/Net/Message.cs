using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Common;
using System.Text;
using LitJson;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

using UnityEngine.Experimental.UIElements;

public class Message  {

    private byte[] data = new byte[10240];
    private int startIndex = 0;//我们存取了多少个字节的数据在数组里面
    private string databuffer="";//用来临时截取未完成的字符

    private string strData;
    //public void AddCount(int count)
    //{
    //    startIndex += count;
    //}
    public byte[] Data
    {
        get { return data; }
    }
    public int StartIndex
    {
        get { return startIndex; }
    }
    /// <summary>
    /// 取得数组还剩多少空间
    /// </summary>
    public int RemainSize
    {
        get { return data.Length - startIndex; }
    }

    /// <summary>
    /// 解析数据或者叫做读取数据
    /// </summary>
    /// 

//    public void GetData(string datas,Action<ActionCode, string> processDataCallback)
//    {
//        Debug.LogWarning("GetData------->"+datas);
//        datas += databuffer;
//        datas += getYourTail(datas);
//        
//        getData(datas,processDataCallback);
//
//    }
//    private void getData(string datas,Action<ActionCode, string> processDataCallback)
//    {
//        for (int i = 0; i < datas.Length; i++)
//        {
//            if (datas[i] == '}')
//            {
//                int end = i;
//                UseData(i,end,datas,processDataCallback);
//                break;
//            }
//           
//        }
//    }
//    private string getYourTail(string datas)
//    {
//
//        if (datas[datas.Length - 1] != '}')
//        {
//            for (int i = datas.Length - 1; i > 0; i--)
//            {
//                if (datas[i] == '{')
//                {
//                    databuffer = datas.Substring(i, datas.Length-1);
//                    datas = datas.Substring(0, datas.Length-databuffer.Length);
//                    Debug.Log("GetYourTail--------->"+data);
//                    Debug.Log("DataBuffer---------->"+databuffer);
//                    break;
//                }
//            }
//        }
//        return datas;
//    }
//    public string UseData(int start,int end,string afterdata,Action<ActionCode, string> processDataCallback)
//    {
//        //TODO 删除已经处理了的数据
//        Debug.LogWarning("UseData");
//        
//        Debug.LogWarning(startIndex);
//        Debug.LogWarning(start);
//
//        int dataLength = afterdata.Length;
//        
//        
//        end += 1;
//        string jsondata=afterdata.Substring(0, end+1);
//        
//       // Debug.LogWarning(jsondata);
//        JsonData temp = JsonMapper.ToObject(jsondata);
//    
//        string temps = temp["actionCode"].ToString();
//            
//        ActionCode actionCode = (ActionCode) Int32.Parse(temps);
//        Debug.LogWarning("actionCode----------"+temp["actionCode"]);
//       
//        Debug.LogWarning("afterCut-------->"+JsonMapper.ToJson(temp).ToString());
//        processDataCallback(actionCode, temp["data"].ToString());
//
//       //Array.Copy(data,dataLength,data,0,startIndex-dataLength);
//
//       afterdata = afterdata.Substring(end + 1, afterdata.Length-1);
//       return afterdata;
//    }
    

    
    
    
    public void ReadMessage(int newDataAmount, Action<ActionCode, string> processDataCallback)
    {
        
        startIndex += newDataAmount;
        int i = 0;
        strData = Encoding.UTF8.GetString(data);
        
       // Debug.Log("-----------strData.Length-------->"+strData.Length);
        while(true)
        {
            if (i <= strData.Length - 1)
            {
                if (strData[i] == '}')
                {
                    string jsonData = strData.Substring(0, i + 1);
                   // Debug.LogWarning("jsonData[0]---------------->"+jsonData[0]);
                    if (jsonData[0] != '{')
                    {
                        continue;
                    }
                    
                    JsonData temp = JsonMapper.ToObject(jsonData);
                    string temps = temp["actionCode"].ToString();

                    ActionCode actionCode = (ActionCode) Int32.Parse(temps);
//                   Debug.LogWarning("actionCode---------->" + temp["actionCode"]);
//                   Debug.LogWarning("afterCut<-------->" + JsonMapper.ToJson(temp).ToString());
//                   Debug.LogWarning(strData);
                    processDataCallback(actionCode, temp["data"].ToString());
                    strData = strData.Substring(i+1,strData.Length-(i+1));
//                    Debug.Log("------afterCut-------strData--------" + strData+"-------strDataLength--------"+strData.Length);
                    //startIndex = i;
//                    Debug.Log(StartIndex);
                    i = 0;
                }
                else if(strData[i]=='\0'||i==strData.Length-1)
                {
//                    Debug.Log("break");
                    
                    data=new byte[10240];
                    byte[] temp= Encoding.UTF8.GetBytes(strData);
                    //data = temp;
                    Array.Copy(temp,0,data,0,temp.Length);
                   
//                   Debug.Log("------------data--------"+Encoding.UTF8.GetString(data));
//                   Debug.Log("------dataLength-----"+data.Length);
                    startIndex = 0;
//                   Debug.Log("after-----break-----startIndex----->"+startIndex);
                    break;
                }
                i++;
            }
            else
            {
                break;
            }
            
        }
    }
    
    public static byte[] PackData(RequestCode requestData,ActionCode actionCode, string data)
    {
//        Debug.LogWarning("Message:"+requestData);
//        Debug.LogWarning("Message:"+actionCode);
//        Debug.LogWarning("Message:"+data);
//        byte[] requestCodeBytes = BitConverter.GetBytes((int)requestData);
//        Debug.LogWarning(BitConverter.ToString(requestCodeBytes));
//        Debug.LogWarning(Encoding.UTF8.GetBytes(BitConverter.ToString(requestCodeBytes)).Length);
//        byte[] actionCodeBytes = BitConverter.GetBytes((int)actionCode);
//        byte[] dataBytes = Encoding.UTF8.GetBytes(data);
//        int dataAmount = requestCodeBytes.Length + dataBytes.Length + actionCodeBytes.Length;
//        Debug.LogWarning("Length:"+dataAmount);
//        byte[] dataAmountBytes = BitConverter.GetBytes(dataAmount);
        //byte[] newBytes = dataAmountBytes.Concat(requestCodeBytes).ToArray<byte>();//Concat(dataBytes);
        //return newBytes.Concat(dataBytes).ToArray<byte>();
//        return dataAmountBytes.Concat(requestCodeBytes).ToArray<byte>()
//            .Concat(actionCodeBytes).ToArray<byte>()
//            .Concat(dataBytes).ToArray<byte>();
//        string test = "django,12345";
//        byte[] datas = Encoding.UTF8.GetBytes(test);
//
//        return datas;

          //  Debug.LogWarning("packData");
           // Debug.LogWarning("actionCode--------->"+(int)actionCode);
        JsonData jsonData = new JsonData();

        jsonData["requestCode"] = requestData.ToString();
        jsonData["actionCode"] =actionCode.ToString();
        jsonData["data"] = data;

        string datas = jsonData.ToJson();
        
      //  Debug.LogWarning("PackedData------>"+datas);
        
        byte[] Json = Encoding.UTF8.GetBytes(datas);
        return Json;

//        byte[] test = dataAmountBytes.Concat(requestCodeBytes).ToArray<byte>()
//            .Concat(actionCodeBytes).ToArray<byte>();


//       Debug.LogWarning("---------"+Encoding.UTF8.GetBytes(BitConverter.ToString(test)).Length);
//        return Encoding.UTF8.GetBytes(BitConverter.ToString(test));
    }
}
