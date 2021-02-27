using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    public static DialogueController dialogueController;
    public static Fader fader;
    public static LevelController levelController;
    
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        dialogueController = GetComponent<DialogueController>();
        fader = GetComponent<Fader>();
        levelController = GetComponent<LevelController>();
    }

   
}
