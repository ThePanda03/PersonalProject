using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //variables for the Name and dialogue
    public Text nameText;
    public Text dialogueText;
    //variable for the sentance que
    private Queue<string> sentances;

    // Start is called before the first frame update
    void Start()
    {
        sentances = new Queue<string>();
    }
    //displays the Name and displays the first dialogue in the que 
    public void StartDialogue(ObjDialogue dialogue)
    {
        Debug.Log("Starting Convo with" + dialogue.name);
        sentances.Clear();

        nameText.text = dialogue.name;

        foreach (string sentance in dialogue.sentances) 
        {
            sentances.Enqueue(sentance);
        }

        DisplayNext();

    }
    //Displays the next peice of dialogue in the que until it is finished 
    public void DisplayNext()
    {
        if (sentances.Count == 0)
        {
            EndDialgoue();
            return;
        }

        string sentance = sentances.Dequeue();
        dialogueText.text = sentance;
    }

    //Gets rid of the dialgoue screen when the conversation is ended 
    void EndDialgoue()
    {
        Debug.Log("End of Convo");
    }

}
