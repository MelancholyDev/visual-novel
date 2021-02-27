using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
#pragma warning disable 0649
public class DialogueController : MonoBehaviour
{
    [SerializeField] private Canvas dialoguePattern;
    [HideInInspector]public DialogueTree dialogueTree;
    private Image firstImage;
    private Image secondImage;
    private Text textField;
    private Button[] answers = new Button[4];
    private Image background;
    private Text name;
    private Canvas instantinatedCanvas;
    private Button endButton;

    private bool nodeFinished;
    private DialogueStatus dialogueStatus;

    
    //set FirstImage
    public void setFirstImage(string image)
    {
        firstImage.sprite = Resources.Load<Sprite>("Dialogues\\Images\\" + image);
    }
    

    //set SecondImage
    public void setSecondImage(string image)
    {
        secondImage.sprite = Resources.Load<Sprite>("Dialogues\\Images\\" + image);
    }
    
    //set BackGround
    private void setBackground(string back)
    {    
        background.sprite = Resources.Load<Sprite>("Dialogues\\Backgrounds\\" + back);
    }

    //set text or append text in text field
    public void setText(TextMode textMode, char text = ' ')
    {
        switch (textMode)
        {
            case TextMode.CLEAR:
            {
                textField.text = "";
            }
                break;
            case TextMode.APPEND:
                textField.text = textField.text + text;
                break;
        }
    }

    //enable num buttons(1-4)
    public void enableButtons(int num)
    {
        if (num == 1)
            num = -1;
        for (int i = 0; i < 4; i++)
        {
            if (i < num)
                answers[i].gameObject.SetActive(true);
            else
                answers[i].gameObject.SetActive(false);
        }
    }

    //set answers on enabled buttons
    public void setAnswers(string text)
    {
        string[] answersText = text.Split('%');
        enableButtons(answersText.Length);
        for (int i = 0; i < answersText.Length; i++)
            answers[i].GetComponentInChildren<Text>().text = answersText[i];
    }

    //whole dialogue process
    IEnumerator dialogueProcess()
    {
        setBackground(dialogueTree.backgroundImageString);
        Node curnode;
        dialogueStatus = DialogueStatus.CONTINUE;
        dialogueTree.restartTree();
        while (dialogueStatus == DialogueStatus.CONTINUE)
        {
            nodeFinished = false;
            curnode = dialogueTree.getCurNode();
            nodeChangeCanvas(curnode);
            string rep = curnode.replique;
            int iter = 0;
            int counter = 0;
            while (!nodeFinished)
            {
                if (rep.Length > iter)
                {
                    setText(TextMode.APPEND, rep[iter]);
                    iter++;
                    yield return new WaitForSeconds(0.05f);
                }
                else
                {
                    if (counter == 0)
                    {
                        counter++;
                        switch (curnode.type)
                        {
                            case NodeType.END:
                            {
                                endDialogue();
                            }
                                break;

                            case NodeType.CHOOSE:
                            {
                                setAnswers(curnode.answers);
                            }
                                break;
                            case NodeType.DEFAULT:
                            {
                                showButton(false);
                            }
                                break;
                        }
                    }

                    yield return new WaitForEndOfFrame();
                }
            }
        }
        Destroy(instantinatedCanvas.gameObject);
    }

    //Change dialogue canvas depends on node parameters
    private void nodeChangeCanvas(Node node)
    {
        setName(node.additionalInformation);
        setText(TextMode.CLEAR);
        setFirstImage(node.imageFirst);
        setSecondImage(node.imageSecond);
        enableButtons(1);
    }

    //se Name of person
    public void setName(String s)
    {
        name.text = s;
    }

    //end dialogue
    private void endDialogue()
    {
        showButton(true);
    }

    //show end or continue button depends on type
    private void showButton(bool type)
    {
        endButton.onClick.RemoveAllListeners();
        if (type)
        {
            endButton.gameObject.SetActive(true);
            endButton.GetComponentInChildren<Text>().text = "Закончить диалог";
            endButton.onClick.AddListener(() =>
            {
                nodeFinished = true;
                dialogueStatus = DialogueStatus.END;
            });
        }
        else
        {
            endButton.gameObject.SetActive(true);
            endButton.GetComponentInChildren<Text>().text = "Продолжить...";
            endButton.onClick.AddListener(() =>
            {
                nodeFinished = true;
                dialogueTree.changeCurNode(1);
                endButton.gameObject.SetActive(false);
            });
        }
    }

    //initialize all dialogue fields
    public void initializeFields()
    {
        if (instantinatedCanvas == null)
            throw new NullReferenceException();
        DialogueCanvas dialogueCanvas = instantinatedCanvas.GetComponent<DialogueCanvas>();
        firstImage = dialogueCanvas.getImage(1);
        secondImage = dialogueCanvas.getImage(2);
        textField = dialogueCanvas.getTextField();
        for (int i = 1; i < 5; i++)
        {
            answers[i - 1] = dialogueCanvas.getButton(i);
        }

        answers[0].onClick.AddListener(() =>
        {
            dialogueTree.changeCurNode(1);
            nodeFinished = true;
        });
        answers[1].onClick.AddListener(() =>
        {
            Debug.Log("second!");
            dialogueTree.changeCurNode(2);
            nodeFinished = true;
        });
        answers[2].onClick.AddListener(() =>
        {
            dialogueTree.changeCurNode(3);
            nodeFinished = true;
        });
        answers[3].onClick.AddListener(() =>
        {
            dialogueTree.changeCurNode(4);
            nodeFinished = true;
        });
        endButton = dialogueCanvas.getEndButton();
        endButton.gameObject.SetActive(false);
        background = dialogueCanvas.getBackground();
        name = dialogueCanvas.getName();
    }

    //download dialogue from json file
    public void createDialogue(string dialogueTree)
    {
        instantinatedCanvas = Instantiate(dialoguePattern);
        initializeFields();
        TextAsset tree = Resources.Load<TextAsset>("Dialogues/Trees/" + dialogueTree);
        this.dialogueTree = JsonUtility.FromJson<DialogueTree>(tree.text);
        StartCoroutine(dialogueProcess());
    }

    

}

enum DialogueStatus
{
    CONTINUE,
    END
}

public enum TextMode
{
    APPEND,
    CLEAR
}