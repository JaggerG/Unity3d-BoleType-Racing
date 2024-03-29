﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Sockets;
using System;
using System.Text;
using Common;
using LitJson;

/// <summary>
/// 这个是用来管理跟服务器端的Socket连接
/// </summary>
public class ClientManager :BaseManager {

    private const string IP = "106.13.144.132";
    private const int PORT = 8885;

    private Socket clientSocket;
    private Message msg = new Message();

    public ClientManager(GameFacade facade) : base(facade) { }

    public override void OnInit()
    {
        base.OnInit();

        clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        try
        {
            clientSocket.Connect(IP, PORT);
            Start();
        }
        catch (Exception e)
        {
            Debug.LogWarning("无法连接到服务器端，请检查您的网络！！" + e);
        }
    }
    private void Start()
    {
        clientSocket.BeginReceive(msg.Data,msg.StartIndex,msg.RemainSize, SocketFlags.None, ReceiveCallback, null);
    }
    private void ReceiveCallback(IAsyncResult ar)
    {
        try
        {
            if (clientSocket == null || clientSocket.Connected == false) return;
            int count = clientSocket.EndReceive(ar);
//            Debug.LogWarning("reciveDataLength------>"+count);
//            Debug.LogWarning("startIndex------->"+msg.StartIndex+"------"+"msg.RemainSize------->"+msg.RemainSize);
            //  Debug.LogWarning("DataFromServer-----"+Encoding.UTF8.GetString(msg.Data,0,msg.Data.Length));
                string datas = Encoding.UTF8.GetString(msg.Data, 0, msg.Data.Length);
               //Debug.LogWarning("2222");
                //JsonData jsondata = JsonMapper.ToObject(Encoding.UTF8.GetString(msg.Data, 0, msg.Data.Length));

               // msg.GetData(datas,OnProcessDataCallback);
             //   Debug.LogWarning("ReceiveCallBack");   
                msg.ReadMessage(count, OnProcessDataCallback);
            
            Start();
         }
         catch(Exception e)
         {
             Debug.Log(e);
         }   
    }
    private void OnProcessDataCallback(ActionCode actionCode,string data)
    {
        //Debug.LogWarning("Process");
        facade.HandleReponse(actionCode, data);
    }
    public void SendRequest(RequestCode requestCode, ActionCode actionCode, string data)
    {
        byte[] bytes = Message.PackData(requestCode, actionCode, data);   
//        Debug.LogWarning("clientSend");
        clientSocket.Send(bytes);
    }
    public override void OnDestroy()
    {
        base.OnDestroy();
        try
        {
            clientSocket.Close();
        }catch(Exception e)
        {
            Debug.LogWarning("无法关闭跟服务器端的连接！！" + e);
        }
    }
}