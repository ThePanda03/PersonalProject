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
    //Variable for animations
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        sentances = new Queue<string>();
    }
    //displays the Name and displays the first dialogue in the que 
    public void StartDialogue(ObjDialogue dialogue)
    {
        animator.SetBool("IsOpen", true);

        Debug.Log("Starting Convo with" + dialogue.name);
        sentances.Clear();

        nameText.text = dialogue.name;

        foreach (string sentance in dialogue.sentances) 
        {
            sentances.Enqueue(sentance);
        }
        
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNext();
        }

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
        animator.SetBool("IsOpen", false);
    }

}
