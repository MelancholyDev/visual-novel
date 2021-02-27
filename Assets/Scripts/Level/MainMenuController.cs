using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    // Start is called before the first frame update
    void Start()
    {
       startButton.onClick.AddListener(()=>GlobalController.levelController.LoadLevel("Level1"));
    }

    
}
