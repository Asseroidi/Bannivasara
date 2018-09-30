using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class PlayerAPI : MonoBehaviour {

    public enum Verb { Get, Post, Put};

    public Text outputText;
    string route1 = "http://localhost:5000/api/players/";
    string route2 = "https://localhost:5001/api/players/";
    byte[] results;

    // Use this for initializationuiiiiiiiiiiiiiiiiiiiiiiiiiii T: Kissa
    void Start () {
        if (!outputText)
            outputText = GameObject.FindGameObjectWithTag("OutputText").GetComponent<Text>();
	}

    IEnumerator Requesting(string address, Verb verb, string sendData)
    {
        UnityWebRequest Request;
        switch (verb)
        {
            case Verb.Get:
                Request = UnityWebRequest.Get(address);
                break;

            case Verb.Post:
                Request = UnityWebRequest.Post(address, sendData);
                break;

            default:
                Request = UnityWebRequest.Get(address);
                break;
        }
        //Request.method = UnityWebRequest.kHttpVerbGET;
        //Request.useHttpContinue = false;

        Debug.Log(Request.method);
        Debug.Log(Request.url);

        yield return Request.SendWebRequest();

        if (Request.isNetworkError || Request.isHttpError)
        {
            Debug.Log(Request.error);
        }
        else
        {
            Debug.Log(Request.downloadHandler.text);
            outputText.text = Request.downloadHandler.text;
            results = Request.downloadHandler.data;

        }

    }

    public void GetAllPlayers()
    {
        StartCoroutine(Requesting(route2, Verb.Get, null));
    }

    public void GetOther(string moreRoute)
    {
        StartCoroutine(Requesting(route1 + moreRoute, Verb.Get, null));
    }

    public void PostStuff()
    {

    }


}
