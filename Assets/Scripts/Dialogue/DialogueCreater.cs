using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueCreater : MonoBehaviour
{
    //create dialogue from previously created repliques
    void Start()
    {
        DialogueTree tree = new DialogueTree(8);
        tree.setBackGround("innhall");
        tree.addNode(new Node("*Вы заходите в корчму,внутри никого нет,только корчмарь вяло потирает стаканы*",
           1,new []{2},"normal","transparent",NodeType.DEFAULT,"Продолжить...",
           EventTypeUI.NOEVENT,"" ));
        tree.addNode(new Node("Что пожелаете,господин?",
            2,new []{3,7},"normal","elisa_wine",NodeType.CHOOSE,"Пиво%Ничего,лучше расскажи новости",
            EventTypeUI.NOEVENT,"Корчмарь" ));
        
        tree.addNode(new Node("Нежить заполоняет окрестности города,сколько мы ещё протянем,как думаете??",
            7,new []{8},"serious","elisa_sad",NodeType.DEFAULT,"",
            EventTypeUI.NOEVENT,"Корчмарь" ));
        
        tree.addNode(new Node("*Вам наливают кружку светлого Лилиотского*Слышали про нашествие нежити??",
            3,new []{4,5},"normal","elisa_sad",NodeType.CHOOSE,"Нет%Да",
            EventTypeUI.NOEVENT,"Корчмарь" ));
        
        tree.addNode(new Node("*Вы соврали,ведь именно вам предстоит руководить отрядом,который стоит между людьми и мертвецами.Вы допиваете пиво и молча уходите*",
            4,new []{4},"serious","transparent",NodeType.END,"Пиво%Ничего,лучше расскажи новости",
            EventTypeUI.NOEVENT,"" ));
        
        tree.addNode(new Node("Неужели мы все умрем?",
            5,new []{6},"serious","elisa_sad",NodeType.DEFAULT,"",
            EventTypeUI.NOEVENT,"Корчмарь" ));
        
        tree.addNode(new Node("*Вам нечего ответить,ведь именно вам предстоит руководить отрядом,который стоит между людьми и мертвецами. Вы не знаете,вернетесь ли вы домой...Допив пиво вы уходите из корчмы.*",
            6,new []{2,3},"serious","transparent",NodeType.END,"",
            EventTypeUI.NOEVENT,"" ));
        
        tree.addNode(new Node("*Вам нечего ответить,ведь именно вам предстоит руководить отрядом,который стоит между людьми и мертвецами. Вы не знаете,вернетесь ли вы домой...Молча вы уходите из корчмы.*",
            8,new []{2,3},"serious","transparent",NodeType.END,"",
            EventTypeUI.NOEVENT,"" ));
        
        
        
        StreamWriter sr=new StreamWriter(File.Create(".\\Assets\\Resources\\Dialogues\\Trees\\2.json"));
        string text = JsonUtility.ToJson(tree);
        sr.Write(text);
        sr.Close();

    }


}
