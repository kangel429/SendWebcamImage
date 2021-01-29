using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;


public class ClientSocket : MonoBehaviour
{

    WebSocket ws;
    
    void Start()
    {
        //using (var ws = new WebSocket("ws://192.168.123.202:8080"))
        //remove using so it stays open!
        ws = new WebSocket("ws://175.198.21.225:8080");
        ws.Connect();


        //ws.OnOpen += (sender, e) =>
        //{
        //    Debug.Log("Connection: OK!");
        //};

        ws.OnMessage += (sender, e) =>
        {
            Debug.Log("OnMessage says: " + e.Data);

        };

        //ws.OnError += (sender, e) =>
        //{
        //    Debug.Log("OnErrorMessage says: " + e.Message);
        //};

        //ws.OnClose += (sender, e) =>
        //{
        //    Debug.Log("OnCloseCode Says: " + e.Code);
        //    Debug.Log("OnCloseReason says: " + e.Reason);
        //    Debug.Log("Was it closed cleanly?: " + e.WasClean);
        //};


       // ws.Send("I'm alive :D!");

        
    }

    private void Update()
    {
        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            Debug.Log("Sending heartbeat!");
            ws.Send("Heartbeart still ticking!");
        }
    }

    private void OnApplicationQuit()
    {
        ws.Close();
        Debug.Log("Closing websocket correctly by calling it before exiting application.");
    }


}
