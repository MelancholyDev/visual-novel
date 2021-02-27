using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    
    
    //start load level couroutine
    public void LoadLevel(string level)
    {
        StartCoroutine(loadLeveling(level));
    }
    
    //create new progress object and load map
    public void StartNewGame()
    {
        LoadLevel("Level1");
    }
    
    
    //load level with fading
    IEnumerator loadLeveling(string level)
    {
        GlobalController.fader.toDark();
        while( GlobalController.fader.fadeState!=FadeState.Static)
            yield return new WaitForEndOfFrame();
        SceneManager.LoadScene(level);
        GlobalController.fader.toTransparent();
    }
    
}
