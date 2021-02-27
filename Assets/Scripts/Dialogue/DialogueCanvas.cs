using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
public class DialogueCanvas : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Text textField;
    [SerializeField] private Button firstButton;
    [SerializeField] private Button secondButton;
    [SerializeField] private Button thirdButton;
    [SerializeField] private Button fourthButton;
    [SerializeField] private Image firstImage;
    [SerializeField] private Image secondImage;
    [SerializeField] private Button endButton;
    [SerializeField] private Text name;
    
    //return background
    public  Image getBackground()
    {
        return background;
    }
    
    //return textfield
   public Text getTextField()
    {
        return textField;
    }

   //return name
   public Text getName()
   {
       return name;
   }
   //return endButton
   public Button getEndButton()
   {
       return endButton;
   }

   //return one of 4 buttons depend on index 
   public Button getButton(int index)
    {
        switch (index)
        {
            case 1: return firstButton;
            case 2: return secondButton; 
            case 3: return thirdButton; 
            case 4: return fourthButton; 
            default:throw new ArgumentException();
        }
    }

   //return first or second image depend on index
   public Image getImage(int index)
    {
        switch (index)
        {
            case 1: return firstImage;
            case 2: return secondImage; 
            default:throw new ArgumentException();
        }
    }
    
}
