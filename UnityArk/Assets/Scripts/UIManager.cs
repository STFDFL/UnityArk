using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject backgroundPanel;

    [Header("Fade")]
    public Color colorToFadeTo;
    public float fadeSpeed;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void FadeIn()
    {
        backgroundPanel.GetComponent<Image>().CrossFadeAlpha(0.1f, fadeSpeed, false);
    }
    public void FadeOut()
    {
        backgroundPanel.GetComponent<Image>().CrossFadeAlpha(1f, fadeSpeed, false);
    }

    public void FadeToColor()
    {
        backgroundPanel.GetComponent<Image>().CrossFadeColor(colorToFadeTo, fadeSpeed, false, true);
    }
}
