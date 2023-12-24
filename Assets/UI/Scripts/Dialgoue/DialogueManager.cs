using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;
    private Queue<string> sentances;

    // Start is called before the first frame update
    void Start()
    {
        sentances = new Queue<string>();
    }

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

    void EndDialgoue()
    {
        Debug.Log("End of Convo");
    }

}
