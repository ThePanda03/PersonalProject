using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialoguetrigger : MonoBehaviour
{
    //sets the dialogue box 
    public ObjDialogue dialogue;
    
    //triggers the dialogue when picking up an obj 
    public void TriggerDialogue()
    {
        FindAnyObjectByType<DialogueManager>().StartDialogue(dialogue);

    }

}
