using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour
{

    void Start()
    {
        GlobalController.dialogueController.createDialogue("1");
    }


}
