using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialoguetrigger : MonoBehaviour
{
    public ObjDialogue dialogue;

    public void TriggerDialogue()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);

    }

}
