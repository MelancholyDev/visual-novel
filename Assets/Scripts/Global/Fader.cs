using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Image fader;
    public FadeState fadeState=FadeState.Static;
    
    //start fader script
    public void Start()
    {
        fader.gameObject.SetActive(true);
        toTransparent();
    }

    //start couroutine of making fader transparent
    public void toTransparent()
    {
        fadeState = FadeState.Fading;
        StartCoroutine(toTransparentEnumerator());
    }
    
    //start couroutine of making fader dark
    public void toDark()
    {
        fadeState = FadeState.Fading;
        StartCoroutine(toDarkEnumrator());
    }

    //making fader darker every 0.001 seconds
    IEnumerator toDarkEnumrator()
    {
        Debug.Log("ToDark");
        fader.gameObject.SetActive(true);
        while (fader.color.a<1)
        {
            fader.color=new Color(0,0,0,fader.color.a+0.5f*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        fadeState = FadeState.Static;
    }
    
    //making fader more transparent every 0.001 seconds
    IEnumerator toTransparentEnumerator()
    {
        while (fader.color.a>0)
        {
            fader.color=new Color(0,0,0,fader.color.a-0.5f*Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
        fader.gameObject.SetActive(false);
        fadeState = FadeState.Static;
    }
}

public enum FadeState
{
    Fading,
    Static
}