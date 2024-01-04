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

        sentances.Clear();

        nameText.text = dialogue.name;

        foreach (string sentance in dialogue.sentances)
        {
            sentances.Enqueue(sentance);
        }


    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("iaowdjoiawj");
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
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentance));

    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    //Gets rid of the dialgoue screen when the conversation is ended 
    void EndDialgoue()
    {
        animator.SetBool("IsOpen", false);
    }

}
