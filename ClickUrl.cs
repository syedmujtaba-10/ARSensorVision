using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Vuforia;
using TMPro;

public class ClickUrl : MonoBehaviour
{
    public string url;
    TMP_InputField Temp;

    TMP_InputField Hum;
    TMP_InputField Soil;
    public void open()
    {
        Temp = GameObject.Find("InputFieldTemp").GetComponent<TMP_InputField>();
        
        Hum = GameObject.Find("InputFieldHum").GetComponent<TMP_InputField>();
        Soil = GameObject.Find("InputFieldSoil").GetComponent<TMP_InputField>();

        
        GetData_tem();
        GetData_hum();
        GetData_soil();
        StartCoroutine(GetRequest(url));
    }
 
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();
 
        }
    }

    void GetData_tem() => StartCoroutine(GetData_Coroutine1());
    void GetData_hum() => StartCoroutine(GetData_Coroutine());
    void GetData_soil() => StartCoroutine(GetData_Coroutine2());

    IEnumerator GetData_Coroutine2()
    {
        Debug.Log("Getting Data");
        Soil.text = "Loading...";
        string uri = "https://blynk.cloud/external/api/get?token=QbdUMZRjWRCw0En5xlj3ZTPl_6nJ_ubB&v2";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                Soil.text = request.error;
            else
            {

                Soil.text = request.downloadHandler.text;
                Soil.text = Soil.text.Substring(2,2);
            }
        }
    }
 
    IEnumerator GetData_Coroutine1()
    {
        Debug.Log("Getting Data");
        Temp.text = "Loading...";
        string uri = "https://blynk.cloud/external/api/get?token=QbdUMZRjWRCw0En5xlj3ZTPl_6nJ_ubB&v0";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                Temp.text = request.error;
            else
            {

                Temp.text = request.downloadHandler.text;
                Temp.text = Temp.text.Substring(2,2);
            }
        }
    }
    IEnumerator GetData_Coroutine()
    {
        Debug.Log("Getting Data");
        Hum.text = "Loading...";
        string uri = "https://blynk.cloud/external/api/get?token=QbdUMZRjWRCw0En5xlj3ZTPl_6nJ_ubB&v1";
        using(UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();
            if (request.isNetworkError || request.isHttpError)
                Hum.text = request.error;
            else
            {

                Hum.text = request.downloadHandler.text;
                Hum.text = Hum.text.Substring(2,2);
            }
        }
    }
}