using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueTree 
{
    
    public string backgroundImageString;
    public Node[] nodes;
    private int iterator;
    private Node curNode;
    
    //dialogue tree constructor
    public DialogueTree(int length)
    {
        nodes=new Node[length];
        iterator = 0;
    }

    //empty constructor for json acccess
    public DialogueTree()
    {
     
    }

    //set background of dialogue
    public void setBackGround(string back)
    {
        backgroundImageString = back;
    }
    
    //add one node
    public void addNode(Node node)
    {
        nodes[iterator] = node;
        iterator++;
    }

    //set first node to current node
    public void restartTree()
    {
        curNode = nodes[0];
    }
    
    //change current node depends on index
    public void changeCurNode(int node=1)
    {
        Debug.Log(curNode.index);
        curNode = findNodeWithindex(curNode.nextIndexes[node - 1]);
    }

    //find next node depends on index
    private Node findNodeWithindex(int index)
    {
        for(int i=0;i<nodes.Length;i++)
            if (nodes[i].index == index)
                return nodes[i];
        throw new ArgumentException();
    }

    //return current node
    public Node getCurNode()
    {
        return curNode;
    }
}

