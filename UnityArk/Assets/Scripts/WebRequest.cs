using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class WebRequest : MonoBehaviour {

    void Start()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        using (UnityWebRequest request = UnityWebRequest.Get("http://unity3d.com/"))
        {
            yield return request.Send();

            if (request.isNetworkError) // Error
            {
                Debug.Log("Error: " + request.error);
            }
            else // Success
            {
                Debug.Log("Success: " + request.downloadHandler.text);
            }
        }
    }
}
