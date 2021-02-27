using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.TestTools;
using UnityEngine.UI;
[Serializable]
public class Node
{
    public string replique;
    public int index;
    public int[] nextIndexes;
    public string imageFirst;
    public string imageSecond;
    public NodeType type;
    [FormerlySerializedAs("eventType")] public EventTypeUI eventTypeUi;
    public string additionalInformation;
    public string answers;

    //node constructor
    public Node(string replique,int index,int[] nextIndexes,string imageFirst,string imageSecond,NodeType type=NodeType.DEFAULT,string answers="",
        EventTypeUI eventTypeUi=EventTypeUI.NOEVENT,string additionalInformation="")
    {
        this.replique = replique;
        this.index = index;
        this.nextIndexes = nextIndexes;
        this.imageFirst = imageFirst;
        this.imageSecond = imageSecond;
        this.type = type;
        this.eventTypeUi = eventTypeUi;
        this.additionalInformation = additionalInformation;
        this.answers = answers;
    }
    
    //empty constructor for json access
    public Node()
    {
        
    }

}

public enum NodeType{
    DEFAULT,
    CHOOSE,
    END
}
public enum EventTypeUI{
    NOEVENT
}